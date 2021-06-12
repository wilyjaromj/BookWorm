using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookWorm.Data
{
    public interface IBookRepository
    {
        Book Add(Book entity);
        Book Update(Book entity);
        Book Get(int id);
        Book Delete(int id);
        IEnumerable<Book> All();
        IEnumerable<Book> Find(Expression<Func<Book, bool>> predicate);
        void SaveChanges();
    }
}
