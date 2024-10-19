using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace datagridview.Contracts.Models
{
    /// <summary>
    /// Описание тура
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
        [Required(ErrorMessage = "Дата отправления обязательна.")]
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
        [Required(ErrorMessage = "Цена тура обязательна.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0.")]
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
        [Range(0, double.MaxValue, ErrorMessage = "Дополнительная плата не может быть отрицательной.")]
        public double AdditionalFees { get; set; }

        public bool IsValid()
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(this, context, results, validateAllProperties: true);
        }
    }
}
