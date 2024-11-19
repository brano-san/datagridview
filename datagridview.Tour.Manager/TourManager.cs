using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using datagridview.Contracts;
using datagridview.Contracts.Models;
using datagridview.TourManager.Models;
using Microsoft.Extensions.Logging;

namespace datagridview.Tour.Manager
{
    /// <inheritdoc cref="ITourManager"/>
    public class TourManager : ITourManager
    {
        private ITourStorage tourStorage;
        private readonly ILogger logger;

        public TourManager(ITourStorage tourStorage, ILogger logger)
        {
            this.tourStorage = tourStorage;
            this.logger = logger;
        }

        /// <inheritdoc cref="ITourManager.AddTourAsync"/>
        public async Task<Contracts.Models.Tour> AddTourAsync(Contracts.Models.Tour tour)
        {
            var timer = Stopwatch.StartNew();
            var result = await tourStorage.AddTourAsync(tour);
            timer.Stop();

            logger.LogInformation("Добавление произошло за {Ms} мс, тур {@tour}", timer.ElapsedMilliseconds, tour);
            return result;
        }

        /// <inheritdoc cref="ITourManager.DeleteTourAsync"/>
        public async Task<bool> DeleteTourAsync(Guid id)
        {
            var timer = Stopwatch.StartNew();
            var result = await tourStorage.DeleteTourAsync(id);
            timer.Stop();

            logger.LogInformation("Удаление произошло за {Ms} мс, id {id}", timer.ElapsedMilliseconds, id);
            return result;
        }

        /// <inheritdoc cref="ITourManager.EditTourAsync"/>
        public Task EditTourAsync(Contracts.Models.Tour tour)
        {
            var timer = Stopwatch.StartNew();
            var result = tourStorage.EditTourAsync(tour);
            timer.Stop();

            logger.LogInformation("Редактирование произошло за {Ms} мс, тур {@tour}", timer.ElapsedMilliseconds, tour);
            return result;
        }

        /// <inheritdoc cref="ITourManager.GetAllToursAsync"/>
        public Task<IReadOnlyCollection<Contracts.Models.Tour>> GetAllToursAsync()
        {
            var timer = Stopwatch.StartNew();
            var result = tourStorage.GetAllToursAsync();
            timer.Stop();

            logger.LogInformation("Получение всех туров произошло за {Ms} мс", timer.ElapsedMilliseconds);
            return result;
        }

        /// <inheritdoc cref="IProductManager.GetStatsAsync"/>
        public async Task<ITourStats> GetStatsAsync()
        {
            var timer = Stopwatch.StartNew();
            var tour = await tourStorage.GetAllToursAsync();
            timer.Stop();

            logger.LogInformation("Получение статистики произошло за {Ms} мс", timer.ElapsedMilliseconds);

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
