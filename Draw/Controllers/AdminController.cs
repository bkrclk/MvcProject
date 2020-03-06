using Microsoft.AspNetCore.Mvc;
using DrawData.Models;
using WizardDataAccess.UnitOfWork;
using DrawData.Context;

namespace Draw.Controllers
{
    public class AdminController : Controller
    {
        private MasterContext context;
        public AdminController(MasterContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UserModel user)
        {
            using (UnitOfWork uow = new UnitOfWork(context))
            {
                uow.GetRepository<UserModel>().Add(user);
                uow.SaveChanges();
                return View(user);
            }
        }
    }
}
