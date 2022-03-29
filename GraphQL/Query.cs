using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using TodoListQL.Data;
using TodoListQL.Models;

namespace TodoListQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection] // We use this for join Query (It Allows nesded Object in the query)
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList>GetItemsList([ScopedService] ApiDbContext context)
        {
            return context.Lists;
        }

        [UseDbContext(typeof (ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData>GetItemDataList([ScopedService] ApiDbContext context)
        {
            return context.Items;
        }
    }
}
