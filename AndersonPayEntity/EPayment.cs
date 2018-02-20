using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("Payment")]
    public class EPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        //[ForeignKey("Client")]
        public int ClientId { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? DateOfPayment { get; set; }
        public decimal AmountReceived { get; set; }
        public decimal Payments { get; set; }
        public decimal Discount { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
    }
}