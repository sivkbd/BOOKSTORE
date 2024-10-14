using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchaseCart
{
    class BOOKS
    {
        
            public Product Product { get; set; }
            public int Quantity { get; set; }

            public BOOKS(Product product, int quantity)
            {
                Product = product;
                Quantity = quantity;
            }
       
    }
}
