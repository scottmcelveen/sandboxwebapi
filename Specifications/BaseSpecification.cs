using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SandboxWebAPI.Interfaces;

namespace SandboxWebAPI.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification(Expression<Func<T, bool>> criteria) : this(criteria, null, null) { }
        protected BaseSpecification(Expression<Func<T, bool>> criteria, int? pageSize, int? pageNumber)
        {
            Criteria = criteria;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}