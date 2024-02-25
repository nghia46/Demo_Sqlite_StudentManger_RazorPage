using Repo.Models;

namespace Repo;

public class UnitOfWork : IDisposable
{
    private DemoSqliteContext context = new DemoSqliteContext();
    private GenericRepository<Student> studentRepository;

    public GenericRepository<Student> StudentRepository
    {
        get
        {

            if (this.studentRepository == null)
            {
                this.studentRepository = new GenericRepository<Student>(context);
            }
            return studentRepository;
        }
    }

    public void Save()
    {
        context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}