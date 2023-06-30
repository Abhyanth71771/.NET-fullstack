using DemoWebAPI2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        static private List<Book> books = new List<Book>()      {
            new Book { BookCode=1, BookName="ASP.NET Core Unleashed", Publisher="SAMS", Cost=1200.00},
            new Book { BookCode=2, BookName="Angular 12 Essentials", Publisher="SAMS", Cost=1300.00},
            new Book { BookCode=3, BookName="C# 10", Publisher="Microsoft Press", Cost=890.00},
            new Book { BookCode=4, BookName="AZ-204", Publisher="Microsoft Press", Cost=1900.00},
            new Book { BookCode=5, BookName="Pro Kubernetes", Publisher="APress", Cost=1500.00},
            new Book { BookCode=6, BookName="SP.NET Core Unleashed", Publisher="SAMS", Cost=1200.00},
        };
        [HttpGet]
        public IActionResult GeAllBooks() //return type is a interface because it can return view/status code
                                          //return type of a interface it returns instance of the class which impliments interface
        {
            //returns OKActionResult -->200
            return Ok(books); //Ok is a helper function  it is predifined it contains logic , ok result is a instance of icollection
        }

        [HttpGet]
        [Route("{bookid:int}")]//this is given to make the server undertand hat if a parameter is given then use this function
        public IActionResult GetAllBooks(int bookid)//the return type is an interface because we can return a view or a status code and the implementation of view and statud code is different so we give an interface as a return type
                                                    //return type is interface then it returns a instance of class which implements that interface
        {
            var result = books.Where(b => b.BookCode == bookid).SingleOrDefault();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Book with id: " + bookid + " not found");
            //return Ok(books);//ok returns a class(OkResult) which implements IAcionResult
        }

        [HttpGet]
        [Route("{publishername}")]
        public IActionResult GetAllBooks(string publishername)//the return type is an interface because we can return a view or a status code and the implementation of view and statud code is different so we give an interface as a return type
                                                              //return type is interface then it returns a instance of class which implements that interface
        {
            var result = books.Where(b => b.Publisher == publishername);
            if (result != null)
            {
                return Ok(result.ToList());
            }
            return NotFound("Book with PublisherName: " + publishername + " not found");
            //return Ok(books);//ok returns a class(OkResult) which implements IAcionResult
        }
        [HttpGet]
        [Route("{p:alpha:maxlength(1)}")]
        public IActionResult GetAllBooks(char p)//the return type is an interface because we can return a view or a status code and the implementation of view and statud code is different so we give an interface as a return type
                                                //return type is interface then it returns a instance of class which implements that interface
        {
            var result = books.Where(b => b.BookName.StartsWith(p));
            if (result != null)
            {
                return Ok(result.ToList());
            }
            return NotFound("Book whose book name stats with: " + p + " not found");
            //return Ok(books);//ok returns a class(OkResult) which implements IAcionResult
        }
        [HttpGet]
        [Route("{publisher}/{p:maxlength(1)}")]
        public IActionResult GetAllBooks(string publisher, char p)//the return type is an interface because we can return a view or a status code and the implementation of view and statud code is different so we give an interface as a return type
                                                                  //return type is interface then it returns a instance of class which implements that interface
        {
            var result = books.Where(b => b.BookName.StartsWith(p) && b.Publisher == publisher);
            if (result != null)
            {
                return Ok(result.ToList());
            }
            return NotFound("Book whose book name stats with: " + p + " not found");
            //return Ok(books);//ok returns a class(OkResult) which implements IAcionResult
        }
        [HttpPost]
        public IActionResult AddBook(Book newbook)
        {
            //check if the book code exists
            var result =
                books.Where(b =>
                                b.BookCode == newbook.BookCode).
                                SingleOrDefault();
            if (result != null)
            {
                //return Internal Server Error
                return StatusCode(500, "Book code: " + result.BookCode + " exists");
            }
            //add the book to the collection
            books.Add(newbook);
            return Ok("Book added successfully");
        }
        [HttpGet]
        [Route("p")]
        public IActionResult GetAllBooks()//the return type is an interface because we can return a view or a status code and the implementation of view and statud code is different so we give an interface as a return type
                                          //return type is interface then it returns a instance of class which implements that interface
        {
            var result = books.Where(b => b.BookName.StartsWith("P"));
            if (result != null)
            {
                return Ok(result.ToList());
            }
            return NotFound("Book whose book name starts with P not found");
            //return Ok(books);//ok returns a class(OkResult) which implements IAcionResult
        }

        [HttpGet]
        [Route("{Publisher}/{cost}")]
        public IActionResult GetAllBooks(string publisher,int cost)//the return type is an interface because we can return a view or a status code and the implementation of view and statud code is different so we give an interface as a return type
                                          //return type is interface then it returns a instance of class which implements that interface
        {
            var result = books.Where(b => b.Publisher==publisher || b.Cost>cost);
            if (result != null)
            {
                return Ok(result.ToList());
            }
            return NotFound("Book whose book name starts with P not found");
            //return Ok(books);//ok returns a class(OkResult) which implements IAcionResult
        }

    }
}
