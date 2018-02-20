using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AndersonPayEntity
{
    [Table("Client")]
    public class EClient : EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }
        public int CompanyId { get; set; }  

        public string Address { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string RegistrationNo { get; set; }

        public int WithHoldingTax { get; set; }

        [ForeignKey("TaxType")]
        public int TaxTypeId { get; set; }
        public ETaxType TaxType { get; set; }

        //public string TaxTypes { get; set; }

        [ForeignKey("CurrencyCode")]
        public int CurrencyCodeId { get; set; }
        public ECurrencyCode CurrencyCode { get; set; }

        //public string CurrencyCodes { get; set; }
    }
}
