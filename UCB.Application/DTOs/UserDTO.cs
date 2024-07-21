using System.Text.Json.Serialization;

namespace UBC.Application.DTOs
{
    public class UserDTO
    {
        //public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
