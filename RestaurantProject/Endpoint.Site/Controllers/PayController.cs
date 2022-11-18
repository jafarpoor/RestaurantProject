using Application.Interfaces.Payments;
using Domain.Payments;
using Dto.Payment;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarinPal.Class;
using Payment = ZarinPal.Class.Payment;

namespace EndPoint.Site.Controllers
{
    public class PayController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentFacade _paymentervice;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly string MerchendId;

        public PayController(IConfiguration configutation , IPaymentFacade paymentervice)
        {
            _configuration = configutation;
            _paymentervice = paymentervice;
            MerchendId = configutation["ZarinpalMerchendId"];

            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index(Guid PaymentId)
        {
            var payment = _paymentervice.getPayment.GetPaymentById(PaymentId);
            if (payment == null)
                NotFound();
            if (payment.UserId != ClaimUtility.GetUserId(User))
                return BadRequest();


            string callBackUrl = Url.Action(nameof(Verify), "pay", new { payment.Id }, protocol: Request.Scheme);

            var reasultZarinpall = await _payment.Request(new DtoRequest
            {
                Amount = payment.Amount,
                CallbackUrl = callBackUrl,
                Description = payment.Description,
                Email = payment.Email,
                MerchantId = MerchendId,
                Mobile = payment.PhoneNumber,
            }, Payment.Mode.sandbox);

            return Redirect($"https://zarinpal.com/pg/StartPay/{reasultZarinpall.Authority}");
        }

        public async Task<IActionResult> Verify()
        {
            return Ok();
        }
    }
}
