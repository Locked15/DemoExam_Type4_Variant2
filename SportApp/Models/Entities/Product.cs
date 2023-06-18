using System.Collections.Generic;
using System.Dynamic;

namespace SportApp.Models.Entities;

public partial class Product
{
    public int Id { get; set; }

    public int ManufacturerId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Image { get; set; }

    public int Amount { get; set; }

    public sbyte? Discount { get; set; }

    public decimal Cost { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public decimal ActualDiscount
    {
        get => Cost * ((Discount ?? 0M) / 100M);
    }

    public decimal FinalCost
    {
        get => Cost - ActualDiscount;
    }

    public dynamic BindProperties
    {
        get
        {
            // 'ExpandoObject' can't be initialized via Initializer. Only with manual setting.
            dynamic variablesToBind = new ExpandoObject();

            variablesToBind.Title = $"Название: {Title}.";
            variablesToBind.Description = Description != null ? $"Описание: {Description}." : string.Empty;
            variablesToBind.Image = $"/Assets/Products/{Image ?? string.Empty}";

            variablesToBind.Manufacturer = $"Производитель: {Manufacturer.Name}.";
            variablesToBind.Discount = Discount != null ? $"Скидка: {Discount}%." : string.Empty;
            variablesToBind.Cost = $"Стоимость: {Cost:0.00}Р.";

            return variablesToBind;
        }
    }
}
