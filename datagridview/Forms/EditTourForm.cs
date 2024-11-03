using datagridview.src;
using Microsoft.Extensions.Logging;

namespace datagridview.Forms
{
    /// <summary>
    /// Форма для добавления и редактирования данных через <see cref="CurrentTour"/>
    /// </summary>
    public partial class EditTourForm : Form
    {
        /// <summary>
        /// Тур, для обработки (добавления/редактирования). Получить после завершения работы с формой
        /// </summary>
        public Contracts.Models.Tour CurrentTour { get; private set; }

        private readonly ILogger logger;

        public EditTourForm(Contracts.Models.Tour tour, ILogger logger)
        {
            InitializeComponent();

            this.logger = logger;

            if (tour != null)
            {
                logger.LogDebug("tour != null. Редактируем существующий тур");
                CurrentTour = new Contracts.Models.Tour
                {
                    Id = tour.Id,
                    AdditionalFees = tour.AdditionalFees,
                    DepartureDate = tour.DepartureDate,
                    Destination = tour.Destination,
                    HasWifi = tour.HasWifi,
                    Nights = tour.Nights,
                    PeopleCount = tour.PeopleCount,
                    PricePerTour = tour.PricePerTour,
                };
            }
            else
            {
                logger.LogDebug("tour == null. Добавляем новый тур");
                CurrentTour = new Contracts.Models.Tour
                {
                    Id = Guid.NewGuid(),
                    DepartureDate = DateTime.Now,
                };
            }

            AddBindings();
            UpdateData();
        }

        private void AddBindings()
        {
            txtDestination.AddBinding(x => x.Text, CurrentTour, x => x.Destination, errorProvider1);
            dtpDepartureDate.AddBinding(x => x.Value, CurrentTour, x => x.DepartureDate, errorProvider1);
            nudNights.AddBinding(x => x.Value, CurrentTour, x => x.Nights, errorProvider1);
            nudPricePerTour.AddBinding(x => x.Value, CurrentTour, x => x.PricePerTour, errorProvider1);
            nudPeopleCount.AddBinding(x => x.Text, CurrentTour, x => x.PeopleCount, errorProvider1);
            chkWifi.AddBinding(x => x.Checked, CurrentTour, x => x.HasWifi);
            nudAdditionalFees.AddBinding(x => x.Value, CurrentTour, x => x.AdditionalFees, errorProvider1);
        }

        private void UpdateData()
        {
            txtCount.Text = (nudPeopleCount.Value * nudPricePerTour.Value + nudAdditionalFees.Value).ToString();
        }

        private void UpdateData(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CurrentTour.IsValid())
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
