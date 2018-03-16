﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary2.Domain.Models
{
    public class AddABookViewModel
    {
        public string BookName { get; set; }
        public int GenreID { get; set; }
        public int AuthorID { get; set; }
        public int YearOfPublish { get; set; }
    }
}
