namespace MiniBankingApp
{
    public interface ICar
    {
        int NoOfWheels { get; set; }
        string ChassisNumber { get; set; }
        void Brake();
        void Accelerate();
        void Start();
    }
}
