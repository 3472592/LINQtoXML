using System.Xml.Linq;

namespace Code
{
    public class Program
    {
        public static void Main()
        {
            /* The XDocument object’s Load() and
            Save() methods read and write XML files. 
            And its ToString() method renders everything
            inside it as one big XML document. */
            XDocument doc = GetStarbuzzData.GetData();
            Console.WriteLine(doc.ToString());
            doc.Save("starbuzzData.xml");
            XDocument anotherDoc = XDocument.Load("starbuzzData.xml");

            /* The Descendants() method  returns a reference to an
            object that you can plug right into LINQ. */
            var data = from item in doc.Descendants("person")
                       select new
                       {
                           drink = item.Element("favoriteDrink").Value,
                           moneySpent = item.Element("moneySpent").Value,
                           /* You already know that LINQ lets you call
                            methods and use them as part of the query, and
                            that works really well with the Element() method. 
                           Element() returns an XElement object, and
                            you can use its properties to check specific values
                            in your XML document.*/
                           zipCode = item.Element("personalInfo").Element("zip").Value
                       };
            foreach (var p in data)
                Console.WriteLine(p.ToString());

            var zipcodeGroups = from item in doc.Descendants("person")
                                group item.Element("favoriteDrink").Value
                                by item.Element("personalInfo").Element("zip").Value
                                into zipcodeGroup
                                select zipcodeGroup;
            foreach (var group in zipcodeGroups)
                Console.WriteLine("{0} favorite drinks in {1}",
                            group.Distinct().Count(), group.Key);

            XDocument ourBlog = XDocument.Load("http://www.stellman-greene.com/feed");
            Console.WriteLine(ourBlog.Element("rss").Element("channel").Element("title").Value);
            var posts = from post in ourBlog.Descendants("item")
                        select new
                        {
                            Title = post.Element("title").Value,
                            Date = post.Element("pubDate").Value
                        };
            foreach (var post in posts)
                Console.WriteLine(post.ToString());
        }
    }
}