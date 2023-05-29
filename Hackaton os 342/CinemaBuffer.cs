using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hackaton_os_342
{
    public class Buffer
    {
        private readonly List<Chair> chairs;
        private readonly object lockObject;
        private readonly int capacity;
        private Semaphore semEmpty;
        private Semaphore semFull;

        private UserControl1 userControl;

        public int Capacity => capacity;
        public int OccupiedCount => chairs.Count(chair => chair.IsTaken);
        public int AvailableCount => capacity - OccupiedCount;

        public Buffer(Chair[] chairDimensions, UserControl1 userControl1)
        {
            chairs = new List<Chair>(chairDimensions);
            lockObject = new object();
            capacity = chairDimensions.Length;
            semEmpty = new Semaphore(capacity, capacity);
            semFull = new Semaphore(0, capacity);
            userControl = userControl1;

        }

        public Chair GetAvailableChair()
        {
            semEmpty.WaitOne();

            lock (lockObject)
            {
                Chair availableChair = chairs.FirstOrDefault(chair => !chair.IsTaken && !chair.pictureBox.Visible);

                if (availableChair != null)
                {
                    availableChair.TakeChair();
                    availableChair.pictureBox.Invoke((MethodInvoker)(() =>
                    {
                        availableChair.pictureBox.Visible = true;
                    }));
                    return availableChair;
                }

                return null;
            }
        }

        public void ReleaseChair(Chair chair)
        {
            lock (lockObject)
            {
                chair.pictureBox.Invoke((MethodInvoker)(() =>
                {
                    chair.pictureBox.Visible = false;
                }));
                chair.ReleaseChair();
            }

            semEmpty.Release();
        }

        public Chair GetOccupiedChair()
        {
            semFull.WaitOne();

            lock (lockObject)
            {
                Chair occupiedChair = chairs.FirstOrDefault(chair => chair.IsTaken && chair.pictureBox.Visible);

                if (occupiedChair != null)
                {
                    return occupiedChair;
                }

                return null;
            }
        }

        public void ReleaseOccupiedChair(Chair chair)
        {
            lock (lockObject)
            {
                chair.ReleaseAnimal();
                chair.ReleaseChair();
            }

            semFull.Release();
        }
    }
}
