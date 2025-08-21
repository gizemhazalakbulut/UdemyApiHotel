using Newtonsoft.Json;

namespace HotelProject.WebUI.Dtos.FollowersDto
{
    public class ResultInstagramFollowersDto
    {


        [JsonProperty("status")] public int Status { get; set; }
        [JsonProperty("message")] public string Message { get; set; }
        [JsonProperty("data")] public InstagramInfo Data { get; set; }
    }

    public class InstagramInfo
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("username")] public string Username { get; set; }
        [JsonProperty("full_name")] public string FullName { get; set; }
        [JsonProperty("is_private")] public bool IsPrivate { get; set; }
        [JsonProperty("is_verified")] public bool IsVerified { get; set; }
        [JsonProperty("profile_pic_url")] public string ProfilePicUrl { get; set; }
        [JsonProperty("profile_pic_url_proxy")] public string ProfilePicUrlProxy { get; set; }
        [JsonProperty("profile_pic_url_hd")] public string ProfilePicUrlHd { get; set; }
        [JsonProperty("profile_pic_url_hd_proxy")] public string ProfilePicUrlHdProxy { get; set; }
        [JsonProperty("followers")] public long Followers { get; set; }
        [JsonProperty("following")] public long Following { get; set; }
        [JsonProperty("fbid")] public long Fbid { get; set; }
        [JsonProperty("usertags_count")] public int UserTagsCount { get; set; }
    }

}

