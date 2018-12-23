using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.ViewModel
{
    public class BrandViewModel : OrderedEntity
    {
        public int ProductsCount { get; set; }
    }
}
