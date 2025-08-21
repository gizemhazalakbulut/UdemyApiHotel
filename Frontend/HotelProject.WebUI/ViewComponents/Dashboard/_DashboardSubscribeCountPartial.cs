using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getinfo/nazlialtac"),
                Headers =
    {
        { "x-rapidapi-key", "a6b0c05eacmsh0cf4fdfaf9eaffcp1d0c0ejsn1ef80e4216e0" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //ResultInstagramFollowersDto resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                var obj = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);

                ViewBag.v1 = obj?.Data?.Followers ?? 0;
                ViewBag.v2 = obj?.Data?.Following ?? 0;
            }
           


         
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/profile?username=nike"),
                Headers =
    {
        { "x-rapidapi-key", "a6b0c05eacmsh0cf4fdfaf9eaffcp1d0c0ejsn1ef80e4216e0" },
        { "x-rapidapi-host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwittterFollowersDto resultTwittterFollowersDto = JsonConvert.DeserializeObject<ResultTwittterFollowersDto>(body2);
                ViewBag.v3 = resultTwittterFollowersDto.data.stats.followers;
                ViewBag.v4 = resultTwittterFollowersDto.data.stats.following;

            }
            return View();
        }
    }
}


