using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyStoreModels
{
    public class Order
    {
        private int m_OrderID;
        private DateTime m_OrderDateTime;
        private Decimal m_Tax;
        private Decimal m_Shipping;
        private List<OrderItem> m_OrderItems;

        public int OrderID
        {
            get
            {
                return m_OrderID;
            }
            set
            {
                m_OrderID = value;
            }
        }
        public DateTime OrderDateTime
        {
            get
            {
                return m_OrderDateTime;
            }
            set
            {
                m_OrderDateTime = value;
            }
        }
        public Decimal Tax
        {
            get
            {
                return m_Tax;
            }
            set
            {
                m_Tax = value;
            }
        }
        public Decimal Shipping
        {
            get
            {
                return m_Shipping;
            }
            set
            {
                m_Shipping = value;
            }
        }
        public List<OrderItem> OrderItems
        {
            get
            {
                return m_OrderItems;
            }
        }


        public Order()
        {
            this.m_OrderDateTime = DateTime.Now;
            this.m_Tax = 0;
            this.m_Shipping = 0;
            this.m_OrderItems = new List<OrderItem>();
        }
    }
}