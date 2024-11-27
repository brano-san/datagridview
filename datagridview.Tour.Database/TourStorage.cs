using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using datagridview.Contracts;
using Microsoft.EntityFrameworkCore;

namespace datagridview.Tour.Database
{
    public class TourStorage : ITourStorage
    {
        public async Task<IReadOnlyCollection<Contracts.Models.Tour>> GetAllToursAsync()
        {
            var context = new DataGridContext();
            var tours = await context.Tours
                .AsNoTracking()
                .ToListAsync();

            return tours;
        }

        public async Task<Contracts.Models.Tour> AddTourAsync(Contracts.Models.Tour tour)
        {
            var context = new DataGridContext();
            await context.AddAsync(tour);
            await context.SaveChangesAsync();
            return tour;
        }

        public async Task EditTourAsync(Contracts.Models.Tour tourToEdit)
        {
            var context = new DataGridContext();
            var tour = await context.Tours.FirstOrDefaultAsync(p => p.Id == tourToEdit.Id);
            if (tour == null)
            {
                return;
            }

            tour.Destination = tourToEdit.Destination;
            tour.AdditionalFees = tourToEdit.AdditionalFees;
            tour.DepartureDate = tourToEdit.DepartureDate;
            tour.PeopleCount = tourToEdit.PeopleCount;
            tour.HasWifi = tourToEdit.HasWifi;
            tour.PricePerTour = tourToEdit.PricePerTour;
            tour.Nights = tourToEdit.Nights;
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteTourAsync(Guid id)
        {
            var context = new DataGridContext();
            var tour = await context.Tours.FirstOrDefaultAsync(p => p.Id == id);
            if (tour == null)
            {
                return false;
            }

            context.Tours.Remove(tour);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
