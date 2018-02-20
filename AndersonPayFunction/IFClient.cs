using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndersonPayModel;

namespace AndersonPayFunction
{
    public interface IFClient
    {
        #region CREATE
        Client Create(Client client);
        #endregion

        #region READ
        Client Read(int clientId);
        List<Client> Read();
        List<Client> ReadId(int clientId);
        #endregion

        #region Update
        Client Update(Client client);
        #endregion

        #region DELETE
        void Delete(Client Client);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }
}
