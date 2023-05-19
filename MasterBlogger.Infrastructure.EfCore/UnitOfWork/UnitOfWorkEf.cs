using _01.Framework.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace MasterBlogger.Infrastructure.EfCore.UnitOfWork
{
    public class UnitOfWorkEf : IUnitOfWork
    {
        private readonly MasterBloggerContext _context;
        public UnitOfWorkEf(MasterBloggerContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
    }
}