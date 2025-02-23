namespace PublicTransportManagementSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PublicTransportRepository : IPublicTransportRepository
    {
        private List<Passenger> passengers;
        private List<Bus> buses;

        public PublicTransportRepository()
        {
            this.passengers = new List<Passenger>();
            this.buses = new List<Bus>();
        }

        public void RegisterPassenger(Passenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public void AddBus(Bus bus)
        {
            this.buses.Add(bus);
        }

        public bool Contains(Passenger passenger)
        {
            return this.passengers.Contains(passenger);
        }

        public bool Contains(Bus bus)
        {
            return this.buses.Contains(bus);
        }

        public IEnumerable<Bus> GetBuses()
        {
            return this.buses;
        }

        public void BoardBus(Passenger passenger, Bus bus)
        {
            if (!this.passengers.Contains(passenger) || !this.buses.Contains(bus))
            {
                throw new ArgumentException();
            }

            bus.AddPassenger(passenger);
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
            if (!this.passengers.Contains(passenger) || !this.buses.Contains(bus))
            {
                throw new ArgumentException();
            }

            bus.RemovePassenger(passenger);
        }

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus)
        {
            return bus.GetPassengers();
        }

        public IEnumerable<Bus> GetBusesOrderedByOccupancy()
        {
            return this.buses.OrderBy(bus => bus);
        }

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity)
        {
            return this.buses.FindAll(bus => bus.Capacity >= capacity);
        }
    }
}