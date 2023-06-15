using Microsoft.EntityFrameworkCore;
using W4Assessment.Data;
using W4Assessment.Model;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace W4Assessment.Repositories
{
    public class ProductsRepository:IProductsRepository
    {
        private readonly AppDbContext _context;

        public ProductsRepository(AppDbContext context)

        {
            _context = context;
        }

        public async Task<Products> Create(Products products)

        {
            _context.Products.Add(products);

            await _context.SaveChangesAsync();

            return products;
        }

        public async Task Delete(int ProductId)

        {
            var productDelete = await _context.Products.FindAsync(ProductId);

            _context.Products.Remove(productDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Products>> Get()

        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> Get(int ProductId)

        {
            return await _context.Products.FindAsync(ProductId);
        }

        public async Task Update(Products products)

        {
            _context.Entry(products).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

    }
}

