﻿using System;
using System.Windows.Forms;
using datagridview.src;

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

        public EditTourForm(Contracts.Models.Tour tour = null)
        {
            InitializeComponent();

            if (tour != null)
            {
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
            DialogResult result = MessageBox.Show(
                "Вы действительно изменить данные?",
                "Подтверждение изменений",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                Close();
                return;
            }

            if (!CurrentTour.IsValid())
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
                Close();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
