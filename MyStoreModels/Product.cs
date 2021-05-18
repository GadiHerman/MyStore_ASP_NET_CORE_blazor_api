using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;



namespace MyStoreModels
{
    public class Product
    {
        private int m_ProductID;
        private string m_ProductName;
        private Decimal m_ProductPrice;
        private string m_ProductDescription;
        private string m_ProductTypeName;
        private int m_ProductShippingOunces;
        private string m_imagePath;
        public int ProductID
        {
            get
            {
                return m_ProductID;
            }
            set
            {
                m_ProductID = value;
            }
        }

        [Required]
        [MinLength(2)]
        public string ProductName
        {
            get
            {
                return m_ProductName;
            }
            set
            {
                m_ProductName = value;
            }
        }

        [Required]
        public Decimal ProductPrice
        {
            get
            {
                return m_ProductPrice;
            }
            set
            {
                m_ProductPrice = value;
            }
        }
        public string ProductDescription
        {
            get
            {
                return m_ProductDescription;
            }
            set
            {
                m_ProductDescription = value;
            }
        }
        public string ProductTypeName
        {
            get
            {
                return m_ProductTypeName;
            }
            set
            {
                m_ProductTypeName = value;
            }
        }
        public int ProductShippingOunces
        {
            get
            {
                return m_ProductShippingOunces;
            }
            set
            {
                m_ProductShippingOunces = value;
            }
        }
        public Product()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string ImagePath
        {
            get
            {
                return m_imagePath;
            }
            set
            {
                m_imagePath = value;
            }
        }


        public Product(int ProductID, string ProductName, Decimal ProductPrice, string ProductDescription, string ProductTypeName, int ProductShippingOunces)
        {
            this.m_ProductID = ProductID;
            this.m_ProductName = ProductName;
            this.m_ProductPrice = ProductPrice;
            this.m_ProductDescription = ProductDescription;
            this.m_ProductTypeName = ProductTypeName;
            this.m_ProductShippingOunces = ProductShippingOunces;
            this.ImagePath = "";
        }

        public Product(int ProductID, string ProductName, Decimal ProductPrice, string ProductDescription, string ProductTypeName, int ProductShippingOunces,string ImagePath)
        {
            this.m_ProductID = ProductID;
            this.m_ProductName = ProductName;
            this.m_ProductPrice = ProductPrice;
            this.m_ProductDescription = ProductDescription;
            this.m_ProductTypeName = ProductTypeName;
            this.m_ProductShippingOunces = ProductShippingOunces;
            this.m_imagePath = ImagePath;
        }

    }
}