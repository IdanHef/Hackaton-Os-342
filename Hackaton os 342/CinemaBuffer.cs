using System;
using System.Collections.Generic;
using System.Threading;

public class CinemaBuffer
{
    private List<Chair> chairDimensions;
    private List<int> occupiedChairs;

    public CinemaBuffer(List<Chair> chairDimensions)
    {
        this.chairDimensions = chairDimensions;
        occupiedChairs = new List<int>(chairDimensions.Count);
    }

    public int GetChair()
    {
        lock (occupiedChairs)
        {
            while (occupiedChairs.Count == chairDimensions.Count)
            {
                Monitor.Wait(occupiedChairs);
            }

            // Find the index of the first unoccupied chair
            int chairIndex = occupiedChairs.IndexOf(0);
            occupiedChairs[chairIndex] = 1; // Mark the chair as occupied

            return chairIndex;
        }
    }

    public void ReleaseChair(int chair)
    {
        lock (occupiedChairs)
        {
            occupiedChairs[chair] = 0; // Mark the chair as unoccupied
            Monitor.Pulse(occupiedChairs);
        }
    }
}
