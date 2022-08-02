namespace APIDotnetTraining.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BookControler : ControllerBase
    {
        private readonly IBaseRepository<Book> _bookRepository;

        public BookControler(IBaseRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var books = _bookRepository.FindAll().ToList();
            return Ok(books);

        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id) {
            var book = _bookRepository.FindById(Id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id ,[FromBody] Book book ) {
            Book book1 = _bookRepository.FindById(id);
            if (book1 == null)
                return NotFound();
            _bookRepository.Update(id , book);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (book == null)
                return BadRequest();
            _bookRepository.Create(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookRepository.FindById(id);
            if(book == null)
                return NotFound();
            
            _bookRepository.Delete(id);
            return Ok();
        }

    }
}
