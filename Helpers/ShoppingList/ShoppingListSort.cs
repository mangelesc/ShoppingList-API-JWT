using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers.ShoppingList
{
    public static class ShoppingListSort
    {
        public static IQueryable<QueryObject> ApplySorting(this IQueryable<QueryObject> query, string sortBy, bool isDescending)
        {
            // Sin ordenamiento si sortBy está vacío
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                return query; 
            }

            // Aplicar ordenamiento según el campo
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                return isDescending ? query.OrderByDescending(l => l.Name) : query.OrderBy(l => l.Name);
            }
            else if (sortBy.Equals("CreatedOn", StringComparison.OrdinalIgnoreCase))
            {
                return isDescending ? query.OrderByDescending(l => l.CreatedOn) : query.OrderBy(l => l.CreatedOn);
            }

            return query; // Sin cambios si sortBy no coincide
        }
    }
}