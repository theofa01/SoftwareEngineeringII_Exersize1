using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Exersize1
{
    public class BookEditionIsbnEqualityComparer : IEqualityComparer<BookEdition>
    {
        public bool Equals(BookEdition? x, BookEdition? y)
        {
            if (x is null && y is null) //If both objects are null, they are considered equal
            {
                return true;
            }

            if (x is null || y is null) //If one of the objects is null and the other is not, they are not equal
            {
                return false;
            }

            return x.Isbn == y.Isbn;
            //In this comparer the checking is based only on the Isbn
        }

        public int GetHashCode(BookEdition obj)
        {
            if (obj is null) //Null checking 
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Isbn.GetHashCode(); //Using the hash code of the ISBN property for hashing
                                           //cause in this case we check base on the Isbn.
        }
    }
}
