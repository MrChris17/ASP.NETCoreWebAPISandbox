using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreWebAPISandbox.DTO
{
    public class StudentDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Student Name is required.")]
        [MinLength(2, ErrorMessage = "Student Name must be at least 2 characters long.")]
        [MaxLength(100, ErrorMessage = "Student Name cannot exceed 100 characters.")]
        public required string Name { get; set; }
    }
}
