namespace MiniBankingApp
{
    public class Volkswagen : ICar
    {
        public int NoOfWheels { get; set; }
        public string ChassisNumber { get; set; }
        public int NoOfDoors { get; set; }

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
