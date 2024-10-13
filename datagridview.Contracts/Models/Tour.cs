using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace datagridview.Contracts.Models
{
    public class Tour
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Назначение")]
        [StringLength(50, MinimumLength = 3)]
        public string Destination { get; set; }

        [DisplayName("Дата отправления")]
        public DateTime? DepartureDate { get; set; }

        [DisplayName("Количество ночей")]
        [Range(1, 31)]
        public int Nights { get; set; }

        [DisplayName("Цена за человека")]
        public double PricePerTour { get; set; }

        [DisplayName("Количество людей")]
        [Range(1, 10)]
        public int PeopleCount { get; set; }

        [DisplayName("Наличие интернета")]
        public bool HasWifi { get; set; }

        [DisplayName("Доп. Плата")]
        public double AdditionalFees { get; set; }

        [DisplayName("Итоговая цена")]
        public double TotalCost { get; set; }
    }
}
