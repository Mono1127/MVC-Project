using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.PL.Dtos
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage ="Name is required !!")]
        public string Name { get; set; }
        public int? Age { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Email is not valid !!")]
        public string Email { get; set; }
        [RegularExpression(@"[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$"
          ,  ErrorMessage ="Adress must be like 123-Street-City-Country"    )] 
        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        [DisplayName("HiringDate")]
        public DateTime HiringDate { get; set; }
        [DisplayName("CreateAt")]
        public DateTime CreateAt { get; set; }
    }
}
