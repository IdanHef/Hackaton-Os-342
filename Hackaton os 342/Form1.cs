using System.Windows.Forms;
using Hackaton_os_342;

namespace Hackaton_os_342
{
    public partial class Form1 : Form
    {
        private UserControl1 userControl1;
        private readonly Buffer buffer; // Declare a private instance of CinemaBuffer
        private readonly Producer producer;
        private readonly Consumer consumer;

        private Thread producerThread;
        private Thread consumerThread;
        private int producerCount;
        private int consumerCount;
        private int producerRatio;
        private int consumerRatio;
        Chair[] chairs;



        public Form1()
        {
            InitializeComponent();
            Form1_Settings2_Load();

            chairs = new Chair[90];
            initializeChairs();
            buffer = new Buffer(chairs, this);
            producer = new Producer(buffer);
            consumer = new Consumer(buffer);


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

            producerCount = numberOfProducers;
            consumerCount = numberOfConsumers;
            producerRatio = producersRate;
            consumerRatio = consumersRate;


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
            StartProducerConsumerCommunication();
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

        private void StartProducerConsumerCommunication()
        {
            producerThread = new Thread(() => producer.ProduceItems(producerCount));
            consumerThread = new Thread(() => consumer.ConsumeItems(consumerCount));
            // Start the producer and consumer threads
            producerThread.Start();
            consumerThread.Start();

            // Optionally, you can join the threads to wait for their completion
            producerThread.Join();
            consumerThread.Join();

            // You can also update the UI or display status messages here
            // to indicate that the producer and consumer actions have started.

        }
        
        private void initializeChairs()
        {
            int[,] coordinates = new int[,]
{
    { 130, 629 },
    { 131, 518 },
    { 131, 574 },
    { 149, 295 },
    { 149, 351 },
    { 149, 406 },
    { 149, 461 },
    { 167, 239 },
    { 168, 518 },
    { 168, 574 },
    { 168, 628 },
    { 187, 351 },
    { 187, 406 },
    { 187, 461 },
    { 188, 295 },
    { 205, 239 },
    { 206, 518 },
    { 206, 574 },
    { 206, 629 },
    { 224, 351 },
    { 224, 461 },
    { 225, 295 },
    { 225, 406 },
    { 242, 239 },
    { 242, 628 },
    { 243, 517 },
    { 243, 574 },
    { 262, 295 },
    { 262, 351 },
    { 262, 406 },
    { 262, 461 },
    { 280, 239 },
    { 281, 518 },
    { 281, 574 },
    { 281, 629 },
    { 300, 295 },
    { 300, 351 },
    { 300, 406 },
    { 300, 461 },
    { 317, 629 },
    { 318, 239 },
    { 319, 517 },
    { 320, 573 },
    { 336, 351 },
    { 337, 295 },
    { 337, 406 },
    { 338, 461 },
    { 355, 239 },
    { 355, 628 },
    { 356, 573 },
    { 357, 517 },
    { 374, 351 },
    { 375, 295 },
    { 375, 406 },
    { 375, 461 },
    { 392, 239 },
    { 393, 628 },
    { 394, 517 },
    { 394, 572 },
    { 412, 295 },
    { 412, 351 },
    { 412, 406 },
    { 413, 461 },
    { 430, 239 },
    { 430, 516 },
    { 431, 572 },
    { 431, 628 },
    { 449, 351 },
    { 450, 295 },
    { 450, 406 },
    { 450, 461 },
    { 467, 239 },
    { 467, 629 },
    { 468, 572 },
    { 469, 517 },
    { 486, 351 },
    { 487, 295 },
    { 487, 406 },
    { 487, 461 },
    { 505, 239 },
    { 505, 517 },
    { 505, 573 },
    { 505, 628 },
    { 524, 295 },
    { 524, 351 },
    { 524, 461 },
    { 525, 406 },
    { 541, 628 },
    { 542, 517 },
    { 543, 572 }
};

            for (int i = 0; i < 90; i++)
            {
                int x = coordinates[i, 0];
                int y = coordinates[i, 1];
                chairs[i] = new Chair(x, y);
            }


        }
    }
}