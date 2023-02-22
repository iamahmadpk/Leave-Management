using Leave_Management.Contracts;
using Leave_Management.Data;

namespace Leave_Management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {   
        //dependency Injection
        private readonly ApplicationDbContext _db;
        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveHistory entity)
        {
            //add recod to LeaveHistories table in db
            _db.LeaveHistories.Add(entity);
            //save changes in db
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            //remove records in LeaveHistories table from Db
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            //to get the list of record available in LeaveHistories table from Db
            return _db.LeaveHistories.ToList();
        }

        public LeaveHistory FindByID(int id)
        {
            return _db.LeaveHistories.Find(id);
        }

        public bool Save()
        {
            //to save change in db if savechanges return >0... because savechanges return integer
            return _db.SaveChanges() > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return Save();
        }
    }
}
