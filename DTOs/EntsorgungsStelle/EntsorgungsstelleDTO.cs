namespace DTOs
{
    public class EntsorgungsstelleDTO
    {
        public string name { get; set; }
        public List<double> geo_point_2d { get; set; }
        public string ortschaft { get; set; }
        public int id_entsorg { get; set; }
        public string zustaendig { get; set; }
        public string kategorie { get; set; }
        public string plz { get; set; }
        public string adresse { get; set; }
        public string telefon { get; set; }
        public string beschreibu { get; set; }
        public string www_link { get; set; }
    }
}