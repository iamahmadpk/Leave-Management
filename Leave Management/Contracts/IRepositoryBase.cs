namespace Leave_Management.Contracts
{
    public interface IRepositoryBase<T > where T : class
    {
        ICollection<T> FindAll();
        T FindByID(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
