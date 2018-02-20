using AndersonPayFunction;
using System.Web.Mvc;
using AndersonPayModel;
namespace AndersonPay.Controllers
{
    public class CurrencyController : Controller
    {
        // GET: Currency

        private IFCurrencyCode _iFCurrencyCode;
        public CurrencyController()
        {
            _iFCurrencyCode = new FCurrencyCode();
        }

        // Read list of Currency

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFCurrencyCode.Read());
        }

        [HttpPost]
        public JsonResult ReadCurrencyId(int id)
        {
            return Json(_iFCurrencyCode.ReadCurrencyId(id));
        }
        #endregion
    }
}