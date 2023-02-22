using Leave_Management.Data;

namespace Leave_Management.Contracts
{
    public interface ILeaveTypeReposiory : IRepositoryBase<LeaveType>
    {
        ICollection<LeaveType> GetEmployeesByLeaveType();
    }
}
