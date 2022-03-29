using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using TodoListQL.Data;
using TodoListQL.Models;

namespace TodoListQL.GraphQL.Lists
{
    public class ListType :ObjectType<ItemList>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemList> descriptor)
        {
            //base.Configure(descriptor);

            descriptor.Description("This Model is use for an item of the List");

            descriptor.Field(s => s.ItemDatas)
                .ResolveWith<Resolvers>(s => s.GetItems(default!, default!))
                .UseDbContext<ApiDbContext>()
                .Description("This is the list that item belogs to");
        }

        private class Resolvers
        {
            public IQueryable<ItemData>GetItems(ItemList list, [ScopedService]ApiDbContext context)
            {
                return context.Items.Where(s=>s.ListId == list.Id);
            }
        }
    }

 
}
