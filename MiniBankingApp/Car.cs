using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    public abstract class Car
    {
        public int NoOfWheels { get; set; }
        public string ChassisNumber { get; set; }
        public abstract void Brake();
        public virtual void Accelerate()
        {
            Console.WriteLine("Accelerating...");
        }
        public void Start()
        {
            Console.WriteLine("Started");
        }
    }

    public class Toyota : Car
    {
        public override void Brake()
        {
            Console.WriteLine("Braking...");
        }
    }

    public class Honda : ICar
    {
        public int NoOfWheels { get; set; }
        public string ChassisNumber { get; set; }

        public void Accelerate()
        {
            throw new NotImplementedException();
        }

        public void Brake()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
