using HotChocolate;

namespace TodoListQL.Models
{
    //[GraphQLDescription("this is the Tble of Data Model")] => this is Not a best practice, that's why we will not use this approach
    public class ItemData
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public bool IsDone { get; set; }

        public int ListId { get; set; }

        public virtual ItemList ItemList { get; set; }
    }
}
