using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngine.Models;

public class Resultat
{
    public int StatusCode { get; }

    public Resultat(int statusCode)
    {
        StatusCode = statusCode;
    }
}

public class Resultat<T> : Resultat
{
    public T Donnees { get; }

    public Resultat(T donnees, int statusCode) : base(statusCode)
    {
        Donnees = donnees;
    }
}

