using System.Collections.Generic;
using AndersonPayModel;

namespace AndersonPayFunction
{
    public interface IFCurrencyCode
    {
        #region CREATE
        CurrencyCode Create(CurrencyCode currencyCode);
        #endregion

        #region READ
        CurrencyCode Read(int currencyCodeId);
        List<CurrencyCode> Read();
        List<CurrencyCode> ReadCurrencyId(int currencyId);
        #endregion

        #region Update
        CurrencyCode Update(CurrencyCode currencyCode);
        #endregion

        #region DELETE
        void Delete(int currencyCodeId);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
