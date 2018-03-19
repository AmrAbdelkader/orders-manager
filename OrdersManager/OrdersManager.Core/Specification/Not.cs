using OrdersManager.Core.Specification;
using System;
using System.Linq.Expressions;

namespace OrdersManager.Core.Specification
{
    public class Not<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> _inner;

        public Not(ISpecification<T> inner)
        {
            _inner = inner;
        }
        
        public override Expression<Func<T, bool>> SpecExpression
        {
            get
            {
                var objParam = Expression.Parameter(typeof(T), "obj");

                var newExpr = Expression.Lambda<Func<T, bool>>(
                    Expression.Not(
                        Expression.Invoke(this._inner.SpecExpression, objParam)
                    ),
                    objParam
                );

                return newExpr;
            }
        }
    }
}
