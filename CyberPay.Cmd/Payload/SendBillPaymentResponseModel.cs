using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPay.Cmd.Payload
{
    public class SendBillPaymentResponseModel
    {
        [JsonProperty("responseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("shortTransactionRef")]
        public int ShortTransactionRef { get; set; }

        [JsonProperty("responseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("rechargePin")]
        public string RechargePin { get; set; }

        [JsonProperty("transactionRef")]
        public string TransactionRef { get; set; }

        [JsonProperty("transactionResponseCode")]
        public string TransactionResponseCode { get; set; }

        [JsonProperty("transactionResponseDesc")]
        public string TransactionResponseDescription { get; set; }
    }
}
