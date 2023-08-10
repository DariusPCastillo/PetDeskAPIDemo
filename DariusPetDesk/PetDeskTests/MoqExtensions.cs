using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Moq;
namespace PetDeskTests
{
    internal static class MoqExtensions
    {
        public static Mock<T> SetupFunc<T, TR>(this Mock<T> moq, Expression<Func<T, TR>> expression, TR returns) where T : class
        {
            moq.Setup(expression).Returns(returns);
            return moq;
        }
        public static Mock<T> SetupAction<T>(this Mock<T> moq, Expression<Action<T>> expression) where T : class
        {
            moq.Setup(expression);
            return moq;
        }
    }
}
