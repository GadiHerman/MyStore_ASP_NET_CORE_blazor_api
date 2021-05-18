using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MyStoreModels
{
    public class Customer
    {
        private int m_CustomerID;
        private string m_Name;
        private string m_Address;
        private string m_Email;
        private string m_CustomerPassword;
        private bool m_IsAdmin;
        private List<Order> m_OldOrders;
        private Order m_CurrentOrder;

        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
            }
        }
        public string CustomerPassword
        {
            get
            {
                return m_CustomerPassword;
            }
            set
            {
                m_CustomerPassword = value;
            }
        }
        public bool IsAdmin
        {
            get
            {
                return m_IsAdmin;
            }
            set
            {
                m_IsAdmin = value;
            }
        }
        public int CustomerID
        {
            get
            {
                return m_CustomerID;
            }
            set
            {
                m_CustomerID = value;
            }
        }
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public string Address
        {
            get
            {
                return m_Address;
            }
            set
            {
                m_Address = value;
            }
        }
        public List<Order> OldOrders
        {
            get
            {
                return m_OldOrders;
            }
        }
        public Order CurrentOrder
        {
            get
            {
                return m_CurrentOrder;
            }
            set
            {
                m_CurrentOrder = value;
            }
        }
        public Customer()
        {
            //
            // TODO: Add constructor logic here
            //
        }
       
        public override string ToString()
        {
            string s = "<br/>CustomerID: " + m_CustomerID.ToString();
            s += "<br/>Name: " + m_Name;
            s += "<br/>Address: " + m_Address;
            s += "<br/>Email: " + m_Email;
            s += "<br/>IsAdmin: " + m_IsAdmin.ToString();
            s += "<br/>CustomerPassword: " + m_CustomerPassword;
            s += "<div style='color:green'>";
            for (int i = 0; i < m_OldOrders.Count; i++)
            {
                Order Myord = m_OldOrders[i];
                s += "<br/>----------------------My OLD Orders-----------------------------";
                s = s + "<br/>Order Date: " + Myord.OrderDateTime;
                s = s + "<br/>OrderID: " + Myord.OrderID;
                s = s + "<br/>Shipping: " + Myord.Shipping;
                s = s + "<br/>Tax: " + Myord.Tax + "<br/>";
                s += "<br/>--------------------------------------------------------";
                for (int j = 0; j < m_OldOrders[i].OrderItems.Count; j++)
                {
                    OrderItem myo = m_OldOrders[i].OrderItems[j];
                    s += "<br/>---Items in my old Order---";
                    s += "<br/>Product Name: " + myo.ProductName;
                    s += "<br/>Quantity: " + myo.Quantity;
                    s += "<br/>Product Description: " + myo.ProductDescription;
                    s += "<br/>Product Price: " + myo.ProductPrice.ToString();
                    s += "<br/>Product ShippingOunces: " + myo.ProductShippingOunces.ToString();
                    s += "<br/>Product Type: " + myo.ProductTypeName;
                    s += "<br/>";
                }
            }
            s += "</ div >";
            if (m_CurrentOrder != null)
            {
                s += "<div style='color:red'>";
                s += "<br/>----------------------My CurrentOrder Orders-----------------------------";
                s = s + "<br/>Order Date: " + m_CurrentOrder.OrderDateTime;
                s = s + "<br/>OrderID: " + m_CurrentOrder.OrderID;
                s = s + "<br/>Shipping: " + m_CurrentOrder.Shipping;
                s = s + "<br/>Tax: " + m_CurrentOrder.Tax + "<br/>";
                s += "<br/>--------------------------------------------------------";
                for (int j = 0; j < m_CurrentOrder.OrderItems.Count; j++)
                {
                    OrderItem myo = m_CurrentOrder.OrderItems[j];
                    s += "<br/>---Items in my old Order---";
                    s += "<br/>Product Name: " + myo.ProductName;
                    s += "<br/>Quantity: " + myo.Quantity;
                    s += "<br/>Product Description: " + myo.ProductDescription;
                    s += "<br/>Product Price: " + myo.ProductPrice.ToString();
                    s += "<br/>Product ShippingOunces: " + myo.ProductShippingOunces.ToString();
                    s += "<br/>Product Type: " + myo.ProductTypeName;
                    s += "<br/>--------------------------";
                }
                s += "</ div >";
            }
            return s;
        }
    }
}