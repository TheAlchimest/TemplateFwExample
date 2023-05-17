using System;

namespace TemplateFwExample.Utilities.Helpers
{
    public static class UiHelper
    {
        public static string ConvertToGridDateTime(this DateTime date)
        {
            string dateString = "";
            if (date > DateTime.MinValue)
            {
                dateString = date.ToString("dd/MM/yyyy") + "<br/>" + date.ToString("hh:mm") + (((date.Hour) > 11) ? "م" : "ص");
            }
            return dateString;
        }
        public static string ConvertToGridDateTime(this DateTime? nullableDate)
        {

            string dateString = "";
            if (nullableDate.HasValue)
            {
                dateString = nullableDate.Value.ConvertToGridDateTime();
            }
            return dateString;
        }

        public static string ConvertToDashboardInputTextDateTime(this DateTime date)
        {
            string dateString = "";
            if (date > DateTime.MinValue)
            {
                dateString = (((date.Hour) > 11) ? "م" : "ص") + " " + date.ToString("hh:mm") + " " + date.ToString("dd/MM/yyyy");
            }
            return dateString;
        }
        public static string ConvertToDashboardInputTextDateTime(this DateTime? nullableDate)
        {

            string dateString = "";
            if (nullableDate.HasValue)
            {
                dateString = nullableDate.Value.ConvertToGridDateTime();
            }
            return dateString;
        }
    }
}
