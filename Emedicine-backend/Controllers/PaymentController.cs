using Emedicine.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emedicine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("creditcard")]
        public async Task<IActionResult> ProcessCreditCardPayment([FromBody] CreditCardPaymentRequest request)
        {
            var transactionId = await _paymentService.ProcessCreditCardPaymentAsync(request.Amount, request.Token);
            return Ok(new { TransactionId = transactionId });
        }

        [HttpPost("bkash")]
        public async Task<IActionResult> ProcessBkashPayment([FromBody] BkashPaymentRequest request)
        {
            var transactionId = await _paymentService.ProcessBkashPaymentAsync(request.Amount, request.PhoneNumber);
            return Ok(new { TransactionId = transactionId });
        }

        [HttpPost("rocket")]
        public async Task<IActionResult> ProcessRocketPayment([FromBody] RocketPaymentRequest request)
        {
            var transactionId = await _paymentService.ProcessRocketPaymentAsync(request.Amount, request.PhoneNumber);
            return Ok(new { TransactionId = transactionId });
        }
    }

    public class CreditCardPaymentRequest
    {
        public decimal Amount { get; set; }
        public string Token { get; set; }
    }

    public class BkashPaymentRequest
    {
        public decimal Amount { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class RocketPaymentRequest
    {
        public decimal Amount { get; set; }
        public string PhoneNumber { get; set; }
    }

}
