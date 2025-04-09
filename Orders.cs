namespace webApiTaxi
{
    public class Orders
    {
        public int ID { get; set; }
        public int id_status {  get; set; }
        public DateTime time_start { get; set; }
        public DateTime time_end { get; set; }
        public required string address_1 { get; set; }
        public required string address_2 { get; set; } 
        public int number_km { get; set; }
        public int  id_rate {  get; set; }
        public int id_types { get; set; }
        public int id_driver { get; set; }
        public string? suName_client {  get; set; }
        public string? name_client { get; set; }
        public required string number_client { get; set; }
        public string? addition {  get; set; }
        public decimal totalCost { get; set; }


    }
}
