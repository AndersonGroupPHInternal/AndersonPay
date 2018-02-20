using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("Service")]
    public class EService
    {
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Subtotal { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }
        [ForeignKey("TypeOfService")]
        public int TypeOfServiceId { get; set; }
        
        public string Comments { get; set; }

        public virtual EInvoice Invoice { get; set; }
        public virtual ETypeOfService TypeOfService { get; set; }
    }
}
