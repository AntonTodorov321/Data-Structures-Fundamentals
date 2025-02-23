namespace PublicTransportManagementSystem
{
    using System;
    using System.Collections.Generic;

    public class Bus : IComparable<Bus>
    {
        private List<Passenger> passengers;

        public Bus()
        {
            this.passengers = new List<Passenger>();
        }

        public string Id { get; set; }

        public string Number { get; set; }

        public int Capacity { get; set; }

        public override string ToString()
        {
            return this.Id;
        }

        public void AddPassenger(Passenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public void RemovePassenger(Passenger passenger)
        {
            if (!this.passengers.Contains(passenger))
            {
                throw new ArgumentException();
            }

            this.passengers.Remove(passenger);
        }

        public IEnumerable<Passenger> GetPassengers()
        {
            return this.passengers;
        }

        public int CompareTo(Bus other)
        {
            return this.passengers.Count.CompareTo(other.passengers.Count);
        }
    }
}