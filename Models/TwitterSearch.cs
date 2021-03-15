using Penguin.Web.Http;
using Penguin.Web.Http.Attributes;
using System;

namespace TwitterScraper.Models
{
    public class TwitterSearch : HttpQuery
    {
        public override string ToString()
        {
            string v = base.ToString();

            v = v.Replace("+", "%20");
            v = v.Replace("=True", "=true");
            v = v.Replace("%28", "(");
            v = v.Replace("%29", ")");

            if(v.EndsWith("&cursor="))
            {
                v = v.Replace("&cursor=", "");
            }

            return v;
        }
        [HttpQueryProperty("include_profile_interstitial_type")]
        public int IncludeProfileInterstitialType { get; set; } = 1;

        [HttpQueryProperty("include_blocking")]
        public int IncludeBlocking { get; set; } = 1;

        [HttpQueryProperty("include_blocked_by")]
        public int IncludeBlockedBy { get; set; } = 1;

        [HttpQueryProperty("include_followed_by")]
        public int IncludeFollowedBy { get; set; } = 1;

        [HttpQueryProperty("include_want_retweets")]
        public int IncludeWantRetweets { get; set; } = 1;

        [HttpQueryProperty("include_mute_edge")]
        public int IncludeMuteEdge { get; set; } = 1;

        [HttpQueryProperty("include_can_dm")]
        public int IncludeCanDM { get; set; } = 1;

        [HttpQueryProperty("include_can_media_tag")]
        public int IncludeCanMediaTag { get; set; } = 1;

        [HttpQueryProperty("skip_status")]
        public int SkipStatus { get; set; } = 1;

        [HttpQueryProperty("cards_platform")]
        public string CardsPlatform { get; set; } = "Web-12";

        [HttpQueryProperty("include_cards")]
        public int IncludeCards { get; set; } = 1;

        [HttpQueryProperty("include_ext_alt_text")]
        public bool IncludeExtAltText { get; set; } = true;

        [HttpQueryProperty("include_quote_count")]
        public bool IncludeQuoteCount { get; set; } = true;

        [HttpQueryProperty("include_reply_count")]
        public int IncludeReplyCount { get; set; } = 1;

        [HttpQueryProperty("tweet_mode")]
        public string TweetMode { get; set; } = "extended";

        [HttpQueryProperty("include_entities")]
        public bool IncludeEntities { get; set; } = true;

        [HttpQueryProperty("include_user_entities")]
        public bool IncludeUserEntities { get; set; } = true;

        [HttpQueryProperty("include_ext_media_color")]
        public bool IncludeExtMediaColor { get; set; } = true;

        [HttpQueryProperty("include_ext_media_availability")]
        public bool IncludeExtMediaAvailability { get; set; } = true;

        [HttpQueryProperty("send_error_codes")]
        public bool SendErrorCodes { get; set; } = true;

        [HttpQueryProperty("simple_quoted_tweet")]
        public bool SimpleQuotedTweet { get; set; } = true;

        [IgnoreQueryProperty]
        public string From { get; set; }

        [IgnoreQueryProperty]
        public DateTime Since { get; set; }

        [IgnoreQueryProperty]
        public DateTime Until { get; set; }

        [HttpQueryProperty("q")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members")]
        public string Query => $"(from:{this.From}) until:{this.Until:yyyy-MM-dd} since:{this.Since:yyyy-MM-dd}";

        [HttpQueryProperty("count")]
        public int Count { get; set; } = 20;

        [HttpQueryProperty("query_source")]
        public string QuerySource { get; set; } = "typed_query";

        [HttpQueryProperty("pc")]
        public int? PC { get; set; } = 1;

        [HttpQueryProperty("spelling_corrections")]
        public int SpellingCorrections { get; set; } = 1;

        [HttpQueryProperty("ext")]
        public string Ext { get; set; } = "mediaStats,highlightedLabel";

        [HttpQueryProperty("cursor")]
        public string Cursor { get; set; }
    }
}