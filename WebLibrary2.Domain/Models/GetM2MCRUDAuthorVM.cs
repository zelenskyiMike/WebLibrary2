﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLibrary2.Domain.Entity;

namespace WebLibrary2.Domain.Models
{
    public class GetM2MCRUDAuthorVM
    {
        public int AuthorID { get; set; }

        [Required(ErrorMessage = "Неободимо добавить название книги")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длинна строки должна быть не менее 5 и не более 50 символов")]
        public string AuthorName { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}