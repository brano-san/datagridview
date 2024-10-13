using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datagridview.Contracts;

namespace datagridview.Tour.Storage
{
    public class TourStorage : ITourStorage
    {
        private readonly List<Contracts.Models.Tour> tours = new List<Contracts.Models.Tour>();

        public Task<Contracts.Models.Tour> AddTourAsync(Contracts.Models.Tour tour)
        {
            tours.Add(tour);
            return Task.FromResult(tour);
        }

        public Task<bool> DeleteTourAsync(Guid id)
        {
            var person = tours.FirstOrDefault(x => x.Id == id);
            if (person != null)
            {
                tours.Remove(person);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task EditTourAsync(Contracts.Models.Tour tour)
        {
            var target = tours.FirstOrDefault(x => x.Id == tour.Id);
            if (tour != null)
            {
                target.Destination = tour.Destination;
                target.DepartureDate = tour.DepartureDate;
                target.Nights = tour.Nights;
                target.PricePerTour = tour.PricePerTour;
                target.PeopleCount = tour.PeopleCount;
                target.HasWifi = tour.HasWifi;
                target.AdditionalFees = tour.AdditionalFees;
            }

            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Contracts.Models.Tour>> GetAllToursAsync()
            => Task.FromResult<IReadOnlyCollection<Contracts.Models.Tour>>(tours);
    }
}
