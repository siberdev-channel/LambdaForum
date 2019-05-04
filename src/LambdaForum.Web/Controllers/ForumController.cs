using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LambdaForum.Service;
using LambdaForum.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable RCS1090 // Call 'ConfigureAwait(false)'.

namespace LambdaForum.Web.Controllers
{
    //[Authorize]
    public class ForumController : Controller
    {
        private readonly IForumService _forums;

        public ForumController(IForumService forumService) =>
            _forums = forumService ?? throw new ArgumentNullException(nameof(forumService));

        // GET: Forum
        public async Task<IActionResult> Index() =>
            View(new ForumIndexViewModel
            {
                ForumList = await _forums.ReadAll<ForumListViewModel>()
            });

        // GET: Forum/Topic/5
        public ActionResult Topic(int id)
        {
            return base.View(id);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Forum/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Forum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

#pragma warning restore RCS1090 // Call 'ConfigureAwait(false)'.
