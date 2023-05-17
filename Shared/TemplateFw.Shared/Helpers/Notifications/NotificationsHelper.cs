namespace TemplateFwExample.Utilities.Helpers.Notifications
{
    public class NotificationsHelper
    {
        public const string ArabicPrefix = "ar";
        public const string EnglishPrefix = "en";

        public class ComplaintsNotifications
        {
            public const string ServiceName = "الإستفسارات و الإقتراحات";
            public const string ArabicTitle = "الرد علي الإستفسار أو مقترح";
            public const string EnglishTitle = "Replay to queries and suggestions";
            public const string ArabicDescriptionSuggestion = "تم الرد على الاقتراح المقدم من طرفكم";
            public const string ArabicDescriptionInquiry = "تم الرد على الإستفسار المقدم من طرفكم";
            public const string EnglishDescriptionSuggestion = "Your suggestion has been answered";
            public const string EnglishDescriptionInquiry = "Your inquiry has been answered";
        }

        public class ActivateUserAccountNotifications
        {
            public const string ServiceName = "تفعيل الحساب";
            public const string ArabicTitle = "تم تفعيل الحساب";
            public const string EnglishTitle = "The account has been activated";
            public const string ArabicDescription = "تم تفعيل الحساب الشخصي الخاص بكم";
            public const string EnglishDescription = "Your personal account has been activated";
        }

        public class ActivateFoundationAccountNotifications
        {
            public const string ServiceName = "تفعيل حساب الجهه";
            public const string ArabicTitle = "تم تفعيل حساب الجهه";
            public const string EnglishTitle = "The account has been activated";
            public const string ArabicDescription = "تم تفعيل حساب {0} الخاص بكم";
            public const string EnglishDescription = "Your {0} account has been activated";
        }

        public class DeactivateFoundationAccountNotifications
        {
            public const string ServiceName = "إيقاف حساب الجهه";
            public const string ArabicTitle = "تم إيقاف حساب الجهه";
            public const string EnglishTitle = "The account has been deactivated";
            public const string ArabicDescription = "تم إيقاف حساب {0} الخاص بكم";
            public const string EnglishDescription = "Your {0} account has been deactivated";
        }
    }
}
