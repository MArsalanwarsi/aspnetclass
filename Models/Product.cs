using System;
using System.Collections.Generic;

namespace Complte_website.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Img { get; set; }

    public string? Price { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
