using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.MVC.Models
{
    public class LocationVM : CreateLocationVM
    {
        public int Id { get; set; }

    }

    public class CreateLocationVM
    {
        [Required]
        public string Town { get; set; }
        [Required]
        public string Street { get; set; }
        public string Address { get { return Town + " " +Street; } }
    }

}
