using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hackaton_os_342
{
    internal class Consumer
    {
        private readonly Buffer buffer;

        public Consumer(Buffer buffer)
        {
            this.buffer = buffer;
        }

        public void ConsumeItems(int numberOfItems)
{
    for (int i = 0; i < numberOfItems; i++)
    {
        // Get an occupied chair from the buffer
        Chair chair = buffer.GetOccupiedChair();

        if (chair != null)
        {
            // Retrieve the item from the chair
            string item = chair.Item;

            // Release the chair and consume the item
            chair.ReleaseChair();
            chair.ReleaseAnimal();
            chair.Item = null;

            Console.WriteLine($"Consumer consumed {item} from chair {chair.Id}");
        }
        else
        {
            Console.WriteLine($"Consumer couldn't find an occupied chair. Waiting...");
            // Add a delay or wait here before trying again
        }

        // Simulate some delay between consuming items
        Thread.Sleep(1500);

        // Release the chair even if it was not found
        buffer.ReleaseChair(chair);
    }
}


    }
}
