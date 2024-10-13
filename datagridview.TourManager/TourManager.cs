using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using datagridview.Contracts;
using datagridview.Contracts.Models;

namespace datagridview.TourManager
{
    /// <summary>
    /// Интерфейс, указывающий методы для управления хранилищем туров
    /// </summary>
    public class TourManager : ITourManager
    {
        private ITourStorage tourStorage;

        public TourManager(ITourStorage tourStorage)
        {
            this.tourStorage = tourStorage;
        }

        /// <summary>
        /// Метод для добавления тура в коллекцию
        /// </summary>
        public async Task<Tour> AddTourAsync(Tour tour)
        {
            var result = await tourStorage.AddTourAsync(tour);
            return result;
        }

        /// <summary>
        /// Метод для удаления тура из коллекции
        /// </summary>
        public async Task<bool> DeleteTourAsync(Guid id)
        {
            var result = await tourStorage.DeleteTourAsync(id);
            return result;
        }

        /// <summary>
        /// Метод для редактирования тура в коллекции
        /// </summary>
        public Task EditTourAsync(Tour tour)
        => tourStorage.EditTourAsync(tour);

        /// <summary>
        /// Метод для получения коллекции туров
        /// </summary>
        public Task<IReadOnlyCollection<Tour>> GetAllToursAsync()
            => tourStorage.GetAllToursAsync();
    }
}
