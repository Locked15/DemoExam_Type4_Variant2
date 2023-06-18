using System;
using System.Collections.Generic;
using System.Linq;

namespace SportApp.Models.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int PointId { get; set; }

    public int StatusId { get; set; }

    public int TakeCode { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual PickupPoint Point { get; set; } = null!;

    public virtual OrderStatus Status { get; set; } = null!;

    public virtual User? User { get; set; }

    public decimal FinalDiscount
    {
        get => OrderProducts.Sum(op => op.Product.ActualDiscount * op.Count);
    }

    public decimal FinalCost
    {
        get => OrderProducts.Sum(op => op.Product.FinalCost * op.Count);
    }

    public bool TryToAddNewProduct(Product product)
    {
        var foundOne = OrderProducts.FirstOrDefault(op => op.ProductId == product.Id);
        if (foundOne != null)
        {
            foundOne.Count++;
            return true;
        }
        else
        {
            var newOrderProduct = new OrderProduct()
            {
                ProductId = product.Id,
                Product = product,
                Count = 1,
                Order = this,
                OrderId = Id
            };
            OrderProducts.Add(newOrderProduct);

            return false;
        }
    }

    public void SetProductCount(Product product, int newCount)
    {
        var foundOne = OrderProducts.FirstOrDefault(op => op.ProductId == product.Id);
        if (foundOne != null)
        {
            if (newCount <= 0)
                OrderProducts.Remove(foundOne);
            else
                foundOne.Count = newCount;
        }
    }

    public static Order GenerateNewOrderByUser(User? user)
    {
        var result = new Order()
        {
            TakeCode = new Random().Next(100, 1000),
            UserId = user?.Id,
            User = user,
            OrderDate = DateOnly.FromDateTime(DateTime.Now),
            StatusId = 1,
            PointId = -1
        };
        return result;
    }
}
