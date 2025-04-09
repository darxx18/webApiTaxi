namespace webApiTaxi
{
    public class Drivers
    {
        public int ID { get; set; }
        public required string Lastname { get; set; }
        public required string Firstname { get; set; }
        public string? Middle_name { get; set; }
        public required string numper_phone { get; set; }
        public bool works {  get; set; }
    }
}
