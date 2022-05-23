using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class AdminsController : Controller
    {
        private readonly LibraryDbContext _context;
        private IAuthorRepository _authorRepository;
        private ICategoryRepository _categoryRepository;

        public AdminsController(LibraryDbContext context, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var authors = _authorRepository.GetAll();
            ViewBag.authors = authors;
            var categories = _categoryRepository.GetAll();
            ViewBag.categories=categories;
            return View();
        }
        public IActionResult Login()
        {
            AdminVM adminViewModel = new AdminVM();
            return View(adminViewModel);
        }
        [HttpPost]
        public IActionResult Login([Bind("Email","Password")] AdminVM adminViewModel)
        {
            //Model.State.IsValid=gerekli doğrulamalardan geçmiş olmalı
            //asp.net core
            if (ModelState.IsValid)
            {
                //system.security.claims
                //claimsIdentity sınıf
                //Sınıfın ClaimsPrincipal da bir Claims özelliği vardır. Çoğu durumda, kullanıcının taleplerine koleksiyon yerine koleksiyon üzerinden ClaimsPrincipal.Claims Claims erişmeniz gerekir. Bir kişinin ClaimsIdentity taleplerine yalnızca sorumlunun birden ClaimsIdentity fazla içerdiği durumlarda erişmeniz ve belirli bir kimliği değerlendirmeniz veya değiştirmeniz gerekir.
                ClaimsIdentity identityy = null;
                bool isAuthenticated = false;
                Admin admin = _context.Admins.FirstOrDefault(m => m.Email == adminViewModel.Email && m.Password == adminViewModel.Password);

                if (admin == null)
                {
                    ModelState.AddModelError("Hata1", "Yönetici Bulunamadı.");
                    return View();
                }

                identityy = new ClaimsIdentity
                (new[]
                        {
                            new Claim(ClaimTypes.Sid,admin.Id.ToString()),
                            new Claim(ClaimTypes.Email,admin.Email),
                        }, CookieAuthenticationDefaults.AuthenticationScheme
                //Microsoft.AspNetCore.Authentication.Cookies/Varsayılan değer, ıeauthenticationoptions. AuthenticationScheme için kullanılır
                //ClaimsIdentity(IEnumerable<Claim>, String): Initializes a new instance of the ClaimsIdentity class with the specified claims and authentication type.
                );
                isAuthenticated = true;

                if (isAuthenticated)
                {
                    //System.Security.Claims
                    //IPrincipal Birden çok talep tabanlı kimliği destekleyen bir uygulama.
                    //ClaimsPrincipal her biri bir ClaimsIdentity olan kimlik koleksiyonunu kullanıma sunar. Yaygın durumda, özelliği aracılığıyla erişilen bu koleksiyon yalnızca tek bir öğeye Identities sahip olur.
                    //ClaimsPrincipal'in birden çok ClaimsIdentity örneği içerdiği olağandışı bir durumda, Identities özelliğini kullanabilir veya Identity özelliğini kullanarak birincil kimliğe erişebilirsiniz. ClaimsPrincipal, bu taleplerin aranabileceği çeşitli yöntemler sağlar ve Dille Tümleşik Sorgu'yu (LINQ) tam olarak destekler.
                    var claimss = new ClaimsPrincipal(identityy);

                    //Microsoft.AspNetCore.Authentication
                    var loginn = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimss,
                       //Microsoft.AspNetCore.Authentication
                       new AuthenticationProperties
                       {
                           IsPersistent = true,
                           ExpiresUtc = DateTime.Now.AddMinutes(60)
                       }

                       );
                    //SignInAsync(HttpContext, ClaimsPrincipal, AuthenticationProperties):Varsayılan kimlik doğrulama düzeni için bir sorumluda oturum açma.Oturum açma için varsayılan düzen kullanılarak yalıtıldı.
                    return Redirect("~/Admins/Index");
                }
            }
            return View(adminViewModel);
        }
    }
}
