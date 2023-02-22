using Leave_Management.Contracts;
using Leave_Management.Data;

namespace Leave_Management.Repository
{
    public class LeaveTypeRpository : ILeaveTypeReposiory
    {   
       //dependency Injection
        private readonly ApplicationDbContext _db;
        public LeaveTypeRpository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveType entity)
        {
            //add to LeaveType table in db
            _db.LeaveTypes.Add(entity);
            //save changes
            return Save();
        }

        public bool Delete(LeaveType entity)
        {   //delete a record from LeaveType table in db
            _db.LeaveTypes.Remove(entity);
            //save changes
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            //to get all list of record available in LeaveType table from Db
            return _db.LeaveTypes.ToList();
        }

        public LeaveType FindByID(int id)
        {
            return _db.LeaveTypes.Find(id);

        }

        public ICollection<LeaveType> GetEmployeesByLeaveType()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {   //to save change in db if savechanges return >0... because savechanges return integer
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveType entity)
        {   //update 
            _db.LeaveTypes.Update(entity);  
           //save in database 
            return Save();
        }
    }
}
