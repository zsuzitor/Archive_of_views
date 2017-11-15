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
        public string Name { get; set; }
        public string Second_name { get; set; }
        public int Current_num_film { get; set; }
        public byte[] Image { get; set; }
        public string Author_name { get; set; }
        public DateTime? Date { get; set; }
        public int? Mark { get { return Mark; }set {
                if (value > 0)
                {
                    if (value < 100)
                        Mark = value;
                    else
                        Mark = 100;
                }
                else
                {
                    Mark = 0;
                }
            } }
        public Film()
        {
            Name = "";
            Second_name = "";
            Current_num_film =1;
            Mark = null;
            Image = null;
            Date = null;
            Author_name= "";
        }
    }
    
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author_name { get; set; }
        public int Current_season{ get; set; }
        public int Current_series { get; set; }
        public byte[] Image { get; set; }
        public DateTime? Date { get; set; }
        public int? Mark
        {
            get { return Mark; }
            set
            {
                if (value > 0)
                {
                    if (value < 100)
                        Mark = value;
                    else
                        Mark = 100;
                }
                else
                {
                    Mark = 0;
                }
            }
        }
        public Series()
        {
            Name = "";
            Author_name = "";
            Current_season = 1;
            Current_series = 1;
            Image = null;
            Mark = null;
            Date = null;
        }
    }
    
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Second_name { get; set; }
        public string Author_name { get; set; }
        public int Current_book { get; set; }
        public DateTime? Date { get; set; }
        public byte[] Image { get; set; }
        public int? Mark
        {
            get { return Mark; }
            set
            {
                if (value > 0)
                {
                    if (value < 100)
                        Mark = value;
                    else
                        Mark = 100;
                }
                else
                {
                    Mark = 0;
                }
            }
        }
        public Book()
        {
            Name = "";
            Second_name = "";
            Author_name = "";
            Current_book = 1;
            Date = null;
            Image = null;
            Mark = null;
        }
    }
    public class Season
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int Series_id { get; set; }
        public string Name { get; set; }
        public int? Mark
        {
            get { return Mark; }
            set
            {
                if (value > 0)
                {
                    if (value < 100)
                        Mark = value;
                    else
                        Mark = 100;
                }
                else
                {
                    Mark = 0;
                }
            }
        }
        public Season()
        {
            Name = "";
            Series_id = 0;
            Image = null;
            Mark = null;
        }
    }
    }