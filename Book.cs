using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA20241219
{
    internal class Book
    {
        private int releaseYear;
        private int stock;
        private string title;
        private long iSBN;
        private int price;
        private string language;

        public Book()
        {
        }

        public long ISBN
        {
            get => iSBN;
            set
            {
                if (value.ToString().Length != 10)
                    throw new Exception("Invalid ISBN");
            }
        }
        public List<Author> Authors { get; set; }
        public string Title
        {
            get => title;
            set
            {
                if (value.Length < 3 || value.Length > 64)
                    throw new Exception("Invalid title");
            }
        }
        public int ReleaseYear
        {
            get => releaseYear;
            set
            {
                if (value < 2007 || value > DateTime.Today.Year)
                    throw new Exception("Invalid release year");
                releaseYear = value;
            }
        }
        public string Language
        {
            get => language;
            set
            {
                if (value != "angol" || value != "magyar" || value != "német")
                    throw new Exception("Invalid language");
            }
        }
        public int Stock
        {
            get => stock;
            set
            {
                if (value < 0)
                    throw new Exception("Invalid stock");
            }
        }
        public int Price
        {
            get => price;
            set
            {
                if (value < 1000 || value > 10000 || value % 100 != 0)
                    throw new Exception("Invalid price");
            }
        }

        public Book(long iSBN, List<Author> authors, string title, int releaseYear, string language, int stock, int price)
        {
            ISBN = iSBN;
            Authors = authors;
            Title = title;
            ReleaseYear = releaseYear;
            Language = language;
            Stock = stock;
            Price = price;
        }

        public Book(string title,params string[] authorName)
        {
            Title = title;
            List<Author> tempauth = [];
            foreach (var item in authorName)
            {
                Authors = tempauth;
            }
            ReleaseYear = 2024;
            Language = "magyar";
            Stock = 0;
            Price = 4500;
            ISBN = GenerateRandomISBN();
        }

        private long GenerateRandomISBN()
        {
            Random random = new Random();
            return random.Next(1000000000, 2000000000);
        }

        public override string ToString()
        {
            string authorLabel = Authors.Count == 1 ? "szerző:" : "szerzők:";
            string stockLabel = Stock == 0 ? "beszerzés alatt" : $"{Stock} db";

            return $"Cím: {Title}\n{authorLabel} {string.Join(", ", Authors)}\nKiadás éve: {ReleaseYear}\nNyelv: {Language}\nKészlet: {stockLabel}\nÁr: {Price} Ft";
        }
    }
}
