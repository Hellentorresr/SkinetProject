using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
                         //can be called <T> but to be more specific we call it <TEntity>
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
      public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery,ISpecification<TEntity> spec)
      {
            var query = InputQuery;

            //evaluating what's inside the spec param
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);  //Criteria is an expression
            }

            //then evaluating the includes, 
            //using Aggregate because we're combining all of our include operations, example:
             //Include(p => p.ProductType).
             //Include(p => p.ProductBrand)
            
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
      }
    }
}
