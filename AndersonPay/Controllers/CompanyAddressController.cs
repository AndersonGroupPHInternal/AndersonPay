using AndersonPayFunction;
using System.Web.Mvc;
using AndersonPayModel;
namespace AndersonPay.Controllers
{
    public class CompanyAddressController : Controller
    {
        // GET: CompanyAddress

        private IFCompanyAddress _iFCompanyAddress;
        public CompanyAddressController()
        {
            _iFCompanyAddress = new FCompanyAddress();
        }

        // Read list of CompanyAddress

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFCompanyAddress.Read());
        }

        #endregion
    }
}