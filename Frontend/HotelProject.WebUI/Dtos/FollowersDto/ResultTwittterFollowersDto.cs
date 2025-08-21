namespace HotelProject.WebUI.Dtos.FollowersDto
{
    public class ResultTwittterFollowersDto
    {
            public string status { get; set; }
            public Data data { get; set; }
      }

        public class Data
        {
            public string fullname { get; set; }
            public string username { get; set; }
            public string bio { get; set; }
            public string location { get; set; }
            public string website { get; set; }
            public string join_date { get; set; }
            public string avatar_url { get; set; }
            public string avatar_image { get; set; }
            public string banner_image { get; set; }
            public Stats stats { get; set; }
        }

        public class Stats
        {
            public string posts { get; set; }
            public string following { get; set; }
            public string followers { get; set; }
            public string likes { get; set; }
        }

    }

