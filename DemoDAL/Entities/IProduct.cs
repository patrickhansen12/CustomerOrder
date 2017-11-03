using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.Entities
{
    interface IProduct: IEntity
    {
        string Name { get; set; }
    }
}
