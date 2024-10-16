using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datagridview.Contracts;
using datagridview.Contracts.Models;
using datagridview.TourManager.Models;

namespace datagridview.TourManager
{
    /// <summary>
    /// Класс управления хранилищем туров <see cref="tourStorage"/>
    /// </summary>
    public class TourManager : ITourManager
    {
        private ITourStorage tourStorage;

        public TourManager(ITourStorage tourStorage)
        {
            this.tourStorage = tourStorage;
        }

        /// <summary>
        /// Метод для добавления тура в коллекцию <see cref="tourStorage"/>
        /// </summary>
        public async Task<Tour> AddTourAsync(Tour tour)
        {
            var result = await tourStorage.AddTourAsync(tour);
            return result;
        }

        /// <summary>
        /// Метод для удаления тура из коллекции <see cref="tourStorage"/>
        /// </summary>
        public async Task<bool> DeleteTourAsync(Guid id)
        {
            var result = await tourStorage.DeleteTourAsync(id);
            return result;
        }

        /// <summary>
        /// Метод для редактирования тура в коллекции <see cref="tourStorage"/>
        /// </summary>
        public Task EditTourAsync(Tour tour)
        => tourStorage.EditTourAsync(tour);

        /// <summary>
        /// Метод для получения коллекции туров <see cref="tourStorage"/>
        /// </summary>
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
