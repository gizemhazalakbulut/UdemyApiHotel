using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast6Bookings:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLast6Bookings(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5147/api/Booking/Last6Bookings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast6BookingsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
