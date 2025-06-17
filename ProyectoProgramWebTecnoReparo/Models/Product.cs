using System;
using System.Collections.Generic;

namespace ProyectoProgramWebTecnoReparo.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public string? Description { get; set; }

    public int? Stock { get; set; }

    public bool? Available { get; set; }

    public string? Image { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? _Category { get; set; }
}
