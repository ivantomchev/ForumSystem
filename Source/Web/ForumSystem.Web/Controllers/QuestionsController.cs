using ForumSystem.Web.IntupModels.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Web.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Questions
        public ActionResult Display(int id, string url, int page = 1)
        {
            return Content(id + " " + url);
        }

        public ActionResult GetByTag(string tag)
        {
            return Content(tag);
        }

        [HttpGet]
        public ActionResult Ask()
        {
            var model = new AskInputModel();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ask(AskInputModel input)
        {
            return Content("POST");
        }
    }
}