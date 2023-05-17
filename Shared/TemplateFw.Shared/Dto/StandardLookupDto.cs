namespace TemplateFwExample.Shared.Dto
{
    public class StandardLookupDto
    {
        public string Icon { get; set; }
        public string Text { get; set; }
        public string Id { get; set; }
        public bool Selected { get; set; }
        public bool Disabled { get; set; }
    }

    public class DynamicLookupControl
    {
        public string Url { get; set; }
        public string Value { get; set; }
    }

    public class RunTimeSelectControl
    {
        public bool Required { get; set; } = true;
        public string Id { get; set; }
        public string ApiUrl { get; set; }
        public string CascadeApiUrl { get; set; }
        public string CascadeWith { get; set; }
        public string AdditionalAttributes { get; set; } = "";
        public string Value { get; set; }
        public string DefaultText { get; set; } = "";
        public string DefaultValue { get; set; } = "";
        public bool AddDefaultOption { get; set; } = true;
    }
}
