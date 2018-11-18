using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.Base
{
    public class OrderedEntity : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
