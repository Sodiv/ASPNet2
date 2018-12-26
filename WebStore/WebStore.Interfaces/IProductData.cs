using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Dto;
using WebStore.Domain.Dto.Product;
using WebStore.Domain.Entities;

namespace WebStore.Infrastuctures.Interfaces
{
    public interface IProductData
    {
        IEnumerable<SectionDto> GetSections();

        Section GetSectionById(int id);

        IEnumerable<BrandDto> GetBrands();

        Brand GetBrandById(int id);

        PagedProductDto GetProducts(ProductFilter filter);

        int GetBrandProductCount(int brandId);

        ProductDto GetProductById(int id);
    }
}
