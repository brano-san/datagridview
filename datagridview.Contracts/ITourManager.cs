using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using datagridview.Contracts.Models;

namespace datagridview.Contracts
{
    /// <summary>
    /// Интерфейс, указывающий методы для управления хранилищем туров
    /// </summary>
    public interface ITourManager
    {
        /// <summary>
        /// Метод для получения коллекции туров
        /// </summary>
        Task<IReadOnlyCollection<Tour>> GetAllToursAsync();

        /// <summary>
        /// Метод для добавления тура в коллекцию
        /// </summary>
        Task<Tour> AddTourAsync(Tour tour);

        /// <summary>
        /// Метод для редактирования тура в коллекции
        /// </summary>
        Task EditTourAsync(Tour tour);

        /// <summary>
        /// Метод для удаления тура из коллекции
        /// </summary>
        Task<bool> DeleteTourAsync(Guid id);

        /// <summary>
        /// Получение стастики по всем турам  <see cref="ITourStats"/>
        /// </summary>
        Task<ITourStats> GetStatsAsync();
    }
}
