using BaseModel;
using System.Collections.Generic;
using System.Linq;

namespace AndersonPayModel
{
    public class TypeOfService : Base
    {
        //public decimal Availed => Services.Sum(a => a.Quantity);

        public int TypeOfServiceId { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }
        public List<Service> Services { get; set; }
    }
}
