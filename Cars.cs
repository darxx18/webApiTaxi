namespace webApiTaxi
{
    public class Cars
    {
        public int ID { get; set; }
        public int Id_brand {  get; set; }
        public required string Model_car {get; set; }
        public required string Number { get; set; }
        public int Id_color { get; set; }
        public int Id_driv {  get; set; }
        public int Year_car { get; set; }
        public required string Number_reqcert {  get; set; }
        public bool Repair { get; set; }
    }
}
