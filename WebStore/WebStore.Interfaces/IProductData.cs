using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Dto;
using WebStore.Domain.Entities;

namespace WebStore.Infrastuctures.Interfaces
{
    public interface IProductData
    {
        IEnumerable<SectionDto> GetSections();

        IEnumerable<BrandDto> GetBrands();

        IEnumerable<ProductDto> GetProducts(ProductFilter filter);

        int GetBrandProductCount(int brandId);

        ProductDto GetProductById(int id);
    }
}
