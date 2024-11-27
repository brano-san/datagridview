using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datagridview.Contracts;

namespace datagridview.Tour.Storage
{
    /// <inheritdoc cref="ITourStorage"/>
    public class TourStorage : ITourStorage
    {
        private readonly List<Contracts.Models.Tour> tours = new List<Contracts.Models.Tour>();

        /// <inheritdoc cref="ITourStorage.AddTourAsync"/>
        public Task<Contracts.Models.Tour> AddTourAsync(Contracts.Models.Tour tour)
        {
            tours.Add(tour);
            return Task.FromResult(tour);
        }

        /// <inheritdoc cref="ITourStorage.DeleteTourAsync"/>
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

        /// <inheritdoc cref="ITourStorage.EditTourAsync"/>
        public Task EditTourAsync(Contracts.Models.Tour tourToEdit)
        {
            if (tourToEdit == null)
            {
                return Task.FromResult(false);
            }

            var target = tours.FirstOrDefault(x => x.Id == tourToEdit.Id);
            if (target == null)
            {
                return Task.FromResult(false);
            }

            target.Destination = tourToEdit.Destination;
            target.DepartureDate = tourToEdit.DepartureDate;
            target.Nights = tourToEdit.Nights;
            target.PricePerTour = tourToEdit.PricePerTour;
            target.PeopleCount = tourToEdit.PeopleCount;
            target.HasWifi = tourToEdit.HasWifi;
            target.AdditionalFees = tourToEdit.AdditionalFees;
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ITourStorage.GetAllToursAsync"/>
        public Task<IReadOnlyCollection<Contracts.Models.Tour>> GetAllToursAsync()
            => Task.FromResult<IReadOnlyCollection<Contracts.Models.Tour>>(tours);
    }
}
