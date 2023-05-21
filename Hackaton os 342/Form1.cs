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
        Chair[] chairDimensions;



        public Form1()
        {
            InitializeComponent();
            Form1_Settings2_Load();

<<<<<<< HEAD
            chairDimensions = new Chair[90];

            buffer = new Buffer(chairDimensions);
=======
            Chair[] chairDimensions = new Chair[90];
            buffer = new Buffer(chairDimensions,this);
>>>>>>> a153f0d0b83216853f387896bba2c5e4d7bef831
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
            var coordinates = new[]
            {
    new KeyValuePair<int, int>(130, 629),
    new KeyValuePair<int, int>(131, 518),
    new KeyValuePair<int, int>(131, 574),
    new KeyValuePair<int, int>(149, 295),
    new KeyValuePair<int, int>(149, 351),
    new KeyValuePair<int, int>(149, 406),
    new KeyValuePair<int, int>(149, 461),
    new KeyValuePair<int, int>(167, 239),
    new KeyValuePair<int, int>(168, 518),
    new KeyValuePair<int, int>(168, 574),
    new KeyValuePair<int, int>(168, 628),
    new KeyValuePair<int, int>(187, 351),
    new KeyValuePair<int, int>(187, 406),
    new KeyValuePair<int, int>(187, 461),
    new KeyValuePair<int, int>(188, 295),
    new KeyValuePair<int, int>(205, 239),
    new KeyValuePair<int, int>(206, 518),
    new KeyValuePair<int, int>(206, 574),
    new KeyValuePair<int, int>(206, 629),
    new KeyValuePair<int, int>(224, 351),
    new KeyValuePair<int, int>(224, 461),
    new KeyValuePair<int, int>(225, 295),
    new KeyValuePair<int, int>(225, 406),
    new KeyValuePair<int, int>(242, 239),
    new KeyValuePair<int, int>(242, 628),
    new KeyValuePair<int, int>(243, 517),
    new KeyValuePair<int, int>(243, 574),
    new KeyValuePair<int, int>(262, 295),
    new KeyValuePair<int, int>(262, 351),
    new KeyValuePair<int, int>(262, 406),
    new KeyValuePair<int, int>(262, 461),
    new KeyValuePair<int, int>(280, 239),
    new KeyValuePair<int, int>(281, 518),
    new KeyValuePair<int, int>(281, 574),
    new KeyValuePair<int, int>(281, 629),
    new KeyValuePair<int, int>(300, 295),
    new KeyValuePair<int, int>(300, 351),
    new KeyValuePair<int, int>(300, 406),
    new KeyValuePair<int, int>(300, 461),
    new KeyValuePair<int, int>(317, 629),
    new KeyValuePair<int, int>(318, 239),
    new KeyValuePair<int, int>(319, 517),
    new KeyValuePair<int, int>(320, 573),
    new KeyValuePair<int, int>(336, 351),
    new KeyValuePair<int, int>(337, 295),
    new KeyValuePair<int, int>(337, 406),
    new KeyValuePair<int, int>(338, 461),
    new KeyValuePair<int, int>(355, 239),
    new KeyValuePair<int, int>(355, 628),
    new KeyValuePair<int, int>(356, 573),
    new KeyValuePair<int, int>(357, 517),
    new KeyValuePair<int, int>(374, 351),
    new KeyValuePair<int, int>(375, 295),
    new KeyValuePair<int, int>(375, 406),
    new KeyValuePair<int, int>(375, 461),
    new KeyValuePair<int, int>(392, 239),
    new KeyValuePair<int, int>(393, 628),
    new KeyValuePair<int, int>(394, 517),
    new KeyValuePair<int, int>(394, 572),
    new KeyValuePair<int, int>(412, 295),
    new KeyValuePair<int, int>(412, 351),
    new KeyValuePair<int, int>(412, 406),
    new KeyValuePair<int, int>(413, 461),
    new KeyValuePair<int, int>(430, 239),
    new KeyValuePair<int, int>(430, 516),
    new KeyValuePair<int, int>(431, 572),
    new KeyValuePair<int, int>(431, 628),
    new KeyValuePair<int, int>(449, 351),
    new KeyValuePair<int, int>(450, 295),
    new KeyValuePair<int, int>(450, 406),
    new KeyValuePair<int, int>(450, 461),
    new KeyValuePair<int, int>(467, 239),
    new KeyValuePair<int, int>(467, 629),
    new KeyValuePair<int, int>(468, 572),
    new KeyValuePair<int, int>(469, 517),
    new KeyValuePair<int, int>(486, 351),
    new KeyValuePair<int, int>(487, 295),
    new KeyValuePair<int, int>(487, 406),
    new KeyValuePair<int, int>(487, 461),
    new KeyValuePair<int, int>(505, 239),
    new KeyValuePair<int, int>(505, 517),
    new KeyValuePair<int, int>(505, 573),
    new KeyValuePair<int, int>(505, 628),
    new KeyValuePair<int, int>(524, 295),
    new KeyValuePair<int, int>(524, 351),
    new KeyValuePair<int, int>(524, 461),
    new KeyValuePair<int, int>(525, 406),
    new KeyValuePair<int, int>(541, 628),
    new KeyValuePair<int, int>(542, 517),
    new KeyValuePair<int, int>(543, 572)
};
            //for (int i = 0; i < coordinates.Length; i++)
            //{
            //    KeyValuePair<int, int> coordinate = coordinates[i];
            //    int x = coordinate.Key;
            //    int y = coordinate.Value;

            //    chairDimensions[i] = new Chair()
            //}


        }
    }
}