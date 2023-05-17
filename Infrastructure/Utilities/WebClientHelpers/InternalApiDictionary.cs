namespace Dashboard.Common.WebClientHelpers
{
    public class InternalApiDictionary
    {
        
        public static class ExampleCategoryUrls
        {
            public const string Create = "examplecategory/Create";
            public const string Update = "examplecategory/Update";
            public const string Delete = "examplecategory/Delete/{0}";
            public const string GetAll = "examplecategory/getall";
            public const string GetPaged = "examplecategory/get-paged";

            public const string GetViewAll = "examplecategory/getallview";
            public const string GetOne = "examplecategory/getone/{0}";
            public const string Info = "examplecategory/info/{0}";
            public const string GetLookup = "examplecategory/lookup";
        }
	public static class ExampleModelUrls
        {
            public const string Create = "examplemodel/Create";
            public const string Update = "examplemodel/Update";
            public const string Delete = "examplemodel/Delete/{0}";
            public const string GetAll = "examplemodel/getall";
            public const string GetPaged = "examplemodel/get-paged";

            public const string GetViewAll = "examplemodel/getallview";
            public const string GetOne = "examplemodel/getone/{0}";
            public const string Info = "examplemodel/info/{0}";
            public const string GetLookup = "examplemodel/lookup?exampleCategoryId={0}&exampleStatusId={1}";
        }
	public static class ExampleStatusUrls
        {
            public const string Create = "examplestatus/Create";
            public const string Update = "examplestatus/Update";
            public const string Delete = "examplestatus/Delete/{0}";
            public const string GetAll = "examplestatus/getall";
            public const string GetPaged = "examplestatus/get-paged";

            public const string GetViewAll = "examplestatus/getallview";
            public const string GetOne = "examplestatus/getone/{0}";
            public const string Info = "examplestatus/info/{0}";
            public const string GetLookup = "examplestatus/lookup";
        }


        public static class IdentityUrls
        {
            public const string Login = "Account/Login";
            public const string UserData = "Account/GetUserData";
        }
        public static class LoggingSystemUrls
        {
            public const string LogData = "LoggingSystem/log_data";
        }

        public static class AttachmentsUrls
        {
            public const string Download = "Attachment/Download";
            public const string Save = "Attachment/Save";
        }

        public static class AdminUrls
        {
            public const string Save = "Identity/Save";
            public const string Delete = "Identity/Delete/{0}";
            public const string GetAll = "Identity/getall";
            public const string GetAllAdmins = "Identity/get-all-admins";
            public const string GetOne = "Identity/getone/{0}";
            public const string Getfullname = "Identity/getfullname/{0}";
        }

        public static class IdentityAdminUrls
        {
            public const string SendAdminNotificationForFoundationCreated = "IdentityAdmin/send-foundation-notification/{0}";
        }



        public static class NotificationsUrls
        {
            public const string GetAll = "Notifications/getall";
            public const string GetOne = "Notifications/getone/{0}";
            public const string GetCount = "Notifications/get-count";
            public const string UpdateSeen = "Notifications/update-seen";
            public const string RegisterWebToken = "Notifications/register-web-token/{0}";
        }
    }
}
