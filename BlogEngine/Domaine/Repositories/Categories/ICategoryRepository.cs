using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Domaine.Entites; 

namespace BlogEngine.Domaine.Repositories.Categories;

public interface ICategoryRepository: IRepository<Category>
{
    bool Verifier(string title);
}
