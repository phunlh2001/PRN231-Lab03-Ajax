using BusinessObjects.Data;
using DataAccess;
using Reposiories.Interface;
using System.Collections.Generic;

namespace Reposiories.Impl
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(int id) => ProductDao.GetInstance.Delete(id);

        public Product GetByName(string name) => ProductDao.GetInstance.GetByName(name);

        public IEnumerable<Product> GetList() => ProductDao.GetInstance.GetAll();

        public Product GetProduct(int id) => ProductDao.GetInstance.GetById(id);

        public void InsertProduct(Product prod) => ProductDao.GetInstance.Insert(prod);

        public void UpdateProduct(Product prod) => ProductDao.GetInstance.Update(prod);
    }
}
