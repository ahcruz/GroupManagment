using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlayBall.GroupManagment.Web.Models;

namespace PlayBall.GroupManagment.Web.Controllers
{
    [Route("groups")]
    public class GroupsController : Controller
    {
        private static long IdIncrement = 1;
        private static List<GroupsViewModel> groups = new List<GroupsViewModel>()
        {
            new GroupsViewModel{ Id = IdIncrement, Name = "Prueba"}
        };

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View(groups);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(long id)
        {
            var group = groups.SingleOrDefault(x => x.Id == id);

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
            var group = groups.SingleOrDefault(x => x.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            group.Name = model.Name;

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
            model.Id = ++IdIncrement;
            groups.Add(model);

            return RedirectToAction("Index");
        }
    }
}