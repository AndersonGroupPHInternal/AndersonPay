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
    public class FPayment : IFPayment
    {
        private IDPayment _iDPayment;

        public FPayment(IDPayment iDPayment)
        {
            _iDPayment = iDPayment;
        }

        public FPayment()
        {
            _iDPayment = new DPayment();
        }

        #region CREATE
        public Payment Create(Payment payment)
        {
            EPayment ePayment = EPayment(payment);
            ePayment = _iDPayment.Create(ePayment);
            return Payment(ePayment);
        }
        #endregion

        #region READ
        public Payment Read(int paymentId)
        {
            EPayment ePayment = _iDPayment.Read<EPayment>(a => a.PaymentId == paymentId);
            return Payment(ePayment);
        }

        public List<Payment> Read()
        {
            List<EPayment> ePayment = _iDPayment.List<EPayment>(a => true);
            return Payment(ePayment);
        }
        #endregion

        #region UPDATE
        public Payment Update(Payment payment)
        {
            var ePayment = _iDPayment.Update(EPayment(payment));
            return (Payment(ePayment));
        }
        #endregion

        #region DELETE
        public void Delete(Payment payment)
        {
            _iDPayment.Delete(EPayment(payment));
        }
        #endregion

        #region OTHER FUNCTION
        private EPayment EPayment(Payment payment)
        {
            EPayment returnEPayment = new EPayment
            {
                PaymentId = payment.PaymentId,
                DateOfPayment = payment.DateOfPayment,
                AmountReceived = payment.AmountReceived,
                Payments = payment.Payments,
                Discount = payment.Discount,
                Balance = payment.Balance,
                ClientId = payment.ClientId,
                Name = payment.Name
            };

            return returnEPayment;
        }

        private Payment Payment(EPayment ePayment)
        {
            Payment returnPayment = new Payment
            {
                PaymentId = ePayment.PaymentId,
                AmountReceived = ePayment.AmountReceived,
                Payments = ePayment.Payments,
                Discount = ePayment.Discount,
                Balance = ePayment.Balance,
                ClientId = ePayment.ClientId,
                Name = ePayment.Name
            };
            return returnPayment;
        }

        private List<Payment> Payment(List<EPayment> ePayment)
        {
            var returnPayment = ePayment.Select(a => new Payment
            {
                PaymentId = a.PaymentId,
                AmountReceived = a.AmountReceived,
                Payments = a.Payments,
                Discount = a.Discount,
                Balance = a.Balance,
                ClientId = a.ClientId,
                Name = a.Name
            });

            return returnPayment.ToList();
        }
        #endregion
    }
}