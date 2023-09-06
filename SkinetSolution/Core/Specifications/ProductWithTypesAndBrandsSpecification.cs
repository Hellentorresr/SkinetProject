using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Products>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            AddInclude(product => product.ProductType);
            AddInclude(product => product.ProductBrand);
        }

        //implementing the second constructor of 'BaseSpecification' with parameter
        public ProductWithTypesAndBrandsSpecification(int PId) : base(product => product.Id == PId) //constructor initializer or constructor chaining
        {
            AddInclude(prod => prod.ProductType);
            AddInclude(prod => prod.ProductBrand);
        }
    }
}