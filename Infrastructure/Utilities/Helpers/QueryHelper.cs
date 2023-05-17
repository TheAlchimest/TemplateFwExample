namespace Dashboard.Common.Helpers
{
    public static class QueryHelper
    {
        /// <summary>
        /// tack val and name to make query
        /// ex:- url?name1=val1&name2=val2
        /// </summary>
        /// <param name="pr">value and name of object to make query</param>
        /// <returns></returns>
        public static string MakeQuery(params (object val, string name)[] pr)
        {
            var str = "?";

            foreach (var (val, name) in pr)
                str += val is not null ? $"{name}={val}&" : string.Empty;

            str = str.Remove(str.Length - 1);

            return str;
        }
    }
}