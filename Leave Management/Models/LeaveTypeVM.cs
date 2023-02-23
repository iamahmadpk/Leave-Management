using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime DateCreated { get; set; }
    }

}
