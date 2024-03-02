namespace Mission08_Team0102.Models
{
    public interface IRepository
    {
        List<Tasklist> Tasklists { get; }

        public void Add(Tasklist tasklist);
        public void Update(Tasklist tasklist);

        public void Remove(Tasklist tasklist);
        List<Category> Categories { get; }
    }
}
