using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        // >> Properties << 
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();


        //  >> Constructors <<
        public BaseSpecification(){}

        public BaseSpecification(Expression<Func<T, bool>> criteria) { 
            Criteria = criteria;
        }

        //creating a method to add include statements to the Include list
        protected void AddInclude(Expression<Func<T, object>> includeExpression) 
        { 
            //This property `Include`
            Includes.Add(includeExpression);
        }
    }
}
