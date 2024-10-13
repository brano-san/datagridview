using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using datagridview.Contracts;
using datagridview.Contracts.Models;

namespace datagridview.TourManager
{
    public class TourManager : ITourManager
    {
        private ITourStorage tourStorage;

        public TourManager(ITourStorage tourStorage)
        {
            this.tourStorage = tourStorage;
        }

        public async Task<Tour> AddTourAsync(Tour tour)
        {
            var result = await tourStorage.AddTourAsync(tour);
            return result;
        }

        public async Task<bool> DeleteTourAsync(Guid id)
        {
            var result = await tourStorage.DeleteTourAsync(id);
            return result;
        }

        public Task EditTourAsync(Tour tour)
            => tourStorage.EditTourAsync(tour);

        public Task<IReadOnlyCollection<Tour>> GetAllToursAsync()
            => tourStorage.GetAllToursAsync();
    }
}
