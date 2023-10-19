using BusinessObjects.Data;
using System.Collections.Generic;

namespace Reposiories.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetList();
        Product GetProduct(int id);
        Product GetByName(string name);
        void InsertProduct(Product prod);
        void UpdateProduct(Product prod);
        void DeleteProduct(int id);
    }
}
