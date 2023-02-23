using Leave_Management.Contracts;
using Leave_Management.Data;

namespace Leave_Management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {   
        private readonly ApplicationDbContext _db;
        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveAllocation entity)
        {
            //add record to LeaveAllocations table in db
            _db.LeaveAllocations.Add(entity);
            //save changes
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            //remove records in LeaveAllocations table from Db
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            //to get all list of record available in LeaveAllocations table from Db
            return _db.LeaveAllocations.ToList();
        }

        public LeaveAllocation FindByID(int id)
        {
            return _db.LeaveAllocations.Find(id);
            
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveAllocations.Any(q => q.Id == id);//using lambda expresssion
            return exists;
        }

        public bool Save()
        {
            //to save change in db if savechanges return >0... because savechanges return integer
            var changes =  _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
