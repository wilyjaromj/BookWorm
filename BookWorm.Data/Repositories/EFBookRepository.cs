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

        public int Add(Book entity)
        {
            try
            {
                return context.Books.Add(entity).Entity.Id;
            }
            catch { return -1; }
        }

        public IEnumerable<Book> All()
        {
            return context.Books.ToList();
        }

        public bool Delete(int id)
        {
            try
            {
                var book = context.Find<Book>(id);
                context.Books.Remove(book);
                return true;
            }
            catch { return false; }
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

        public int Update(Book entity)
        {
            try
            {
                return context.Update(entity).Entity.Id;
            }
            catch { return -1; }
        }
    }
}
