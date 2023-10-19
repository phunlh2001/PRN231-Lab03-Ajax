using BusinessObjects.Data;
using System.Collections.Generic;

namespace Reposiories.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
    }
}
