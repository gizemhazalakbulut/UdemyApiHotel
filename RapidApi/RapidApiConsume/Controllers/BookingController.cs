using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&adults_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&checkout_date=2025-10-15&dest_type=city&page_number=0&units=metric&order_by=popularity&room_number=1&checkin_date=2025-10-14&filter_by_currency=EUR&dest_id=-1456928&locale=en-gb&include_adjacency=true"),
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
                var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                return View(values.results.ToList());
            }
          
        }
    }
}
