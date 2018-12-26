using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Dto.Product
{
    public class PagedProductDto
    {
        public IEnumerable<ProductDto> Products { get; set; }

        public int TotalCount { get; set; }
    }
}
