using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Microsoft.Identity.Client;

namespace Ecom.Infrastructure.Repositories {
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }


    }
}