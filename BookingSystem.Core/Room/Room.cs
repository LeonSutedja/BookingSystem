namespace BookingSystem
{
    using Abp.Domain.Entities;

    public class Room : Entity<int>
    {
        public static Room Create(string name)
        {
            return new Room(name);
        }

        public string Name { get; private set; }

        protected Room() { }

        private Room(string name)
        {
            Name = name;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
