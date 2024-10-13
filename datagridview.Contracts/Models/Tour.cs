using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace datagridview.Contracts.Models
{
    /// <summary>
    /// Класс, описывающий тур
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// Иникальный номер для каждого тура
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Точка назначения тура
        /// </summary>
        [Required]
        [DisplayName("Назначение")]
        [StringLength(50, MinimumLength = 3)]
        public string Destination { get; set; }

        /// <summary>
        /// Дата отправления в тур
        /// </summary>
        [DisplayName("Дата отправления")]
        public DateTime? DepartureDate { get; set; }

        /// <summary>
        /// Количество ночей в туре
        /// </summary>
        [DisplayName("Количество ночей")]
        [Range(1, 31)]
        public int Nights { get; set; }

        /// <summary>
        /// Цена тура для одного человека
        /// </summary>
        [DisplayName("Цена за человека")]
        public double PricePerTour { get; set; }

        /// <summary>
        /// Количество человек, которые отправляются в тур
        /// </summary>
        [DisplayName("Количество людей")]
        [Range(1, 10)]
        public int PeopleCount { get; set; }

        /// <summary>
        /// Имеется ли интернет в номере тура
        /// </summary>
        [DisplayName("Наличие интернета")]
        public bool HasWifi { get; set; }

        /// <summary>
        /// Количество взимаемой дополнительной платы
        /// </summary>
        [DisplayName("Доп. Плата")]
        public double AdditionalFees { get; set; }

        /// <summary>
        /// Итоговая цена за весь тур
        /// </summary>
        [DisplayName("Итоговая цена")]
        public double TotalCost { get; set; }
    }
}
