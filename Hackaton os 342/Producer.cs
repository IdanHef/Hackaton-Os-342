using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton_os_342
{
    internal class Producer
    {
        private readonly Buffer buffer;

        public Producer(Buffer buffer)
        {
            this.buffer = buffer;
        }

        public void ProduceItems(int numberOfItems)
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                // Simulate producing an item
                string item = $"Item {i + 1}";

                // Get an available chair from the buffer
                Chair chair = buffer.GetAvailableChair();

                if (chair != null)
                {
                    // Place the item on the chair
                    chair.TakeChair();
                    chair.AssignAnimal();
                    chair.Item = item;
                    Console.WriteLine($"Producer placed {item} on chair {chair.Id}");
                }
                else
                {
                    Console.WriteLine($"Producer couldn't find an available chair. Waiting...");
                    // Add a delay or wait here before trying again
                }

                // Simulate some delay before producing the next item
                Thread.Sleep(1000);
            }
        }
    }
}
