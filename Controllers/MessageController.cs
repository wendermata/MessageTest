using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace MessagesTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {

        private readonly ILogger<MessageController> _logger;
        private readonly ISendEndpointProvider _publisher;

        public MessageController(ILogger<MessageController> logger, ISendEndpointProvider publishEndpoint)
        {
            _logger = logger;
            _publisher = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerOmieContract contract)
        {

            var endpoint = await _publisher.GetSendEndpoint(new Uri("rabbitmq://localhost/accountancy_accountgateway_mottuaccounting_customer_integrate_omie"));
            await endpoint.Send(contract);
            return Ok();
        }
    }
}
