using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Routes
{
    public partial class FormRoutes : Form
    {
        Transport busNet;
        
        public FormRoutes()
        {
            InitializeComponent();
        }

        private void buttOpenSch_Click(object sender, EventArgs e)
        {
            if (openSchDialog.ShowDialog() == DialogResult.OK)
            {
                busNet = new Transport();
                bool fileCorrect = busNet.loadScheduleFile(openSchDialog.FileName);
                if (fileCorrect)
                {
                    comboBoxStart.DataSource = busNet.BusStops;
                    comboBoxFinish.DataSource = busNet.BusStops;
                    listBoxFast.Items.Clear();
                    listBoxCheap.Items.Clear();
                    groupBoxProp.Enabled = true;
                } else {
                    groupBoxProp.Enabled = false;
                    listBoxFast.Items.Clear();
                    listBoxCheap.Items.Clear();
                }
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            listBoxFast.Items.Clear();
            listBoxCheap.Items.Clear();
            if ((int)comboBoxStart.SelectedItem == (int)comboBoxFinish.SelectedItem)
            {
                listBoxFast.Items.Add("Start add finish are equivalent");
                listBoxCheap.Items.Add("Start add finish are equivalent");
            }
            else if (busNet.FindRoutes((int)comboBoxStart.SelectedItem, (int)comboBoxFinish.SelectedItem, startTimePicker.Value))
            {
                listBoxFast.Items.AddRange(busNet.FastRoute.ToArray());
                listBoxCheap.Items.AddRange(busNet.CheapRoute.ToArray());
                listBoxFast.Items.Add("Cost: " + busNet.FastRoute.Last().Cost);
                listBoxFast.Items.Add("Time: " + TimeConverter.IntToTime(busNet.FastRoute.Last().Time).ToShortTimeString());
                listBoxCheap.Items.Add("Cost: " + busNet.CheapRoute.Last().Cost);
                listBoxCheap.Items.Add("Time: " + TimeConverter.IntToTime(busNet.CheapRoute.Last().Time).ToShortTimeString());
            }
            else
            {
                listBoxFast.Items.Add("Route not exist");
                listBoxCheap.Items.Add("Route not exist");
            }

        }

        bool sizesInit = false;
        int groupBoxResultsDX = 0;
        int groupBoxResultsDY = 0;
        int listBoxesDY = 0;
        int listBoxesDXfull = 0;
        int listBoxesDXbetween = 0;

        private void FormRoutes_Resize(object sender, EventArgs e)
        {
            if (sizesInit)
            {
                groupBoxResults.Width = this.Width - groupBoxResultsDX;
                groupBoxResults.Height = this.Height - groupBoxResultsDY;
                listBoxFast.Height = groupBoxResults.Height - listBoxesDY;
                listBoxCheap.Height = groupBoxResults.Height - listBoxesDY;
                listBoxFast.Width = (groupBoxResults.Width - listBoxesDXfull) / 2;
                listBoxCheap.Width = (groupBoxResults.Width - listBoxesDXfull) / 2;
                listBoxCheap.Location = new Point(listBoxFast.Right + listBoxesDXbetween, listBoxCheap.Location.Y);
                labelCheapRoute.Location = new Point(listBoxFast.Right + listBoxesDXbetween, labelCheapRoute.Location.Y);
            }
        }

        private void FormRoutes_Shown(object sender, EventArgs e)
        {
            groupBoxResultsDX = this.Width - groupBoxResults.Width;
            groupBoxResultsDY = this.Height - groupBoxResults.Height;
            listBoxesDY = groupBoxResults.Height - listBoxFast.Height;
            listBoxesDXfull = groupBoxResults.Width - (listBoxFast.Width + listBoxCheap.Width);
            listBoxesDXbetween = listBoxCheap.Location.X - listBoxFast.Right;
            sizesInit = true;
        }
    }
}
