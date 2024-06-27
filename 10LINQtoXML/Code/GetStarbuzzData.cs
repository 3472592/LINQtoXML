using System.Xml.Linq;

namespace Code
{
    public static class GetStarbuzzData
    {
        public static XDocument GetData()
        {
            /* You can use an XDocument to create
            an XML file, and that includes XML
            files you can read and write using
            DataContractSerializer. An XMLDocument object
            represents an XML document. It’s part of the
            System.Xml.Linq namespace. */
            XDocument doc = new(

                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Starbuzz Customer Loyalty Data"),

                new XElement("starbuzzData",
                    new XAttribute("storeName", "Park Slope"),
                    new XAttribute("location", "Brooklyn, NY"),

                    new XElement("person",
                        new XElement("personalInfo",
                            /* Use XElement objects to create
                            elements under the XML tree. */
                            new XElement("name", "Janet Venutian"),
                            new XElement("zip", 11215)),
                        new XElement("favoriteDrink", "Choco Macchiato"),
                        new XElement("moneySpent", 255),
                        new XElement("visits", 50)),

                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Liz Nelson"),
                            new XElement("zip", 11238)),
                        new XElement("favoriteDrink", "Double Cappuccino"),
                        new XElement("moneySpent", 150),
                        new XElement("visits", 35)),

                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Matt Franks"),
                            new XElement("zip", 11217)),
                        new XElement("favoriteDrink", "Zesty Lemon Chai"),
                        new XElement("moneySpent", 75),
                        new XElement("visits", 15)),

                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Joe Ng"),
                            new XElement("zip", 11217)),
                        new XElement("favoriteDrink", "Banana Split in a Cup"),
                        new XElement("moneySpent", 60),
                        new XElement("visits", 10)),

                    new XElement("person",
                        new XElement("personalInfo",
                            new XElement("name", "Sarah Kalter"),
                            new XElement("zip", 11215)),
                        new XElement("favoriteDrink", "Boring Coffee"),
                        new XElement("moneySpent", 110),
                        new XElement("visits", 15))));

            return doc;
        }
    }
}
