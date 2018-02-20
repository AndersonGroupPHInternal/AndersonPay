using AndersonPayEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AndersonPayContext
{
    public class DBInitializer : CreateDatabaseIfNotExists<Context>
    {
        public DBInitializer()
        {

        }

        protected override void Seed(Context context)
        {
            
           List<ECurrencyCode> currencyCodes = new List<ECurrencyCode>()
            {
                new ECurrencyCode
                {
                    CurrencyCodes = "USD"
                },

                new ECurrencyCode
                {
                    CurrencyCodes = "GBP"
                },

                new ECurrencyCode
                {
                    CurrencyCodes = "PHP"
                }
            };
                context.CurrencyCode.AddRange(currencyCodes);
                context.SaveChanges();

            List<ETaxType> taxTypes = new List<ETaxType>()
            {
                new ETaxType
                {
                    TaxTypes = "VAT"
                },

                new ETaxType
                {
                    TaxTypes = "NON-VAT"
                },

                new ETaxType
                {
                    TaxTypes = "ZERO RATED"
                }
            };
                context.TaxType.AddRange(taxTypes);
                context.SaveChanges();

            List<ECompanyAddress> companyAddress = new List<ECompanyAddress>()
            {
                new ECompanyAddress
                {
                    CompanyBranch = "WYNSUM",
                    Address = "11/F Wynsum Corporate Plaza, #22 F. Ortigas Jr. Road Ortigas Center,Pasig City Philippines ",
                    SINo = "WNSM-",
                    TIN = "0001"
                },

                new ECompanyAddress
                {
                    CompanyBranch = "CYBERGATE",
                    Address = "20/F Robinsons Cybergate Tower 3, Pioneer Street, Mandaluyong City, Pioneer St, Mandaluyong, Metro Manila",
                    SINo = "CG3-",
                    TIN = "0002"
                },

                new ECompanyAddress
                {
                    CompanyBranch = "ECOTOWER",
                    Address = "Ecotower Building Unit 1504, 32nd Street corner 9th avenue Bonifacio Global City, Taguig City Philippines",
                    SINo = "ECT-",
                    TIN = "0003"
                }
            };
                context.CompanyAddress.AddRange(companyAddress);
                context.SaveChanges();

        }
    }
}
