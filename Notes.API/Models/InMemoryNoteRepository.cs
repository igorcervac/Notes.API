namespace Notes.API.Models
{
    public class InMemoryNoteRepository : InMemoryGenericRepository<Note>
    {
        public override async Task UpdateAsync(Note entity)
        {
            var entityToUpdate = _objects.Find(x => x.Id == entity.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Title = entity.Title;
                entityToUpdate.Content = entity.Content;
            }
            await Task.Delay(0);
        }
    }
}
