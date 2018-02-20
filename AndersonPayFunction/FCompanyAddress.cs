using System;
using System.Collections.Generic;
using System.Linq;
using AndersonPayData;
using AndersonPayModel;
using AndersonPayEntity;

namespace AndersonPayFunction   
{
  public class FCompanyAddress : IFCompanyAddress
    {
        private IDCompanyAddress _iDCompanyAddress;

        public FCompanyAddress(IDCompanyAddress iDCompanyAddress)
        {
            _iDCompanyAddress = iDCompanyAddress;
        }

        public FCompanyAddress()
        {
            _iDCompanyAddress = new DCompanyAddress();
        }

        #region CREATE
        public CompanyAddress Create(CompanyAddress companyAddress)
        {
            ECompanyAddress eCompanyAddress = ECompanyAddress(companyAddress);
            eCompanyAddress = _iDCompanyAddress.Create(eCompanyAddress);
            return CompanyAddress(eCompanyAddress);
        }
        #endregion

        #region READ
        public CompanyAddress Read(int companyAddressId)
        {
            ECompanyAddress eCompanyAddress = _iDCompanyAddress.Read<ECompanyAddress>(a => a.CompanyAddressId == companyAddressId);
            return CompanyAddress(eCompanyAddress);
        }

        public List<CompanyAddress> Read()
        {
            List<ECompanyAddress> eCompanyAddress = _iDCompanyAddress.List<ECompanyAddress>(a => true);
            return CompanyAddress(eCompanyAddress);
        }
        #endregion

        #region UPDATE
        public CompanyAddress Update(CompanyAddress companyAddress)
        {
            var eCompanyAddress = _iDCompanyAddress.Update(ECompanyAddress(companyAddress));
            return (CompanyAddress(eCompanyAddress));
        }
        #endregion

        #region DELETE
        public void Delete(int companyAddressId)
        {
            _iDCompanyAddress.Delete<ECompanyAddress>(a => a.CompanyAddressId == companyAddressId);
        }
        #endregion

        #region OTHER FUNCTION
        private ECompanyAddress ECompanyAddress(CompanyAddress companyAddress)
        {
            ECompanyAddress returnECompanyAddress = new ECompanyAddress
            {
               CompanyAddressId = companyAddress.CompanyAddressId,
               CompanyBranch = companyAddress.CompanyBranch,
               Address = companyAddress.Address,
               SINo = companyAddress.SINo,
               TIN = companyAddress.TIN
            };
            return returnECompanyAddress;
        }

        private CompanyAddress CompanyAddress(ECompanyAddress eCompanyAddress)
        {
            CompanyAddress returnCompanyAddress = new CompanyAddress
            {
                CompanyAddressId = eCompanyAddress.CompanyAddressId,
                CompanyBranch = eCompanyAddress.CompanyBranch,
                Address = eCompanyAddress.Address,
                SINo = eCompanyAddress.SINo,
                TIN = eCompanyAddress.TIN
            };
            return returnCompanyAddress;
        }

        private List<CompanyAddress> CompanyAddress(List<ECompanyAddress> eCompanyAddress)
        {
            var returnCompanyAddress = eCompanyAddress.Select(a => new CompanyAddress
            {
                CompanyAddressId = a.CompanyAddressId,
                CompanyBranch = a.CompanyBranch,
                Address = a.Address,
                SINo = a.SINo,
                TIN = a.TIN

            });
            return returnCompanyAddress.ToList();
        }

        #endregion
    }
}
