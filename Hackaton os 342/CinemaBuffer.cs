using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

    public double PercentageCapacity => (double)OccupiedCount / capacity * 100;
    public double AverageWaitingTime { get; private set; }

    public Buffer(Chair[] chairDimensions)
    {
        chairs = new List<Chair>(chairDimensions);
        lockObject = new object();
        capacity = chairDimensions.Length;
        waitingCount = 0;
    }

    public Chair GetAvailableChair()
    {
        lock (lockObject)
        {
            Chair availableChair = chairs.FirstOrDefault(chair => !chair.IsTaken);

            if (availableChair != null)
            {
                availableChair.TakeChair();
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = // Set the image for the PictureBox
                pictureBox.Location = // Set the location (top-left coordinates) where you want the PictureBox to appear on the form
                pictureBox.Size = // Set the size of the PictureBox
                //pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust the size mode according to your needs

                // Add the PictureBox to the form's Controls collection 
                Hackaton_os_342.Form1.getControlers();
                return availableChair;
            }

            return null;
        }
    }

    public void ReleaseChair(Chair chair)
    {
        lock (lockObject)
        {
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
