using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using datagridview.Contracts.Models;

namespace datagridview.Contracts
{
    /// <summary>
    /// Интерфейс хранения коллекции <see cref="Tour"/>
    /// </summary>
    public interface ITourStorage
    {
        /// <summary>
        /// Получения коллекции <see cref="Tour"/>
        /// </summary>
        Task<IReadOnlyCollection<Tour>> GetAllToursAsync();

        /// <summary>
        /// Добавления <see cref="Tour"/> в коллекцию
        /// </summary>
        Task<Tour> AddTourAsync(Tour tour);

        /// <summary>
        /// Редактирования <see cref="Tour"/> в коллекции
        /// </summary>
        Task EditTourAsync(Tour tour);

        /// <summary>
        /// Удаления <see cref="Tour"/> из коллекции
        /// </summary>
        Task<bool> DeleteTourAsync(Guid id);
    }
}
