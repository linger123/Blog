using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngine.Domaine.Entites;

public class Category: Entite
{
    public string Title { set; get; } = null!;
}
