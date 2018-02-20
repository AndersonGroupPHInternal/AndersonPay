using AndersonPayFunction;
using System.Web.Mvc;
using AndersonPayModel;
namespace AndersonPay.Controllers
{
    public class TaxTypeController : Controller
    {
        // GET: TaxType

        private IFTaxType _iFTaxType;
        public TaxTypeController()
        {
            _iFTaxType = new FTaxType();
        }

        // Read list of TaxType

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFTaxType.Read());
        }

        #endregion
    }
}