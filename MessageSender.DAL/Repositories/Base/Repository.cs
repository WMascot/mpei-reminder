using MessageSender.DAL.Context;
using MessageSender.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessageSender.DAL.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _set;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        public IQueryable<T> Items => _set.AsNoTracking();

        public T Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Added;
            _db.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Added;
            await _db.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public void Delete(int id)
        {
            var entity = Items.AsNoTracking().SingleOrDefault(x => x.Id == id) ?? new T { Id = id };
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await Items.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false) ?? new T { Id = id };
            _db.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public T? Get(int id)
            => Items.AsNoTracking().SingleOrDefault(x => x.Id == id);

        public async Task<T?> GetAsync(int id, CancellationToken cancellationToken = default)
           => await Items.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);

        public T Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }
    }
}
