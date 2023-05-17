using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using TemplateFwExample.Shared.Domain.Enums;

namespace TemplateFwExample.Shared.Helpers
{
    public class LocalizationsManager
    {
        private static string[] LanguagesCodes = new string[2] { "ar", "en" };

        const string LanguageAR = "ar-EG";
        const string LanguageEN = "en-US";
        private static LanguageData ArabicLanguageData = null;
        private static LanguageData EnglishLanguageData = null;

        static LocalizationsManager()
        {
            ArabicLanguageData = new LanguageData
            {
                Code = "ar",
                Culture = LanguageAR,
                Direction = "",
                LangId = 1,
                Language = EnumLanguage.Arabic

            };
            EnglishLanguageData = new LanguageData
            {
                Code = "en",
                Culture = LanguageEN,
                Direction = "ltr",
                LangId = 2,
                Language = EnumLanguage.English

            };
        }

        public static CultureInfo[] SupportedCultures =
        {
            new CultureInfo(LanguageAR),
            new CultureInfo(LanguageEN)
        };

        public static string GetLanguageCulture(string lang)
        {
            switch (lang)
            {
                case "ar":
                    return LanguageAR;

                case "en":
                    return LanguageEN;

                default:
                    return LanguageAR;
            }
        }

        public static int GetLanguage()
        {
            switch (Thread.CurrentThread.CurrentCulture.Name)
            {
                case LanguageAR:
                    return 1;

                case LanguageEN:
                    return 2;

                default:
                    return 1;
            }
        }

        public static EnumLanguage GetLanguageEnum()
        {
            switch (Thread.CurrentThread.CurrentCulture.Name)
            {
                case LanguageAR:
                    return EnumLanguage.Arabic;
                case LanguageEN:
                    return EnumLanguage.English;
                default:
                    return EnumLanguage.Arabic;
            }
        }

        public static string GetLanguageCulture()
        {
            switch (GetLanguage())
            {
                case 1:
                    return LanguageAR;

                case 2:
                    return LanguageEN;

                default:
                    return LanguageAR;
            }
        }

        public static string GetLanguageCode()
        {
            switch (GetLanguage())
            {
                case 1:
                    return "ar";

                case 2:
                    return "en";

                default:
                    return "ar";
            }
        }
        public static string GetLanguageDirection()
        {
            switch (GetLanguage())
            {
                case 1:
                    return "rtl";

                case 2:
                    return "ltr";

                default:
                    return "rtl";
            }
        }
        public static string[] GetLanguageCodes()
        {
            return LocalizationsManager.LanguagesCodes;
        }
        public static bool IsSupportedLangCode(string code)
        {
            return LocalizationsManager.LanguagesCodes.Contains(code.ToLower());
        }
        public static string GetDefaultLangCode()
        {
            return "ar";
        }

        public static EnumLanguage GetLanguageEnum(string LangCode)
        {
            if (LocalizationsManager.IsSupportedLangCode(LangCode))
            {
                switch (LangCode.ToLower())
                {
                    case "ar":
                        return EnumLanguage.Arabic;

                    case "en":
                        return EnumLanguage.English;

                    default:
                        return EnumLanguage.Arabic;
                }
            }
            return EnumLanguage.Arabic;
        }

        public static LanguageData GetCurrentLanguage()
        {
            if (Thread.CurrentThread.CurrentCulture.Name == LanguageEN)
            {
                return EnglishLanguageData;
            }
            return ArabicLanguageData;

        }

    }

    public class LanguageData
    {

        public int LangId { get; set; }
        public EnumLanguage Language { get; set; }
        public string Code { get; set; }
        public string Direction { get; set; }
        public string Culture { get; set; }
    }
}
