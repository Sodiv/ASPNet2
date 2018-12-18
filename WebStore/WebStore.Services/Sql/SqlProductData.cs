using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain.Dto;
using WebStore.Domain.Entities;
using WebStore.Infrastuctures.Interfaces;

namespace WebStore.Infrastuctures.Sql
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreContext _context;

        public SqlProductData(WebStoreContext context)
        {
            _context = context;
        }
        
        public int GetBrandProductCount(int brandId)
        {
            return _context.Products.Count(c => c.BrandId == brandId);
        }

        public IEnumerable<BrandDto> GetBrands()
        {
            return _context.Brands.Select(b => new BrandDto()
            {
                Id = b.Id,
                Name = b.Name,
                Order = b.Order
            }).ToList();
        }

        public ProductDto GetProductById(int id)
        {
            return _context.Products.Include("Brand").Include("Section").Select(p=>new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Brand = p.BrandId.HasValue ? new BrandDto() { Id = p.Brand.Id, Name = p.Brand.Name } : null
            }).FirstOrDefault(p => p.Id.Equals(id));
        }

        public IEnumerable<ProductDto> GetProducts(ProductFilter filter)
        {
            var query = _context.Products.Include("Brand").Include("Section").AsQueryable();

            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.SectionId.HasValue)
                query = query.Where(c => c.SectionId.Equals(filter.SectionId.Value));

            return query.Select(p=>new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Brand = p.BrandId.HasValue ? new BrandDto() { Id = p.Brand.Id, Name = p.Brand.Name } : null
            }).ToList();
        }

        public IEnumerable<SectionDto> GetSections()
        {
            return _context.Sections.Select(s=>new SectionDto()
            {
                Id = s.Id,
                Name = s.Name,
                Order = s.Order,
                ParentId = s.ParentId
            }).ToList();
        }
    }
}
