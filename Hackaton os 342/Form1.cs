using System.Windows.Forms;

namespace Hackaton_os_342
{
    public partial class Form1 : Form
    {
        private UserControl1 userControl1;

        public Form1()
        {
            InitializeComponent();
            Form1_Settings2_Load();
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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void startButton_Click(object sender, EventArgs e)
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

            // Create an instance of UserControl1
            userControl1 = new UserControl1();

            // Set the position and size of the user control
            userControl1.Location = new Point(0, 0);    
            userControl1.Size = this.ClientSize;

            // Add UserControl1 to the form's controls
            this.Controls.Add(userControl1);

            // Set all controls within the user control to invisible
            //SetAllControlsVisibility(this, false);



            // Show the user control
            userControl1.Visible = true;
            // Show UserControl1 as a separate form
            userControl1.Show();

            SetAllControlsVisibility_ver2();
        }

        private void SetAllControlsVisibility(Control control, bool isVisible)
        {
            // Set the visibility of the current control
            control.Visible = isVisible;

            // Recursively iterate over the child controls
            foreach (Control childControl in control.Controls)
            {
                if(childControl is not UserControl1)
                {
                    SetAllControlsVisibility(childControl, isVisible);
                }
            }
        }

        private void SetAllControlsVisibility_ver2()
        {
            this.titleLabel.Visible = false;
            this.numberOfProducersLabel.Visible = false;
            this.numberOfProducersTextBox.Visible = false;
            this.numberOfConsumersLabel.Visible = false;
            this.numberOfConsumersTextBox.Visible = false;
            this.producersRateLabel.Visible = false;
            this.producersRateTextBox.Visible = false;
            this.consumersRateLabel.Visible = false;
            this.consumersRateTextBox.Visible = false;
            this.startButton.Visible = false;
        }

    }
}