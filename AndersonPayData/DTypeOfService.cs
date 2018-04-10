using AndersonPayContext;
using AndersonPayEntity;
using BaseData;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AndersonPayData
{
    public class DTypeOfService : DBase, IDTypeOfService
    {

        public DTypeOfService() : base(new Context())
        {
        }

        public List<ETypeOfService> Read()
        {
            using (var context = new Context())
            {
                return context.Typeofservices
                    .Include(a => a.Services)
                    .ToList();
            }
        }

    }
}
