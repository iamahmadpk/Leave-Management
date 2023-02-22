using AutoMapper;
using Leave_Management.Data;
using Leave_Management.Models;

namespace Leave_Management.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {           //source from Data...Target from ViewModel
            //ReverseMap....=> wo-way mapping which is also called as bidirectional mapping
            CreateMap<LeaveType, DetailsLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveHistory, LeaveHistoryVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
