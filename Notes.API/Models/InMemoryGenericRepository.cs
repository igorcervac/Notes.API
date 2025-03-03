
namespace Notes.API.Models
{
    public class InMemoryGenericRepository<T> : IGenericRepository<T> where T: IEntity
    {
        private static List<T> _objects = new List<T>();

        public IEnumerable<T> GetAll()
        {
            return _objects;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var @object = _objects.Find(x => x.Id == id);
            return await Task.FromResult(@object);
        }

        public async Task<T> AddAsync(T @object)
        {
            @object.Id = (_objects.Any() ? _objects.Max(x => x.Id) : 0) + 1;
            _objects.Add(@object);

            return await Task.FromResult(@object);
        }

        public async Task DeleteAsync(T @object)
        {
            _objects.Remove(@object);
            await Task.Delay(0);
        }

        public async Task UpdateAsync(T note)
        {
            await Task.Delay(0);
        }

    }
}
