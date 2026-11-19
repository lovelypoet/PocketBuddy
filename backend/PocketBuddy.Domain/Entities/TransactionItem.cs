using System;
using System.Collections.Generic;
using System.Text;

namespace PocketBuddy.Domain.Entities
{
    public class TransactionItem
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; } // mã giao dịch mà mục giao dịch này thuộc về
        public string ItemName { get; set; }
        public decimal Quantity { get; set; } // Quantity : số lượng
        public decimal UnitPrice { get; set; } // UnitPrice : giá đơn vị sản phẩm   

        public decimal LinePortal { get; set; } // LinePortal : tổng giá trị của dòng sản phẩm
        public Transaction Transaction { get; set; }



    }
}
