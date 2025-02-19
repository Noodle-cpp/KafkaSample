using Api.ViewModels.Requests;
using Application.Abstractions.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KafkaController : ControllerBase
    {
        private readonly IKafkaProducer _kafkaProducer;
        
        public KafkaController(IKafkaProducer kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }
        
        // POST <KafkaController>
        /// <summary>
        /// Отправка тестового сообщения в kafka
        /// </summary>
        /// <param name="testRequest">Тестовое тело</param>
        /// <returns></returns>
        /// <response code="404">Информация о книге не найдена</response>
        [HttpPost]
        public IActionResult Post([FromBody] KafkaTestRequest testRequest)
        {
            _kafkaProducer.SendMessage("test_topic", "key1", testRequest);
            return Ok();
        }
    }
}
