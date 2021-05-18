using System;
using System.Collections.Generic;
using System.Linq;



namespace MyStoreModels
{
    public class OrderItem : Product
    {
        private int m_Quantity;
        public int Quantity
        {
            get
            {
                return m_Quantity;
            }
            set
            {
                m_Quantity = value;
            }
        }
    

        public OrderItem()
        {
            //
            //
        }
        public OrderItem(int Quantity, int ProductID, string ProductName, Decimal ProductPrice, string ProductDescription, string ProductTypeName, int ProductShippingOunces)
            : base(ProductID, ProductName, ProductPrice, ProductDescription, ProductTypeName, ProductShippingOunces)
        {
            this.m_Quantity = Quantity;
        }
    }
}