namespace webApiTaxi
{
    public class License
    {
        public int ID { get; set; }
        public int Id_driv {  get; set; }
        public DateTime License_issue_date { get; set; }
        public DateTime License_expiry_date { get; set; }
        public required string Issued_by { get; set; }
        public required string License_code { get; set; }
        public required string Residence { get; set; }
        public required string Category { get; set; }
    }
}
