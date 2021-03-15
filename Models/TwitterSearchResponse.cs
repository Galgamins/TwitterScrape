using Newtonsoft.Json;
using System.Collections.Generic;

namespace TwitterScraper.Models
{
    public class OriginalInfo
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Size
    {
        [JsonProperty("w")]
        public int W { get; set; }

        [JsonProperty("h")]
        public int H { get; set; }

        [JsonProperty("resize")]
        public string Resize { get; set; }

        [JsonProperty("faces")]
        public List<Face> Faces { get; set; }
    }

    public class Sizes
    {
        [JsonProperty("small")]
        public Size Small { get; set; }

        [JsonProperty("large")]
        public Size Large { get; set; }

        [JsonProperty("thumb")]
        public Size Thumb { get; set; }

        [JsonProperty("medium")]
        public Size Medium { get; set; }

        [JsonProperty("orig")]
        public Orig Orig { get; set; }
    }

    public class Face
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonProperty("h")]
        public int H { get; set; }

        [JsonProperty("w")]
        public int W { get; set; }
    }

    public class Orig
    {
        [JsonProperty("faces")]
        public List<Face> Faces { get; set; }
    }

    public class Media
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id_str")]
        public string IdStr { get; set; }

        [JsonProperty("indices")]
        public List<int> Indices { get; set; }

        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }

        [JsonProperty("media_url_https")]
        public string MediaUrlHttps { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("original_info")]
        public OriginalInfo OriginalInfo { get; set; }

        [JsonProperty("sizes")]
        public Sizes Sizes { get; set; }

        [JsonProperty("features")]
        public Sizes Features { get; set; }

        [JsonProperty("media_key")]
        public string MediaKey { get; set; }

        [JsonProperty("ext_alt_text")]
        public string ExtAltText { get; set; }

        [JsonProperty("ext_media_availability")]
        public ExtMediaAvailability ExtMediaAvailability { get; set; }

        [JsonProperty("ext_media_color")]
        public ExtMediaColor ExtMediaColor { get; set; }

        [JsonProperty("video_info")]
        public VideoInfo VideoInfo { get; set; }
    }

    public class Entities
    {
        [JsonProperty("urls")]
        public List<object> Urls { get; set; }

        [JsonProperty("media")]
        public List<Media> Media { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("url")]
        public Url Url { get; set; }
    }

    public class ExtMediaAvailability
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Rgb
    {
        [JsonProperty("red")]
        public int Red { get; set; }

        [JsonProperty("green")]
        public int Green { get; set; }

        [JsonProperty("blue")]
        public int Blue { get; set; }
    }

    public class Palette
    {
        [JsonProperty("rgb")]
        public Rgb Rgb { get; set; }

        [JsonProperty("percentage")]
        public double Percentage { get; set; }
    }

    public class ExtMediaColor
    {
        [JsonProperty("palette")]
        public List<Palette> Palette { get; set; }
    }

    public class ExtendedEntities
    {
        [JsonProperty("media")]
        public List<Media> Media { get; set; }
    }

    public partial class Tweet
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id_str")]
        public string IdStr { get; set; }

        [JsonProperty("full_text")]
        public string FullText { get; set; }

        [JsonProperty("truncated")]
        public bool Truncated { get; set; }

        [JsonProperty("display_text_range")]
        public List<int> DisplayTextRange { get; set; }

        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("extended_entities")]
        public ExtendedEntities ExtendedEntities { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("user_id_str")]
        public string UserIdStr { get; set; }

        [JsonProperty("is_quote_status")]
        public bool IsQuoteStatus { get; set; }

        [JsonProperty("retweet_count")]
        public int RetweetCount { get; set; }

        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        [JsonProperty("reply_count")]
        public int ReplyCount { get; set; }

        [JsonProperty("quote_count")]
        public int QuoteCount { get; set; }

        [JsonProperty("conversation_id")]
        public long ConversationId { get; set; }

        [JsonProperty("conversation_id_str")]
        public string ConversationIdStr { get; set; }

        [JsonProperty("favorited")]
        public bool Favorited { get; set; }

        [JsonProperty("retweeted")]
        public bool Retweeted { get; set; }

        [JsonProperty("possibly_sensitive")]
        public bool PossiblySensitive { get; set; }

        [JsonProperty("possibly_sensitive_editable")]
        public bool PossiblySensitiveEditable { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("self_thread")]
        public SelfThread SelfThread { get; set; }
    }

    public class SelfThread
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id_str")]
        public string IdStr { get; set; }
    }

    public partial class UserMention
    {
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("id_str")]
        public string IdStr { get; set; }

        [JsonProperty("indices")]
        public List<int> Indices { get; set; }

        [JsonProperty("in_reply_to_status_id")]
        public long InReplyToStatusId { get; set; }

        [JsonProperty("in_reply_to_status_id_str")]
        public string InReplyToStatusIdStr { get; set; }

        [JsonProperty("in_reply_to_user_id")]
        public int InReplyToUserId { get; set; }

        [JsonProperty("in_reply_to_user_id_str")]
        public string InReplyToUserIdStr { get; set; }

        [JsonProperty("in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }
    }

    public class Variant
    {
        [JsonProperty("bitrate")]
        public int Bitrate { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class VideoInfo
    {
        [JsonProperty("aspect_ratio")]
        public List<int> AspectRatio { get; set; }

        [JsonProperty("variants")]
        public List<Variant> Variants { get; set; }
    }

    public class Url
    {
        [JsonProperty("url")]
        public string Value { get; set; }

        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("indices")]
        public List<int> Indices { get; set; }
    }

    public class Description
    {
        [JsonProperty("urls")]
        public List<object> Urls { get; set; }
    }

    public class ProfileImageExtensionsMediaColor
    {
        [JsonProperty("palette")]
        public List<Palette> Palette { get; set; }
    }


    public class ProfileBannerExtensionsMediaColor
    {
        [JsonProperty("palette")]
        public List<Palette> Palette { get; set; }
    }

    public partial class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id_str")]
        public string IdStr { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("protected")]
        public bool Protected { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("fast_followers_count")]
        public int FastFollowersCount { get; set; }

        [JsonProperty("normal_followers_count")]
        public int NormalFollowersCount { get; set; }

        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; }

        [JsonProperty("listed_count")]
        public int ListedCount { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("favourites_count")]
        public int FavouritesCount { get; set; }

        [JsonProperty("geo_enabled")]
        public bool GeoEnabled { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("statuses_count")]
        public int StatusesCount { get; set; }

        [JsonProperty("media_count")]
        public int MediaCount { get; set; }

        [JsonProperty("contributors_enabled")]
        public bool ContributorsEnabled { get; set; }

        [JsonProperty("is_translator")]
        public bool IsTranslator { get; set; }

        [JsonProperty("is_translation_enabled")]
        public bool IsTranslationEnabled { get; set; }

        [JsonProperty("profile_background_color")]
        public string ProfileBackgroundColor { get; set; }

        [JsonProperty("profile_background_tile")]
        public bool ProfileBackgroundTile { get; set; }

        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }

        [JsonProperty("profile_image_url_https")]
        public string ProfileImageUrlHttps { get; set; }

        [JsonProperty("profile_banner_url")]
        public string ProfileBannerUrl { get; set; }

        [JsonProperty("profile_image_extensions_media_color")]
        public ProfileImageExtensionsMediaColor ProfileImageExtensionsMediaColor { get; set; }

        [JsonProperty("profile_banner_extensions_media_color")]
        public ProfileBannerExtensionsMediaColor ProfileBannerExtensionsMediaColor { get; set; }

        [JsonProperty("profile_link_color")]
        public string ProfileLinkColor { get; set; }

        [JsonProperty("profile_sidebar_border_color")]
        public string ProfileSidebarBorderColor { get; set; }

        [JsonProperty("profile_sidebar_fill_color")]
        public string ProfileSidebarFillColor { get; set; }

        [JsonProperty("profile_text_color")]
        public string ProfileTextColor { get; set; }

        [JsonProperty("profile_use_background_image")]
        public bool ProfileUseBackgroundImage { get; set; }

        [JsonProperty("has_extended_profile")]
        public bool HasExtendedProfile { get; set; }

        [JsonProperty("default_profile")]
        public bool DefaultProfile { get; set; }

        [JsonProperty("default_profile_image")]
        public bool DefaultProfileImage { get; set; }

        [JsonProperty("has_custom_timelines")]
        public bool HasCustomTimelines { get; set; }

        [JsonProperty("can_dm")]
        public bool CanDm { get; set; }

        [JsonProperty("can_media_tag")]
        public bool CanMediaTag { get; set; }

        [JsonProperty("following")]
        public bool Following { get; set; }

        [JsonProperty("follow_request_sent")]
        public bool FollowRequestSent { get; set; }

        [JsonProperty("notifications")]
        public bool Notifications { get; set; }

        [JsonProperty("muting")]
        public bool Muting { get; set; }

        [JsonProperty("blocking")]
        public bool Blocking { get; set; }

        [JsonProperty("blocked_by")]
        public bool BlockedBy { get; set; }

        [JsonProperty("want_retweets")]
        public bool WantRetweets { get; set; }

        [JsonProperty("advertiser_account_type")]
        public string AdvertiserAccountType { get; set; }

        [JsonProperty("profile_interstitial_type")]
        public string ProfileInterstitialType { get; set; }

        [JsonProperty("business_profile_state")]
        public string BusinessProfileState { get; set; }

        [JsonProperty("translator_type")]
        public string TranslatorType { get; set; }

        [JsonProperty("followed_by")]
        public bool FollowedBy { get; set; }

        [JsonProperty("require_some_consent")]
        public bool RequireSomeConsent { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("pinned_tweet_ids")]
        public List<long> PinnedTweetIds { get; set; }

        [JsonProperty("pinned_tweet_ids_str")]
        public List<string> PinnedTweetIdsStr { get; set; }

        [JsonProperty("advertiser_account_service_levels")]
        public List<string> AdvertiserAccountServiceLevels { get; set; }

        [JsonProperty("profile_background_image_url")]
        public string ProfileBackgroundImageUrl { get; set; }

        [JsonProperty("profile_background_image_url_https")]
        public string ProfileBackgroundImageUrlHttps { get; set; }
    }

    public class Url2
    {
        [JsonProperty("urls")]
        public List<Url> Urls { get; set; }
    }

    public class GlobalObjects
    {
        [JsonProperty("tweets")]
        public Dictionary<string, Tweet> Tweets { get; set; }

        [JsonProperty("users")]
        public Dictionary<string, User> Users { get; set; }

        [JsonProperty("media")]
        public Media Media { get; set; }
    }

    public class TextHighlight
    {
        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }

        [JsonProperty("endIndex")]
        public int EndIndex { get; set; }
    }

    public class Highlights
    {
        [JsonProperty("textHighlights")]
        public List<TextHighlight> TextHighlights { get; set; }
    }

    public class MiniTweet
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayType")]
        public string DisplayType { get; set; }

        [JsonProperty("highlights")]
        public Highlights Highlights { get; set; }
    }

    public class TimelinesDetails
    {
        [JsonProperty("controllerData")]
        public string ControllerData { get; set; }
    }

    public class Details
    {
        [JsonProperty("timelinesDetails")]
        public TimelinesDetails TimelinesDetails { get; set; }
    }

    public class ClientEventInfo
    {
        [JsonProperty("component")]
        public string Component { get; set; }

        [JsonProperty("element")]
        public string Element { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

    public class DisplayContext
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }

    public class FeedbackInfo
    {
        [JsonProperty("feedbackKeys")]
        public List<string> FeedbackKeys { get; set; }

        [JsonProperty("displayContext")]
        public DisplayContext DisplayContext { get; set; }

        [JsonProperty("clientEventInfo")]
        public ClientEventInfo ClientEventInfo { get; set; }
    }


    public class Givefeedback
    {
        [JsonProperty("feedbackType")]
        public string FeedbackType { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("confirmation")]
        public string Confirmation { get; set; }

        [JsonProperty("childKeys")]
        public List<string> ChildKeys { get; set; }

        [JsonProperty("hasUndoAction")]
        public bool HasUndoAction { get; set; }

        [JsonProperty("confirmationDisplayType")]
        public string ConfirmationDisplayType { get; set; }

        [JsonProperty("clientEventInfo")]
        public ClientEventInfo ClientEventInfo { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class Notrelevant
    {
        [JsonProperty("feedbackType")]
        public string FeedbackType { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("confirmation")]
        public string Confirmation { get; set; }

        [JsonProperty("hasUndoAction")]
        public bool HasUndoAction { get; set; }

        [JsonProperty("confirmationDisplayType")]
        public string ConfirmationDisplayType { get; set; }

        [JsonProperty("clientEventInfo")]
        public ClientEventInfo ClientEventInfo { get; set; }
    }

    public class Notcredible
    {
        [JsonProperty("feedbackType")]
        public string FeedbackType { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("confirmation")]
        public string Confirmation { get; set; }

        [JsonProperty("hasUndoAction")]
        public bool HasUndoAction { get; set; }

        [JsonProperty("confirmationDisplayType")]
        public string ConfirmationDisplayType { get; set; }

        [JsonProperty("clientEventInfo")]
        public ClientEventInfo ClientEventInfo { get; set; }
    }

    public class FeedbackActions
    {
        [JsonProperty("givefeedback")]
        public Givefeedback Givefeedback { get; set; }

        [JsonProperty("notrelevant")]
        public Notrelevant Notrelevant { get; set; }

        [JsonProperty("notcredible")]
        public Notcredible Notcredible { get; set; }
    }

    public class ResponseObjects
    {
        [JsonProperty("feedbackActions")]
        public FeedbackActions FeedbackActions { get; set; }
    }

    public class Timeline
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("responseObjects")]
        public ResponseObjects ResponseObjects { get; set; }
    }

    public class TwitterSearchResponse
    {
        [JsonProperty("globalObjects")]
        public GlobalObjects GlobalObjects { get; set; }

        [JsonProperty("timeline")]
        public Timeline Timeline { get; set; }
    }
}