using Hackaton_os_342;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    private UserControl userControl1;


    public int Capacity => capacity;
    public int OccupiedCount => chairs.Count(chair => chair.IsTaken);
    public int AvailableCount => capacity - OccupiedCount;
    public int WaitingCount => waitingCount;

    private UserControl1 userControl;

    public double PercentageCapacity => (double)OccupiedCount / capacity * 100;
   

    //public double AverageWaitingTime => producerTasksWaiting > 0 ? stopwatch.Elapsed.TotalMilliseconds / producerTasksWaiting : 0;

   
    public Buffer(Chair[] chairDimensions, UserControl1 userControl1)
    {
        chairs = new List<Chair>(chairDimensions);
        lockObject = new object();
        capacity = chairDimensions.Length;
        waitingCount = 0;
        userControl = userControl1;
        //producerTasksWaiting = 0;
        
    }

   

    public Chair GetAvailableChair()
    {
        lock (lockObject)
        {
            Chair availableChair = chairs.FirstOrDefault(chair => !chair.IsTaken);

            if (availableChair != null)
            {
                availableChair.TakeChair();

                PictureBox pictureBox = availableChair.pictureBox;
                if (pictureBox == null)
                {
                  
                }
                else
                {
                    userControl1.Invoke((MethodInvoker)(() =>
                    {
                        availableChair.pictureBox.Visible = true;
                        availableChair.pictureBox.BringToFront();
                    }));
                }

                return availableChair;
            }

            return null;
        }
    }



public int GetChairIndex(Chair chair)
    {
        lock (lockObject)
        {
            return chairs.IndexOf(chair);
        }
    }

    public Chair GetOccupiedChairAndR()
    {
        lock (lockObject)
        {
            Chair occupiedChair = chairs.FirstOrDefault(chair => chair.IsTaken);

            if (occupiedChair != null)
            {
                userControl1.Invoke((MethodInvoker)(() =>
                {
                    occupiedChair.pictureBox.Visible = false;
                }));
                occupiedChair.ReleaseChair();
                return occupiedChair;
            }

            return null;
        }
    }
    public void SetUserControl(UserControl userControl)
    {
        this.userControl1 = userControl;
    }

}
