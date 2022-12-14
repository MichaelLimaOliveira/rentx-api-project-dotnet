namespace RentX.Domain
{
    internal class CarImage
    {
        public CarImage(
            Guid id,
            Car car,
            string imageName)
        {
            Id = id;
            Car = car;
            ImageName = imageName;
        }

        public Guid Id { get; protected set; }
        public Car Car { get; protected set; }
        public string ImageName { get; protected set; }
    }
}
