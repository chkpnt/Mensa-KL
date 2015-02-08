using Microsoft.Data.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensa_KL.Tests
{
    static class ExtensionMethods
    {
        // Source: http://stackoverflow.com/questions/21069986/nsubstitute-dbset-iqueryablet
        public static Mock<DbSet<T>> Initialize<T>(this Mock<DbSet<T>> dbSet, IQueryable<T> data) where T : class
        {
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return dbSet;
        }
    }
}
