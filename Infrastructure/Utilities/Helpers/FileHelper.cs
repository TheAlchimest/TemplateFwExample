using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Common.Helpers
{
    internal record FileContent(IEnumerable<byte> Bytes, string Extension, string ContentType)
    {
        public bool Equals(byte[] file) => file.Take(Bytes.Count()).SequenceEqual(Bytes);
    }

    public static class FileHelper
    {
        private static readonly List<FileContent> FileContents = new()
        {
            new FileContent(new byte[] { 0x42, 0x4D }, "bmp", "image/bmp"),
            new FileContent(new byte[] { 0, 0, 1, 0 }, "ico", "image/ico"),
            new FileContent(new byte[] { 0xFF, 0xD8, 0xFF }, "jpg", "image/jpg"),
            new FileContent(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },
                "png",
                "image/png"),
            new FileContent(new byte[] { 0x25, 0x50, 0x44, 0x46 }, "pdf", "image/pdf"),
        };

        public static (string extension, string contentType) GetMimeType(byte[] file)
        {
            var fileContent = FileContents.FirstOrDefault(c => c.Equals(file));

            return fileContent is not null ? (fileContent.Extension, fileContent.ContentType) : (null, null);
        }
    }
}
