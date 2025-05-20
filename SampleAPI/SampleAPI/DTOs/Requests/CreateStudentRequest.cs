using System.ComponentModel.DataAnnotations;

namespace SampleAPI.DTOs.Requests
{
    public class CreateStudentRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
