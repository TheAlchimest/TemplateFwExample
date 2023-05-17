namespace TemplateFwExample.Utilities.Helpers
{
    //public class LocalizationsManager
    //{
    //    private static string[] LanguagesCodes = new string[2] { "ar", "en" };

    //    const string LanguageAR = "ar-EG";
    //    const string LanguageEN = "en-US";

    //    public static CultureInfo[] SupportedCultures =
    //    {
    //        new CultureInfo(LanguageAR),
    //        new CultureInfo(LanguageEN)
    //    };


    //    public static int GetLanguage()
    //    {
    //        switch (Thread.CurrentThread.CurrentCulture.Name)
    //        {
    //            case LanguageAR:
    //                return 1;

    //            case LanguageEN:
    //                return 2;

    //            default:
    //                return 1;
    //        }
    //    }

    //    public static EnumLanguage GetLanguageEnum()
    //    {
    //        switch (Thread.CurrentThread.CurrentCulture.Name)
    //        {
    //            case LanguageAR:
    //                return EnumLanguage.Arabic;
    //            case LanguageEN:
    //                return EnumLanguage.English;
    //            default:
    //                return EnumLanguage.Arabic;
    //        }
    //    }

    //    public static string GetLanguageCulture()
    //    {
    //        switch (GetLanguage())
    //        {
    //            case 1:
    //                return LanguageAR;

    //            case 2:
    //                return LanguageEN;

    //            default:
    //                return LanguageAR;
    //        }
    //    }

    //    public static string GetLanguageCode()
    //    {
    //        switch (GetLanguage())
    //        {
    //            case 1:
    //                return "ar";

    //            case 2:
    //                return "en";

    //            default:
    //                return "ar";
    //        }
    //    }
    //    private static string[] GetLanguageCodes()
    //    {
    //        return LocalizationsManager.LanguagesCodes;
    //    }
    //    public static bool IsSupportedLangCode(string code)
    //    {
    //        return LocalizationsManager.LanguagesCodes.Contains(code.ToLower());
    //    }
    //    public static string GetDefaultLangCode()
    //    {
    //        return "ar";
    //    }

    //    public static EnumLanguage GetLanguageEnum(string LangCode)
    //    {
    //        if (LocalizationsManager.IsSupportedLangCode(LangCode))
    //        {
    //            switch (LangCode.ToLower())
    //            {
    //                case "ar":
    //                    return EnumLanguage.Arabic;

    //                case "en":
    //                    return EnumLanguage.English;

    //                default:
    //                    return EnumLanguage.Arabic;
    //            }
    //        }
    //        return EnumLanguage.Arabic;
    //    }
    //}
}
