using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
    }
}
