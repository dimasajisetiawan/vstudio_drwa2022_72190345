namespace Drwa_2022.Models
{
    public class JadwalItem
    {
        private JadwalContext context;

        public int id { get; set; }
        public string tahun { get; set; }

        public string semester { get; set; }    

        public int id_guru { get; set; }

        public string nip { get; set; }

        public string nama_guru { get; set; }

        public string hari { get; set; }

        public int id_kelas { get; set; }

        public string kelas { get; set; }   

        public string jurusan { get; set; } 

        public string sub { get; set; }
        
        public int id_mapel {get; set; }

        public string nama_mapel { get; set; }  

        public string jam_mulai { get; set; }   

        public string jam_selesai { get; set; } 
    }
}
