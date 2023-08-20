namespace MessageSender.DAL.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Items { get; }
        T? Get(int id);
        Task<T?> GetAsync(int id, CancellationToken cancellationToken = default);
        T Add(T entity);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        T Update(T entity);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        void Delete(int id);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
