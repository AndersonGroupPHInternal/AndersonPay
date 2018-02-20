using BaseModel;


namespace AndersonPayModel
{
    public class Client : Base
    {
        public int ClientId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string RegistrationNo { get; set; }
        public string EmailAddress { get; set; }

        public int CompanyId { get; set; }
        
        public int EmailId { get; set; }
        public int WithHoldingTax { get; set; }

        public int TaxTypeId { get; set; }
        public TaxType TaxType { get; set; }

        //public string TaxTypes { get; set; }

        public int CurrencyCodeId { get; set; }
        public CurrencyCode CurrencyCode { get; set; }

        //public string CurrencyCodes { get; set; }
    }
}
