using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        //generic properties
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; } 
    }
}
