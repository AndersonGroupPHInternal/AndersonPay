using System.Collections.Generic;
using AndersonPayModel;

namespace AndersonPayFunction
{
    public interface IFCompanyAddress
    {
        #region CREATE
        CompanyAddress Create(CompanyAddress companyAddress);
        #endregion

        #region READ
        CompanyAddress Read(int companyAddressId);
        List<CompanyAddress> Read();
        #endregion

        #region Update
        CompanyAddress Update(CompanyAddress companyAddress);
        #endregion

        #region DELETE
        void Delete(int companyAddressId);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
