using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class ShoppingListFilter
    {
    //     public static IQueryable<QueryObject> ApplyFilters(QueryObject query)
    // {
    //     // Filtro Name 
    //     if (!string.IsNullOrWhiteSpace(query.Name)) 
    //     {
    //       shoppingLists = shoppingLists.Where( l => l.Name.Contains(query.Name)); 
    //     }

    //     // Filtro IsPurchase 
    //     if (query.IsPurchased.HasValue) 
    //     {
    //       shoppingLists = shoppingLists.Where(l => l.IsPurchased == query.IsPurchased.Value);
    //     }

    //     // Filtro Date 
    //     if (query.CreatedOn.HasValue) 
    //     {
    //       if (query.DateTimeFilterBefore) 
    //       {
    //         shoppingLists = shoppingLists.Where(l => l.CreatedOn.Date < query.CreatedOn.Value.Date);
    //       }

    //       if (query.DateTimeFilterAfter) 
    //       {
    //         shoppingLists = shoppingLists.Where(l => l.CreatedOn.Date > query.CreatedOn.Value.Date);
    //       }

    //       if (!query.DateTimeFilterBefore && !query.DateTimeFilterAfter) 
    //       {
    //         shoppingLists = shoppingLists.Where(l => l.CreatedOn.Date == query.CreatedOn.Value.Date);
    //       }
    //     }

    //     return query;
    // }
    }
}