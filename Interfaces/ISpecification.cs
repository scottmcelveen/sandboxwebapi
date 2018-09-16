using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SandboxWebAPI.Interfaces
{
    public interface ISpecification<T>
    {
        int? PageSize { get; set; }
        int? PageNumber { get; set; }
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}