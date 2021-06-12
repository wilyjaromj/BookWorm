using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookWorm.Data
{
    public class NHibernateBookRepository : IBookRepository
    {
        private readonly ISession session;
        private ITransaction transaction;

        public NHibernateBookRepository(ISession session)
        {
            this.session = session;
        }

        public int Add(Book entity)
        {
            BeginTransaction();
            try
            {
                session.Save(entity);
                return entity.Id;
            }
            catch
            {
                RollbackTransaction();
                CloseTransaction();
                return -1;
            }
        }

        public IEnumerable<Book> All()
        {
            return session.Query<Book>().ToList();
        }

        public bool Delete(int id)
        {
            BeginTransaction();
            try
            {
                session.Delete(session.Get<Book>(id));
                return true;
            }
            catch
            {
                RollbackTransaction();
                CloseTransaction();
                return false;
            }
        }

        public IEnumerable<Book> Find(Expression<Func<Book, bool>> predicate)
        {
            return session.Query<Book>().Where(predicate).ToList();
        }

        public Book Get(int id)
        {
            return session.Get<Book>(id);
        }

        public void SaveChanges()
        {
            transaction.Commit();
            CloseTransaction();
        }

        public int Update(Book entity)
        {
            BeginTransaction();
            try
            {
                session.Update(entity);
                return entity.Id;
            }
            catch
            {
                RollbackTransaction();
                CloseTransaction();
                return -1;
            }        
        }

        private void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        private void RollbackTransaction()
        {
            transaction.Rollback();
        }

        private void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }
    }
}
