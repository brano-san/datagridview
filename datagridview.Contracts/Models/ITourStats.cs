namespace datagridview.Contracts.Models
{
    /// <summary>
    /// Статистика по всем <see cref="Tour"/>
    /// </summary>
    public interface ITourStats
    {
        /// <summary>
        /// Общее количество туров
        /// </summary>
        int ToursCount { get; set; }

        /// <summary>
        /// Общая сумма за все туры
        /// </summary>
        double TotalSum { get; set; }

        /// <summary>
        /// Количество туров с доплатами
        /// </summary>
        int ToursCountWithAdd { get; set; }

        /// <summary>
        /// Общую сумма доплат
        /// </summary>
        double AdditionSum { get; set; }
    }
}
