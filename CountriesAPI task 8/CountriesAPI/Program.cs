using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.Json;

namespace CountriesAPI
{
    internal class Program
    {
        static async Task Main()
        {
            var allCountries = await MapApiInformation();
            GenerateCountryDataFiles(allCountries);
        }


        //ფაილების შექმნა
        public static void GenerateCountryDataFiles(List<Country> countries)
        {
            try
            {
                foreach (var country in countries)
                {
                    string fileName = $"{country?.Name?.Common}";

                    if (!Directory.Exists("../../../CountryFiles"))
                        Directory.CreateDirectory("../../../CountryFiles");

                    using (StreamWriter writer = File.CreateText($"../../../CountryFiles/{fileName}"))
                    {
                        writer.WriteLine($"Region: {country?.Region}");
                        writer.WriteLine($"Subregion: {country?.Subregion}");
                        writer.WriteLine($"LatLang: {string.Join(",", country.LatLng)}");
                        writer.WriteLine($"Area: {country?.Area}");
                        writer.WriteLine($"Population: {country?.Population}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //ინფორმაციის წაკითხვა API დან
        public static async Task<List<Country>?> MapApiInformation()
        {
            try
            {
                HttpClient httpClient = new();
                const string url = "https://restcountries.com/v3.1/all";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseAsJson = await response.Content.ReadAsStringAsync();
                    var countries = JArray.Parse(responseAsJson).ToObject<List<Country>>();

                    return countries;
                }
                else
                {
                    await Console.Out.WriteLineAsync($"API request failed with {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
        }
    }
}