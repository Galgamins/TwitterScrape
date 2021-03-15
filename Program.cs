using Newtonsoft.Json.Linq;
using Penguin.Reflection.Extensions;
using Penguin.Web;
using System;
using System.IO;
using TwitterScraper.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterScraper
{
    internal class Program
    {
        public const string HEADER_X_CSRF_TOKEN = "";
        public const string HEADER_AUTHORIZATION = "";
        public const string HEADER_COOKIES = "";
        public const string HEADER_USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.72 Safari/537.36";

        private static void SetBrowser()
        {
            Client.UserAgent = HEADER_USER_AGENT;

            TrySetHeader("sec-ch-ua", "\"Google Chrome\";v=\"89\", \"Chromium\";v=\"89\", \"; Not A Brand\";v=\"99\"");
            TrySetHeader("x-twitter-client-language", "en");
            TrySetHeader("x-csrf-token", HEADER_X_CSRF_TOKEN);
            TrySetHeader("sec-ch-ua-mobile", "?0");
            TrySetHeader("authorization", HEADER_AUTHORIZATION);
            TrySetHeader("x-twitter-auth-type", "OAuth2Session");
            TrySetHeader("x-twitter-active-user", "yes");
            TrySetHeader("Referer", "https://twitter.com/search?q=cows&src=typeahead_click");
            TrySetHeader("Cookie", HEADER_COOKIES);

        }
        private static async Task<string> Request(string url)
        {
            SetBrowser();

            await Task.Delay(1000);

            return Client.DownloadString(url);
        }

        private static async Task Download(string url, string target)
        {
            SetBrowser();

            await Task.Delay(1000);

            Client.DownloadFile(url, target);
        }

        private static void TrySetHeader(string key, string value)
        {
            if(Client.Headers.AllKeys.Any(k => k == key))
            {
                Client.Headers[key] = value;
            } else
            {
                Client.Headers.Add(key, value);
            }
        }

        static JsonClient Client = new JsonClient();

        private static async Task Main(string[] args)
        {
            string DataDir = "Data";

            if (!Directory.Exists(DataDir))
            {
                Directory.CreateDirectory(DataDir);
            }

            foreach (string user in args)
            {
               

                string UserDir = Path.Combine(DataDir, user); 
                
                string checkpointFile = Path.Combine(UserDir, "Checkpoint.dat");

                if (!Directory.Exists(UserDir))
                {
                    Directory.CreateDirectory(UserDir);
                }

                DateTime StartDate = File.Exists(checkpointFile) ? DateTime.Parse(File.ReadAllText(checkpointFile)) : DateTime.Now.Date;

                TwitterSearch searchModel = new TwitterSearch()
                {
                    From = user,
                    Since = StartDate.AddDays(-1),
                    Until = StartDate
                };



                string url = $"https://twitter.com/i/api/2/search/adaptive.json?{searchModel}";

                do
                {
                    do
                    {
                        Console.WriteLine($"Requesting [{user}] {searchModel.Since:yyyy-MM-dd} => {searchModel.Until:yyyy-MM-dd}");

                        string sresponse = await Request(url);

                        JObject jResponse = JObject.Parse(sresponse);

                        TwitterSearchResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<TwitterSearchResponse>(sresponse);

                        foreach (Tweet t in response.GlobalObjects.Tweets.Values)
                        {
                            Console.WriteLine($"\tTweet: {t.Id}");
                            string tweetDir = Path.Combine(UserDir, $"{t.Id}");
                            string sourceFile = Path.Combine(tweetDir, "Source.json");

                            if (!Directory.Exists(tweetDir))
                            {
                                Directory.CreateDirectory(tweetDir);
                            }

                            string sourceJson = jResponse["globalObjects"]["tweets"][$"{t.Id}"].ToString();

                            if (!File.Exists(sourceFile))
                            {
                                File.WriteAllText(sourceFile, sourceJson);
                            }

                            if(t.Entities?.Media?.Any() ?? false)
                            {
                                foreach(Media m in t.Entities.Media)
                                {
                                    string fName = Path.GetFileName(m.MediaUrl);

                                    fName = Path.Combine(tweetDir, fName);

                                    if(!File.Exists(fName))
                                    {
                                        await Download(m.MediaUrl, fName);
                                    }
                                }
                            }
                        }

                        if (response.GlobalObjects.Tweets.Values.Count == searchModel.Count)
                        {
                            ///The path to the scroll cursor is convoluted
                            if (jResponse["timeline"]["instructions"] is JArray instructions)
                            {
                                foreach (JObject instruction in instructions)
                                {
                                    foreach (JProperty jprop in instruction.Properties())
                                    {
                                        if (jprop.Value is JObject replaceEntry)
                                        {
                                            //It might be an entries array, or an entry object
                                            if(replaceEntry["entries"] is JArray entries)
                                            {
                                                foreach(JObject entry in entries)
                                                {
                                                    string eId = entry["entryId"].ToString();

                                                    if (eId == "sq-cursor-bottom")
                                                    {
                                                        searchModel.Cursor = entry["content"]["operation"]["cursor"]["value"]?.ToString();

                                                        url = $"https://twitter.com/i/api/2/search/adaptive.json?{searchModel}";
                                                    }
                                                }
                                            } else if (replaceEntry["entry"] is JObject entry)
                                            {
                                                string eId = entry["entryId"].ToString();

                                                if (eId == "sq-cursor-bottom")
                                                {
                                                    searchModel.Cursor = entry["content"]["operation"]["cursor"]["value"]?.ToString();

                                                    url = $"https://twitter.com/i/api/2/search/adaptive.json?{searchModel}";
                                                }
                                            }

                                        }
                                    }
                                }
                                
                            }
                        }
                        else
                        {
                            break;
                        }

                       
                    } while (true);

                    searchModel.Cursor = null;

                    //This will just keep going forever
                    searchModel.Since = searchModel.Since.AddDays(-1);
                    searchModel.Until = searchModel.Until.AddDays(-1);     
                    
                    File.WriteAllText(checkpointFile, $"{searchModel.Until}");

                    url = $"https://twitter.com/i/api/2/search/adaptive.json?{searchModel}";

                } while (true);
            }
        }
    }
}