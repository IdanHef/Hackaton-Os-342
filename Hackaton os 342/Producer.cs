using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton_os_342
{
    internal class Producer
    {
        bool first_run;
        private readonly Buffer buffer;
        // Other members

        private bool isTaskPending;

        public bool IsTaskPending => isTaskPending;

        public void SetTaskPending(bool value)
        {
            isTaskPending = value;
        }

        public Producer(Buffer buffer)
        {   
            //Thread.Sleep(1000);
            this.buffer = buffer;
            first_run = true;
        }

        public void change_f_run() { first_run = false; }
         
        public bool get_f_run() { return first_run; }

        //public void ProduceItems()
        //{
        //    if (!IsTaskPending)
        //    {
        //        // Perform the producer task here
        //        // You can call buffer methods to add pictures for producers

        //        if (buffer.OccupiedCount < buffer.Capacity)
        //        {
        //            // Add pictures to the buffer
        //            // ...

        //            SetTaskPending(true); // Mark the task as pending
        //        }
        //    }
        //}

        public void ProduceItems()
        {

            // Get an available chair from the buffer
            Chair chair = buffer.GetAvailableChair();

            if (chair != null)
            {
                // Place the item on the chair
                chair.TakeChair();
            }
          
        }

    }
}
