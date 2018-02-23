using AndersonPayEntity;
using AndersonPayFunction;
using AndersonPayModel;
using Rotativa;
using Rotativa.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndersonPay.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        private IFClient _iFClient;
        private IFInvoice _iFInvoice;
        private IFService _iFService;
        private IFTypeOfService _iFTypeOfService;
        private IFCurrencyCode _iFCurrencyCode;
        public InvoiceController()
        {
            _iFClient = new FClient();
            _iFInvoice = new FInvoice();
            _iFService = new FService();
            _iFTypeOfService = new FTypeOfService();
            _iFCurrencyCode = new FCurrencyCode();
        }
        // Create new Invoice
        #region Create 
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Invoice());
        }

        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            invoice = _iFInvoice.Create(invoice);
            return RedirectToAction("Index");
            //, new { id = invoice.InvoiceId }
        }
        #endregion
        public ActionResult InvoiceSummary(int id)
        {
            var invoice = _iFInvoice.Read(id);
            var services = _iFService.Read(id);
            var client = _iFClient.Read(invoice.ClientId);
            var clients = _iFClient.ReadId(invoice.ClientId);
            var typeOfServices = _iFTypeOfService.Read();
            var currencies = _iFCurrencyCode.ReadCurrencyId(invoice.CurrencyId);
            //var taxType = _iFTaxType.Read(client.TaxTypeId); // uncomment the next two lines once the TaxType table is done
            //client.TaxType = taxType;
            invoice.Client = client;
            invoice.Clients = clients;
            invoice.Services = services;
            invoice.TypeOfServices = typeOfServices;
            invoice.Currencies = currencies;
            return PartialView(invoice);
        }

        public ActionResult InvoicePDF(int id)
        {
            var invoice = _iFInvoice.Read(id);
            var services = _iFService.Read(id);
            var client = _iFClient.Read(invoice.ClientId);
            var clients = _iFClient.ReadId(invoice.ClientId);
            var typeOfServices = _iFTypeOfService.Read();
            var currencies = _iFCurrencyCode.ReadCurrencyId(invoice.CurrencyId);
            invoice.Client = client;
            invoice.Clients = clients;
            invoice.Services = services;
            invoice.TypeOfServices = typeOfServices;
            invoice.Currencies = currencies;

            var viewAsPdf = new ViewAsPdf("~/Views/Invoice/InvoicePDF.cshtml", invoice)
            {
                FileName = client.Name + "-" + invoice.SINo + invoice.InvoiceId + ".pdf",
                PageSize = Size.Letter,
                PageOrientation = Orientation.Portrait,
                PageMargins = { Left = 20, Right = 20, Top = 20, Bottom = 20 }
            };
            return (viewAsPdf);
        }
        // Read list of invoices

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFInvoice.Read());
        }
        [HttpPost]
        public JsonResult ReadClientId(int id)
        {
            return Json(_iFInvoice.ReadClientId(id));
        }
        #endregion

        //UPDATE CLIENT
        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFInvoice.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Invoice invoice)
        {
            _iFService.Delete(invoice.InvoiceId);
            if (invoice.Services != null)
                foreach (Service service in invoice.Services)
                {
                    _iFService.Create(invoice.InvoiceId, service);
                }

            invoice = _iFInvoice.Update(invoice);
            return RedirectToAction("Index");

        }
        #endregion

        //Delete Invoice
        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {

            _iFInvoice.Delete(id);
            return Json(string.Empty);

        }
        #endregion
    }
}