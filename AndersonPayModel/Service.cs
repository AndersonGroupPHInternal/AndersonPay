namespace AndersonPayModel
{
    public class Service
    {
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Subtotal => Quantity * Rate;

        public int InvoiceId { get; set; }
        public int ServiceId { get; set; }
        public int TypeOfServiceId { get; set; }

        public string Comments { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual TypeOfService typeofservices { get; set; }
    }
}
