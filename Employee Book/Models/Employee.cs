using System.ComponentModel.DataAnnotations;

namespace Employee_Book.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter the Name"), MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter the Email"),DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter te phonr number"),MaxLength(10),DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Enter the Address")]   
        public string Address { get; set; }

        [Required(ErrorMessage ="Enter the Date"), DataType(DataType.Date)]
        public string CreatedAt { get; set; }
    }
}
