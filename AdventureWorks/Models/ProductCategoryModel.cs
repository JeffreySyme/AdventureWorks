﻿using System.Diagnostics.CodeAnalysis;

namespace AdventureWorks.Models;

[ExcludeFromCodeCoverage]
public class ProductCategoryModel
{
    public int ProductCategoryId { get; set; }
    public int? ParentProductCategoryId { get; set; }
    public string Name { get; set; }
    public DateTime ModifiedDate { get; set; }
}