using System;
using System.Windows.Forms;
using datagridview.Contracts;
using datagridview.Forms;

namespace datagridview
{
    public partial class MainForm : Form
    {
        private ITourManager tourManager;
        private BindingSource bindingSource;

        public MainForm(ITourManager tourManager)
        {
            InitializeComponent();

            this.tourManager = tourManager;

            bindingSource = new BindingSource();
            dataGridView1.DataSource = bindingSource;

            UpdateToolStrip();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }
            var selectedTour = (Contracts.Models.Tour)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            var form = new EditTourForm(selectedTour);
            form.ShowDialog();

            await tourManager.EditTourAsync(form.CurrentTour);
            bindingSource.ResetBindings(false);
            UpdateToolStrip();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditTourForm();
            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            await tourManager.AddTourAsync(form.CurrentTour);
            bindingSource.ResetBindings(false);
            UpdateToolStrip();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            var selectedTour = (Contracts.Models.Tour)dataGridView1.CurrentRow.DataBoundItem;

            await tourManager.DeleteTourAsync(selectedTour.Id);
            bindingSource.ResetBindings(false);
            UpdateToolStrip();
        }

        private void UpdateToolStrip()
        {
            var toursCount = dataGridView1.RowCount;
            var sum = 0.0;
            var toursCountWithAdd = 0;
            var additionSum = 0.0;

            for (var i = 0; i < dataGridView1.RowCount; i++)
            {
                var tour = (Contracts.Models.Tour)dataGridView1.Rows[i].DataBoundItem;
                sum += tour.TotalCost;

                if (tour.AdditionalFees != 0)
                {
                    ++toursCountWithAdd;
                    additionSum += tour.AdditionalFees;
                }
            }

            strip1.Text = $"Количество туров {toursCount};";
            strip2.Text = $"Общая сумма {sum}; ";
            strip3.Text = $"Количество туров с доплатами {toursCountWithAdd}; ";
            strip4.Text = $"Общая сумма доплат {additionSum}; ";
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = await tourManager.GetAllToursAsync();
            dataGridView1.Columns[nameof(Contracts.Models.Tour.Id)].Visible = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "TotalCost")
            {
                var data = (Contracts.Models.Tour)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                data.TotalCost = data.PricePerTour * data.PeopleCount + data.AdditionalFees;
                e.Value = data.TotalCost;
            }
            UpdateToolStrip();
        }
    }
}
