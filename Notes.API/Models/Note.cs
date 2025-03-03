namespace Notes.API.Models;

public partial class Note: IEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }
}
