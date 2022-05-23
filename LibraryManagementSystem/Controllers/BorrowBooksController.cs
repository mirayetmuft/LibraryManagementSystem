using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowBooksController : Controller
    {
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;
        private IBorrowBookRepository _borrowBookRepository;

        public BorrowBooksController(IBookRepository bookRepository, IUserRepository userRepository, IBorrowBookRepository borrowBookRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _borrowBookRepository = borrowBookRepository;
        }

        public IActionResult Index()
        {
            var borrowBooks = _borrowBookRepository.GetBorrowingDetails();
            ViewBag.borrowBooks = borrowBooks;
            return View();

        }
        [HttpPost]
        public IActionResult CreateReservation([Bind("Id", "UserId", "BookId", "BorrowingDate", "DateToBeReturned", "ReturnDate")] BorrowBook borrowBook)
        {

            ViewBag.borrowBooks = _borrowBookRepository.GetAll();
            ViewBag.users = this._userRepository.GetAll();
            ViewBag.books = this._bookRepository.GetAll();
            if (ModelState.IsValid)
            {
                Book book = _bookRepository.GetById(borrowBook.BookId);
                User user = _userRepository.GetById(borrowBook.UserId);
                if (user == null)
                {
                    return RedirectToAction("Index", "Home",new ErrorResult("Kullanıcı Bulunamadı"));
                }
                if (book.Status == false)
                {
                    
                    return RedirectToAction("Index", "Home", new ErrorResult("Kitap Geri Getirilmemiş"));
                    
                }
                ViewBag.messages = "Kullanıcı Bulunamadı";
                _borrowBookRepository.Add(borrowBook);
                book.Status = false;
                _bookRepository.Update(book);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateReservation(string message)
        {

            ViewBag.borrowBooks = _borrowBookRepository.GetAll();
            ViewBag.users = this._userRepository.GetAll();
            ViewBag.books = this._bookRepository.GetAll();
            BorrowBook borrowBook = new BorrowBook();
            return View(borrowBook);
        }

        public IActionResult UpdateReservation(int Id)
        {
            var bringingBook = _borrowBookRepository.GetById(Id);
            ViewBag.borrowBooks = bringingBook;
            var theBook = _bookRepository.GetById(bringingBook.BookId);
            bringingBook.ReturnDate = DateTime.Today;
            theBook.Status = true;
            _borrowBookRepository.Update(bringingBook);
            _bookRepository.Update(theBook);
            return View();
        }
       
    }

}
