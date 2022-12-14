namespace RentX.Domain
{
    public class Category
    {
        public Category(
            Guid id,
            string name,
            string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}
