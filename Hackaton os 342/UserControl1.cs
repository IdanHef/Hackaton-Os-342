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
    public partial class UserControl1 : UserControl
    {
        Chair[] chairs;
        private int producerCount;
        private int consumerCount;
        private int producerRatio;
        private int consumerRatio;
        private Thread producerThread;
        private Thread consumerThread;
        private readonly Producer producer;
        private readonly Consumer consumer;
        Buffer buffer;

        public UserControl1(int[] data)
        {   
            InitializeComponent();
            producerCount = data[0];
            consumerCount = data[1];
            producerRatio = data[2];
            consumerRatio = data[3];
            chairs = new Chair[90];
            initializeChairs();
            buffer= new Buffer(chairs, this);
            producer = new Producer(buffer);
            consumer = new Consumer(buffer);
            for (int i = 0; i < chairs.Length; i++)
            {
                Chair chair = chairs[i];
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile("D:\\My documents\\university\\year 2 semester 2\\Operating System\\homeworks\\hw2\\Hackaton os 342\\images_folder\\monkey.png");
                //pictureBox.Image = Image.FromFile("C:\\Users\\physics\\Documents\\david\\uni\\year_2_semester_2\\Hackaton-Os-342\\images_folder\\monkey.png");
                //pictureBox.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "pic.png")); // Set the image for the PictureBox
                pictureBox.Location = new Point(chair.Dimension[0] +600, -10 + chair.Dimension[1]); // Set the location (top-left coordinates) where you want the PictureBox to appear on the form
                // TO DO : add to ponit the strat coordinated of the big image.
                pictureBox.Size = new Size(36, 40);                // Set the size of the PictureBox
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Visible = true;
                chair.pictureBox = pictureBox;
                
                this.Controls.Add(pictureBox);
            }
            this.pictureBox1.SendToBack();
            Thread myThread = new Thread(StartProducerConsumerCommunication);
            //asdfasdfasdfadsfasdfasdf

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
        //private void StartProducerConsumerCommunication()
        //{
        //    Thread.Sleep(1000);
        //    producerThread = new Thread(() => producer.ProduceItems(producerCount));
        //    consumerThread = new Thread(() => consumer.ConsumeItems(consumerCount));
        //    Start the producer and consumer threads
        //    producerThread.Start();
        //    consumerThread.Start();

        //    Optionally, you can join the threads to wait for their completion

        //   producerThread.Join();
        //   consumerThread.Join();

        //    You can also update the UI or display status messages here
        //    to indicate that the producer and consumer actions have started.

        //}
        private void StartProducerConsumerCommunication()
        {
            // Create a timer with an interval based on the producer ratio
            System.Threading.Timer producerTimer = new System.Threading.Timer(ProduceItemsTimerCallback, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(producerRatio));

            // Create a timer with an interval based on the consumer ratio
            System.Threading.Timer consumerTimer = new System.Threading.Timer(ConsumeItemsTimerCallback, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(consumerRatio));

            // Optionally, you can update the UI or display status messages here
            // to indicate that the producer and consumer actions have started.
        }

        private void ProduceItemsTimerCallback(object state)
        {
            // Create a new producer thread
            Thread producerThread = new Thread(() => producer.ProduceItems(producerCount));

            // Start the producer thread
            producerThread.Start();

            // Optionally, you can join the producer thread to wait for its completion
            producerThread.Join();
        }

        private void ConsumeItemsTimerCallback(object state)
        {
            // Create a new consumer thread
            Thread consumerThread = new Thread(() => consumer.ConsumeItems(consumerCount));

            // Start the consumer thread
            consumerThread.Start();

            // Optionally, you can join the consumer thread to wait for its completion
            consumerThread.Join();
        }


        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
