

namespace console_appli
{
    public class OrderWithDetailsView
    {
        public int OrderId { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity {  get; set; }   
        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return $"#{OrderId}\t{OrderDate}\t{ProductName}\t X{Quantity}\t @ {UnitPrice.ToString("C")}";
        }
    }
}
