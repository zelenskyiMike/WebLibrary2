﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebLibrary2.ViewModelsLayer.ViewModels
{
    public class GetBookView
    {
        public int BookID { get; set; }
        [Required(ErrorMessage = "Неободимо добавить название книги")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длинна строки должна быть не менее 3 и не более 50 символов")]
        public string BookName { get; set; }

        [Required(ErrorMessage ="Выберите жанр")]
        public int GenreID { get; set; }

        [Required(ErrorMessage ="Выберите хотя бы одного автора")]
        public List<int> AuthorsIDs { get; set; }

        [Required(ErrorMessage = "Необходимо ввести год издания")]
        [Range(868, 2018, ErrorMessage = "Книга не могла быть издана раньше 868 и поже 2018 года")]
        public int YearOfPublish { get; set; }
    }
}