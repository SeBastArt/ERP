namespace ERP.Domain.Respositories
{
    public interface IRespository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
