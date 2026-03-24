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
            Console.WriteLine("Books sorted by the IComparable interface: ");
            Console.WriteLine("------------------------");
            PrintBooks(books);
            Console.WriteLine();
        }

        private static void PrintBooks(List<BookEdition> books)
        {
            foreach (BookEdition edition in books)
            {
                Console.WriteLine(edition);
            }
        }
    }
}