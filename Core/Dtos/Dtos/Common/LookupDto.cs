namespace TemplateFwExample.Dtos.Common
{
    public class LookupDto
    {
        public LookupDto()
        {

        }
        public LookupDto(int id, string text)
        {
            Id = id.ToString();
            Text = text;
        }
        public LookupDto(string id, string text)
        {
            Id = id;
            Text = text;
        }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
