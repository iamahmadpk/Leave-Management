using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management.Data
{
    public class LeaveAllocation
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }//Employee obj to whom these allocation is issued
        public string EmployeeId { get; set; }//targeted employee id, get details and stored in Employe obj above
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; } //leaveType obj 
        public int LeaveTypeId { get; set; }// targetd Leave Type
        public int Period { get; set; }
    }
}
