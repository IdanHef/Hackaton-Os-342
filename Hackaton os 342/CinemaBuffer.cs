using Hackaton_os_342;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Windows.Forms;


public class Buffer
{
    private readonly List<Chair> chairs;
    private readonly object lockObject;
    private readonly int capacity;
    private int waitingCount;

    public int Capacity => capacity;
    public int OccupiedCount => chairs.Count(chair => chair.IsTaken);
    public int AvailableCount => capacity - OccupiedCount;
    public int WaitingCount => waitingCount;

    private UserControl1 userControl;

    public double PercentageCapacity => (double)OccupiedCount / capacity * 100;
    public double AverageWaitingTime { get; private set; }

    public Buffer(Chair[] chairDimensions, UserControl1 userControl1)
    {
        chairs = new List<Chair>(chairDimensions);
        lockObject = new object();
        capacity = chairDimensions.Length;
        waitingCount = 0;
        userControl = userControl1;
    }

    public Chair GetAvailableChair()
    {
        lock (lockObject)
        {
            Chair availableChair = chairs.FirstOrDefault(chair => !chair.IsTaken);

            if (availableChair != null)
            {
                availableChair.TakeChair();
                //PictureBox pictureBox = availableChair.pictureBox;
                //if (pictureBox == null) {
                //    availableChair.pictureBox = new PictureBox();
                //    pictureBox = availableChair.pictureBox;
                //    pictureBox.Image = Image.FromFile("C:\\Users\\physics\\Documents\\david\\uni\\year_2_semester_2\\Hackaton-Os-342\\images_folder\\monkey.png");
                //    //pictureBox.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, "pic.png")); // Set the image for the PictureBox
                //    pictureBox.Location = new Point(availableChair.Dimension[0], availableChair.Dimension[1]); // Set the location (top-left coordinates) where you want the PictureBox to appear on the form
                //    // TO DO : add to ponit the strat coordinated of the big image.
                //    pictureBox.Size = new Size(36, 40);                // Set the size of the PictureBox
                //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;                // Adjust the size mode according to your needs
                //}
                //else
                //{
                    userControl.Invoke((MethodInvoker)(() =>
                    {
                        availableChair.pictureBox.Visible = true;
                        availableChair.pictureBox.BringToFront();

                    }));
                    //give new image, random func that givens random image
                //}
                // Add the PictureBox to the form's Controls collection                
                return availableChair;
            }

            return null;
        }
    }

    public void ReleaseChair(Chair chair)
    {
        lock (lockObject)
        {   
            chair.pictureBox.Visible = false;
            chair.ReleaseChair();
        }
    }
    
    public int GetChairIndex(Chair chair)
    {
        lock (lockObject)
        {
            return chairs.IndexOf(chair);
        }
    }

    public Chair GetOccupiedChair()
    {
        lock (lockObject)
        {
            Chair occupiedChair = chairs.FirstOrDefault(chair => chair.IsTaken && chair.HasAnimal);

            if (occupiedChair != null)
            {
                return occupiedChair;
            }

            return null;
        }
    }
    // asdf

}
