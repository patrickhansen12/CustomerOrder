using DemoBLL.BusinessObjects;
using System.Collections.Generic;

namespace DemoBLL
{
    public interface IService<IEntity>
    {
        //C
        IEntity Create(IEntity cust);
        //R
        List<IEntity> GetAll();
        IEntity Get(int Id);
        //U
        IEntity Update(IEntity cust);
        //D
        IEntity Delete(int Id);
    }
    
}
