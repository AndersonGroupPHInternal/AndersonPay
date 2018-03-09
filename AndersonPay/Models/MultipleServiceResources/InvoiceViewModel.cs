
using AndersonPayEntity;
using System.Collections.Generic;

namespace AndersonPay.Models
{
    public class InvoiceViewModel
    {
        public int invoiceId { get; set; }
        public string CompanyName { get; set; }
        public bool Multiple { get; set; }
        public List<CheckBoxViewModel> Services { get; set; }
        public List<ETypeOfService> service { get; set; }
    }
}