using System.Collections.Generic;
using System.Linq;
using AndersonPayData;
using AndersonPayModel;
using AndersonPayEntity;

namespace AndersonPayFunction
{
    public class FCurrencyCode : IFCurrencyCode
    {
        private IDCurrencyCode _iDCurrencyCode;

        public FCurrencyCode(IDCurrencyCode iDCurrencyCode)
        {
            _iDCurrencyCode = iDCurrencyCode;
        }

        public FCurrencyCode()
        {
            _iDCurrencyCode = new DCurrencyCode();
        }

        #region CREATE
        public CurrencyCode Create(CurrencyCode currencyCode)
        {
            ECurrencyCode eCurrencyCode = ECurrencyCode(currencyCode);
            eCurrencyCode = _iDCurrencyCode.Create(eCurrencyCode);
            return CurrencyCode(eCurrencyCode);
        }
        #endregion

        #region READ
        public CurrencyCode Read(int currencyId)
        {
            ECurrencyCode eCurrencyCode = _iDCurrencyCode.Read<ECurrencyCode>(a => a.CurrencyId == currencyId);
            return CurrencyCode(eCurrencyCode);
        }

        public List<CurrencyCode> Read()
        {
            List<ECurrencyCode> eCurrencyCode = _iDCurrencyCode.List<ECurrencyCode>(a => true);
            return CurrencyCode(eCurrencyCode);
        }

        public List<CurrencyCode> ReadCurrencyId(int currencyId)
        {
            List<ECurrencyCode> eCurrencyCode = _iDCurrencyCode.List<ECurrencyCode>(a => a.CurrencyId == currencyId);
            return CurrencyCode(eCurrencyCode);
        }
        #endregion

        #region UPDATE
        public CurrencyCode Update(CurrencyCode currencyCode)
        {
            var eCurrencyCode = _iDCurrencyCode.Update(ECurrencyCode(currencyCode));
            return (CurrencyCode(eCurrencyCode));
        }
        #endregion

        #region DELETE
        public void Delete(int currencyId)
        {
            _iDCurrencyCode.Delete<ECurrencyCode>(a => a.CurrencyId == currencyId);
        }
        #endregion

        #region OTHER FUNCTION
        private ECurrencyCode ECurrencyCode(CurrencyCode currencyCode)
        {
            ECurrencyCode returnECurrencyCode = new ECurrencyCode
            {
                CurrencyId = currencyCode.CurrencyId,
                CurrencyCodes = currencyCode.CurrencyCodes
            };
            return returnECurrencyCode;
        }

        private CurrencyCode CurrencyCode(ECurrencyCode eCurrencyCode)
        {
            CurrencyCode returnCurrencyCode = new CurrencyCode
            {
                CurrencyId = eCurrencyCode.CurrencyId,
                CurrencyCodes = eCurrencyCode.CurrencyCodes
            };
            return returnCurrencyCode;
        }

        private List<CurrencyCode> CurrencyCode(List<ECurrencyCode> eCurrencyCode)
        {
            var returnCurrencyCode = eCurrencyCode.Select(a => new CurrencyCode
            {
                CurrencyId = a.CurrencyId,
                CurrencyCodes = a.CurrencyCodes

            });
            return returnCurrencyCode.ToList();
        }

        #endregion
    }
}
