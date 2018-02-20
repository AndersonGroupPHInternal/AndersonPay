using BaseModel;
using System;
using System.Collections.Generic;

namespace AndersonPayModel
{
    public class Payment : Base
    {
        public int PaymentId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateOfPayment { get; set; }
        public decimal AmountReceived { get; set; }
        public decimal Payments { get; set; }
        public decimal Discount { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
    }
}