using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace BookWorm.Data
{
    public class BookMap : ClassMapping<Book>
    {
        public BookMap()
        {
            Id(b => b.Id, b =>
            {
                b.Generator(Generators.Native);
                b.Type(NHibernateUtil.Int32);
                b.Column("Id");
                b.UnsavedValue(0);
            });

            Property(b => b.Title, b =>
            {
                b.Length(250);
                b.Type(NHibernateUtil.String);
                b.NotNullable(true);
            });

            Property(b => b.Author, b =>
            {
                b.Length(150);
                b.Type(NHibernateUtil.String);
                b.NotNullable(true);
            });

            Property(b => b.CoverArt, b =>
            {
                b.Length(int.MaxValue);
                b.Type(NHibernateUtil.BinaryBlob);
                b.NotNullable(false);
            });

            Property(b => b.Description, b =>
            {
                b.Length(2500);
                b.Type(NHibernateUtil.String);
                b.NotNullable(false);
            });

            Property(b => b.Rating, b =>
            {
                b.Type(NHibernateUtil.Int32);
                b.NotNullable(false);
            });

            Property(b => b.Series, b =>
            {
                b.Length(200);
                b.Type(NHibernateUtil.String);
                b.NotNullable(false);
            });

            Table("Book");
        }
    }
}
