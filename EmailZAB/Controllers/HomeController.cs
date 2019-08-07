using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailZAB.Models;
using EmailZAB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmailZAB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailRepository emailRepository;

        public HomeController(IEmailRepository emailRepository)
        {
            this.emailRepository = emailRepository;
        }
        public ViewResult Index()
        {
            var model = emailRepository.GetAllEmails();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel() {
                Email = emailRepository.GetEmail(id),
                PageTitle = "Email Details"
        };
            
            return View(homeDetailsViewModel);
        }
    }
}