using System.Text.Json.Serialization;

namespace CountriesAPI
{
    public class Country
    {
        public Name? Name { get; set; }
        public string? Region { get; set; }
        public string? Subregion { get; set; }
        public List<double>? LatLng { get; set; }
        public int Area { get; set; }
        public int Population { get; set; }
    }
}
