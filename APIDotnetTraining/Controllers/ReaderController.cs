 namespace APIDotnetTraining.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly IBaseRepository<Reader> _ReaderRepository;

        public ReaderController(IBaseRepository<Reader> ReaderRepository)
        {
            _ReaderRepository = ReaderRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var readers = _ReaderRepository.FindAll();
            return Ok(readers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reader = _ReaderRepository.FindById(id);
            if (reader == null)
                return NotFound();
            return Ok(reader);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Reader reader)
        { 
            if(reader == null)
                return BadRequest();
            _ReaderRepository.Create(reader);
            return Ok(reader);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var reader = _ReaderRepository.FindById(id);
            if (reader == null)
                return NotFound();

            _ReaderRepository.Delete(id);
            return Ok();
        }

    }
}
