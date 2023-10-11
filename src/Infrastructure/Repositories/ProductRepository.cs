using AutoMapper;
using Ecom.Core.Dtos;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Ecom.Core.Sharing;
using Ecom.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repositories {
    public class ProductRepository : GenericRepository<Product>, IProductRepository {
        private readonly ApplicationDbContext _context;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context,
            IFileProvider fileProvider, IMapper mapper) : base(context) {
            _context = context;
            _fileProvider = fileProvider;
            _mapper = mapper;
        }
        public async Task<ReturnProductDto> GetAllAsync(ProductParams productParams) {
            var result_ = new ReturnProductDto();
            var query = await _context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .ToListAsync();

           
            if (!string.IsNullOrEmpty(productParams.Search))
                query = query.Where(x => x.Name.ToLower().Contains(productParams.Search)).ToList();

           
            if (productParams.CategoryId.HasValue)
                query = query.Where(x => x.CategoryId == productParams.CategoryId.Value).ToList();

           
            if (!string.IsNullOrEmpty(productParams.Sort)) {
                query = productParams.Sort switch {
                    "PriceAsc" => query.OrderBy(x => x.Price).ToList(),
                    "PriceDesc" => query.OrderByDescending(x => x.Price).ToList(),
                    _ => query.OrderBy(x => x.Name).ToList(),
                };
            }
            result_.TotalItems = query.Count;
                 
            query = query.Skip((productParams.PageSize) * (productParams.PageNumber - 1)).Take(productParams.PageSize).ToList();

            result_.ProductDtos = _mapper.Map<List<ProductDto>>(query);
            return result_;
        }
        public async Task<bool> AddAsync(CreateProductDto dto) {
            if (!string.IsNullOrEmpty(dto.Image)){   
                var product = _mapper.Map<Product>(dto);

               
                product.ProductPicture = dto.Image;

              
                await _context.Products.AddAsync(product);

              
                await _context.SaveChangesAsync();

                return true;
            }

            return false;

        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto) {
            var currentProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (currentProduct is not null) {
                if (!string.IsNullOrEmpty(dto.Image)) {
                   
                    currentProduct.ProductPicture = dto.Image;

                   
                    _mapper.Map(dto, currentProduct);


                    _context.Products.Update(currentProduct);
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            return false;
        }
        public async Task<bool> DeleteAsyncWithPicture(int id) {
            var currentProduct = await _context.Products.FindAsync(id);
            if (currentProduct is not null) {
              
                if (!string.IsNullOrEmpty(currentProduct.ProductPicture)) {
                   
                    var picInfo = _fileProvider.GetFileInfo(currentProduct.ProductPicture);
                    var rootPath = picInfo.PhysicalPath;
                    System.IO.File.Delete(rootPath);
                }

               
                _context.Products.Remove(currentProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}
