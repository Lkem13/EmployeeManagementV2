using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.MVC.Models
{
    public class PositionVM : CreatePositionVM
    {
         public int Id { get; set; }
    }

    public class CreatePositionVM
    {
            [Required]
            public string Name { get; set; }

    }
}

