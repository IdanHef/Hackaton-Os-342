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
            // Initialize the form controls and set default values
            titleLabel.Text = "Producer-Consumer Screen";
            numberOfProducersLabel.Text = "Number of Producers:";
            numberOfConsumersLabel.Text = "Number of Consumers:";
            producersRateLabel.Text = "Producers Rate:";
            consumersRateLabel.Text = "Consumers Rate:";

            // Set default values for the integer text boxes
            numberOfProducersTextBox.Text = "1";
            numberOfConsumersTextBox.Text = "1";
            producersRateTextBox.Text = "1000";
            consumersRateTextBox.Text = "1000";
        }

        // Event handler for the start button click
        private void startButton_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}