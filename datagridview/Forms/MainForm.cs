using datagridview.Contracts;
using datagridview.Forms;
using Microsoft.Extensions.Logging;

namespace datagridview
{
    /// <summary>
    /// Главная форма приложения, отображающая все туры
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly ITourManager tourManager;
        private readonly BindingSource bindingSource;
        private readonly ILogger logger;

        public MainForm(ITourManager tourManager, ILogger logger)
        {
            InitializeComponent();

            this.tourManager = tourManager;
            this.logger = logger;

            bindingSource = new BindingSource();
            dataGridView1.DataSource = bindingSource;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы действительно хотите редактировать строку?",
                "Подтверждение редактирования",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                logger.LogInformation("Редактирование отменено");
                return;
            }

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                logger.LogInformation("Редактирование отменено. Отсутствуют данные");
                return;
            }

            var selectedTour = (Contracts.Models.Tour)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            var form = new EditTourForm(selectedTour, logger);
            if (form.ShowDialog() != DialogResult.OK)
            {
                logger.LogInformation("Редактирование отменено. Результат редактирования отрицательный");
                return;
            }

            await tourManager.EditTourAsync(form.CurrentTour);
            bindingSource.ResetBindings(false);
            await UpdateToolStrip();

            logger.LogInformation("Данные успешно отредактированы");
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditTourForm(null, logger);
            if (form.ShowDialog() != DialogResult.OK)
            {
                logger.LogInformation("Добавление отменено");
                return;
            }

            await tourManager.AddTourAsync(form.CurrentTour);
            bindingSource.ResetBindings(false);
            await UpdateToolStrip();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                logger.LogInformation("Удаление отменено. Нет выделенной строки");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Вы действительно удалить строку?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                logger.LogInformation("Удаление отменено");
                return;
            }

            var selectedTour = (Contracts.Models.Tour)dataGridView1.CurrentRow.DataBoundItem;

            await tourManager.DeleteTourAsync(selectedTour.Id);
            bindingSource.ResetBindings(false);
            await UpdateToolStrip();

            logger.LogInformation("Удаление завершено успешно");
        }

        private async Task UpdateToolStrip()
        {
            var stats = await tourManager.GetStatsAsync();

            strip1.Text = $"Количество туров {stats.ToursCount};";
            strip2.Text = $"Общая сумма {stats.TotalSum}; ";
            strip3.Text = $"Количество туров с доплатами {stats.ToursCountWithAdd}; ";
            strip4.Text = $"Общая сумма доплат {stats.AdditionSum}; ";
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = await tourManager.GetAllToursAsync();
            dataGridView1.Columns[nameof(Contracts.Models.Tour.Id)].Visible = false;
            dataGridView1.Columns.Add("TotalCost", "Общая стоимость");

            await UpdateToolStrip();
        }

        private async void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "TotalCost")
            {
                var data = (Contracts.Models.Tour)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = data.PricePerTour * data.PeopleCount + data.AdditionalFees;
                e.Value = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            }
            await UpdateToolStrip();
        }
    }
}
