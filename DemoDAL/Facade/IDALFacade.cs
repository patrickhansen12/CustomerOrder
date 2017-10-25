using DemoDAL.UOW;
using System;
namespace DemoDAL.Facade
{
    public interface IDALFacade
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
