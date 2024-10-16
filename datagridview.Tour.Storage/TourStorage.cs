using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datagridview.Contracts;

namespace datagridview.Tour.Storage
{
    /// <summary>
    /// Класс обеспечивающий хранение туров <see cref="tours"/>
    /// </summary>
    public class TourStorage : ITourStorage
    {
        private readonly List<Contracts.Models.Tour> tours = new List<Contracts.Models.Tour>();

        /// <summary>
        /// Метод добавления туров в коллекцию <see cref="tours"/>
        /// </summary>
        public Task<Contracts.Models.Tour> AddTourAsync(Contracts.Models.Tour tour)
        {
            tours.Add(tour);
            return Task.FromResult(tour);
        }

        /// <summary>
        /// Метод удаления туров из коллекции <see cref="tours"/>
        /// </summary>
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

        /// <summary>
        /// Метод редактирования туров в коллекции <see cref="tours"/>
        /// </summary>
        public Task EditTourAsync(Contracts.Models.Tour tour)
        {
            if (tour == null)
            {
                return Task.FromResult(false);
            }

            var target = tours.FirstOrDefault(x => x.Id == tour.Id);
            if (target == null)
            {
                return Task.FromResult(false);
            }

            target.Destination = tour.Destination;
            target.DepartureDate = tour.DepartureDate;
            target.Nights = tour.Nights;
            target.PricePerTour = tour.PricePerTour;
            target.PeopleCount = tour.PeopleCount;
            target.HasWifi = tour.HasWifi;
            target.AdditionalFees = tour.AdditionalFees;
            return Task.CompletedTask;
        }

        /// <summary>
        /// Метод получения коллекции туров <see cref="tours"/>
        /// </summary>
        public Task<IReadOnlyCollection<Contracts.Models.Tour>> GetAllToursAsync()
            => Task.FromResult<IReadOnlyCollection<Contracts.Models.Tour>>(tours);
    }
}
