using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookWorm.Data
{
    public class EFBookRepository : IBookRepository
    {
        BookContext context;

        public EFBookRepository()
        {
            this.context = new BookContext();
        }

        public Book Add(Book entity)
        {
            return context.Books.Add(entity).Entity;
        }

        public IEnumerable<Book> All()
        {
            return context.Books.ToList();
        }

        public Book Delete(int id)
        {
            var book = context.Find<Book>(id);
            context.Books.Remove(book);
            return book;
        }

        public IEnumerable<Book> Find(Expression<Func<Book, bool>> predicate)
        {
            return context.Books.Where(predicate).ToList();
        }

        public Book Get(int id)
        {
            return context.Find<Book>(id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Book Update(Book entity)
        {
            return context.Update(entity).Entity;
        }
    }
}
