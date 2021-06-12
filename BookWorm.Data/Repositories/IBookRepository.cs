using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookWorm.Data
{
    public interface IBookRepository
    {
        int Add(Book entity);
        int Update(Book entity);
        Book Get(int id);
        bool Delete(int id);
        IEnumerable<Book> All();
        IEnumerable<Book> Find(Expression<Func<Book, bool>> predicate);
        void SaveChanges();
    }
}
