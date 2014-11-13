using ForumSystem.Data.Common.Repository;
using ForumSystem.Data.Models;
using ForumSystem.Web.IntupModels.Questions;
using ForumSystem.Web.ViewModels.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ForumSystem.Web.Infrastructure;

namespace ForumSystem.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private IDeletableEntityRepository<Post> posts;
        private ISanitizer sanitizer;

        public QuestionsController(IDeletableEntityRepository<Post> posts, ISanitizer sanitizer)
        {
            this.posts = posts;
            this.sanitizer = sanitizer;
        }

        // GET: Questions
        public ActionResult Display(int id, string url, int page = 1)
        {
            var viewModel = this.posts.All()
                                .Where(x => x.Id == id).Project()
                                .To<QuestionDisplayViewModel>()
                                .FirstOrDefault();

            if (viewModel == null)
            {
                return HttpNotFound("No such post");
            }
            return View(viewModel);
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
            if (ModelState.IsValid)
            {
                var post = new Post
                    {
                        Title = input.Title,
                        Content = sanitizer.Sanitize(input.Content)
                    };

                this.posts.Add(post);
                this.posts.SaveChanges();

                return RedirectToAction("GetById", new { id = post.Id, url = "new" });
            }

            return View(input);
        }
    }
}