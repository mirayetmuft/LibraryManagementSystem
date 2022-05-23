using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    
    public class AdminHomePagesController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private IUserRepository _userRepository;

        public AdminHomePagesController(ICategoryRepository categoryRepository, IBookRepository bookRepository, IAuthorRepository authorRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
       public IActionResult BooksIndex()
        {
            ViewBag.books = this._bookRepository.GetAllWithDetail();
            return View();
        }
        public IActionResult UsersIndex()
        {
            ViewBag.users = this._userRepository.GetAll();
            return View();
        }
        public IActionResult CategoriesIndex()
        {
            ViewBag.categories = this._categoryRepository.GetAll();
            return View();
        }
        public IActionResult AuthorsIndex()
        {
            ViewBag.authors = this._authorRepository.GetAll();
            return View();
        }


    }
}
