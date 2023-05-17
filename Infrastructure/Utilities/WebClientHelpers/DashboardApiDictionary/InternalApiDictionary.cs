namespace Dashboard.Common.WebClientHelpers.AccountsApiDictionary
{
    public static class FoundationAccountControllersUrls
    {
        public static string BusinessInternal = "FoundationAccountBusinessInternal";
        public static string BusinessExternal = "FoundationAccountBusinessExternal";
        public static string Government = "FoundationAccountGovernment";
        public static string Security = "FoundationAccountSecurity";
        public static string ServiceProvider = "FoundationAccountServiceProvider";
    }
    public static class BusinessToSpUrls
    {
        public const string AddSpAccountForBusiness = "FoundationAccountBusinessToSp/AddSpAccountForBusiness/{0}";
        public const string GetBsusinessNotHaveSP = "FoundationAccountBusinessToSp/GetBsusinessNotHaveSP";
    }

    public static class FoundationAccountUrls
    {
        public const string Create = "{0}/Create";
        public const string Add = "{0}/Create";
        public const string Edit = "{0}/Edit";
        public const string SaveAttachment = "{0}/SaveAttachment";
        public const string DeleteAttachment = "{0}/DeleteAttachment";
        public const string Activate = "{0}/Activate/{1}";
        public const string Deactivate = "{0}/deactivate/";
        public const string Reject = "{0}/reject/{1}";
        public const string GetAll = "{0}/getall";
        public const string GetActive = "{0}/getactive";
        public const string GetOne = "{0}/getone/{1}";
        public const string GetOneByNumber = "{0}/getone-by-number/{1}";
        public const string GetOneForLoggedIn = "{0}/getone-logged-in";
        public const string IsFoundationNumberExists = "{0}/is-foundation-number-exists/{1}";
        public const string IsFoundationArNameExists = "{0}/is-foundation-arabic-name-exists/{1}";
        public const string IsFoundationEnNameExists = "{0}/is-foundation-english-name-exists/{1}";

        public const string GetBlockReasonNotes = "{0}/GetBlockReasonNotes/{1}";

        public const string GetDelegateAccounts = "{0}/GetDelegateAccounts";
        public const string AddDelegateAccount = "{0}/AddDelegateAccount";
        public const string UpdateDelegateAccount = "{0}/UpdateDelegateAccount";
        public const string DeleteDelegateAccount = "{0}/DeleteDelegateAccount/{1}";

        public const string SaveFoundationBase = "{0}/SaveFoundationBase";
        public const string SaveFoundationContact = "{0}/SaveFoundationContact";
        public const string DeleteFoundationContact = "{0}/DeleteFoundationContact/{1}";

        public const string ChangePassword = "{0}/ChangePassword";
        public const string ChangePasswordAndEmail = "{0}/ChangePasswordAndEmail";
        public const string SendOtp = "{0}/SendOtp";
        public const string RestorePassword = "{0}/RestorePassword";
        public const string UserLoginSendOTP = "{0}/UserLoginSendOTP";
        public const string UserLogin = "{0}/UserLogin";

        public const string SaveFoundationAccountIntegration = "{0}/save-foundation-integration/{1}";

        public const string GetFoundationById = "{0}/get-foundation-data/{1}";
        public const string GetFoundationByFoundationNo = "{0}/get-foundation-data-by-number/{1}";
        public const string GetAllFoundationsCategories = "{0}/get-foundations-categories";
    }

    public static class FoundationAccountIntegrationUrls
    {
        public const string UserFoundations = "Integration/user-foundations";
        public const string FoundationDetails = "Integration/foundation-details/{0}";
    }

    public static class UserAccountsControllersUrls
    {
        public static string BusinessInternal = "UserAccountBusinessInternal";
        public static string BusinessExternal = "UserAccountBusinessExternal";
        public static string Government = "UserAccountGovernment";
        public static string Security = "UserAccountSecurity";
        public static string ServiceProvider = "UserAccountServiceProvider";
        public static string Individual = "UserAccountIndividual";
    }
    public static class UserAccountsUrls
    {
        public const string GetAllDelegations = "{0}/getall-delegations";
        public const string GetAllIndiviuals = "{0}/getall-individuals";
        public const string Activate = "{0}/Activate/{1}";
        public const string Reject = "{0}/Reject/{1}";
        public const string Deactivate = "{0}/deactivate";
        public const string GetBlockReasonNotes = "{0}/GetBlockReasonNotes/{1}";
    }

    public static class ExternalUserAccountUrls
    {
        public const string GetUserData = "{0}/get-user-data";
        public const string GetUserDataByFoundationId = "{0}/get-user-data/{1}";
        public const string GetUserFoundationData = "{0}/get-foundation-data";
        public const string GetUserFoundationDataByEncryptedFoundationNo = "{0}/get-foundation-data?encfoundationNo={1}";
    }

    public static class UserProfileControllersUrls
    {
        public static string BusinessInternal = "UserProfileBusinessInternal";
        public static string BusinessExternal = "UserProfileBusinessExternal";
        public static string Government = "UserProfileGovernment";
        public static string Security = "UserProfileSecurity";
        public static string ServiceProvider = "UserProfileServiceProvider";
        public static string Individual = "UserProfileIndividual";
    }
    public static class UserProfilesUrls
    {
        public const string SaveUserInfo = "save";
        public const string SaveUserInfoMobile = "Save-Mobile";
        public const string Get = "Get";
        public const string GetUserFullData = "GetUserFullData";
        public const string SaveImage = "SaveImage";
        public const string GetImage = "GetImage";
        public const string RemoveProfileImage = "RemoveProfileImage";
    }

}
