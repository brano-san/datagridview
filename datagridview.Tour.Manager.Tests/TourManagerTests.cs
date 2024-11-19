using Moq;
using Xunit;
using datagridview.Contracts;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace datagridview.Tour.Manager.Tests
{
    /// <summary>
    /// Тесты для класса <see cref="TourManager"/>.
    /// </summary>
    public class TourManagerTests
    {
        private readonly Mock<ITourStorage> tourStorageMock;
        private readonly Mock<ILogger<ITourManager>> loggerMock;
        private readonly ITourManager tourManager;

        public TourManagerTests()
        {
            tourStorageMock = new Mock<ITourStorage>();
            loggerMock = new Mock<ILogger<ITourManager>>();
            loggerMock.Setup(x => x.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()
            ));

            tourManager = new TourManager(tourStorageMock.Object, loggerMock.Object);
        }

        /// <summary>
        /// Удаление тура должно возвращать true и вызывать логгер 1 раз
        /// </summary>
        [Fact]
        public async Task DeleteAsyncShouldReturnTrueAndCallLoggerOnce()
        {
            var newId = Guid.NewGuid();
            tourStorageMock.Setup(x => x.DeleteTourAsync(newId))
                .ReturnsAsync(true);

            var result = await tourManager.DeleteTourAsync(newId);
            result.Should().BeTrue();

            tourStorageMock.Verify(x => x.DeleteTourAsync(newId), Times.Once);
            tourStorageMock.VerifyNoOtherCalls();
            loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
        }

        /// <summary>
        /// Добавление тура должно работать корректно
        /// </summary>
        [Fact]
        public async Task EditToursNeedToBeCorrect()
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

            tourStorageMock.Setup(x => x.EditTourAsync(It.IsAny<Contracts.Models.Tour>()));

            await tourManager.EditTourAsync(tour);

            tourStorageMock.Verify(x => x.EditTourAsync(It.IsAny<Contracts.Models.Tour>()), Times.Once);
            tourStorageMock.VerifyNoOtherCalls();
            loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
        }

        /// <summary>
        /// Добавление тура добавляет корректный тур
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

            tourStorageMock.Setup(x => x.AddTourAsync(It.IsAny<Contracts.Models.Tour>()))
                .ReturnsAsync(tour);

            var result = await tourManager.AddTourAsync(tour);

            result.Should().NotBeNull().And.Be(tour);
            tourStorageMock.Verify(x => x.AddTourAsync(It.Is<Contracts.Models.Tour>(y => y.Id == tour.Id)), Times.Once);
            tourStorageMock.VerifyNoOtherCalls();
            loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
        }

        /// <summary>
        /// Получение всех туров возвращает корректное значение
        /// </summary>
        [Fact]
        public async Task GetAllTourReturnCorrectValues()
        {
            var tour = new List<Contracts.Models.Tour>
            {
                new() { Id = Guid.NewGuid(), Destination = "qwerty", DepartureDate = DateTime.Now, Nights = 5, PeopleCount = 5, PricePerTour = 123, AdditionalFees = 1000000 },
                new() { Id = Guid.NewGuid(), Destination = "aye", DepartureDate = DateTime.Now, Nights = 5, PeopleCount = 5, PricePerTour = 321, AdditionalFees = 1000000 }
            }.AsReadOnly();

            tourStorageMock.Setup(x => x.GetAllToursAsync()).ReturnsAsync(tour);

            var result = await tourManager.GetAllToursAsync();

            result.Should().BeEquivalentTo(tour);

            tourStorageMock.Verify(x => x.GetAllToursAsync(), Times.Once);
            tourStorageMock.VerifyNoOtherCalls();
            loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
        }

        /// <summary>
        /// Получение статистики возвращает корректные значения
        /// </summary>
        [Fact]
        public async Task GetTourStatsNeedToBeCorrect()
        {
            var tour = new List<Contracts.Models.Tour>
            {
                new() { Id = Guid.NewGuid(), Destination = "qwerty", DepartureDate = DateTime.Now, Nights = 5, PeopleCount = 5, PricePerTour = 123, AdditionalFees = 1000000 },
                new() { Id = Guid.NewGuid(), Destination = "aye", DepartureDate = DateTime.Now, Nights = 5, PeopleCount = 5, PricePerTour = 321, AdditionalFees = 1000000 }
            }.AsReadOnly();

            tourStorageMock.Setup(x => x.GetAllToursAsync()).ReturnsAsync(tour);

            var result = await tourManager.GetStatsAsync();

            result.ToursCount.Should().Be(tour.Count);
            result.TotalSum.Should().Be(tour.Select(x => x.PeopleCount * x.PricePerTour + x.AdditionalFees).Sum());
            result.ToursCountWithAdd.Should().Be(tour.Count(x => x.AdditionalFees != 0));
            result.AdditionSum.Should().Be(tour.Select(x => x.AdditionalFees).Sum());

            tourStorageMock.Verify(x => x.GetAllToursAsync(), Times.Once);
            tourStorageMock.VerifyNoOtherCalls();
            loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
        }
    }
}
