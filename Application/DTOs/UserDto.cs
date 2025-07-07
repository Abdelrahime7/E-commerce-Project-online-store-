using Domain.entities;
using Domain.Enums;

namespace Application.DTOs
{
    public record UserDto
    {
    
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsGuest { get; set; }

        public int PersonID { get; set; }
        public EnPermission EnPermission { get; set; }

       

    }


}