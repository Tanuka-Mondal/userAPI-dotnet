namespace UserAPI_Tanuka.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsBlocked { get; set; } = false;
    }
}
