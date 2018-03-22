using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _5KToolKitConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================");
            Console.WriteLine("This is a debug window");
            Console.WriteLine("======================");
            ParseExample();
            Console.WriteLine("End of Book Sample");
            L5XExample();
            Console.WriteLine("End of L5X exampl");
            Console.ReadLine();
        }

        // Example - Open and Read XML
        // From - https://www.c-sharpcorner.com/UploadFile/dhananjaycoder/reading-xml-file-through-linq-a-few-tips/
        public static void ParseExample()
        {
            XDocument document = XDocument.Load("C:\\Users\\danie\\source\\repos\\5KToolKit\\Examples\\sample.xml");
            var books = from r in document.Descendants("book")
                select new
                {
                    Author = r.Element("author").Value,
                    Title = r.Element("title").Value,
                    Genere = r.Element("genre").Value,
                    Price = r.Element("price").Value,
                    PublishDate = r.Element("publish_date").Value,
                    Description = r.Element("description").Value,
                };

            foreach (var r in books)
            {
                Console.WriteLine(r.PublishDate + r.Title + r.Author);
            }

            Console.ReadKey(true);

            var selectedBook = from r in document.Descendants("book").Where
                                   (r => (string)r.Attribute("id") == "bk102")
                               select new
                               {
                                   Author = r.Element("author").Value,
                                   Title = r.Element("title").Value,
                                   Genere = r.Element("genre").Value,
                                   Price = r.Element("price").Value,
                                   PublishDate = r.Element("publish_date").Value,
                                   Description = r.Element("description").Value,

                               };

            foreach (var r in selectedBook)
            {
                Console.WriteLine(r.PublishDate + r.Title + r.Author);
            }
            Console.ReadKey(true);

            var selectedBookAttribute = (from r in document.Descendants("book").Where
                                        (r => (string)r.Attribute("id") == "bk102")
                                         select r.Element("author").Attribute("id").Value).FirstOrDefault();

            Console.WriteLine(selectedBookAttribute);

            Console.ReadKey(true);
        
            var allauthors = from r in document.Descendants("book")
                             select r.Element("author").Value;
            foreach (var r in allauthors)
            {
                Console.WriteLine(r.ToString());
            }

            Console.ReadKey(true);

        }

        public static void L5XExample()
        {

        }
    }
}
