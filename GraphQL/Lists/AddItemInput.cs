namespace TodoListQL.GraphQL.Lists
{
    public record AddItemInput(string title, string description, bool isDone, int listId);

}
