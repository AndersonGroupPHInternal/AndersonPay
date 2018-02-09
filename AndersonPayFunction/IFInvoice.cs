using AndersonPayModel;
using System.Collections.Generic;

namespace AndersonPayFunction
{
    public interface IFInvoice
    {
        #region CREATE
        Invoice Create(Invoice invoice);
        #endregion

        #region READ
        Invoice Read(int invoiceId);
        List<Invoice> Read();
        List<Invoice> ReadClientId(int clientId);
        #endregion

        #region Update
        Invoice Update(Invoice invoice);
        #endregion

        #region DELETE
        void Delete(int InvoiceId);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}