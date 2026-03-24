namespace SE_Exersize1
{
    public class BookEdition: IEquatable<BookEdition>, IComparable<BookEdition>
    {
        public string Isbn { get; }
        public string Title { get; }
        public string Author { get; }
        public int EditionNumber { get; }
        public int PublicationYear { get; }
        public int DecimalPrice { get; }

        public BookEdition(string isbn, string title, string author, int editionNumber, int publicationYear, int decimalPrice)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            EditionNumber = editionNumber;
            PublicationYear = publicationYear;
            DecimalPrice = decimalPrice;
        }

        public bool Equals(BookEdition? other)
        {
            if (other is null) //if the other object is null, then they are not equal
            {
                return false;
            }

            if (ReferenceEquals(this, other)) //if the reference is the same, then they are equal
            {
                return true;
            }

            if (other.Isbn == this.Isbn && other.Title == this.Title && other.Author == this.Author
                && other.EditionNumber == this.EditionNumber
                && other.PublicationYear == this.PublicationYear) //if all the properties that are part of the equality
                                                                  //check are the same, then they are equal
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(BookEdition? book1, BookEdition? book2)
        {
            if (book1 is null && book2 is null) //if both objects are null, then they are equal
            {
                return true;
            }

            if (book1 is null || book2 is null) //if one of the objects is null, then they are not equal
            {
                return false;
            }

            return book1.Equals(book2); //if both objects are not null,
                                        //then we can use the Equals method to check for equality
        }

        public static bool operator !=(BookEdition? book1, BookEdition? book2)
        {
            if (book1 is null && book2 is null) //if both objects are null, then they are equal, but we are checking
                                                //for inequality, so we return false
            {
                return false;
            }

            if (book1 is null || book2 is null) //if one of the objects is null, then they are not equal,
                                                //but we are checking for inequality, so we return true
            {
                return true;
            }

            return !book1.Equals(book2); //if both objects are not null, then we can use the Equals method to check for equality,
                                         //but we are checking for inequality, so we return the opposite of the Equals method
        }

        public int CompareTo(BookEdition? other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other)); //The comparison cannot be done if
                                                                //the other object is null
            }

            if (other.Title != this.Title)
            {
                return this.Title.CompareTo(other.Title);
            }

            if (other.Author != this.Author)
            {
                return this.Author.CompareTo(other.Author);
            }

            if (other.EditionNumber != this.EditionNumber)
            {
                return this.EditionNumber.CompareTo(other.EditionNumber);
            }

            if (other.PublicationYear != this.PublicationYear)
            {
                return this.PublicationYear.CompareTo(other.PublicationYear);
            }

            return 0;
        }

        public static bool operator >(BookEdition? book1, BookEdition? book2)
        {
            if (book1 is null && book2 is null) //the comparison cannot be done if both objects are null
            {
                throw new ArgumentNullException();
            }

            if (book1 is null || book2 is null) //the comparison cannot be done if one of the objects is null
            {
                throw new ArgumentNullException();
            }

            if (book1.CompareTo(book2) > 0) //if the result of the comparison is greater than zero we return true 
            {
                return true;
            }

            return false;
        }

        public static bool operator <(BookEdition? book1, BookEdition? book2)
        {
            if (book1 is null && book2 is null) //the comparison cannot be done if both objects are null
            {
                throw new ArgumentNullException();
            }

            if (book1 is null || book2 is null) //the comparison cannot be done if one of the objects is null
            {
                throw new ArgumentNullException();
            }

            if (book1.CompareTo(book2) < 0) //if the result of the comparison is less than zero we return true
            {
                return true;
            }

            return false;
        }

        public static bool operator >=(BookEdition? book1, BookEdition? book2)
        {
            if (book1 is null && book2 is null) //the comparison cannot be done if both objects are null
            {
                throw new ArgumentNullException();
            }

            if (book1 is null || book2 is null) //the comparison cannot be done if one of the objects is null
            {
                throw new ArgumentNullException();
            }

            if (book1.CompareTo(book2) >= 0) //if the result of the comparison is greater than or equal to zero we return true
            {
                return true;
            }

            return false;
        }

        public static bool operator <=(BookEdition? book1, BookEdition? book2)
        {
            if (book1 is null && book2 is null) //the comparison cannot be done if both objects are null
            {
                throw new ArgumentNullException();
            }

            if (book1 is null || book2 is null) //the comparison cannot be done if one of the objects is null
            {
                throw new ArgumentNullException();
            }

            if (book1.CompareTo(book2) <= 0) //if the result of the comparison is less than or equal to zero we return true
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not BookEdition) //type checking if it is null or of a different type
                                        //then they are not equal
            {
                return false;
            }

            BookEdition book = obj as BookEdition;

            if (base.Equals(book)) //if the reference is the same, then they are equal
            {
                return true;
            }

            if (book.Isbn == this.Isbn && book.Title == this.Title && book.Author == this.Author
                && book.EditionNumber == this.EditionNumber 
                && book.PublicationYear == this.PublicationYear) //if all the properties that are part of the equality
                                                                 //check are the same, then they are equal
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Isbn.Length + this.Title.Length + this.Author.Length +
                   this.EditionNumber + this.PublicationYear; //we are not including the price in the hash code because
                                                              //it is not part of the equality check
        }

        public override string ToString()
        {
            return $"Isbn: {this.Isbn} " +
                   $"Title: {this.Title} " +
                   $"Author: {this.Author} " +
                   $"EditionNumber: {this.EditionNumber} " +
                   $"PublicationYear: {this.PublicationYear} " +
                   $"DecimalPrice: {this.DecimalPrice}";
        }
    }
}
