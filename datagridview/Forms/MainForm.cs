using datagridview.Contracts;
using datagridview.Forms;
using Microsoft.Extensions.Logging;

namespace datagridview
{
    /// <summary>
    /// ������� ����� ����������, ������������ ��� ����
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
                "�� ������������� ������ ������������� ������?",
                "������������� ��������������",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                logger.LogInformation("�������������� ��������");
                return;
            }

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                logger.LogInformation("�������������� ��������. ����������� ������");
                return;
            }

            var selectedTour = (Contracts.Models.Tour)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            var form = new EditTourForm(selectedTour, logger);
            if (form.ShowDialog() != DialogResult.OK)
            {
                logger.LogInformation("�������������� ��������. ��������� �������������� �������������");
                return;
            }

            await tourManager.EditTourAsync(form.CurrentTour);
            bindingSource.ResetBindings(false);
            await UpdateToolStrip();

            logger.LogInformation("������ ������� ���������������");
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditTourForm(null, logger);
            if (form.ShowDialog() != DialogResult.OK)
            {
                logger.LogInformation("���������� ��������");
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
                logger.LogInformation("�������� ��������. ��� ���������� ������");
                return;
            }

            DialogResult result = MessageBox.Show(
                "�� ������������� ������� ������?",
                "������������� ��������",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                logger.LogInformation("�������� ��������");
                return;
            }

            var selectedTour = (Contracts.Models.Tour)dataGridView1.CurrentRow.DataBoundItem;

            await tourManager.DeleteTourAsync(selectedTour.Id);
            bindingSource.ResetBindings(false);
            await UpdateToolStrip();

            logger.LogInformation("�������� ��������� �������");
        }

        private async Task UpdateToolStrip()
        {
            var stats = await tourManager.GetStatsAsync();

            strip1.Text = $"���������� ����� {stats.ToursCount};";
            strip2.Text = $"����� ����� {stats.TotalSum}; ";
            strip3.Text = $"���������� ����� � ��������� {stats.ToursCountWithAdd}; ";
            strip4.Text = $"����� ����� ������ {stats.AdditionSum}; ";
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = await tourManager.GetAllToursAsync();
            dataGridView1.Columns[nameof(Contracts.Models.Tour.Id)].Visible = false;
            dataGridView1.Columns.Add("TotalCost", "����� ���������");

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
