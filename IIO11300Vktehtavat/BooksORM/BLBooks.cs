using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksORM
{
    [Serializable]
    public class Book
    {
        #region PROPERTIES
        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
        }

        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        #endregion
        #region CONSTRUCTORS
        public Book(int id)
        {
            this.id = id;
        }

        public Book(int id, string name, string author, string country, int year)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.country = country;
            this.year = year;
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return name + " written by " + author;
        }
        #endregion

    }
    public class BookShop
    {
        private static string cs = BooksORM.Properties.Settings.Default.Kirjakauppa; 
        public static List<Book> GetTestBooks()
        {
            //metodi palauttaa kokoelman Book-olioita
            List<Book> temp = new List<Book>();
            temp.Add(new Book(1, "Sota ja rauha", "Leo Tolstoi", "Venäjä", 1867));
            temp.Add(new Book(1, "Anna ja rauno", "Leo Tolstoi", "Venäjä", 1877));
            return temp;
        }
        public static List<Book> GetBooks(Boolean useDB)
        {
            DataTable dt;
            List<Book> temp = new List<Book>();
            //haetaan kirjat db-kerroksen palauttama datatable mapataan olioiksi eli tehdään ormi
            try
            {
                if (useDB)
                {

                    dt = DBBooks.GetBooks(cs);
                }
                else
                {
                    dt = DBBooks.GetTestData();
                }
                //Tehdään ORM eli DataTablen rivit muutetaan olioiksi
                Book book;
                foreach (DataRow dr in dt.Rows)
                {
                    book = new Book((int)dr[0]);
                    book.Author = dr["author"].ToString();
                    book.Name = dr["name"].ToString();
                    book.Country = dr["country"].ToString();
                    book.Year = (int)dr["year"];
                    //olio lisätään kokoelmaan
                    temp.Add(book);

                }
                return temp;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void UpdateBook(Book book)
        {
            try
            {
                int lkm = DBBooks.UpdateBook(cs, book.Id,book.Name,book.Author,book.Country,book.Year);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
