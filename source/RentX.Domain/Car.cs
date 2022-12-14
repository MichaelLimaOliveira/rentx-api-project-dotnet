namespace RentX.Domain
{
    public class Car
    {
        public Car(
            Guid id,
            string name,
            string description,
            decimal dailyRate,
            string licensePlate,
            decimal fineAmount,
            string brand,
            Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            DailyRate = dailyRate;
            Available = true;
            LicensePlate = licensePlate;
            FineAmount = fineAmount;
            Brand = brand;
            Category = category;
            Specifications = new List<Specification>();
        }

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal DailyRate { get; protected set; }
        public bool Available { get; protected set; }
        public string LicensePlate { get; protected set; }
        public decimal FineAmount { get; protected set; }
        public string Brand { get; protected set; }
        public Category Category { get; protected set; }
        public List<Specification> Specifications { get; protected set; }

        public void AddSpecification(Specification specification)
        {
            if(specification == null) 
            { 
                throw new ArgumentNullException("Specification cannot be null!"); 
            }

            if(Specifications.Any(s => s.Id == specification.Id))
            {
                throw new ArgumentException("Specification already bound");
            }

            Specifications.Add(specification);
        }

        public void SetAvailability(bool available)
        {
            Available = available;
        }
    }
}
