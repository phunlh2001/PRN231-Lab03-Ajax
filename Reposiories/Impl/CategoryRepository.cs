using BusinessObjects.Data;
using DataAccess;
using Reposiories.Interface;
using System.Collections.Generic;

namespace Reposiories.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAll() => CategoryDao.GetInstance.GetAll();

        public Category GetById(int id) => CategoryDao.GetInstance.GetById(id);
    }
}
