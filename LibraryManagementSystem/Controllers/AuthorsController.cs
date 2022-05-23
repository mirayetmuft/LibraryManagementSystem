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
    public class AuthorsController : Controller
    {

        private IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IActionResult Index()
        {
            ViewBag.authors = this._authorRepository.GetAll();
            return View();
        }
        public IActionResult Add(string message = null)
        {
            ViewBag.message = message;
            return View();
        }
        public IActionResult Update(int id, string message = null)
        {
            var author = this._authorRepository.GetById(id);
            if (author == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.message = message;
            ViewBag.author = author;
            return View();
        }
        [HttpPost]
        public IActionResult Save(Author author)
        {
            string route = (author.Id == 0) ? "Add" : "Update";
            if (author.FullName == null)
            {
                return BadRequest(new ErrorResult(author.Id, "Lütfen İsim Giriniz"));
            }
            if (author.Id == 0)
            {
                this._authorRepository.Add(author);
            }
            else
            {
                this._authorRepository.Update(author);
            }
            return Ok(author);
        }
        public IActionResult Delete(int id)
        {
            this._authorRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
