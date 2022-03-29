using HotChocolate;
using HotChocolate.Data;
using System.Threading.Tasks;
using TodoListQL.Data;
using TodoListQL.GraphQL.Lists;
using TodoListQL.Models;

namespace TodoListQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddListPayload> AddListAsync(AddListInput addListInput, [ScopedService] ApiDbContext context)
        {
            var list = new ItemList
            {
                Name = addListInput.name
            };

            context.Lists.Add(list);
            await context.SaveChangesAsync();

            return new AddListPayload(list);
        }


        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddItemPayload> AddItemDataAsync(AddItemInput input, [ScopedService] ApiDbContext context)
        {
            var itemData = new ItemData
            { Description = input.description,
            IsDone = input.isDone,
            Title = input.title,
            ListId = input.listId
            };

            context.Items.Add(itemData);
            await context.SaveChangesAsync();

            return new AddItemPayload(itemData);
        }
    }
}
