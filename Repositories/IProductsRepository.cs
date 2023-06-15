using W4Assessment.Model;

namespace W4Assessment.Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> Get();       
        Task<Products> Get(int ProductId);     
        Task<Products> Create(Products products);    
        Task Update(Products products);
        Task Delete(int ProductId);
    }
}
