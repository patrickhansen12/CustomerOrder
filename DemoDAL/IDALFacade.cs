using System;
namespace DemoDAL
{
    public interface IDALFacade
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
