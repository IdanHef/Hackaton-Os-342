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
        private System.Threading.Timer timer_for_screen
;
        public Stopwatch stopwatch;

        private System.Threading.Timer avgWaitingTimeTimer;
        public Stopwatch avgWaitingTimeStopwatch;
        private bool isAvgWaitingTimeRunning = false;

        public double AverageWaitingTime => waitingTasks > 0 ? stopwatch.Elapsed.TotalMilliseconds / waitingTasks : 0;

        private int currentScreenImageIndex = 0; // Index of the current screen image to display



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
                //pictureBox.Location = new Point(chair.Dimension[0] - 385, chair.Dimension[1] - 50); // Set the location (top-left coordinates) where you want the PictureBox to appear on the form
                pictureBox.Location = new Point(chair.Dimension[0] , chair.Dimension[1]); // Set the location (top-left coordinates) where you want the PictureBox to appear on the form
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
            timer_for_screen = new System.Threading.Timer(Timer_Tick_for_screen, null, 0, 3000);
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
    //{1105, 685},
    {1000, 290 },
    {975, 290}, {950, 290}, {925, 290}, {900, 290}, {875, 290}, {850, 290}, {825, 290}, {800, 290}, {775, 290}, {750, 290},
    {750, 340},{775, 340}, {800, 340}, {825, 340}, {850, 340}, {875, 340}, {900, 340}, {925, 340}, {950, 340}, {975, 340}, {1000, 340},
    {750, 388},{775, 388}, {800, 388}, {825, 388}, {850, 388}, {875, 388}, {900, 388}, {925, 388}, {950, 388}, {975, 388}, {1000, 388},
    {750, 435},{775, 435}, {800, 435}, {825, 435}, {850, 435}, {875, 435}, {900, 435}, {925, 435}, {950, 435}, {975, 435}, {1000, 435},
    
                {734, 571},
                {759, 571},
                {784, 571},
                {809, 571},
                {834, 571},
                {859, 571},
                {884, 571},
                {909, 571},
                {934, 571},
                {959, 571},
                {984, 571},
                {1009, 571},

                // 12
                {734, 525},
                {759, 525},
                {784, 525},
                {809, 525},
                {834, 525},
                {859, 525},
                {884, 525},
                {909, 525},
                {934, 525},
                {959, 525},
                {984, 525},
                {1009, 525},

                // 12
                {734, 478},
                {759, 478},
                {784, 478},
                {809, 478},
                {834, 478},
                {859, 478},
                {884, 478},
                {909, 478},
                {934, 478},
                {959, 478},
                {984, 478},
                {1009, 478},

                // 10 first line
                {744+ 15, 245},
                {769+ 15, 245},
                {794+ 15, 245},
                {819+ 15, 245},
                {844+ 15, 245},
                {869+ 15, 245},
                {894+ 15, 245},
                {919+ 15, 245},
                {944+ 15, 245},
                {969+ 15, 245},
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
            catch (Exception e) { }

        }
        private void Timer_Tick_for_screen(object state)
        {
            try 
            {
                Invoke(new Action(() => {
                    // Hide the current screen image
                    pictureBox2.Visible = false;

                    // Switch to the next screen image
                    currentScreenImageIndex = (currentScreenImageIndex + 1) % 4; // Assuming you have 4 different images

                    // Set the next screen image
                    string imageName = GetNextScreenImagePath(); // Implement this method to get the path of the next screen image
                    string path = Path.Combine(Environment.CurrentDirectory, imageName);
                    pictureBox2.Image = Image.FromFile(path);

                    // Show the next screen image
                    pictureBox2.Visible = true;
                }));

            }
            catch (Exception e){ }
            
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

        private string GetNextScreenImagePath()
        {
            // Implement this method to return the path of the next screen image based on the currentScreenImageIndex
            // You can use a switch statement, if-else conditions, or any logic to determine the path

            // Example:
            switch (currentScreenImageIndex)
            {
                case 0:
                    return "zootopia.jpg"; // Replace with the actual path of the first image
                case 1:
                    return "tarzan.jpg"; // Replace with the actual path of the second image
                case 2:
                    return "KungFuPanda.jpg"; // Replace with the actual path of the third image
                case 3:
                    return "lion.jpg"; // Replace with the actual path of the fourth image
                default:
                    return "default.jpg"; // Replace with the default image path or handle the case as needed
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
