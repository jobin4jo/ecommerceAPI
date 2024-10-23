namespace ecommerceAPI.Model
{
    public class Order
    {
        public int OrderId { get; set; }    
        public string CustomerId { get; set; }      
        public DateTime OrderDate { get; set; }
        public DateTime DeliveredExcepted {  get; set; }    
        public bool ContainsGift {  get; set; } 
    }
}
