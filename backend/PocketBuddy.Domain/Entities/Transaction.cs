using System;
using System.Collections.Generic;
using System.Text;

namespace PocketBuddy.Domain.Entities
{
    // Đây gọi là Navigation Property(thuộc tính điều hướng). Nó giúp Entity Framework Core hiểu mối quan hệ giữa hai Entity.
    // Nếu một Transaction có 5 TransactionItem thì quan hệ là gì? One-to-Many (Một-nhiều). Một Transaction có thể có nhiều TransactionItem, nhưng một TransactionItem chỉ thuộc về một Transaction.
    public class Transaction
    {
        public Guid Id { get; set; }

        // Merchant :  người bán hàng, cửa hàng 
        public string? MerchantName { get; set; }

        public DateOnly TransactionDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string? Note { get; set; } // Note : ghi chú  

        public DateTimeOffset CreatedAt { get; set; }
        public ICollection<TransactionItem> Items { get; set; } // Items là 1 collection (tập hợp) chứa nhiều đối tượng TransactionItem


    }
}
