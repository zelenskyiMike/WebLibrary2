﻿using System.Collections.Generic;
using WebLibrary2.Domain.Abstract;
using WebLibrary2.Domain.Entity;

namespace WebLibrary2.Domain.Concrete
{
    public class EFBookRepository : IBookRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Books> Books
        {
            get { return context.Books; }
        }
    }
}
