﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary2.Domain.Entity
{
    public class Author : IEnumerable
    {
        [Key]
        public int AuthorID { get; set; }

        [Required(ErrorMessage = "Необходимо ввести имя и фамилию автора")]
        public string AuthorName { get; set; }

        //public IEnumerable<Book> Books { get; set; }
        //public ICollection<Book> Books { get; set; }

        //public Author()
        //{
        //    Books = new List<Book>();
        //}

        private IEnumerable Authors()
        {
            yield return AuthorID;
            yield return AuthorName;
        }
        public IEnumerator GetEnumerator()
        {
            return Authors().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
