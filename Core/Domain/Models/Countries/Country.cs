namespace TemplateFwExample.Domain.Models.Countries
{
    public partial class Country
    {
        public Country()
        {

        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }

    }
}
