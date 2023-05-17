using Microsoft.AspNetCore.Http;
using System.IO;

namespace TemplateFwExample.Utilities.Extensions
{
    public static class Extensions
    {
        public static byte[] ToByteArray(this IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            }

            return default(byte[]);
        }
    }
}
