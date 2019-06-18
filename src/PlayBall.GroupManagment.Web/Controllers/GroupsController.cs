using Microsoft.AspNetCore.Mvc;
using PlayBall.GroupManagment.Services.Services;
using PlayBall.GroupManagment.Web.Mappings;
using PlayBall.GroupManagment.Web.Models;

namespace PlayBall.GroupManagment.Web.Controllers
{
    [Route("groups")]
    public class GroupsController : Controller
    {
        private readonly IGroupServices _groupServices;

        public GroupsController(IGroupServices groupServices)
        {
            _groupServices = groupServices;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View(_groupServices.GetAll().ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(long id)
        {
            var group = _groupServices.GetById(id).ToViewModel();

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, GroupsViewModel model)
        {
            var group = _groupServices.Update(model.ToModel());

            if (group == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDB(GroupsViewModel model)
        {
            _groupServices.Create(model.ToModel());

            return RedirectToAction("Index");
        }
    }
}