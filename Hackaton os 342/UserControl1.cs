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

        private static object counterLock = new object();
        private static int counter_to_check = 0;

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
                Chair chair = chairs[i];
                PictureBox pictureBox = new PictureBox();
                //pictureBox.Image = Image.FromFile("D:\\My documents\\university\\year 2 semester 2\\Operating System\\homeworks\\hw2\\Hackaton os 342\\images_folder\\monkey.png");
                pictureBox.Image = Image.FromFile("C:\\Users\\physics\\Documents\\david\\uni\\year_2_semester_2\\Hackaton-Os-342\\images_folder\\monkey.png");
                //pictureBox.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "pic.png")); // Set the image for the PictureBox

                int x = pictureBox2.Left;
                int y = pictureBox2.Top;
                pictureBox.Location = new Point(chair.Dimension[0] + x, y + chair.Dimension[1]); // Set the location (top-left coordinates) where you want the PictureBox to appear on the form
                // TO DO : add to ponit the strat coordinated of the big image.
                pictureBox.Size = new Size(28, 31);                // Set the size of the PictureBox
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
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
                {{131, 629},
{132, 518},
{132, 574},
{150, 295},
{150, 351},
{150, 406},
{150, 461},
{168, 239},
{169, 518},
{169, 574},
{169, 628},
{188, 351},
{188, 406},
{188, 461},
{189, 295},
{206, 239},
{207, 518},
{207, 574},
{207, 629},
{225, 351},
{225, 461},
{226, 295},
{226, 406},
{243, 239},
{243, 628},
{244, 517},
{244, 574},
{263, 295},
{263, 351},
{263, 406},
{263, 461},
{281, 239},
{282, 518},
{282, 574},
{282, 629},
{301, 295},
{301, 351},
{301, 406},
{301, 461},
{318, 629},
{319, 239},
{320, 517},
{321, 573},
{337, 351},
{338, 295},
{338, 406},
{339, 461},
{356, 239},
{356, 628},
{357, 573},
{358, 517},
{375, 351},
{376, 295},
{376, 406},
{376, 461},
{393, 239},
{394, 628},
{395, 517},
{395, 572},
{413, 295},
{413, 351},
{413, 406},
{414, 461},
{431, 239},
{431, 516},
{432, 572},
{432, 628},
{450, 351},
{451, 295},
{451, 406},
{451, 461},
{468, 239},
{468, 629},
{469, 572},
{470, 517},
{487, 351},
{488, 295},
{488, 406},
{488, 461},
{506, 239},
{506, 517},
{506, 573},
{506, 628},
{525, 295},
{525, 351},
{525, 461},
{526, 406},
{542, 628},
{543, 517},
{544, 572}};

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
                bool was_full = false;
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
            Invoke(new Action(() =>
            {
                label6.Text = stopwatch.Elapsed.TotalSeconds.ToString();
                label9.Text = buffer.PercentageCapacity.ToString();
                label10.Text = waitingTasks.ToString();
                label11.Text = AverageWaitingTime.ToString();
            }));
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
