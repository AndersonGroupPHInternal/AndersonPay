using BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonPayEntity
{
    [Table("Invoice")]
    public class EInvoice : EBase
    {
        /* 
         TO DO:
         Use identity as primary key
         Removed error messages
         Removed properties that are irelevant
         Use Capital Letters on non private properties
         Remove Display annotation
         Remove [HiddenInput(DisplayValue = true)] 
         Remove multipeServiceJSON
             */

        public decimal AmountDue { get; set; }
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        public decimal Tax { get; set; }

        public int CurrencyId { get; set; }
        public ECurrencyCode CurrencyCode { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public EClient Client { get; set; }
        public virtual ICollection<EService> Services { get; set; }

        public string Name { get; set; }

        public int TaxTypeId { get; set; }
        public ETaxType TaxType { get; set; }

        public decimal Subtotal { get; set; }
        public string SINo { get; set; }
        public string TIN { get; set; }
        public string Address { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? DueDate { get; set; }
        public int NumberOfDelays { get; set; }
        public decimal Interest { get; set; }
    }
}
