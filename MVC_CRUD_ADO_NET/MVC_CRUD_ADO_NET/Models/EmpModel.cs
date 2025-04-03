using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD_ADO_NET.Models
{
    public class EmpModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string City { get; set; }
    }
}
