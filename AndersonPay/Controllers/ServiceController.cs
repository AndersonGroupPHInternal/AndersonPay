using AndersonPayFunction;
using System.Web.Mvc;
using AndersonPayModel;
namespace AndersonPay.Controllers
{
    public class ServiceController : Controller
    {

        private IFService _iFService;
        public ServiceController()
        {
            _iFService = new FService();
        }
        #region Create
        #endregion

        #region Read
        [HttpPost]
        public JsonResult ReadId(int id)
        {
            return Json(_iFService.Read(id));
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFService.Read());
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}