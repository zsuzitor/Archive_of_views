using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archive_of_views.Models
{
    public class db_models
    {
    }

    public class Film
    {
        public int Id { get; set; }
        public string Person_id { get; set; }
        public string Name { get; set; }
        public string Second_name { get; set; }
        public int Current_num_film { get; set; }
        public byte[] Image { get; set; }
        public string Author_name { get; set; }
        public DateTime? Date { get; set; }
        public string Comment { get; set; }
        public bool Looked { get; set; }
        private int? mark { get; set; }
        public int? Mark { get { return mark; }
            set
            {
                if (value == null)
                    mark = null;
                if (value > 0)
                {
                    if (value < 100)
                        mark = value;
                    else
                        mark = 100;
                }
                else
                {
                    mark = 0;
                }
            }
        }
        public Film()
        {
            Id = 0;
            Person_id = "";
            Name = "";
            Second_name = "";
            Current_num_film =1;
            Mark = null;
            Image = null;
            Date = null;
            Author_name= "";
            Comment = null;
            Looked = false;
        }
        public Film Eq_user(Film eq)
        {
            Name = eq.Name;
            Second_name = eq.Second_name;
            Current_num_film = eq.Current_num_film;
            Mark = eq.Mark;
            Author_name = eq.Author_name;
            Comment = eq.Comment;

            return this;
        }
    }
    
    public class Series
    {
        public int Id { get; set; }
        public string Person_id { get; set; }
        public string Name { get; set; }
        public string Author_name { get; set; }
        public int Current_season{ get; set; }
        public int Current_series { get; set; }//серия
        public byte[] Image { get; set; }
        public DateTime? Date { get; set; }
        public string Comment { get; set; }
        public bool Looked { get; set; }
        private int? mark { get; set; }
        public int? Mark
        {
            get { return mark; }
            set
            {
                if (value == null)
                    mark = null;
                if (value > 0)
                {
                    if (value < 100)
                        mark = value;
                    else
                        mark = 100;
                }
                else
                {
                    mark = 0;
                }
            }
        }
        public Series()
        {
            Id = 0;
            Looked = false;
            Comment = null;
            Person_id = "";
            Name = "";
            Author_name = "";
            Current_season = 1;
            Current_series = 1;
            Image = null;
            Mark = null;
            Date = null;
        }
        public Series Eq_user(Series eq)
        {
            Name = eq.Name;
            Current_season = eq.Current_season;
            Current_series = eq.Current_series;
            Mark = eq.Mark;
            Author_name = eq.Author_name;
            Comment = eq.Comment;

            return this;
        }
    }
    
        public class Book
    {
        public int Id { get; set; }
        public string Person_id { get; set; }
        public string Name { get; set; }
        public string Second_name { get; set; }
        public string Author_name { get; set; }
        public int Current_book { get; set; }
        public DateTime? Date { get; set; }
        public byte[] Image { get; set; }
        public string Comment { get; set; }
        public bool Looked { get; set; }
        private int? mark { get; set; }
        public int? Mark
        {
            get { return mark; }
            set
            {
                if (value == null)
                    mark = null;
                if (value > 0)
                {
                    if (value < 100)
                        mark = value;
                    else
                        mark = 100;
                }
                else
                {
                    mark = 0;
                }
            }
        }
        public Book()
        {
            Id = 0;
            Looked = false;
            Comment = null;
            Person_id = "";
            Name = "";
            Second_name = "";
            Author_name = "";
            Current_book = 1;
            Date = null;
            Image = null;
            Mark = null;
        }
        public Book Eq_user(Book eq)
        {
            Name = eq.Name;
            Second_name = eq.Second_name;
            Current_book = eq.Current_book;
            Mark = eq.Mark;
            Author_name = eq.Author_name;
            Comment = eq.Comment;

            return this;
        }
    }
    public class Season
    {
        
        public int Id { get; set; }
        public string Person_id { get; set; }
        public byte[] Image { get; set; }
        public int Series_id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool Looked { get; set; }
        private int? mark { get; set; }
        public int? Mark
        {
            get { return mark; }
            set
            {
                if (value == null)
                    mark = null;
                if (value > 0)
                {
                    if (value < 100)
                        mark = value;
                    else
                        mark = 100;
                }
                else
                {
                    mark = 0;
                }
            }
        }
        public Season()
        {
            Id = 0;
            Looked = false;
            Comment = null;
            Person_id = "";
            Name = "";
            Series_id = 0;
            Image = null;
            Mark = null;
        }
        public Season Eq_user(Season eq)
        {
            Name = eq.Name;
            
            Mark = eq.Mark;
            
            Comment = eq.Comment;

            return this;
        }
    }
    }