﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebLibrary2.EntitiesLayer.Entities
{
    public class Magazine
    {
        [Key]
        public int MagazineID { get; set; }
        [Required]
        public int MagazineGenreID { get; set; }
        [Required]
        public string MagazineName { get; set; }
        [Required]
        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfMagazinePublish { get; set; }

        [XmlIgnore]
        //[IgnoreDataMember]
        public MagazineGenre MagazineGenres { get; set; }
        [XmlIgnore]
        //[IgnoreDataMember]
        public virtual IEnumerable<Author> Authors { get; set; }

        [XmlIgnore]
        //[IgnoreDataMember]
        public List<int> AuthorsIDs { get; set; }

        public Magazine()
        {
            Authors = new List<Author>();
        }
    }
}