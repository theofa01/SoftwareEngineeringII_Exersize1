namespace SE_Exersize1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<BookEdition> books = new List<BookEdition>();

            using (StreamReader bookReader = new StreamReader("books.txt"))
            {
                while (!bookReader.EndOfStream)
                {
                    String isbn = bookReader.ReadLine();
                    String title = bookReader.ReadLine();
                    String author = bookReader.ReadLine();
                    int editionNumber = int.Parse(bookReader.ReadLine());
                    int publicationYear = int.Parse(bookReader.ReadLine());
                    int price = int.Parse(bookReader.ReadLine());
                    bookReader.ReadLine();

                    books.Add(new BookEdition(isbn, title, author, editionNumber, publicationYear, price));
                }

                Console.WriteLine("Books: ");
                Console.WriteLine("------------------------");
                PrintBooks(books);
                Console.WriteLine();
            }

            books.Sort();
            Console.WriteLine("Books sorted by the IComparable interface (default comparer): ");
            Console.WriteLine("------------------------");
            PrintBooks(books);
            Console.WriteLine();

            books.Sort(new BookEditionYearTitleComparer());
            Console.WriteLine("Books sorted by the IComparer interface (year title): ");
            Console.WriteLine("------------------------");
            PrintBooks(books);
            Console.WriteLine(); // this time we have different order because the
            // IComparer interface sorts only by year and title

            HashSet<BookEdition> bookHashSetDefault = new HashSet<BookEdition>(books);
            HashSet<BookEdition> bookHashSetAlternative = new HashSet<BookEdition>(books,
                new BookEditionIsbnEqualityComparer());

            Console.WriteLine("Books in the HashSet with the default equality class: ");
            Console.WriteLine("------------------------");
            PrintBooks(bookHashSetDefault.ToList());
            Console.WriteLine();

            Console.WriteLine("Books in the HashSet with the alternative equality class: ");
            Console.WriteLine("------------------------");
            PrintBooks(bookHashSetAlternative.ToList());
            Console.WriteLine(); //this time the two different editions of the books Salem's Lot
            //do not appear twice in the Hashset as before because the
            //alternative equality class compare only by the isbn

            SortedSet<BookEdition> bookSortSetDefault = new SortedSet<BookEdition>(books);
            SortedSet<BookEdition> bookSortSetAlternative = new SortedSet<BookEdition>(books,
                new BookEditionYearTitleComparer());

            Console.WriteLine("Books in the SortSet with the default comparer: ");
            Console.WriteLine("------------------------");
            PrintBooks(bookSortSetDefault.ToList());
            Console.WriteLine();

            Console.WriteLine("Books in the SortSet with the alternative comparer class: ");
            Console.WriteLine("------------------------");
            PrintBooks(bookSortSetAlternative.ToList());
            Console.WriteLine(); //same items with the HashSets only this time we have alphabetical
            //order because we use SortedSet

            Dictionary<BookEdition, String> dictBooksDefault = new Dictionary<BookEdition, String>();
            Dictionary<BookEdition, String> dictBooksAlternative =
                new Dictionary<BookEdition, String>(new BookEditionIsbnEqualityComparer());

            foreach (BookEdition edition in books)
            {
                try
                {
                    dictBooksDefault.Add(edition, edition.Title);
                    dictBooksAlternative.Add(edition, edition.Title);
                }
                catch (ArgumentException ex)
                {
                    continue;
                }
            }

            Console.WriteLine("Books in the Dictionary (keys, values) with the default equality class");
            Console.WriteLine("------------------------");
            PrintBooks(dictBooksDefault);
            Console.WriteLine();

            Console.WriteLine("Books in the Dictionary (keys, values) with the alternative equality class");
            Console.WriteLine("------------------------");
            PrintBooks(dictBooksAlternative);
            Console.WriteLine();
        }

        private static void PrintBooks(List<BookEdition> books)
        {
            foreach (BookEdition edition in books)
            {
                Console.WriteLine(edition);
            }
        }

        private static void PrintBooks(Dictionary<BookEdition, string> books)
        {
            foreach (BookEdition book in books.Keys)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("------------------------");

            foreach (string title in books.Values)
            {
                Console.WriteLine(title);
            }
        }
    }
}