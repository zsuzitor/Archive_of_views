using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archive_of_views.Models
{
    public class View_class
    {
    }
    public class Person
    {
        public ApplicationUser Db { get; set; }

        public List<Film> Films { get; set; }
        public List<Series> Series { get; set; }
        public List<Book> Books { get; set; }

        public Person()
        {
            Db = null;
            Films = new List<Film>();
            Series = new List<Series>();
            Books = new List<Book>();
        }
    }
    public class List_view_all
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Second_name { get; set; }
        public string Author_name { get; set; }
        public string Type { get; set; }
        public int? Mark { get; set; }
        public byte[] Image { get; set; }
        public List_view_all()
        {
            Id = 0;
            Name = "";
            Second_name = "";
            Author_name = "";
            Type = "";
            Mark = null;
            Image = null;
        }
    }
}