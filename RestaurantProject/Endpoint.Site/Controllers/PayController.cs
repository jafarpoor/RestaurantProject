using Application.Interfaces.Order;
using Application.Interfaces.Payments;
using Domain.Payments;
using Dto.Payment;
using EndPoint.Site.Utilities;
using EndPoint.Site.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarinPal.Class;
using Payment = ZarinPal.Class.Payment;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentFacade _paymentervice;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly string MerchendId;

        public PayController(IConfiguration configutation, IPaymentFacade paymentervice )
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


            string callBackUrl = Url.Action(nameof(Verify), "pay", new { payment.Id  , payment.OrderId}, protocol: Request.Scheme);

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
            //Guid Id,  , int OrderId ,string Authority
            #region Code
            //string Status = HttpContext.Request.Query["Status"];
            //bool ResultPay = false;
            //if (Status != "" && Status.ToString().ToLower() == "ok"
            //    && Authority != "")
            //{
            //    var payment = _paymentervice.getPayment.GetPaymentById(Id);
            //    if (payment == null)
            //    {
            //        return NotFound();
            //    }

            //    var client = new RestClient("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
            //    client.Timeout = -1;
            //    var request = new RestRequest(Method.POST);
            //    request.AddHeader("Content-Type", "application/json");
            //    request.AddParameter("application/json", $"{{\"MerchantID\" :\"{MerchendId}\",\"Authority\":\"{Authority}\",\"Amount\":\"{payment.Amount}\"}}", ParameterType.RequestBody);
            //    var response = client.Execute(request);

            //    VerificationPayResultViewModel verification =
            //        JsonConvert.DeserializeObject<VerificationPayResultViewModel>(response.Content);

            //    if (verification.Status == 100)
            //    {
            //        bool verifyResult = _paymentervice.getPayment.VerifyPayment(Id, Authority, verification.RefID);
            //        if (verifyResult)
            //        {
            //            return RedirectToAction("checkout", "basket", new { ResultPay = true , OrderID =OrderId  });
            //        }
            //        else
            //        {
            //            return RedirectToAction("checkout", "basket", new { ResultPay = false ,OrderID =OrderId  });
            //        }
            //    }
            //    else
            //    {
            //        return RedirectToAction("checkout", "basket", new { ResultPay = false ,OrderID =0 });
            //    }

            //}
            //return RedirectToAction("checkout", "basket", new { ResultPay = false ,OrderID =0});
            #endregion


            return RedirectToAction("checkout", "basket", new { ResultPay  = true , OrderID =8}) ; 
        }
    }
}

