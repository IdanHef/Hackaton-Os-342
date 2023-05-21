using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hackaton_os_342
{
    public partial class UserControl2 : UserControl
    {
        UserControl1 userControl1;
        public UserControl2()
        {
            InitializeComponent();
            Form1_Settings2_Load();
            buildUserControl_ver1();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Settings2_Load()
        {
            // Set the form properties
            BackColor = Color.FromArgb(20, 20, 20);
            ForeColor = Color.White;
            Font = new Font("Arial", 12, FontStyle.Bold);

            // Set the control properties
            titleLabel.ForeColor = Color.White;
            numberOfProducersLabel.ForeColor = Color.White;
            numberOfConsumersLabel.ForeColor = Color.White;
            producersRateLabel.ForeColor = Color.White;
            consumersRateLabel.ForeColor = Color.White;

            numberOfProducersTextBox.BackColor = Color.FromArgb(40, 40, 40);
            numberOfProducersTextBox.ForeColor = Color.White;
            numberOfConsumersTextBox.BackColor = Color.FromArgb(40, 40, 40);
            numberOfConsumersTextBox.ForeColor = Color.White;
            producersRateTextBox.BackColor = Color.FromArgb(40, 40, 40);
            producersRateTextBox.ForeColor = Color.White;
            consumersRateTextBox.BackColor = Color.FromArgb(40, 40, 40);
            consumersRateTextBox.ForeColor = Color.White;

            startButton.BackColor = Color.FromArgb(240, 0, 0);
            startButton.ForeColor = Color.White;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.Font = new Font("Arial", 12, FontStyle.Bold);
        }


        private void startButton_Click_1(object sender, EventArgs e)
        {
            // Retrieve the values from the integer text boxes

            int numberOfProducers = int.Parse(numberOfProducersTextBox.Text);
            int numberOfConsumers = int.Parse(numberOfConsumersTextBox.Text);
            int producersRate = int.Parse(producersRateTextBox.Text);
            int consumersRate = int.Parse(consumersRateTextBox.Text);

            int[] data2 = new int[4];
            data2[0] = numberOfProducers;
            data2[1] = numberOfConsumers;
            data2[2] = producersRate;
            data2[3] = consumersRate;

            this.Visible = false;

        }

        public void buildUserControl_ver1()
        {
            userControl1 = new UserControl1();
            userControl1.Dock = DockStyle.Fill;
            Controls.Add(userControl1);
            userControl1.Visible = false;
        }
    }
}
