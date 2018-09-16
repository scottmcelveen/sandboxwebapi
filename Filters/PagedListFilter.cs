using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using X.PagedList;

namespace SandboxWebAPI.Filters
{
    public class PagedListFilter : IResultFilter
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        public PagedListFilter(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result as ObjectResult;
            if(result == null) return;
            var pagedList = result.Value as IPagedList;
            if(pagedList == null) return;

            var query = context.HttpContext.Request.Query;
            var routeName = (context.ActionDescriptor as ControllerActionDescriptor).AttributeRouteInfo.Name;

            var routeValueDictionary = new RouteValueDictionary();
            foreach(var item in query)
            {
                routeValueDictionary.Add(item.Key, item.Value);
            }

            var urlHelper = urlHelperFactory.GetUrlHelper(context);
            var links = new List<string>();

            if(pagedList.HasNextPage)
            {
                routeValueDictionary["pageNumber"] = pagedList.PageNumber + 1;
                links.Add(buildLink(routeName, routeValueDictionary, urlHelper, "next"));
            }
            if(!pagedList.IsLastPage)
            {
                routeValueDictionary["pageNumber"] = pagedList.PageCount;
                links.Add(buildLink(routeName, routeValueDictionary, urlHelper, "last"));
            }
            if(pagedList.HasPreviousPage)
            {
                routeValueDictionary["pageNumber"] = pagedList.PageNumber - 1;
                links.Add(buildLink(routeName, routeValueDictionary, urlHelper, "prev"));
            }
            if(!pagedList.IsFirstPage)
            {
                routeValueDictionary["pageNumber"] = 1;
                links.Add(buildLink(routeName, routeValueDictionary, urlHelper, "first"));
            }
            if(!links.Any()) return;
            context.HttpContext.Response.Headers["Link"] = string.Join(", ", links);
        }

        private string buildLink(string routeName, RouteValueDictionary routeValues, IUrlHelper urlHelper, string rel)
        {
            var link = urlHelper.Link(routeName, routeValues);
            return $"<{link}>; rel=\"{rel}\"";
        }
    }
}