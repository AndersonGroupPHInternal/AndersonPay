using AndersonPayData;
using AndersonPayEntity;
using AndersonPayModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonPayFunction
{
    public class FTypeOfService : IFTypeOfService
    {
        private IDTypeOfService _iDTypeOfService;

        public FTypeOfService(IDTypeOfService iDTypeOfService)
        {
            _iDTypeOfService = iDTypeOfService;
        }

        public FTypeOfService()
        {
            _iDTypeOfService = new DTypeOfService();
        }

        #region CREATE
        public TypeOfService Create(TypeOfService typeOfService)
        {
            ETypeOfService eTypeOfService = ETypeOfService(typeOfService);
            eTypeOfService = _iDTypeOfService.Create(eTypeOfService);
            return TypeOfService(eTypeOfService);
        }
        #endregion

        #region READ
        public TypeOfService Read(int typeOfServiceId)
        {
            ETypeOfService eTypeOfService = _iDTypeOfService.Read<ETypeOfService>(a => a.TypeOfServiceId == typeOfServiceId);
            return TypeOfService(eTypeOfService);
        }

        public List<TypeOfService> Read()
        {
            List<ETypeOfService> eTypeOfService = _iDTypeOfService.Read();
            return TypeOfService(eTypeOfService);
        }
        #endregion

        #region UPDATE
        public TypeOfService Update(TypeOfService typeOfService)
        {
            var eTypeOfService = _iDTypeOfService.Update(ETypeOfService(typeOfService));
            return (TypeOfService(eTypeOfService));
        }
        #endregion

        #region DELETE
        public void Delete(TypeOfService typeOfService)
        {
            _iDTypeOfService.Delete(ETypeOfService(typeOfService));
        }
        #endregion

        #region OTHER FUNCTION
        private ETypeOfService ETypeOfService(TypeOfService typeOfService)
        {
            ETypeOfService returnETypeOfService = new ETypeOfService
            {
                TypeOfServiceId = typeOfService.TypeOfServiceId,
                Description = typeOfService.Description,
                Name = typeOfService.Name
            };

            return returnETypeOfService;
        }

        private TypeOfService TypeOfService(ETypeOfService eTypeOfService)
        {
            TypeOfService returnTypeOfService = new TypeOfService
            {
                TypeOfServiceId = eTypeOfService.TypeOfServiceId,
                Description = eTypeOfService.Description,
                Name = eTypeOfService.Name
            };
            return returnTypeOfService;
        }

        private List<TypeOfService> TypeOfService(List<ETypeOfService> eTypeOfService)
        {
            var returnTypeOfService = eTypeOfService.Select(a => new TypeOfService
            {
                TypeOfServiceId = a.TypeOfServiceId,
                Description = a.Description,
                Name = a.Name,

                Services = a.Services?.Select(b =>
                    new Service
                    {
                        Quantity = b.Quantity,
                        Rate = b.Rate,

                        InvoiceId = b.InvoiceId,
                        ServiceId = b.ServiceId,
                        TypeOfServiceId = b.TypeOfServiceId,

                        Comments = b.Comments,
                    }).ToList()
            });

            return returnTypeOfService.ToList();
        }


        #endregion
    }
}
