using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngine.Domaine.Entites;

public class Post: Entite
{
    public int CategoryId { set; get; }
    public string Title { set; get; } = null!;
    public DateTime PublicationDate { set; get; }
    public string Content { set; get; } = null!;
}
