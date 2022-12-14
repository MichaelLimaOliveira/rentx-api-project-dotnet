namespace RentX.Domain
{
    public class Rental
    {
        public Rental(
            Guid id, 
            Car car, 
            User user, 
            DateTime expectedReturnDate)
        {
            Id = id;
            SetCar(car);
            SetUser(user);
            SetExpectedReturnDate(expectedReturnDate);
            StartDate = DateTime.Now;
        }

        public Guid Id { get; protected set; }
        public Car Car { get; protected set; }
        public User User { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }
        public DateTime ExpectedReturnDate { get; protected set; }
        public decimal? Total { get; protected set; }

        public void SetCar(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException("Car cannot be null!");
            }

            Car = car;
        }

        public void SetUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null!");
            }

            User = user;
        }

        public void SetExpectedReturnDate(DateTime expectedReturnDate)
        {
            var timeDifference = DateTime.Now.Subtract(expectedReturnDate);
            var dayTimeInMinutes = 3600;
            if (timeDifference.Minutes < dayTimeInMinutes)
            {
                throw new ArgumentException("Minimum rental time is 24 hours");
            };

            ExpectedReturnDate = expectedReturnDate;
        }

        public void FinishRental()
        {
            Total = CalculateTotalRentalValue();
            EndDate = DateTime.Now;
        }

        private decimal CalculateTotalRentalValue()
            => CalculateRentalValue() + CalculateDelayFineAmount();

        private decimal CalculateDelayFineAmount()
        {
            var devulationDate = DateTime.Now;
            var delayDays = devulationDate.Subtract(ExpectedReturnDate).Days;

            if (delayDays <= 0)
                return 0;

            var fineAmount = delayDays * Car.FineAmount;

            return fineAmount;
        }
        
        private decimal CalculateRentalValue()
        {
            var devolutionDate = DateTime.Now;
            var minimumRentDays = 1;
            var totalRentDays = devolutionDate.Subtract(StartDate).Days;

            if (totalRentDays < minimumRentDays)
                totalRentDays = minimumRentDays;

            var rentalValue = totalRentDays * Car.DailyRate;

            return rentalValue;
        }
    }
}
