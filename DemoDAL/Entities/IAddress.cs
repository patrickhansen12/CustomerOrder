using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.Entities
{
    interface IAddress : IEntity
    {
        String Street { get; set; }
        String Number { get; set; }
        String City { get; set; }
    }
}
