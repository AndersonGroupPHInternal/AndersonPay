using System;
using System.Collections.Generic;
using System.Linq;
using AndersonPayData;
using AndersonPayModel;
using AndersonPayEntity;

namespace AndersonPayFunction   
{
  public class FTaxType : IFTaxType
    {
        private IDTaxType _iDTaxType;

        public FTaxType(IDTaxType iDTaxType)
        {
            _iDTaxType = iDTaxType;
        }

        public FTaxType()
        {
            _iDTaxType = new DTaxType();
        }

        #region CREATE
        public TaxType Create(TaxType taxType)
        {
            ETaxType eTaxType = ETaxType(taxType);
            eTaxType = _iDTaxType.Create(eTaxType);
            return TaxType(eTaxType);
        }
        #endregion

        #region READ
        public TaxType Read(int taxTypeId)
        {
            ETaxType eTaxType = _iDTaxType.Read<ETaxType>(a => a.TaxTypeId == taxTypeId);
            return TaxType(eTaxType);
        }

        public List<TaxType> Read()
        {
            List<ETaxType> eTaxType = _iDTaxType.List<ETaxType>(a => true);
            return TaxType(eTaxType);
        }
        #endregion

        #region UPDATE
        public TaxType Update(TaxType taxType)
        {
            var eTaxType = _iDTaxType.Update(ETaxType(taxType));
            return (TaxType (eTaxType));
        }
        #endregion

        #region DELETE
        public void Delete(int taxTypeId)
        {
            _iDTaxType.Delete<ETaxType>(a => a.TaxTypeId == taxTypeId);
        }
        #endregion

        #region OTHER FUNCTION
        private ETaxType ETaxType(TaxType taxType)
        {
            ETaxType returnETaxType = new ETaxType 
            {
                TaxTypes = taxType.TaxTypes,
                TaxTypeId = taxType.TaxTypeId 
            };
            return returnETaxType;
        }

        private TaxType TaxType(ETaxType eTaxType)
        {
            TaxType returnTaxType = new TaxType
            {
                TaxTypes = eTaxType.TaxTypes,
                TaxTypeId = eTaxType.TaxTypeId
            };
            return returnTaxType;
        }

        private List<TaxType> TaxType(List<ETaxType> eTaxType)
        {
            var returnTaxType = eTaxType.Select(a => new TaxType
            {
                TaxTypes = a.TaxTypes,
                TaxTypeId = a.TaxTypeId

            });
            return returnTaxType.ToList();
        }

        #endregion
    }
}
