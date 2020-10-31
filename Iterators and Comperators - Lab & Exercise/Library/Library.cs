using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public partial class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new SortedSet<Book>(books, new BookComparator());
        }

        public SortedSet<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int index;
            private List<Book> books;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = books.ToList();
            }

            public Book Current => this.books[index];

            object IEnumerator.Current => this.Current;

            public void Dispose() {}

            public bool MoveNext()
            {
                return ++this.index < this.books.Count;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
