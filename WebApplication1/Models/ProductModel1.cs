using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public partial class ProductModel1
{
    [Key]

    public int ProductModelId { get; set; }

    public string Name { get; set; } = null!;

    public string? CatalogDescription { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<ProductModelProductDescription> ProductModelProductDescriptions { get; } = new List<ProductModelProductDescription>();

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
