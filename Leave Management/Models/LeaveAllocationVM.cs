using Leave_Management.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Leave_Management.Models
{
    public class LeaveAllocationVM
    {   
        public int Id { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        //need to access list of employees
        public EmployeeVM Employee { get; set; }//Employee obj to whom these allocation is issued
        public string EmployeeId { get; set; }//targeted employee id, get details and stored in Employe obj above
        
        //need to have access list of leaveType
        public DetailsLeaveTypeVM LeaveType { get; set; } //leaveType obj 
        public int LeaveTypeId { get; set; }// targetd Leave Type
        //public int Period { get; set; }

        public IEnumerable<SelectListItem> Employees { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }

    }
}
