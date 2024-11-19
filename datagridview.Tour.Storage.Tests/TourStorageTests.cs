using Xunit;
using FluentAssertions;

namespace datagridview.Tour.Storage.Tests
{
    /// <summary>
    /// Тесты для класса <see cref="TourStorage"/>.
    /// </summary>
    public class TourStorageTests
    {
        private readonly TourStorage tourStorage = new TourStorage();

        /// <summary>
        /// Добавление тура корректно
        /// </summary>
        [Fact]
        public async Task AddTourNeedToBeCorrect()
        {
            var tour = new Contracts.Models.Tour
            {
                Id = Guid.NewGuid(),
                Destination = "qwerty",
                DepartureDate = DateTime.Now,
                Nights = 5,
                PricePerTour = 5,
                PeopleCount = 5,
                HasWifi = false,
                AdditionalFees = 1000000,
            };

            var result = await tourStorage.AddTourAsync(tour);

            result.Should()
                .NotBeNull()
                .And.BeEquivalentTo(new
                {
                    tour.Id,
                    tour.Destination,
                    tour.DepartureDate,
                    tour.Nights,
                    tour.PricePerTour,
                    tour.HasWifi,
                    tour.AdditionalFees,
                });
        }

        /// <summary>
        /// Удаление тура корректно
        /// </summary>
        [Fact]
        public async Task DeleteTourNeedToBeCorrect()
        {
            var tour = new Contracts.Models.Tour
            {
                Id = Guid.NewGuid(),
                Destination = "qwerty",
                DepartureDate = DateTime.Now,
                Nights = 5,
                PricePerTour = 5,
                PeopleCount = 5,
                HasWifi = false,
                AdditionalFees = 1000000,
            };

            await tourStorage.AddTourAsync(tour);
            var result = await tourStorage.DeleteTourAsync(tour.Id);
            var list = await tourStorage.GetAllToursAsync();

            result.Should().BeTrue();
            list.Should().NotContain(p => p.Id == tour.Id);
        }

        /// <summary>
        /// Изменение списка туров корректно
        /// </summary>
        [Fact]
        public async Task EditTaskNeedToBeCorrect()
        {
            var tour = new Contracts.Models.Tour
            {
                Id = Guid.NewGuid(),
                Destination = "qwerty",
                DepartureDate = DateTime.Now,
                Nights = 5,
                PricePerTour = 5,
                PeopleCount = 5,
                HasWifi = false,
                AdditionalFees = 1000000,
            };

            var newTour = new Contracts.Models.Tour
            {
                Id = tour.Id,
                Destination = "asdf",
                DepartureDate = DateTime.Now,
                Nights = 1,
                PricePerTour = 2,
                PeopleCount = 5,
                HasWifi = false,
                AdditionalFees = 100,
            };

            await tourStorage.AddTourAsync(tour);
            await tourStorage.EditTourAsync(newTour);
            var result = await tourStorage.GetAllToursAsync();
            var product = result.FirstOrDefault(x => x.Id == tour.Id);

            product.Should().BeEquivalentTo(newTour);
        }

        /// <summary>
        /// Получение туров в пустом контейнере возвращает ничего
        /// </summary>
        [Fact]
        public async Task GetAllEmptyToursNeedToReturnEmpty()
        {
            var result = await tourStorage.GetAllToursAsync();
            result.Should()
                .NotBeNull()
                .And.BeEmpty();
        }
    }
}
