﻿using System.Collections.Generic;
using System.Linq;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;

namespace SimplCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class OrderItemVm
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public int ShippedQuantity { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TaxPercent { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal Total => Quantity * ProductPrice;

        public decimal RowTotal => Total + TaxAmount - DiscountAmount;

        public string TaxAmountString => TaxAmount.ToString("C0");

        public string ProductPriceString => ProductPrice.ToString("C0");

        public string DiscountAmountString => DiscountAmount.ToString("C0");

        public string TotalString => Total.ToString("C0");

        public string RowTotalString => RowTotal.ToString("C0");

        public IEnumerable<ProductVariationOptionVm> VariationOptions { get; set; } =
            new List<ProductVariationOptionVm>();

        public static IEnumerable<ProductVariationOptionVm> GetVariationOption(Product variation)
        {
            if (variation == null)
            {
                return new List<ProductVariationOptionVm>();
            }

            return variation.OptionCombinations.Select(x => new ProductVariationOptionVm
            {
                OptionName = x.Option.Name,
                Value = x.Value
            });
        }
    }
}
