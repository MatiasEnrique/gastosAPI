namespace gastosAPI.models
{
    public class Gasto
    {
        public int Id { get; set; }

        public string Detail { get; set; } = null!;
        
        public double Amount { get; set; }
    }
}
