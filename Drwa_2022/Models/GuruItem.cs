namespace Drwa_2022.Models
{
    public class GuruItem
    {
        private GuruContext context;

        public int id { get; set; }
        public string rfid { get; set; }

        public string nip { get; set; }

        public string nama { get; set; }

        public string alamat { get; set; }

        public int status { get; set; }
    }
}
