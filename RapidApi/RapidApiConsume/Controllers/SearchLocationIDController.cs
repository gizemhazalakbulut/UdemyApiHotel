using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={cityName}"),
                    Headers =
    {
        { "x-rapidapi-key", "a6b0c05eacmsh0cf4fdfaf9eaffcp1d0c0ejsn1ef80e4216e0" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(model.Take(1).ToList());
                }

            }
            else
            {
                
                    List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name=Berlin"),
                        Headers =
    {
        { "x-rapidapi-key", "a6b0c05eacmsh0cf4fdfaf9eaffcp1d0c0ejsn1ef80e4216e0" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                    };
                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                        return View(model.Take(1).ToList());

                    }

                }
            

            
        }
    }
}

