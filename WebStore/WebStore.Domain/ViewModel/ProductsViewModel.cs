using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.ViewModel
{
    public class ProductsViewModel
    {
        public string Title { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
