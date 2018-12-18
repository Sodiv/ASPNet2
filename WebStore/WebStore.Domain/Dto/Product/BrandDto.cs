using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Dto
{
    public class BrandDto : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
