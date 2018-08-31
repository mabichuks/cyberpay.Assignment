using CyberPay.Cmd.Payload.Quickteller;
using CyberPay.Cmd.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using CyberPay.Cmd.Payload;

namespace CyberPay.WebApp.Controllers
{
    [RoutePrefix("api/quickteller")]
    public class QuicktellerBillsController : ApiController
    {
        private readonly IQuickTellerBillProvider billProvider;

        public QuicktellerBillsController() : this(new QuickTellerBillProvider())
        {
        }

        public QuicktellerBillsController(IQuickTellerBillProvider billProvider)
        {
            this.billProvider = billProvider;
        }

        [Route("getbillers")]
        public HttpResponseMessage GetBillers()
        {
            var billers = billProvider.GetBillers();
            ApiResult<List<QuicktellerBiller>> result = new ApiResult<List<QuicktellerBiller>>();
            result.Data = billers;
            return Request.CreateResponse(result);
        }

        [Route("getBankCodes")]
        public HttpResponseMessage GetBankCodes()
        {
            var bankCodes = billProvider.GetBankCodes();

            ApiResult<List<QuicktellerBankCodeResponseModel>> result = new ApiResult<List<QuicktellerBankCodeResponseModel>>();
            result.Data = bankCodes;

            return this.Request.CreateResponse(result);
        }

        [HttpPost]
        [Route("sendbill")]
        public HttpResponseMessage SendBill(SendBillPaymentRequestModel srm)
        {
            var responseBody = billProvider.SendBillPaymentRequest(srm.Amount, srm.CustomerMobileNumber, srm.TransactionRef, srm.CardNumber, srm.PinData, srm.SecureData);

            ApiResult<SendBillPaymentResponseModel> result = new ApiResult<SendBillPaymentResponseModel>()
            {
                Data = responseBody
            };

            return this.Request.CreateResponse(result);
        }

    }
}