using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public int? ParentProductCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<ProductCategory> InverseParentProductCategory { get; } = new List<ProductCategory>();

    public virtual ProductCategory? ParentProductCategory { get; set; }
}
