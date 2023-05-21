namespace Hackaton_os_342
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ProducerConsumerScreen_Load(object sender, EventArgs e)
        {
            // Set default values for the integer text boxes
            numberOfProducersTextBox.Text = "1";
            numberOfConsumersTextBox.Text = "1";
            producersRateTextBox.Text = "1000";
            consumersRateTextBox.Text = "1000";

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