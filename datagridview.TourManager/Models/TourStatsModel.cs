using datagridview.Contracts.Models;

namespace datagridview.TourManager.Models
{
    /// <inheritdoc cref="ITourStats"/>
    public class TourStatsModel : ITourStats
    {
        /// <inheritdoc cref="ITourStats.ToursCount"/>
        public int ToursCount { get; set; }

        /// <inheritdoc cref="ITourStats.TotalSum"/>
        public double TotalSum { get; set; }

        /// <inheritdoc cref="ITourStats.ToursCountWithAdd"/>
        public int ToursCountWithAdd { get; set; }

        /// <inheritdoc cref="ITourStats.AdditionSum"/>
        public double AdditionSum { get; set; }
    }
}
