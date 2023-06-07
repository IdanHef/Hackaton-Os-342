using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hackaton_os_342
{
    public partial class UserControl1 : UserControl
    {
        Chair[] chairs;
        private int producerCount;
        private int consumerCount;
        private int producerRatio;
        private int consumerRatio;

        Buffer buffer;
        private List<Thread> producerThreads;
        private List<Thread> consumerThreads;
        private List<Producer> producers;


        private Semaphore full_semaphore = new Semaphore(0, 90);
        private Semaphore empty_semaphore = new Semaphore(90, 90);


        private System.Threading.Timer timer;
        public Stopwatch stopwatch;

        private System.Threading.Timer avgWaitingTimeTimer;
        public Stopwatch avgWaitingTimeStopwatch;
        private bool isAvgWaitingTimeRunning = false;

        public double AverageWaitingTime => waitingTasks > 0 ? stopwatch.Elapsed.TotalMilliseconds / waitingTasks : 0;




        //CustomSemaphore semaphore = new CustomSemaphore(0, 90);
        //Semaphore semaphore = new Semaphore(0,90); // Semaphore to control buffer space
        Mutex mutex = new Mutex();
        Mutex mutex1 = new Mutex();
        int waitingTasks;


        public UserControl1(int[] data)
        {
            InitializeComponent();
            producerCount = data[0];
            consumerCount = data[1];
            producerRatio = data[2];
            consumerRatio = data[3];
            chairs = new Chair[90];
            waitingTasks = 0;
            initializeChairs();
            buffer = new Buffer(chairs, this);

            for (int i = 0; i < chairs.Length; i++)
            {

            }

            for (int i = 0; i < chairs.Length; i++)
            {
                Chair chair = chairs[i];
                PictureBox pictureBox = new PictureBox();
                string path = Path.Combine(Environment.CurrentDirectory, "monkey.png");
                pictureBox.Image = Image.FromFile(path);
                //pictureBox.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "pic.png")); // Set the image for the PictureBox

                int x = pictureBox2.Left;
                int y = pictureBox2.Top;
                pictureBox.Location = new Point(chair.Dimension[0] - 385, chair.Dimension[1] - 50); // Set the location (top-left coordinates) where you want the PictureBox to appear on the form
                // TO DO : add to ponit the strat coordinated of 2he big image.
                pictureBox.Size = new Size(28, 31 );                // Set the size of the PictureBox
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox.Visible = false;
                chair.pictureBox = pictureBox;

                this.Controls.Add(pictureBox);
                pictureBox.BringToFront();
                // Adjust the Padding and Margin properties of the PictureBox
                pictureBox.Padding = new Padding(0);  // Remove padding
                pictureBox.Margin = new Padding(0);  // Remove margin
            }
            this.pictureBox1.SendToBack();
            // Initialize the producerThreads and consumerThreads lists
            producerThreads = new List<Thread>();
            consumerThreads = new List<Thread>();
            // Create synchronization objects


            producers = new List<Producer>();
            for (int i = 0; i < producerCount; i++)
            {
                Producer producer = new Producer(buffer);
                producers.Add(producer);

                Thread producerThread = new Thread(() => ProducerThreadStart(producer));
                producerThreads.Add(producerThread);
            }


            // Create and start the consumer threads
            for (int i = 0; i < consumerCount; i++)
            {
                Consumer consumer = new Consumer(buffer);
                Thread consumerThread = new Thread(() => ConsumerThreadStart());
                consumerThreads.Add(consumerThread);
            }



            Thread myThread = new Thread(StartProducerConsumerCommunication);

            myThread.Start();

            // Set up timer
            timer = new System.Threading.Timer(Timer_Tick, null, 0, 250);
            stopwatch = new Stopwatch();
            stopwatch.Start();
            avgWaitingTimeStopwatch = new Stopwatch();

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void initializeChairs()
        {
            int[,] coordinates = new int[,]
                {
    {1105, 685},
    {1106, 574},
    {1106, 630},//
    {1124, 351},
    {1124, 407},
    {1124, 462},
    {1124, 517},
    {1142, 295},
    {1143, 574},
    {1143, 630},
    {1143, 684},
    {1162, 407},
    {1162, 462},
    {1162, 517},
    {1163, 351},
    {1180, 295},
    {1181, 574},
    {1181, 630},
    {1181, 685},
    {1199, 407},
    {1199, 517},
    {1200, 351},
    {1200, 462},
    {1217, 295},
    {1217, 684},
    {1218, 573},
    {1218, 630},
    {1237, 351},
    {1237, 407},
    {1237, 462},
    {1237, 517},
    {1255, 295},
    {1256, 574},//
    {1256, 630},
    {1256, 685},
    {1275, 351},
    {1275, 407},
    {1275, 462},
    {1275, 517},
    {1292, 685},
    {1293, 295},
    {1294, 573},
    {1295, 629},
    {1311, 407},
    {1312, 351},
    {1312, 462},
    {1313, 517},
    {1330, 295},
    {1330, 684},
    {1331, 629},
    {1332, 573},
    {1349, 407},
    {1350, 351},
    {1350, 462},
    {1350, 517},
    {1367, 295},
    {1368, 684},
    {1369, 573},
    {1369, 628},
    {1387, 351},
    {1387, 407},
    {1387, 462},
    {1388, 517},
    {1405, 295},
    {1405, 572},
    {1406, 628},
    {1406, 684},
    {1424, 407},
    {1425, 351},
    {1425, 462},
    {1425, 517},
    {1442, 295},
    {1442, 685},
    {1443, 628},
    {1444, 573},
    {1461, 407},
    {1462, 351},
    {1462, 462},
    {1462, 517},
    {1480, 295},
    {1480, 573},
    {1480, 629},
    {1480, 684},
    {1499, 351},
    {1499, 407},
    {1499, 517},
    {1500, 462},
    {1516, 684},
    {1517, 573},
    {1518, 628}
};

            for (int i = 0; i < 90; i++)
            {
                int x = coordinates[i, 0];
                int y = coordinates[i, 1];
                chairs[i] = new Chair(x, y);
            }


        }

        private void StartProducerConsumerCommunication()
        {
            Thread.Sleep(500);
            buffer.SetUserControl(this);
            //Thread.Sleep(1000);

            Thread createP_threads = new Thread(() => StartProducerThreads());
            createP_threads.Start();
            Thread createC_threads = new Thread(() => StartConsumerThreads());
            createC_threads.Start();
        }



        public void StartProducerThreads()
        {

            // Start the producer threads
            for (int i = 0; i < producerCount; i++)
            {
                Thread.Sleep(producerRatio * 100);
                producerThreads[i].Start();
                //producers[i].change_f_run();
            }
        }

        public void StartConsumerThreads()
        {
            // Start the consumer threads

            foreach (Thread consumerThread in consumerThreads)
            {
                Thread.Sleep(consumerRatio * 100);
                consumerThread.Start();
            }
        }

        void ConsumerThreadStart()
        {
            while (true)
            {
                //semaphore_test.WaitOne();
                full_semaphore.WaitOne();

                mutex.WaitOne();

                // Remove an item from the buffer (consume)
                buffer.GetOccupiedChairAndR();


                mutex.ReleaseMutex();

                empty_semaphore.Release(); // Signal the producer thread

                Thread.Sleep(consumerCount * consumerRatio * 100); // Sleep based on the ratio and number of consumer threads
            }
        }

        void ProducerThreadStart(Producer producer)
        {
            while (true)
            {
                //if (!semaphore_test.WaitOne(0)) // Check if there is space in the buffer
                //{
                //    // Producer is waiting, increase waitingTasks
                //    mutex1.WaitOne();
                //    was_full = true;
                //    // Producer is waiting, increase waitingTasks
                //    waitingTasks++;
                //    Invoke(new Action(() =>
                //    {
                //        label6.Text = "enter";

                //    }));
                //    mutex1.ReleaseMutex();
                //    semaphore_test.Release();

                //}

                //if (!empty_semaphore.WaitOne(0))
                //{
                //    lock (counterLock)
                //    {
                //        was_full = true;
                //        waitingTasks++;
                //    }
                //    empty_semaphore.Release();
                //}

                //semaphore.WaitOne(Int32.MaxValue); // Wait for an item in the buffer
                mutex.WaitOne();

                if (waitingTasks > 0 && !isAvgWaitingTimeRunning)
                {
                    avgWaitingTimeStopwatch.Start();
                    isAvgWaitingTimeRunning = true;
                }

                waitingTasks++; // Increment the waiting producers counter

               
                mutex.ReleaseMutex();

                empty_semaphore.WaitOne();
                //semaphore.Wait();

                mutex.WaitOne();
                //if (was_full)
                //{
                //    mutex1.WaitOne();
                //    //Invoke(new Action(() =>
                //    //{
                //    //    counter_to_check++;
                //    //    label6.Text = counter_to_check.ToString();
                //    //}));
                //    waitingTasks--;
                //    mutex1.ReleaseMutex();
                //}

                //if (was_full)
                //{
                //    lock (counterLock)
                //    {
                //        waitingTasks--;
                //    }
                //}
               

                waitingTasks--;

                // Add the item to the buffer (produce)
                producer.ProduceItems();

                mutex.ReleaseMutex();

                full_semaphore.Release(); // Signal the consumer thread

                Thread.Sleep(producerCount * producerRatio * 100); // Sleep based on the ratio and number of producer threads
            }
        }
        private void Timer_Tick(object state)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    label6.Text = stopwatch.Elapsed.TotalSeconds.ToString();
                    label9.Text = buffer.PercentageCapacity.ToString();
                    label10.Text = waitingTasks.ToString();
                    label11.Text = GetAverageWaitingTime().ToString();
                }));
            }
            catch (Exception ex) { }

        }
        private double GetAverageWaitingTime()
        {
            if (waitingTasks > 0)
            {
                return avgWaitingTimeStopwatch.Elapsed.TotalSeconds / waitingTasks;
            }
            else
            {
                return 0;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

        }
    }
}
