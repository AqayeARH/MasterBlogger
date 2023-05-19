namespace _01.Framework.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void Rollback();
    }
}
