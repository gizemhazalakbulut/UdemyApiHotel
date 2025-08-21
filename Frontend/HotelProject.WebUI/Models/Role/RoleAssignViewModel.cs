namespace HotelProject.WebUI.Models.Role
{
    public class RoleAssignViewModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; } //Kullanıcı bu role sahip mi değil mi sahipse:1 değilse:0 döner
    }
}
