namespace BookingSystem
{
    using Abp.Domain.Entities;

    public class Room : Entity
    {
        public static Room Create(string name, int numberOfPeople)
        {
            return new Room(name, numberOfPeople);
        }

        public string Name { get; private set; }

        public int NumberOfPeople { get; private set; }

        protected Room() { }

        private Room(string name, int numberOfPeople)
        {
            Name = name;
            NumberOfPeople = numberOfPeople;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
