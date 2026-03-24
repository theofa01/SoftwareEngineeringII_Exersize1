using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Exersize1
{
    public class BookEditionYearTitleComparer: IComparer<BookEdition>
    {
        public int Compare(BookEdition? x, BookEdition? y)
        {
            if (x is null && y is null) //The comparison cannot happen if both are null
            {
                throw new ArgumentNullException(nameof(x));
            }

            if (x is null || y is null) //The comparison cannot happen if one of them is null
            {
                throw new ArgumentNullException();
            }

            if (x.PublicationYear != y.PublicationYear)
            {
                return x.PublicationYear.CompareTo(y.PublicationYear);
            }

            if (x.Title != y.Title)
            {
                return x.Title.CompareTo(y.Title);
            }
            //checking based on the alternative properties in this Comparer

            return 0;
        }
    }
}
