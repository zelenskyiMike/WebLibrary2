﻿using System.Web.Mvc;
using WebLibrary2.Domain.Concrete;
using System.Net;
using System.Data;
using WebLibrary2.Domain.Models;
using WebLibrary2.Domain.Abstract.AbstractAuthor;
using WebLibrary2.Domain.Abstract.AbstractBook;
using WebLibrary2.Domain.Abstract.AbstractArticle;
using WebLibrary2.Domain.Abstract.AbstractMagazine;
using WebLibrary2.Domain.Abstract.AbstractPublication;

namespace WebLibrary2.WebUI.Controllers.AuthorControllers
{
    public class CRUDAuthorController : Controller
    {
        private EFDbContext context;
        IAuthorsRepository authorRepository;
        IBookAuthorsRepository bookAuthorRepository;
        IArticeAuthorsRepository articeAuthorsRepository;
        IMagazineAuthorsRepository magazineAuthorsRepository;
        IPublicationAuthorsRepository publicationAuthorsRepository;

        public CRUDAuthorController(IAuthorsRepository authorsRepository, IBookAuthorsRepository bookAuthorsRepository, 
                                    IArticeAuthorsRepository articeAuthorsRepository, IMagazineAuthorsRepository magazineAuthorsRepository, 
                                    IPublicationAuthorsRepository publicationAuthorsRepository, EFDbContext dataContext)
        {
            this.context = dataContext;
            this.authorRepository = authorsRepository;
            this.bookAuthorRepository = bookAuthorsRepository;
            this.publicationAuthorsRepository = publicationAuthorsRepository;
            this.articeAuthorsRepository = articeAuthorsRepository;
            this.magazineAuthorsRepository = magazineAuthorsRepository;
        }

        public ActionResult CreateAuthor()
        {
            MultiSelectList books = new MultiSelectList(context.Books, "BookID", "BookName");
            ViewData["Books"] = books;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuthor(AuthorViewModel authorVM)
        {
            if (ModelState.IsValid)
            {
                authorRepository.CreateAuthor(authorVM);
                return RedirectToAction("Index", "Home");
            }

            MultiSelectList books = new MultiSelectList(context.Books, "BookID", "BookName");
            ViewData["Books"] = books;
            return View(authorVM);
        }

        public ActionResult AuthorsDetails(int id = 0)
        {
            var authorVM = authorRepository.GetAuthorDetails(id);
            return View(authorVM);
        }

        public ActionResult EditAuthor(int? id)
        {
            var authorVM = authorRepository.GetAuthorDetails(id);
            if (authorVM == null)
            {
                return HttpNotFound();
            }

            return View(authorVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAuthor(GetM2MCRUDAuthorVM author)
        {
            var authorToUpdate = authorRepository.GetAuthorByID(author.AuthorID);

            if (TryUpdateModel(authorToUpdate))
            {
                try
                {
                    authorRepository.Save();
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteAuthor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = authorRepository.GetAuthorDetails(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAuthor(int id)
        {
            try
            {
                authorRepository.DeleteAuthor(id);
            }
            catch (DataException)
            {
                return RedirectToAction("DeleteAuthor", new { id = id });
            }
            return RedirectToAction("Index", "Home");
        }
    }
}