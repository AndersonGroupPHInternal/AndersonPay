using System;
using System.Collections.Generic;
using System.Linq;
using AndersonPayData;
using AndersonPayModel;
using AndersonPayEntity;

namespace AndersonPayFunction   
{
  public class FClient : IFClient
    {
        private IDClient _iDClient;

        public FClient(IDClient iDClient)
        {
            _iDClient = iDClient;
        }

        public FClient()
        {
            _iDClient = new DClient();
        }

        #region CREATE
        public Client Create(Client client)
        {
            EClient eClient = EClient(client);
            eClient = _iDClient.Create(eClient);
            return Client(eClient);
        }
        #endregion

        #region READ
        public Client Read(int clientId)
        {
            EClient eClient = _iDClient.Read<EClient>(a => a.ClientId == clientId);
            return Client(eClient);
        }

        public List<Client> Read()
        {
            List<EClient> eClient = _iDClient.List<EClient>(a => true);
            return Client(eClient);
        }

        public List<Client> ReadId(int clientId)
        {
            List<EClient> eClient = _iDClient.List<EClient>(a => a.ClientId == clientId);
            return Client(eClient);
        }
        #endregion

        #region UPDATE
        public Client Update(Client client)
        {
            var eClient = _iDClient.Update(EClient(client));
            return (Client (eClient));
        }
        #endregion

        #region DELETE
        public void Delete(Client client)
        {
            _iDClient.Delete(EClient(client));
        }
        #endregion

        #region OTHER FUNCTION
        private EClient EClient(Client client)
        {
            EClient returnEClient = new EClient 
            {
                Code = client.Code,
                ClientId = client.ClientId,
                Name = client.Name,
                Address = client.Address,
                CompanyId = client.CompanyId,
                RegistrationNo = client.RegistrationNo,
                TaxTypeId = client.TaxTypeId,
                CurrencyCodeId = client.CurrencyCodeId,
                WithHoldingTax = client.WithHoldingTax,
                //TaxTypes = client.TaxTypes,
                //CurrencyCodes = client.CurrencyCodes
 
            };
            return returnEClient;
        }

        private Client Client(EClient eClient)
        {
            Client returnClient = new Client

            {
                Code = eClient.Code,
                ClientId = eClient.ClientId,
                Name = eClient.Name,
                Address = eClient.Address,
                CompanyId = eClient.CompanyId,
                RegistrationNo = eClient.RegistrationNo,
                TaxTypeId = eClient.TaxTypeId,
                CurrencyCodeId = eClient.CurrencyCodeId,
                WithHoldingTax = eClient.WithHoldingTax,
                //TaxTypes = eClient.TaxTypes,
                //CurrencyCodes = eClient.CurrencyCodes

            };
            return returnClient;
        }

        private List<Client> Client(List<EClient> eClient)
        {
            var returnClient = eClient.Select(a => new Client

            {
                Code = a.Code,
                ClientId = a.ClientId,
                Name = a.Name,
                Address = a.Address,
                CompanyId = a.CompanyId,
                RegistrationNo = a.RegistrationNo,
                TaxTypeId = a.TaxTypeId,
                CurrencyCodeId = a.CurrencyCodeId,
                WithHoldingTax = a.WithHoldingTax,
                //TaxTypes = a.TaxTypes,
                //CurrencyCodes = a.CurrencyCodes

            });

            return returnClient.ToList();
        }

        #endregion
    }
}
