using System;
using System.Collections.Generic;
using System.Text;

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
            if (other == null)
            {
                return false;
            }

            if (this == other)
            {
                return true;
            }

            if (other.Isbn == this.Isbn && other.Title == this.Title && other.Author == this.Author
                && other.EditionNumber == this.EditionNumber
                && other.PublicationYear == this.PublicationYear)
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(BookEdition? book1, BookEdition? book2)
        {
            if (book1 == null && book2 == null)
            {
                return true;
            }

            if (book1 == null || book2 == null)
            {
                return false;
            }

            return book1.Equals(book2);
        }

        public static bool operator !=(BookEdition? book1, BookEdition? book2)
        {
            if (book1 == null && book2 == null)
            {
                return false;
            }

            if (book1 == null || book2 == null)
            {
                return true;
            }

            return !book1.Equals(book2);
        }

        public int CompareTo(BookEdition? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (other.Title != this.Title)
            {
                return other.Title.CompareTo(this.Title);
            }

            if (other.Author != this.Author)
            {
                return other.Author.CompareTo(this.Author);
            }

            if (other.EditionNumber != this.EditionNumber)
            {
                return other.EditionNumber.CompareTo(this.EditionNumber);
            }

            if (other.PublicationYear != this.PublicationYear)
            {
                return other.PublicationYear.CompareTo(this.PublicationYear);
            }

            return 0;
        }

        public static bool operator >(BookEdition? book1, BookEdition? book2)
        {
            if (book1 == null && book2 == null)
            {
                throw new ArgumentNullException();
            }

            if (book1 == null || book2 == null)
            {
                throw new ArgumentNullException();
            }

            if (book1.CompareTo(book2) > 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(BookEdition? book1, BookEdition? book2)
        {
            if (book1 == null && book2 == null)
            {
                throw new ArgumentNullException();
            }

            if (book1 == null || book2 == null)
            {
                throw new ArgumentNullException();
            }

            if (book1.CompareTo(book2) < 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator >=(BookEdition? book1, BookEdition? book2)
        {
            if (book1 == null && book2 == null)
            {
                throw new ArgumentNullException();
            }

            if (book1 == null || book2 == null)
            {
                throw new ArgumentNullException();
            }

            if (book1.CompareTo(book2) >= 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator <=(BookEdition? book1, BookEdition? book2)
        {
            if (book1 == null && book2 == null)
            {
                throw new ArgumentNullException();
            }

            if (book1 == null || book2 == null)
            {
                throw new ArgumentNullException();
            }

            if (book1.CompareTo(book2) <= 0)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not BookEdition)
            {
                return false;
            }

            BookEdition book = obj as BookEdition;

            if (base.Equals(book))
            {
                return true;
            }

            if (book.Isbn == this.Isbn && book.Title == this.Title && book.Author == this.Author
                && book.EditionNumber == this.EditionNumber 
                && book.PublicationYear == this.PublicationYear)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Isbn.Length + this.Title.Length + this.Author.Length +
                   this.EditionNumber + this.PublicationYear;
        }

        public override string ToString()
        {
            return $"Isbn: {this.Isbn}" +
                   $"Title: {this.Title}" +
                   $"Author: {this.Author}" +
                   $"EditionNumber: {this.EditionNumber}" +
                   $"PublicationYear: {this.PublicationYear}" +
                   $"DecimalPrice: {this.DecimalPrice}";
        }
    }
}
