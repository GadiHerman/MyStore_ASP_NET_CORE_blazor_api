using Microsoft.AspNetCore.Components;
using MyStoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStoreWEB.Pages
{
    public class ProductListBase : ComponentBase
    {
        public List<Product> Products { get; set; }

        protected override Task OnInitializedAsync()
        {
            LoadProducts();
            return base.OnInitializedAsync();
        }

        private void LoadProducts()
        {
            Product p1 = new Product()
            {
                ProductID = 1,
                ProductName = "Car",
                ProductDescription = "Very Good car",
                ProductPrice = 150000,
                ProductShippingOunces = 122,
                ProductTypeName = "Transport",
                ImagePath = "images/Car.png"

            };
            Product p2 = new Product()
            {
                ProductID = 2,
                ProductName = "Boat",
                ProductDescription = "Very Good Boat",
                ProductPrice = 450000,
                ProductShippingOunces = 15000,
                ProductTypeName = "Transport",
                ImagePath = "images/Boat.png"
            };
            Product p3 = new Product()
            {
                ProductID = 3,
                ProductName = "Plane",
                ProductDescription = "Very Good plane",
                ProductPrice = 10000000,
                ProductShippingOunces = 50000,
                ProductTypeName = "Transport",
                ImagePath = "images/Plane.jpg"
            };
            Product p4 = new Product()
            {
                ProductID = 4,
                ProductName = "Motorcycle",
                ProductDescription = "Very Good motorcycle",
                ProductPrice = 90000,
                ProductShippingOunces = 85,
                ProductTypeName = "Transport",
                ImagePath = "images/Motorcycle.png"
            };
            Products = new List<Product> { p1, p2, p3, p4 };

        }
    }
}
