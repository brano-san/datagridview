using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datagridview.Contracts;
using datagridview.Contracts.Models;
using datagridview.TourManager.Models;

namespace datagridview.TourManager
{
    /// <inheritdoc cref="ITourManager"/>
    public class TourManager : ITourManager
    {
        private ITourStorage tourStorage;

        public TourManager(ITourStorage tourStorage)
        {
            this.tourStorage = tourStorage;
        }

        /// <inheritdoc cref="ITourManager.AddTourAsync"/>
        public async Task<Tour> AddTourAsync(Tour tour)
        {
            var result = await tourStorage.AddTourAsync(tour);
            return result;
        }

        /// <inheritdoc cref="ITourManager.DeleteTourAsync"/>
        public async Task<bool> DeleteTourAsync(Guid id)
        {
            var result = await tourStorage.DeleteTourAsync(id);
            return result;
        }

        /// <inheritdoc cref="ITourManager.EditTourAsync"/>
        public Task EditTourAsync(Tour tour)
        => tourStorage.EditTourAsync(tour);

        /// <inheritdoc cref="ITourManager.GetAllToursAsync"/>
        public Task<IReadOnlyCollection<Tour>> GetAllToursAsync()
            => tourStorage.GetAllToursAsync();

        /// <inheritdoc cref="IProductManager.GetStatsAsync"/>
        public async Task<ITourStats> GetStatsAsync()
        {
            var tour = await tourStorage.GetAllToursAsync();
            return new TourStatsModel()
            {
                ToursCount = tour.Count,
                TotalSum = tour.Select(x => x.PeopleCount * x.PricePerTour + x.AdditionalFees).Sum(),
                ToursCountWithAdd = tour.Count(x => x.AdditionalFees != 0),
                AdditionSum = tour.Select(x => x.AdditionalFees).Sum(),
            };
        }
    }
}
