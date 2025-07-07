using Domain.entities;

namespace Application.DTOs
{
    public record PersonDto
    {

        public required string FName { get; set; }
        public required string LName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

       
    }


}