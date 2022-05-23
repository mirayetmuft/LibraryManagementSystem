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
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;

        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        public IActionResult Index()
        {
            ViewBag.users = this._userRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Add(string message = null)
        {
            ViewBag.message = message;
            return View();

        }

        public IActionResult Add()
        {
            User user = new User();
            return View(user);

        }
        public IActionResult Save(User user)
        {
            string route = (user.Id == 0) ? "Add" : "Update";
            if (user.IdNumber==null)
            {
                return RedirectToAction(route, new ErrorResult(user.Id, "Lütfen TC Kimlik Numaranızı Giriniz."));
            }
            if (user.FullName==null)
            {
                return RedirectToAction(route,new ErrorResult(user.Id,"Lütfen İsim Giriniz."));
            }
         
            if (user.PhoneNumber==null)
            {
                return RedirectToAction(route,new ErrorResult(user.Id,"Lütfen Telefon Numarasını Giriniz."));
            }
            if (user.Faculty==null)
            {
                return RedirectToAction(route,new ErrorResult(user.Id,"Lütfen Fakülte Adı Giriniz."));
            }
            if (user.Department == null)
            {
                return RedirectToAction(route, new ErrorResult(user.Id, "Lütfen Fakülte Adı Giriniz."));
            }
            if (user.Email==null)
            {
                return RedirectToAction(route,new ErrorResult(user.Id,"Lütfen Bölüm Giriniz."));
            }
            if (user.Id==0)
            {
                this._userRepository.Add(user);
            }
            else
            {
                this._userRepository.Update(user);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id,string message=null)
        {
            var user = _userRepository.GetById(id);
            if (user==null)
            {
                RedirectToAction("Index");
            }
            ViewBag.user = user;
            ViewBag.message = message;
            return View();
        }
        public IActionResult Delete(int id)
        {
            this._userRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
