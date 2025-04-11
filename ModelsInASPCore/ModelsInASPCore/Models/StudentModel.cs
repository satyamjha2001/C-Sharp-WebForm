using System.ComponentModel.DataAnnotations;

namespace ModelsInASPCore.Models
{
    public class StudentModel
    {
        [Required]
        public int Rollno { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Standard { get; set; }
    }
}
