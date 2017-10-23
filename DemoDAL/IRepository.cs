using DemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL
{
    public interface IRepository<IEntity>
    {
        //C
        IEntity Create(IEntity ent);
        //R
        IEnumerable<IEntity> GetAll();
        IEnumerable<IEntity> GetAllById(List<int> ids);
        IEntity Get(int Id);
        //U
        //No Update for Repository, It will be the task of Unit of Work
        //D
        IEntity Delete(int Id);
    }
}
