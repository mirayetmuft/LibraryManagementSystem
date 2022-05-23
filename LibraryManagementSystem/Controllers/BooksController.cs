using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {

        private IBookRepository _bookRepository;
        private ICategoryRepository _categoryRepository;
        private IAuthorRepository _authorRepository;

        public BooksController(IBookRepository bookRepository, ICategoryRepository categoryRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
        }

        public IActionResult Index(string p)
        {
            ViewBag.authors = _authorRepository.GetAll();
            ViewBag.categories = _categoryRepository.GetAll();
            if (!string.IsNullOrEmpty(p))
            {
                ViewBag.books = _bookRepository.GetAll(b => b.Name == p);
                ViewBag.authors = _authorRepository.GetAll();
                ViewBag.categories = _categoryRepository.GetAll();
                return View();
            }
            ViewBag.books = this._bookRepository.GetAll();
            ViewBag.authors = _authorRepository.GetAll();
            ViewBag.categories = _categoryRepository.GetAll();
            return View();
        }

        public IActionResult Add(string message)
        {
            ViewBag.message = message;
            return View();
        }
        public IActionResult Save(Book book)
        {
            string route = (book.Id == 0) ? "Add" : "Update";
            if (book.Name==null)
            {
                return BadRequest(new ErrorResult(book.Id,"Lütfen Kitap Adını Giriniz"));
            }
            if (book.Page==0)
            {
                return BadRequest(new ErrorResult(book.Id, "Lütfen Sayfa Sayısını Giriniz"));
            }
            if (book.Shelf==null)
            {
                return BadRequest(new ErrorResult(book.Id, "Lütfen Bulunduğu Rafı Giriniz"));
            }
            if (book.AuthorId==0)
            {
                return BadRequest(new ErrorResult(book.Id, "Lütfen Yazar Seçiniz"));
            }
            if (book.CategoryId==0)
            {
                return BadRequest(new ErrorResult(book.Id,"Lütfen Kategori Seçiniz"));
            }
            if (book.Status==false)
            {
                return BadRequest(new ErrorResult(book.Id,"Lütfen Durumu Seçiniz"));
            }
            if (book.Id == 0)
            {
                this._bookRepository.Add(book);
            }
            else
            {
                this._bookRepository.Update(book);
            }
            return RedirectToAction("Index");
        }
    }
}
