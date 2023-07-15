using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.MVC.Models
{
    public class EmployeeVM : CreateEmployeeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public PositionVM Position { get; set; }
        public LocationVM Location { get; set; }
    }

    public class CreateEmployeeVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public SelectList Positions{ get; set; }
        [Display(Name = "Positions")]
        [Required]
        public int PositionId { get; set; }
        [Required]
        public SelectList Locations { get; set; }
        [Display(Name = "Locations")]
        [Required]
        public int LocationId { get; set; }
    }

    public class AdminEmployeeViewVM
    {
        public List<EmployeeVM> Employees { get; set; }
    }
}
