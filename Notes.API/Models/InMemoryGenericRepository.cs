namespace Notes.API.Models
{
    public abstract class InMemoryGenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        protected static List<T> _objects = new List<T>();

        public async Task<T> AddAsync(T entity)
        {
            var maxId = _objects.Any() ? _objects.Max(x => x.Id) : 0;
            entity.Id = maxId + 1;
            _objects.Add(entity);
            return await Task.FromResult(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _objects.Remove(entity);
            await Task.Delay(0);
        }

        public IEnumerable<T> GetAll()
        {
            return _objects;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var @object = _objects.Find(x => x.Id == id);
            return await Task.FromResult(@object);
        }

        public abstract Task UpdateAsync(T entity);
    }
}
