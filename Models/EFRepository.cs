
using SQLitePCL;

namespace Mission08_Team0102.Models
{
    public class EFRepository : IRepository
    {
        private TaskSubmissionContext _context;
        public EFRepository(TaskSubmissionContext temp) 
        { 
            _context = temp;
        }
        public List<Tasklist> Tasklists => _context.Tasklists.ToList();
        public List<Category> Categories => _context.Categories.ToList();

        public void Add(Tasklist tasklist)
        {
            _context.Tasklists.Add(tasklist);
            _context.SaveChanges();
        }

        public void Update(Tasklist tasklist)
        {
            _context.Tasklists.Update(tasklist);
            _context.SaveChanges();
        }

        public void Remove(Tasklist tasklist)
        {
            _context.Tasklists.Remove(tasklist);
            _context.SaveChanges();
        }
    }
}
