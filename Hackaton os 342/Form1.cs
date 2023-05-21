namespace Hackaton_os_342
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Settings2_Load();
        }
        private void Form1_Settings_Load()
        {
            // Set the form properties
            BackColor = Color.Black;
            ForeColor = Color.Red;
            Font = new Font("Arial", 12, FontStyle.Bold);

            // Set the control properties
            titleLabel.ForeColor = Color.Red;
            numberOfProducersLabel.ForeColor = Color.Red;
            numberOfConsumersLabel.ForeColor = Color.Red;
            producersRateLabel.ForeColor = Color.Red;
            consumersRateLabel.ForeColor = Color.Red;

            numberOfProducersTextBox.BackColor = Color.Black;
            numberOfProducersTextBox.ForeColor = Color.Red;
            numberOfConsumersTextBox.BackColor = Color.Black;
            numberOfConsumersTextBox.ForeColor = Color.Red;
            producersRateTextBox.BackColor = Color.Black;
            producersRateTextBox.ForeColor = Color.Red;
            consumersRateTextBox.BackColor = Color.Black;
            consumersRateTextBox.ForeColor = Color.Red;

            startButton.BackColor = Color.Red;
            startButton.ForeColor = Color.Black;
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

        private void startButton_Click_1(object sender, EventArgs e)
        {
            // Retrieve the values from the integer text boxes
            int numberOfProducers = int.Parse(numberOfProducersTextBox.Text);
            int numberOfConsumers = int.Parse(numberOfConsumersTextBox.Text);
            int producersRate = int.Parse(producersRateTextBox.Text);
            int consumersRate = int.Parse(consumersRateTextBox.Text);

            // TODO: Start the producer-consumer logic with the provided values
            // Implement your logic here

            // For example, you can display a message box with the values for testing
            string message = $"Number of Producers: {numberOfProducers}\n" +
                             $"Number of Consumers: {numberOfConsumers}\n" +
                             $"Producers Rate: {producersRate}\n" +
                             $"Consumers Rate: {consumersRate}";
            MessageBox.Show(message, "Start Button Clicked");

        }
    }
}