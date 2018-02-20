using System.Collections.Generic;
using AndersonPayModel;
using AndersonPayEntity;
namespace AndersonPayFunction
{
    public interface IFService
    {
        #region CREATE
        Service Create(int invoiceId, Service service);
        #endregion

        #region READ
        List<Service> Read();
        List<Service> Read(int invoiceId);
        #endregion

        #region Update
        Service Update(Service Service);
        #endregion

        #region DELETE
        void Delete(int invoiceId);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}