
using Ecom.Core.Dtos;
using Ecom.Core.Entities;
using Ecom.Core.Sharing;


namespace Ecom.Core.Interfaces {
    public interface IProductRepository : IGenericRepository<Product> {
        Task<ReturnProductDto> GetAllAsync(ProductParams productParams);
        Task<bool> AddAsync(CreateProductDto dto);
        Task<bool> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteAsyncWithPicture(int id);
    }
}
