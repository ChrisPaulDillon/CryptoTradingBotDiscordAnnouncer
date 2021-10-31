using System;
using System.Collections.Generic;
using System.Text;

namespace CoinListingScraper.Coinbase.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AmpLogo
    {
        public string backgroundSize { get; set; }
        public string filter { get; set; }
        public int height { get; set; }
        public string imageId { get; set; }
        public int originalHeight { get; set; }
        public int originalWidth { get; set; }
        public string strategy { get; set; }
        public int width { get; set; }
    }

    public class ColorPoint
    {
        public string color { get; set; }
        public double point { get; set; }
    }

    public class DarkBackgroundSpectrum
    {
        public string backgroundColor { get; set; }
        public List<ColorPoint> colorPoints { get; set; }
    }

    public class DefaultBackgroundSpectrum
    {
        public string backgroundColor { get; set; }
        public List<ColorPoint> colorPoints { get; set; }
    }

    public class HighlightSpectrum
    {
        public string backgroundColor { get; set; }
        public List<ColorPoint> colorPoints { get; set; }
    }

    public class TintBackgroundSpectrum
    {
        public string backgroundColor { get; set; }
        public List<ColorPoint> colorPoints { get; set; }
    }

    public class ColorPalette
    {
        public DarkBackgroundSpectrum darkBackgroundSpectrum { get; set; }
        public DefaultBackgroundSpectrum defaultBackgroundSpectrum { get; set; }
        public HighlightSpectrum highlightSpectrum { get; set; }
        public TintBackgroundSpectrum tintBackgroundSpectrum { get; set; }
    }

    public class Favicon
    {
        public string backgroundSize { get; set; }
        public string filter { get; set; }
        public int height { get; set; }
        public string imageId { get; set; }
        public int originalHeight { get; set; }
        public int originalWidth { get; set; }
        public string strategy { get; set; }
        public int width { get; set; }
    }

    public class BackgroundImage
    {
        public string id { get; set; }
        public int originalHeight { get; set; }
        public int originalWidth { get; set; }
    }

    public class LogoImage
    {
        public string alt { get; set; }
        public string id { get; set; }
        public int originalHeight { get; set; }
        public int originalWidth { get; set; }
    }

    public class Header
    {
        public int alignment { get; set; }
        public BackgroundImage backgroundImage { get; set; }
        public string description { get; set; }
        public int layout { get; set; }
        public LogoImage logoImage { get; set; }
        public string title { get; set; }
    }

    public class Image
    {
        public string backgroundSize { get; set; }
        public string filter { get; set; }
        public int height { get; set; }
        public string imageId { get; set; }
        public int originalHeight { get; set; }
        public int originalWidth { get; set; }
        public string strategy { get; set; }
        public int width { get; set; }
        public string id { get; set; }
    }

    public class Logo
    {
        public string backgroundSize { get; set; }
        public string filter { get; set; }
        public int height { get; set; }
        public string imageId { get; set; }
        public int originalHeight { get; set; }
        public int originalWidth { get; set; }
        public string strategy { get; set; }
        public int width { get; set; }
    }

    public class Metadata
    {
        public long activeAt { get; set; }
        public int followerCount { get; set; }
        public string id { get; set; }
        public bool isFeatured { get; set; }
        public int originalHeight { get; set; }
        public int originalWidth { get; set; }
        public CoverImage coverImage { get; set; }
        public int postCount { get; set; }
    }

    public class NavItem
    {
        public string source { get; set; }
        public string title { get; set; }
        public string topicId { get; set; }
        public int type { get; set; }
        public string url { get; set; }
    }

    public class PolarisCoverImage
    {
        public string backgroundSize { get; set; }
        public string filter { get; set; }
        public int height { get; set; }
        public string imageId { get; set; }
        public int originalHeight { get; set; }
        public int originalWidth { get; set; }
        public string strategy { get; set; }
        public int width { get; set; }
    }

    public class CollectionHeaderMetadata
    {
        public int alignment { get; set; }
        public BackgroundImage backgroundImage { get; set; }
        public string description { get; set; }
        public int layout { get; set; }
        public LogoImage logoImage { get; set; }
        public string title { get; set; }
    }

    public class PostListMetadata
    {
        public int layout { get; set; }
        public int number { get; set; }
        public List<string> postIds { get; set; }
        public int source { get; set; }
    }

    public class Section
    {
        public CollectionHeaderMetadata collectionHeaderMetadata { get; set; }
        public int type { get; set; }
        public PostListMetadata postListMetadata { get; set; }
        public int startIndex { get; set; }
        public string name { get; set; }
    }

    public class Permissions
    {
        public bool canAddWriters { get; set; }
        public bool canBeAssignedAuthor { get; set; }
        public bool canCreateNewsletterV3 { get; set; }
        public bool canEditOwnPosts { get; set; }
        public bool canEditPosts { get; set; }
        public bool canEnrollInHightower { get; set; }
        public bool canLockOwnPostsForMediumMembers { get; set; }
        public bool canLockPostsForMediumMembers { get; set; }
        public bool canManageAll { get; set; }
        public bool canPublish { get; set; }
        public bool canPublishAll { get; set; }
        public bool canRemove { get; set; }
        public bool canRepublish { get; set; }
        public bool canSendNewsletter { get; set; }
        public bool canSubmit { get; set; }
        public bool canViewCloaked { get; set; }
        public bool canViewLockedPosts { get; set; }
        public bool canViewNewsletterV2Stats { get; set; }
        public bool canViewStats { get; set; }
    }

    public class Virtuals
    {
        public bool canToggleEmail { get; set; }
        public bool isEligibleForHightower { get; set; }
        public bool isEnrolledInHightower { get; set; }
        public bool isMuted { get; set; }
        public bool isSubscribed { get; set; }
        public bool isSubscribedToCollectionEmails { get; set; }
        public bool isWriter { get; set; }
        public Permissions permissions { get; set; }
        public bool allowNotes { get; set; }
        public int imageCount { get; set; }
        public bool isBookmarked { get; set; }
        public bool isLockedPreviewOnly { get; set; }
        public Links links { get; set; }
        public string metaDescription { get; set; }
        public bool noIndex { get; set; }
        public PreviewImage previewImage { get; set; }
        public int publishedInCount { get; set; }
        public int readingList { get; set; }
        public double readingTime { get; set; }
        public int recommends { get; set; }
        public int responsesCreatedCount { get; set; }
        public int sectionCount { get; set; }
        public int socialRecommendsCount { get; set; }
        public string statusForCollection { get; set; }
        public string subtitle { get; set; }
        public List<Tag> tags { get; set; }
        public List<Topic> topics { get; set; }
        public int totalClapCount { get; set; }
        public List<object> usersBySocialRecommends { get; set; }
        public int wordCount { get; set; }
    }

    public class Collection
    {
        public int acceleratedMobilePagesState { get; set; }
        public AmpLogo ampLogo { get; set; }
        public int cloakedAt { get; set; }
        public List<int> collectionFeatures { get; set; }
        public string collectionMastheadId { get; set; }
        public int colorBehavior { get; set; }
        public ColorPalette colorPalette { get; set; }
        public string creatorId { get; set; }
        public string description { get; set; }
        public string domain { get; set; }
        public string facebookPageName { get; set; }
        public Favicon favicon { get; set; }
        public Header header { get; set; }
        public string id { get; set; }
        public Image image { get; set; }
        public bool isCurationAllowedByDefault { get; set; }
        public bool isOptedIntoAurora { get; set; }
        public bool lightText { get; set; }
        public Logo logo { get; set; }
        public Metadata metadata { get; set; }
        public string name { get; set; }
        public List<NavItem> navItems { get; set; }
        public PolarisCoverImage polarisCoverImage { get; set; }
        public long ptsQualifiedAt { get; set; }
        public string publicEmail { get; set; }
        public List<Section> sections { get; set; }
        public string shortDescription { get; set; }
        public string slug { get; set; }
        public int subscriberCount { get; set; }
        public string tagline { get; set; }
        public List<string> tags { get; set; }
        public string tintColor { get; set; }
        public string twitterUsername { get; set; }
        public string type { get; set; }
        public Virtuals virtuals { get; set; }
    }

    public class Next
    {
        public int limit { get; set; }
        public string to { get; set; }
    }

    public class Previous
    {
        public string from { get; set; }
        public int limit { get; set; }
    }

    public class Paging
    {
        public Next next { get; set; }
        public string path { get; set; }
        public Previous previous { get; set; }
    }

    public class C114225aeaf7
    {
        public int acceleratedMobilePagesState { get; set; }
        public AmpLogo ampLogo { get; set; }
        public int cloakedAt { get; set; }
        public List<int> collectionFeatures { get; set; }
        public string collectionMastheadId { get; set; }
        public int colorBehavior { get; set; }
        public ColorPalette colorPalette { get; set; }
        public string creatorId { get; set; }
        public string description { get; set; }
        public string domain { get; set; }
        public string facebookPageName { get; set; }
        public Favicon favicon { get; set; }
        public Header header { get; set; }
        public string id { get; set; }
        public Image image { get; set; }
        public bool isCurationAllowedByDefault { get; set; }
        public bool isOptedIntoAurora { get; set; }
        public bool lightText { get; set; }
        public Logo logo { get; set; }
        public Metadata metadata { get; set; }
        public string name { get; set; }
        public List<NavItem> navItems { get; set; }
        public PolarisCoverImage polarisCoverImage { get; set; }
        public long ptsQualifiedAt { get; set; }
        public string publicEmail { get; set; }
        public List<Section> sections { get; set; }
        public string shortDescription { get; set; }
        public string slug { get; set; }
        public int subscriberCount { get; set; }
        public string tagline { get; set; }
        public List<string> tags { get; set; }
        public string tintColor { get; set; }
        public string twitterUsername { get; set; }
        public string type { get; set; }
        public Virtuals virtuals { get; set; }
    }

    public class Collection2
    {
        public C114225aeaf7 c114225aeaf7 { get; set; }
    }

    public class PostDisplay
    {
        public bool coverless { get; set; }
    }

    public class Content
    {
        public PostDisplay postDisplay { get; set; }
        public string subtitle { get; set; }
    }

    public class Markup
    {
        public int end { get; set; }
        public int start { get; set; }
        public int type { get; set; }
        public int anchorType { get; set; }
        public string href { get; set; }
        public string rel { get; set; }
        public string title { get; set; }
    }

    public class Paragraph
    {
        public int layout { get; set; }
        public Metadata metadata { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public int type { get; set; }
        public int? alignment { get; set; }
        public List<Markup> markups { get; set; }
    }

    public class BodyModel
    {
        public List<Paragraph> paragraphs { get; set; }
        public List<Section> sections { get; set; }
    }

    public class PreviewContent
    {
        public BodyModel bodyModel { get; set; }
        public bool isFullContent { get; set; }
        public string subtitle { get; set; }
    }

    public class PreviewContent2
    {
        public BodyModel bodyModel { get; set; }
        public bool isFullContent { get; set; }
        public string subtitle { get; set; }
    }

    public class Entry
    {
        public List<object> alts { get; set; }
        public int httpStatus { get; set; }
        public string url { get; set; }
    }

    public class Links
    {
        public List<Entry> entries { get; set; }
        public long generatedAt { get; set; }
        public string version { get; set; }
    }

    public class PreviewImage
    {
        public string backgroundSize { get; set; }
        public string filter { get; set; }
        public int height { get; set; }
        public string imageId { get; set; }
        public int originalHeight { get; set; }
        public int originalWidth { get; set; }
        public string strategy { get; set; }
        public int width { get; set; }
    }

    public class CoverImage
    {
        public string id { get; set; }
        public bool isFeatured { get; set; }
        public int originalHeight { get; set; }
        public int originalWidth { get; set; }
        public string unsplashPhotoId { get; set; }
    }

    public class Tag
    {
        public Metadata metadata { get; set; }
        public string name { get; set; }
        public int postCount { get; set; }
        public string slug { get; set; }
        public string type { get; set; }
    }

    public class Topic
    {
        public object createdAt { get; set; }
        public int deletedAt { get; set; }
        public string description { get; set; }
        public Image image { get; set; }
        public string name { get; set; }
        public List<object> relatedTags { get; set; }
        public List<object> relatedTopicIds { get; set; }
        public List<object> relatedTopics { get; set; }
        public string seoTitle { get; set; }
        public string slug { get; set; }
        public string topicId { get; set; }
        public string type { get; set; }
        public int visibility { get; set; }
    }

    public class _1bbad477af59
    {
        public int acceptedAt { get; set; }
        public bool allowResponses { get; set; }
        public string approvedHomeCollectionId { get; set; }
        public int audioVersionDurationSec { get; set; }
        public string canonicalUrl { get; set; }
        public int cardType { get; set; }
        public Content content { get; set; }
        public bool coverless { get; set; }
        public long createdAt { get; set; }
        public string creatorId { get; set; }
        public int curationEligibleAt { get; set; }
        public int deletedAt { get; set; }
        public string detectedLanguage { get; set; }
        public string displayAuthor { get; set; }
        public string editorialPreviewDek { get; set; }
        public string editorialPreviewTitle { get; set; }
        public string experimentalCss { get; set; }
        public int featureLockRequestAcceptedAt { get; set; }
        public long firstPublishedAt { get; set; }
        public bool hasUnpublishedEdits { get; set; }
        public int hightowerMinimumGuaranteeEndsAt { get; set; }
        public int hightowerMinimumGuaranteeStartsAt { get; set; }
        public string homeCollectionId { get; set; }
        public string id { get; set; }
        public int importedPublishedAt { get; set; }
        public string importedUrl { get; set; }
        public string inResponseToMediaResourceId { get; set; }
        public string inResponseToPostId { get; set; }
        public int inResponseToRemovedAt { get; set; }
        public bool isApprovedTranslation { get; set; }
        public bool isBlockedFromHightower { get; set; }
        public bool isDistributionAlertDismissed { get; set; }
        public bool isEligibleForRevenue { get; set; }
        public bool isLimitedState { get; set; }
        public bool isLockedResponse { get; set; }
        public bool isMarkedPaywallOnly { get; set; }
        public bool isNewsletter { get; set; }
        public bool isProxyPost { get; set; }
        public bool isPublishToEmail { get; set; }
        public bool isSeries { get; set; }
        public bool isShortform { get; set; }
        public bool isSubscriptionLocked { get; set; }
        public bool isSuspended { get; set; }
        public bool isTitleSynthesized { get; set; }
        public long latestPublishedAt { get; set; }
        public string latestPublishedVersion { get; set; }
        public int latestRev { get; set; }
        public string latestVersion { get; set; }
        public int layerCake { get; set; }
        public int license { get; set; }
        public int lockedPostSource { get; set; }
        public string mediumUrl { get; set; }
        public string migrationId { get; set; }
        public int mongerRequestType { get; set; }
        public string newsletterId { get; set; }
        public bool notifyFacebook { get; set; }
        public bool notifyFollowers { get; set; }
        public bool notifyTwitter { get; set; }
        public PreviewContent previewContent { get; set; }
        public PreviewContent2 previewContent2 { get; set; }
        public string proxyPostFaviconUrl { get; set; }
        public string proxyPostProviderName { get; set; }
        public int proxyPostType { get; set; }
        public int responseDistribution { get; set; }
        public int responseHiddenOnParentPostAt { get; set; }
        public bool responsesLocked { get; set; }
        public string seoTitle { get; set; }
        public string sequenceId { get; set; }
        public int seriesLastAppendedAt { get; set; }
        public int shortformType { get; set; }
        public string slug { get; set; }
        public string socialDek { get; set; }
        public string socialTitle { get; set; }
        public string title { get; set; }
        public string translationSourceCreatorId { get; set; }
        public string translationSourcePostId { get; set; }
        public string type { get; set; }
        public string uniqueSlug { get; set; }
        public long updatedAt { get; set; }
        public string versionId { get; set; }
        public Virtuals virtuals { get; set; }
        public int visibility { get; set; }
        public bool vote { get; set; }
        public string webCanonicalUrl { get; set; }
    }

    public class _343e6e7ed6f1
    {
        public int acceptedAt { get; set; }
        public bool allowResponses { get; set; }
        public string approvedHomeCollectionId { get; set; }
        public int audioVersionDurationSec { get; set; }
        public string canonicalUrl { get; set; }
        public int cardType { get; set; }
        public Content content { get; set; }
        public bool coverless { get; set; }
        public long createdAt { get; set; }
        public string creatorId { get; set; }
        public int curationEligibleAt { get; set; }
        public int deletedAt { get; set; }
        public string detectedLanguage { get; set; }
        public string displayAuthor { get; set; }
        public string editorialPreviewDek { get; set; }
        public string editorialPreviewTitle { get; set; }
        public string experimentalCss { get; set; }
        public int featureLockRequestAcceptedAt { get; set; }
        public long firstPublishedAt { get; set; }
        public bool hasUnpublishedEdits { get; set; }
        public int hightowerMinimumGuaranteeEndsAt { get; set; }
        public int hightowerMinimumGuaranteeStartsAt { get; set; }
        public string homeCollectionId { get; set; }
        public string id { get; set; }
        public int importedPublishedAt { get; set; }
        public string importedUrl { get; set; }
        public string inResponseToMediaResourceId { get; set; }
        public string inResponseToPostId { get; set; }
        public int inResponseToRemovedAt { get; set; }
        public bool isApprovedTranslation { get; set; }
        public bool isBlockedFromHightower { get; set; }
        public bool isDistributionAlertDismissed { get; set; }
        public bool isEligibleForRevenue { get; set; }
        public bool isLimitedState { get; set; }
        public bool isLockedResponse { get; set; }
        public bool isMarkedPaywallOnly { get; set; }
        public bool isNewsletter { get; set; }
        public bool isProxyPost { get; set; }
        public bool isPublishToEmail { get; set; }
        public bool isSeries { get; set; }
        public bool isShortform { get; set; }
        public bool isSubscriptionLocked { get; set; }
        public bool isSuspended { get; set; }
        public bool isTitleSynthesized { get; set; }
        public long latestPublishedAt { get; set; }
        public string latestPublishedVersion { get; set; }
        public int latestRev { get; set; }
        public string latestVersion { get; set; }
        public int layerCake { get; set; }
        public int license { get; set; }
        public int lockedPostSource { get; set; }
        public string mediumUrl { get; set; }
        public string migrationId { get; set; }
        public int mongerRequestType { get; set; }
        public string newsletterId { get; set; }
        public bool notifyFacebook { get; set; }
        public bool notifyFollowers { get; set; }
        public bool notifyTwitter { get; set; }
        public PreviewContent previewContent { get; set; }
        public PreviewContent2 previewContent2 { get; set; }
        public string proxyPostFaviconUrl { get; set; }
        public string proxyPostProviderName { get; set; }
        public int proxyPostType { get; set; }
        public int responseDistribution { get; set; }
        public int responseHiddenOnParentPostAt { get; set; }
        public bool responsesLocked { get; set; }
        public string seoTitle { get; set; }
        public string sequenceId { get; set; }
        public int seriesLastAppendedAt { get; set; }
        public int shortformType { get; set; }
        public string slug { get; set; }
        public string socialDek { get; set; }
        public string socialTitle { get; set; }
        public string title { get; set; }
        public string translationSourceCreatorId { get; set; }
        public string translationSourcePostId { get; set; }
        public string type { get; set; }
        public string uniqueSlug { get; set; }
        public long updatedAt { get; set; }
        public string versionId { get; set; }
        public Virtuals virtuals { get; set; }
        public int visibility { get; set; }
        public bool vote { get; set; }
        public string webCanonicalUrl { get; set; }
    }

    public class _38b880c0298a
    {
        public int acceptedAt { get; set; }
        public bool allowResponses { get; set; }
        public string approvedHomeCollectionId { get; set; }
        public int audioVersionDurationSec { get; set; }
        public string canonicalUrl { get; set; }
        public int cardType { get; set; }
        public Content content { get; set; }
        public bool coverless { get; set; }
        public long createdAt { get; set; }
        public string creatorId { get; set; }
        public int curationEligibleAt { get; set; }
        public int deletedAt { get; set; }
        public string detectedLanguage { get; set; }
        public string displayAuthor { get; set; }
        public string editorialPreviewDek { get; set; }
        public string editorialPreviewTitle { get; set; }
        public string experimentalCss { get; set; }
        public int featureLockRequestAcceptedAt { get; set; }
        public long firstPublishedAt { get; set; }
        public bool hasUnpublishedEdits { get; set; }
        public int hightowerMinimumGuaranteeEndsAt { get; set; }
        public int hightowerMinimumGuaranteeStartsAt { get; set; }
        public string homeCollectionId { get; set; }
        public string id { get; set; }
        public int importedPublishedAt { get; set; }
        public string importedUrl { get; set; }
        public string inResponseToMediaResourceId { get; set; }
        public string inResponseToPostId { get; set; }
        public int inResponseToRemovedAt { get; set; }
        public bool isApprovedTranslation { get; set; }
        public bool isBlockedFromHightower { get; set; }
        public bool isDistributionAlertDismissed { get; set; }
        public bool isEligibleForRevenue { get; set; }
        public bool isLimitedState { get; set; }
        public bool isLockedResponse { get; set; }
        public bool isMarkedPaywallOnly { get; set; }
        public bool isNewsletter { get; set; }
        public bool isProxyPost { get; set; }
        public bool isPublishToEmail { get; set; }
        public bool isSeries { get; set; }
        public bool isShortform { get; set; }
        public bool isSubscriptionLocked { get; set; }
        public bool isSuspended { get; set; }
        public bool isTitleSynthesized { get; set; }
        public long latestPublishedAt { get; set; }
        public string latestPublishedVersion { get; set; }
        public int latestRev { get; set; }
        public string latestVersion { get; set; }
        public int layerCake { get; set; }
        public int license { get; set; }
        public int lockedPostSource { get; set; }
        public string mediumUrl { get; set; }
        public string migrationId { get; set; }
        public int mongerRequestType { get; set; }
        public string newsletterId { get; set; }
        public bool notifyFacebook { get; set; }
        public bool notifyFollowers { get; set; }
        public bool notifyTwitter { get; set; }
        public PreviewContent previewContent { get; set; }
        public PreviewContent2 previewContent2 { get; set; }
        public string proxyPostFaviconUrl { get; set; }
        public string proxyPostProviderName { get; set; }
        public int proxyPostType { get; set; }
        public int responseDistribution { get; set; }
        public int responseHiddenOnParentPostAt { get; set; }
        public bool responsesLocked { get; set; }
        public string seoTitle { get; set; }
        public string sequenceId { get; set; }
        public int seriesLastAppendedAt { get; set; }
        public int shortformType { get; set; }
        public string slug { get; set; }
        public string socialDek { get; set; }
        public string socialTitle { get; set; }
        public string title { get; set; }
        public string translationSourceCreatorId { get; set; }
        public string translationSourcePostId { get; set; }
        public string type { get; set; }
        public string uniqueSlug { get; set; }
        public long updatedAt { get; set; }
        public string versionId { get; set; }
        public Virtuals virtuals { get; set; }
        public int visibility { get; set; }
        public bool vote { get; set; }
        public string webCanonicalUrl { get; set; }
    }

    public class _3e6088c3dcb3
    {
        public int acceptedAt { get; set; }
        public bool allowResponses { get; set; }
        public string approvedHomeCollectionId { get; set; }
        public int audioVersionDurationSec { get; set; }
        public string canonicalUrl { get; set; }
        public int cardType { get; set; }
        public Content content { get; set; }
        public bool coverless { get; set; }
        public long createdAt { get; set; }
        public string creatorId { get; set; }
        public int curationEligibleAt { get; set; }
        public int deletedAt { get; set; }
        public string detectedLanguage { get; set; }
        public string displayAuthor { get; set; }
        public string editorialPreviewDek { get; set; }
        public string editorialPreviewTitle { get; set; }
        public string experimentalCss { get; set; }
        public int featureLockRequestAcceptedAt { get; set; }
        public long firstPublishedAt { get; set; }
        public bool hasUnpublishedEdits { get; set; }
        public int hightowerMinimumGuaranteeEndsAt { get; set; }
        public int hightowerMinimumGuaranteeStartsAt { get; set; }
        public string homeCollectionId { get; set; }
        public string id { get; set; }
        public int importedPublishedAt { get; set; }
        public string importedUrl { get; set; }
        public string inResponseToMediaResourceId { get; set; }
        public string inResponseToPostId { get; set; }
        public int inResponseToRemovedAt { get; set; }
        public bool isApprovedTranslation { get; set; }
        public bool isBlockedFromHightower { get; set; }
        public bool isDistributionAlertDismissed { get; set; }
        public bool isEligibleForRevenue { get; set; }
        public bool isLimitedState { get; set; }
        public bool isLockedResponse { get; set; }
        public bool isMarkedPaywallOnly { get; set; }
        public bool isNewsletter { get; set; }
        public bool isProxyPost { get; set; }
        public bool isPublishToEmail { get; set; }
        public bool isSeries { get; set; }
        public bool isShortform { get; set; }
        public bool isSubscriptionLocked { get; set; }
        public bool isSuspended { get; set; }
        public bool isTitleSynthesized { get; set; }
        public long latestPublishedAt { get; set; }
        public string latestPublishedVersion { get; set; }
        public int latestRev { get; set; }
        public string latestVersion { get; set; }
        public int layerCake { get; set; }
        public int license { get; set; }
        public int lockedPostSource { get; set; }
        public string mediumUrl { get; set; }
        public string migrationId { get; set; }
        public int mongerRequestType { get; set; }
        public string newsletterId { get; set; }
        public bool notifyFacebook { get; set; }
        public bool notifyFollowers { get; set; }
        public bool notifyTwitter { get; set; }
        public PreviewContent previewContent { get; set; }
        public PreviewContent2 previewContent2 { get; set; }
        public string proxyPostFaviconUrl { get; set; }
        public string proxyPostProviderName { get; set; }
        public int proxyPostType { get; set; }
        public int responseDistribution { get; set; }
        public int responseHiddenOnParentPostAt { get; set; }
        public bool responsesLocked { get; set; }
        public string seoTitle { get; set; }
        public string sequenceId { get; set; }
        public int seriesLastAppendedAt { get; set; }
        public int shortformType { get; set; }
        public string slug { get; set; }
        public string socialDek { get; set; }
        public string socialTitle { get; set; }
        public string title { get; set; }
        public string translationSourceCreatorId { get; set; }
        public string translationSourcePostId { get; set; }
        public string type { get; set; }
        public string uniqueSlug { get; set; }
        public long updatedAt { get; set; }
        public string versionId { get; set; }
        public Virtuals virtuals { get; set; }
        public int visibility { get; set; }
        public bool vote { get; set; }
        public string webCanonicalUrl { get; set; }
    }

    public class _5411d68dfd2b
    {
        public int acceptedAt { get; set; }
        public bool allowResponses { get; set; }
        public string approvedHomeCollectionId { get; set; }
        public int audioVersionDurationSec { get; set; }
        public string canonicalUrl { get; set; }
        public int cardType { get; set; }
        public Content content { get; set; }
        public bool coverless { get; set; }
        public long createdAt { get; set; }
        public string creatorId { get; set; }
        public int curationEligibleAt { get; set; }
        public int deletedAt { get; set; }
        public string detectedLanguage { get; set; }
        public string displayAuthor { get; set; }
        public string editorialPreviewDek { get; set; }
        public string editorialPreviewTitle { get; set; }
        public string experimentalCss { get; set; }
        public int featureLockRequestAcceptedAt { get; set; }
        public long firstPublishedAt { get; set; }
        public bool hasUnpublishedEdits { get; set; }
        public int hightowerMinimumGuaranteeEndsAt { get; set; }
        public int hightowerMinimumGuaranteeStartsAt { get; set; }
        public string homeCollectionId { get; set; }
        public string id { get; set; }
        public int importedPublishedAt { get; set; }
        public string importedUrl { get; set; }
        public string inResponseToMediaResourceId { get; set; }
        public string inResponseToPostId { get; set; }
        public int inResponseToRemovedAt { get; set; }
        public bool isApprovedTranslation { get; set; }
        public bool isBlockedFromHightower { get; set; }
        public bool isDistributionAlertDismissed { get; set; }
        public bool isEligibleForRevenue { get; set; }
        public bool isLimitedState { get; set; }
        public bool isLockedResponse { get; set; }
        public bool isMarkedPaywallOnly { get; set; }
        public bool isNewsletter { get; set; }
        public bool isProxyPost { get; set; }
        public bool isPublishToEmail { get; set; }
        public bool isSeries { get; set; }
        public bool isShortform { get; set; }
        public bool isSubscriptionLocked { get; set; }
        public bool isSuspended { get; set; }
        public bool isTitleSynthesized { get; set; }
        public long latestPublishedAt { get; set; }
        public string latestPublishedVersion { get; set; }
        public int latestRev { get; set; }
        public string latestVersion { get; set; }
        public int layerCake { get; set; }
        public int license { get; set; }
        public int lockedPostSource { get; set; }
        public string mediumUrl { get; set; }
        public string migrationId { get; set; }
        public int mongerRequestType { get; set; }
        public string newsletterId { get; set; }
        public bool notifyFacebook { get; set; }
        public bool notifyFollowers { get; set; }
        public bool notifyTwitter { get; set; }
        public PreviewContent previewContent { get; set; }
        public PreviewContent2 previewContent2 { get; set; }
        public string proxyPostFaviconUrl { get; set; }
        public string proxyPostProviderName { get; set; }
        public int proxyPostType { get; set; }
        public int responseDistribution { get; set; }
        public int responseHiddenOnParentPostAt { get; set; }
        public bool responsesLocked { get; set; }
        public string seoTitle { get; set; }
        public string sequenceId { get; set; }
        public int seriesLastAppendedAt { get; set; }
        public int shortformType { get; set; }
        public string slug { get; set; }
        public string socialDek { get; set; }
        public string socialTitle { get; set; }
        public string title { get; set; }
        public string translationSourceCreatorId { get; set; }
        public string translationSourcePostId { get; set; }
        public string type { get; set; }
        public string uniqueSlug { get; set; }
        public long updatedAt { get; set; }
        public string versionId { get; set; }
        public Virtuals virtuals { get; set; }
        public int visibility { get; set; }
        public bool vote { get; set; }
        public string webCanonicalUrl { get; set; }
    }

    public class _7b1787f163c9
    {
        public int acceptedAt { get; set; }
        public bool allowResponses { get; set; }
        public string approvedHomeCollectionId { get; set; }
        public int audioVersionDurationSec { get; set; }
        public string canonicalUrl { get; set; }
        public int cardType { get; set; }
        public Content content { get; set; }
        public bool coverless { get; set; }
        public long createdAt { get; set; }
        public string creatorId { get; set; }
        public int curationEligibleAt { get; set; }
        public int deletedAt { get; set; }
        public string detectedLanguage { get; set; }
        public string displayAuthor { get; set; }
        public string editorialPreviewDek { get; set; }
        public string editorialPreviewTitle { get; set; }
        public string experimentalCss { get; set; }
        public int featureLockRequestAcceptedAt { get; set; }
        public long firstPublishedAt { get; set; }
        public bool hasUnpublishedEdits { get; set; }
        public int hightowerMinimumGuaranteeEndsAt { get; set; }
        public int hightowerMinimumGuaranteeStartsAt { get; set; }
        public string homeCollectionId { get; set; }
        public string id { get; set; }
        public int importedPublishedAt { get; set; }
        public string importedUrl { get; set; }
        public string inResponseToMediaResourceId { get; set; }
        public string inResponseToPostId { get; set; }
        public int inResponseToRemovedAt { get; set; }
        public bool isApprovedTranslation { get; set; }
        public bool isBlockedFromHightower { get; set; }
        public bool isDistributionAlertDismissed { get; set; }
        public bool isEligibleForRevenue { get; set; }
        public bool isLimitedState { get; set; }
        public bool isLockedResponse { get; set; }
        public bool isMarkedPaywallOnly { get; set; }
        public bool isNewsletter { get; set; }
        public bool isProxyPost { get; set; }
        public bool isPublishToEmail { get; set; }
        public bool isSeries { get; set; }
        public bool isShortform { get; set; }
        public bool isSubscriptionLocked { get; set; }
        public bool isSuspended { get; set; }
        public bool isTitleSynthesized { get; set; }
        public long latestPublishedAt { get; set; }
        public string latestPublishedVersion { get; set; }
        public int latestRev { get; set; }
        public string latestVersion { get; set; }
        public int layerCake { get; set; }
        public int license { get; set; }
        public int lockedPostSource { get; set; }
        public string mediumUrl { get; set; }
        public string migrationId { get; set; }
        public int mongerRequestType { get; set; }
        public string newsletterId { get; set; }
        public bool notifyFacebook { get; set; }
        public bool notifyFollowers { get; set; }
        public bool notifyTwitter { get; set; }
        public PreviewContent previewContent { get; set; }
        public PreviewContent2 previewContent2 { get; set; }
        public string proxyPostFaviconUrl { get; set; }
        public string proxyPostProviderName { get; set; }
        public int proxyPostType { get; set; }
        public int responseDistribution { get; set; }
        public int responseHiddenOnParentPostAt { get; set; }
        public bool responsesLocked { get; set; }
        public string seoTitle { get; set; }
        public string sequenceId { get; set; }
        public int seriesLastAppendedAt { get; set; }
        public int shortformType { get; set; }
        public string slug { get; set; }
        public string socialDek { get; set; }
        public string socialTitle { get; set; }
        public string title { get; set; }
        public string translationSourceCreatorId { get; set; }
        public string translationSourcePostId { get; set; }
        public string type { get; set; }
        public string uniqueSlug { get; set; }
        public long updatedAt { get; set; }
        public string versionId { get; set; }
        public Virtuals virtuals { get; set; }
        public int visibility { get; set; }
        public bool vote { get; set; }
        public string webCanonicalUrl { get; set; }
    }

    public class Alt
    {
        public int type { get; set; }
        public string url { get; set; }
    }

    public class _950e5ff70370
    {
        public int acceptedAt { get; set; }
        public bool allowResponses { get; set; }
        public string approvedHomeCollectionId { get; set; }
        public int audioVersionDurationSec { get; set; }
        public string canonicalUrl { get; set; }
        public int cardType { get; set; }
        public Content content { get; set; }
        public bool coverless { get; set; }
        public long createdAt { get; set; }
        public string creatorId { get; set; }
        public int curationEligibleAt { get; set; }
        public int deletedAt { get; set; }
        public string detectedLanguage { get; set; }
        public string displayAuthor { get; set; }
        public string editorialPreviewDek { get; set; }
        public string editorialPreviewTitle { get; set; }
        public string experimentalCss { get; set; }
        public int featureLockRequestAcceptedAt { get; set; }
        public long firstPublishedAt { get; set; }
        public bool hasUnpublishedEdits { get; set; }
        public int hightowerMinimumGuaranteeEndsAt { get; set; }
        public int hightowerMinimumGuaranteeStartsAt { get; set; }
        public string homeCollectionId { get; set; }
        public string id { get; set; }
        public int importedPublishedAt { get; set; }
        public string importedUrl { get; set; }
        public string inResponseToMediaResourceId { get; set; }
        public string inResponseToPostId { get; set; }
        public int inResponseToRemovedAt { get; set; }
        public bool isApprovedTranslation { get; set; }
        public bool isBlockedFromHightower { get; set; }
        public bool isDistributionAlertDismissed { get; set; }
        public bool isEligibleForRevenue { get; set; }
        public bool isLimitedState { get; set; }
        public bool isLockedResponse { get; set; }
        public bool isMarkedPaywallOnly { get; set; }
        public bool isNewsletter { get; set; }
        public bool isProxyPost { get; set; }
        public bool isPublishToEmail { get; set; }
        public bool isSeries { get; set; }
        public bool isShortform { get; set; }
        public bool isSubscriptionLocked { get; set; }
        public bool isSuspended { get; set; }
        public bool isTitleSynthesized { get; set; }
        public long latestPublishedAt { get; set; }
        public string latestPublishedVersion { get; set; }
        public int latestRev { get; set; }
        public string latestVersion { get; set; }
        public int layerCake { get; set; }
        public int license { get; set; }
        public int lockedPostSource { get; set; }
        public string mediumUrl { get; set; }
        public string migrationId { get; set; }
        public int mongerRequestType { get; set; }
        public string newsletterId { get; set; }
        public bool notifyFacebook { get; set; }
        public bool notifyFollowers { get; set; }
        public bool notifyTwitter { get; set; }
        public PreviewContent previewContent { get; set; }
        public PreviewContent2 previewContent2 { get; set; }
        public string primaryTopicId { get; set; }
        public string proxyPostFaviconUrl { get; set; }
        public string proxyPostProviderName { get; set; }
        public int proxyPostType { get; set; }
        public int responseDistribution { get; set; }
        public int responseHiddenOnParentPostAt { get; set; }
        public bool responsesLocked { get; set; }
        public string seoTitle { get; set; }
        public string sequenceId { get; set; }
        public int seriesLastAppendedAt { get; set; }
        public int shortformType { get; set; }
        public string slug { get; set; }
        public string socialDek { get; set; }
        public string socialTitle { get; set; }
        public string title { get; set; }
        public string translationSourceCreatorId { get; set; }
        public string translationSourcePostId { get; set; }
        public string type { get; set; }
        public string uniqueSlug { get; set; }
        public long updatedAt { get; set; }
        public string versionId { get; set; }
        public Virtuals virtuals { get; set; }
        public int visibility { get; set; }
        public bool vote { get; set; }
        public string webCanonicalUrl { get; set; }
    }

    public class _9b4c6f9c484f
    {
        public int acceptedAt { get; set; }
        public bool allowResponses { get; set; }
        public string approvedHomeCollectionId { get; set; }
        public int audioVersionDurationSec { get; set; }
        public string canonicalUrl { get; set; }
        public int cardType { get; set; }
        public Content content { get; set; }
        public bool coverless { get; set; }
        public long createdAt { get; set; }
        public string creatorId { get; set; }
        public int curationEligibleAt { get; set; }
        public int deletedAt { get; set; }
        public string detectedLanguage { get; set; }
        public string displayAuthor { get; set; }
        public string editorialPreviewDek { get; set; }
        public string editorialPreviewTitle { get; set; }
        public string experimentalCss { get; set; }
        public int featureLockRequestAcceptedAt { get; set; }
        public long firstPublishedAt { get; set; }
        public bool hasUnpublishedEdits { get; set; }
        public int hightowerMinimumGuaranteeEndsAt { get; set; }
        public int hightowerMinimumGuaranteeStartsAt { get; set; }
        public string homeCollectionId { get; set; }
        public string id { get; set; }
        public int importedPublishedAt { get; set; }
        public string importedUrl { get; set; }
        public string inResponseToMediaResourceId { get; set; }
        public string inResponseToPostId { get; set; }
        public int inResponseToRemovedAt { get; set; }
        public bool isApprovedTranslation { get; set; }
        public bool isBlockedFromHightower { get; set; }
        public bool isDistributionAlertDismissed { get; set; }
        public bool isEligibleForRevenue { get; set; }
        public bool isLimitedState { get; set; }
        public bool isLockedResponse { get; set; }
        public bool isMarkedPaywallOnly { get; set; }
        public bool isNewsletter { get; set; }
        public bool isProxyPost { get; set; }
        public bool isPublishToEmail { get; set; }
        public bool isSeries { get; set; }
        public bool isShortform { get; set; }
        public bool isSubscriptionLocked { get; set; }
        public bool isSuspended { get; set; }
        public bool isTitleSynthesized { get; set; }
        public long latestPublishedAt { get; set; }
        public string latestPublishedVersion { get; set; }
        public int latestRev { get; set; }
        public string latestVersion { get; set; }
        public int layerCake { get; set; }
        public int license { get; set; }
        public int lockedPostSource { get; set; }
        public string mediumUrl { get; set; }
        public string migrationId { get; set; }
        public int mongerRequestType { get; set; }
        public string newsletterId { get; set; }
        public bool notifyFacebook { get; set; }
        public bool notifyFollowers { get; set; }
        public bool notifyTwitter { get; set; }
        public PreviewContent previewContent { get; set; }
        public PreviewContent2 previewContent2 { get; set; }
        public string proxyPostFaviconUrl { get; set; }
        public string proxyPostProviderName { get; set; }
        public int proxyPostType { get; set; }
        public int responseDistribution { get; set; }
        public int responseHiddenOnParentPostAt { get; set; }
        public bool responsesLocked { get; set; }
        public string seoTitle { get; set; }
        public string sequenceId { get; set; }
        public int seriesLastAppendedAt { get; set; }
        public int shortformType { get; set; }
        public string slug { get; set; }
        public string socialDek { get; set; }
        public string socialTitle { get; set; }
        public string title { get; set; }
        public string translationSourceCreatorId { get; set; }
        public string translationSourcePostId { get; set; }
        public string type { get; set; }
        public string uniqueSlug { get; set; }
        public long updatedAt { get; set; }
        public string versionId { get; set; }
        public Virtuals virtuals { get; set; }
        public int visibility { get; set; }
        public bool vote { get; set; }
        public string webCanonicalUrl { get; set; }
    }

    public class B1c3cdc358f2
    {
        public int acceptedAt { get; set; }
        public bool allowResponses { get; set; }
        public string approvedHomeCollectionId { get; set; }
        public int audioVersionDurationSec { get; set; }
        public string canonicalUrl { get; set; }
        public int cardType { get; set; }
        public Content content { get; set; }
        public bool coverless { get; set; }
        public long createdAt { get; set; }
        public string creatorId { get; set; }
        public int curationEligibleAt { get; set; }
        public int deletedAt { get; set; }
        public string detectedLanguage { get; set; }
        public string displayAuthor { get; set; }
        public string editorialPreviewDek { get; set; }
        public string editorialPreviewTitle { get; set; }
        public string experimentalCss { get; set; }
        public int featureLockRequestAcceptedAt { get; set; }
        public long firstPublishedAt { get; set; }
        public bool hasUnpublishedEdits { get; set; }
        public int hightowerMinimumGuaranteeEndsAt { get; set; }
        public int hightowerMinimumGuaranteeStartsAt { get; set; }
        public string homeCollectionId { get; set; }
        public string id { get; set; }
        public int importedPublishedAt { get; set; }
        public string importedUrl { get; set; }
        public string inResponseToMediaResourceId { get; set; }
        public string inResponseToPostId { get; set; }
        public int inResponseToRemovedAt { get; set; }
        public bool isApprovedTranslation { get; set; }
        public bool isBlockedFromHightower { get; set; }
        public bool isDistributionAlertDismissed { get; set; }
        public bool isEligibleForRevenue { get; set; }
        public bool isLimitedState { get; set; }
        public bool isLockedResponse { get; set; }
        public bool isMarkedPaywallOnly { get; set; }
        public bool isNewsletter { get; set; }
        public bool isProxyPost { get; set; }
        public bool isPublishToEmail { get; set; }
        public bool isSeries { get; set; }
        public bool isShortform { get; set; }
        public bool isSubscriptionLocked { get; set; }
        public bool isSuspended { get; set; }
        public bool isTitleSynthesized { get; set; }
        public long latestPublishedAt { get; set; }
        public string latestPublishedVersion { get; set; }
        public int latestRev { get; set; }
        public string latestVersion { get; set; }
        public int layerCake { get; set; }
        public int license { get; set; }
        public int lockedPostSource { get; set; }
        public string mediumUrl { get; set; }
        public string migrationId { get; set; }
        public int mongerRequestType { get; set; }
        public string newsletterId { get; set; }
        public bool notifyFacebook { get; set; }
        public bool notifyFollowers { get; set; }
        public bool notifyTwitter { get; set; }
        public PreviewContent previewContent { get; set; }
        public PreviewContent2 previewContent2 { get; set; }
        public string proxyPostFaviconUrl { get; set; }
        public string proxyPostProviderName { get; set; }
        public int proxyPostType { get; set; }
        public int responseDistribution { get; set; }
        public int responseHiddenOnParentPostAt { get; set; }
        public bool responsesLocked { get; set; }
        public string seoTitle { get; set; }
        public string sequenceId { get; set; }
        public int seriesLastAppendedAt { get; set; }
        public int shortformType { get; set; }
        public string slug { get; set; }
        public string socialDek { get; set; }
        public string socialTitle { get; set; }
        public string title { get; set; }
        public string translationSourceCreatorId { get; set; }
        public string translationSourcePostId { get; set; }
        public string type { get; set; }
        public string uniqueSlug { get; set; }
        public long updatedAt { get; set; }
        public string versionId { get; set; }
        public Virtuals virtuals { get; set; }
        public int visibility { get; set; }
        public bool vote { get; set; }
        public string webCanonicalUrl { get; set; }
    }

    public class F67425cd3c3
    {
        public int acceptedAt { get; set; }
        public bool allowResponses { get; set; }
        public string approvedHomeCollectionId { get; set; }
        public int audioVersionDurationSec { get; set; }
        public string canonicalUrl { get; set; }
        public int cardType { get; set; }
        public Content content { get; set; }
        public bool coverless { get; set; }
        public long createdAt { get; set; }
        public string creatorId { get; set; }
        public int curationEligibleAt { get; set; }
        public int deletedAt { get; set; }
        public string detectedLanguage { get; set; }
        public string displayAuthor { get; set; }
        public string editorialPreviewDek { get; set; }
        public string editorialPreviewTitle { get; set; }
        public string experimentalCss { get; set; }
        public int featureLockRequestAcceptedAt { get; set; }
        public long firstPublishedAt { get; set; }
        public bool hasUnpublishedEdits { get; set; }
        public int hightowerMinimumGuaranteeEndsAt { get; set; }
        public int hightowerMinimumGuaranteeStartsAt { get; set; }
        public string homeCollectionId { get; set; }
        public string id { get; set; }
        public int importedPublishedAt { get; set; }
        public string importedUrl { get; set; }
        public string inResponseToMediaResourceId { get; set; }
        public string inResponseToPostId { get; set; }
        public int inResponseToRemovedAt { get; set; }
        public bool isApprovedTranslation { get; set; }
        public bool isBlockedFromHightower { get; set; }
        public bool isDistributionAlertDismissed { get; set; }
        public bool isEligibleForRevenue { get; set; }
        public bool isLimitedState { get; set; }
        public bool isLockedResponse { get; set; }
        public bool isMarkedPaywallOnly { get; set; }
        public bool isNewsletter { get; set; }
        public bool isProxyPost { get; set; }
        public bool isPublishToEmail { get; set; }
        public bool isSeries { get; set; }
        public bool isShortform { get; set; }
        public bool isSubscriptionLocked { get; set; }
        public bool isSuspended { get; set; }
        public bool isTitleSynthesized { get; set; }
        public long latestPublishedAt { get; set; }
        public string latestPublishedVersion { get; set; }
        public int latestRev { get; set; }
        public string latestVersion { get; set; }
        public int layerCake { get; set; }
        public int license { get; set; }
        public int lockedPostSource { get; set; }
        public string mediumUrl { get; set; }
        public string migrationId { get; set; }
        public int mongerRequestType { get; set; }
        public string newsletterId { get; set; }
        public bool notifyFacebook { get; set; }
        public bool notifyFollowers { get; set; }
        public bool notifyTwitter { get; set; }
        public PreviewContent previewContent { get; set; }
        public PreviewContent2 previewContent2 { get; set; }
        public string proxyPostFaviconUrl { get; set; }
        public string proxyPostProviderName { get; set; }
        public int proxyPostType { get; set; }
        public int responseDistribution { get; set; }
        public int responseHiddenOnParentPostAt { get; set; }
        public bool responsesLocked { get; set; }
        public string seoTitle { get; set; }
        public string sequenceId { get; set; }
        public int seriesLastAppendedAt { get; set; }
        public int shortformType { get; set; }
        public string slug { get; set; }
        public string socialDek { get; set; }
        public string socialTitle { get; set; }
        public string title { get; set; }
        public string translationSourceCreatorId { get; set; }
        public string translationSourcePostId { get; set; }
        public string type { get; set; }
        public string uniqueSlug { get; set; }
        public long updatedAt { get; set; }
        public string versionId { get; set; }
        public Virtuals virtuals { get; set; }
        public int visibility { get; set; }
        public bool vote { get; set; }
        public string webCanonicalUrl { get; set; }
    }

    public class Post
    {
        public _1bbad477af59 _1bbad477af59 { get; set; }
        public _343e6e7ed6f1 _343e6e7ed6f1 { get; set; }
        public _38b880c0298a _38b880c0298a { get; set; }
        public _3e6088c3dcb3 _3e6088c3dcb3 { get; set; }
        public _5411d68dfd2b _5411d68dfd2b { get; set; }
        public _7b1787f163c9 _7b1787f163c9 { get; set; }
        public _950e5ff70370 _950e5ff70370 { get; set; }
        public _9b4c6f9c484f _9b4c6f9c484f { get; set; }
        public B1c3cdc358f2 b1c3cdc358f2 { get; set; }
        public F67425cd3c3 f67425cd3c3 { get; set; }
    }

    public class _913e7ed84452
    {
        public int allowNotes { get; set; }
        public string backgroundImageId { get; set; }
        public string bio { get; set; }
        public long createdAt { get; set; }
        public bool hasCompletedProfile { get; set; }
        public bool hasSeenIcelandOnboarding { get; set; }
        public string imageId { get; set; }
        public bool isMembershipTrialEligible { get; set; }
        public bool isSuspended { get; set; }
        public bool isWriterProgramEnrolled { get; set; }
        public long mediumMemberAt { get; set; }
        public string name { get; set; }
        public bool optInToIceland { get; set; }
        public int postSubscribeMembershipUpsellShownAt { get; set; }
        public int replyToEmailBannerShownCount { get; set; }
        public string twitterScreenName { get; set; }
        public string type { get; set; }
        public List<int> userDismissableFlags { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
    }

    public class User
    {
        public _913e7ed84452 _913e7ed84452 { get; set; }
    }

    public class References
    {
        public Collection Collection { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }

    public class HeadingBasic
    {
        public string title { get; set; }
    }

    public class Heading
    {
        public string fallbackTitle { get; set; }
        public HeadingBasic headingBasic { get; set; }
        public string headingType { get; set; }
        public Heading heading { get; set; }
        public string text { get; set; }
    }

    public class Post2
    {
        public string postId { get; set; }
    }

    public class Item
    {
        public string itemType { get; set; }
        public Post post { get; set; }
    }

    public class Section23
    {
        public Heading heading { get; set; }
        public List<Item> items { get; set; }
        public int layout { get; set; }
    }

    public class PostPreview
    {
        public string postId { get; set; }
    }

    public class StreamItem
    {
        public object createdAt { get; set; }
        public string itemType { get; set; }
        public string randomId { get; set; }
        public Section section { get; set; }
        public string type { get; set; }
        public Heading heading { get; set; }
        public PostPreview postPreview { get; set; }
    }

    public class CoinBaseArticle
    {
        public Collection collection { get; set; }
        public Paging paging { get; set; }
        public References references { get; set; }
        public List<StreamItem> streamItems { get; set; }
    }


}
