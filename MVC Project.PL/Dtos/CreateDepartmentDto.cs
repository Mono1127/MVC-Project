using System.ComponentModel.DataAnnotations;

namespace MVC_Project.PL.Dtos
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage = "Code is Required ")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is Required ")]
        public string Name { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
