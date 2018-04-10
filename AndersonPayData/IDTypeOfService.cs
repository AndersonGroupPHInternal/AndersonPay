using AndersonPayEntity;
using BaseData;
using System.Collections.Generic;

namespace AndersonPayData
{
    public interface IDTypeOfService : IDBase
    {
        List<ETypeOfService> Read();
    }
}
