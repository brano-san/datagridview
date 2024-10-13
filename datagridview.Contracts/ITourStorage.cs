using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using datagridview.Contracts.Models;

namespace datagridview.Contracts
{
    public interface ITourStorage
    {
        Task<IReadOnlyCollection<Tour>> GetAllToursAsync();

        Task<Tour> AddTourAsync(Tour tour);

        Task EditTourAsync(Tour tour);

        Task<bool> DeleteTourAsync(Guid id);
    }
}