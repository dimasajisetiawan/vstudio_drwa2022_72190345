using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Text;

namespace Drwa_2022.Models
{
    public class JadwalContext : DbContext
    {
        public JadwalContext(DbContextOptions<JadwalContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        //public JadwalContext(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //}

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = sibaru; Uid = root; Pwd = ");
        }

        public List<JadwalItem> GetAllJadwal()
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from jadwal_guru j join mapel m on j.id_mapel = m.id_mapel join guru g on j.id_guru = g.id_guru join kelas k on j.id_kelas = k.id_kelas;", conn);
                var jsonResult = new StringBuilder();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id = reader.GetInt32("id_jadwal_guru"),
                            tahun = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            hari = reader.GetString("hari"),
                            kelas = reader.GetString("kelas"),
                            jurusan = reader.GetString("jurusan"),
                            sub = reader.GetString("sub"),
                            nama_mapel = reader.GetString("nama_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai"),
                            id_guru = reader.GetInt32("id_guru"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            id_kelas = reader.GetInt32("id_kelas"),

                        });
                    }
                }
            }
            return list;

        }

        public List<JadwalItem> GetJadwalByNip(string id)
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from jadwal_guru j join mapel m on j.id_mapel = m.id_mapel join guru g on j.id_guru = g.id_guru join kelas k on j.id_kelas = k.id_kelas where nip=@id or j.id_mapel = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id = reader.GetInt32("id_jadwal_guru"),
                            tahun = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            hari = reader.GetString("hari"),
                            kelas = reader.GetString("kelas"),
                            jurusan = reader.GetString("jurusan"),
                            sub = reader.GetString("sub"),
                            nama_mapel = reader.GetString("nama_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai"),
                            id_guru = reader.GetInt32("id_guru"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            id_kelas = reader.GetInt32("id_kelas"),
                        });
                    }
                }
            }
            return list;
        }

        /*public List<JadwalItem> GetJadwalByIDMapel(string id)
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from jadwal_guru j join mapel m on j.id_mapel = m.id_mapel join guru g on j.id_guru = g.id_guru join kelas k on j.id_kelas = k.id_kelas where id_mapel=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id = reader.GetInt32("id_jadwal_guru"),
                            tahun = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            hari = reader.GetString("hari"),
                            kelas = reader.GetString("kelas"),
                            jurusan = reader.GetString("jurusan"),
                            sub = reader.GetString("sub"),
                            nama_mapel = reader.GetString("nama_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai"),
                            id_guru = reader.GetInt32("id_guru"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            id_kelas = reader.GetInt32("id_kelas"),
                        });
                    }
                }
            }
            return list;
        }*/
        public JadwalItem AddJadwal(JadwalItem mi)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into jadwal_guru (tahun_akademik, semester, id_guru, hari, id_kelas, id_mapel, jam_mulai, jam_selesai) values (@tahun, @semester, @id_guru, @hari, @id_kelas, @id_mapel, @jam_mulai, @jam_selesai) ", conn);
                cmd.Parameters.AddWithValue("@tahun", mi.tahun);
                cmd.Parameters.AddWithValue("@semester", mi.semester);
                cmd.Parameters.AddWithValue("@id_guru", mi.id_guru);
                cmd.Parameters.AddWithValue("@hari", mi.hari);
                cmd.Parameters.AddWithValue("@id_kelas", mi.id_kelas);
                cmd.Parameters.AddWithValue("@id_mapel", mi.id_mapel);
                cmd.Parameters.AddWithValue("@jam_mulai", mi.jam_mulai);
                cmd.Parameters.AddWithValue("@jam_selesai", mi.jam_selesai);

                cmd.ExecuteReader();
                /*using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        *//*list.Add(new JadwalItem()
                        {
                            id = reader.GetInt32("id_kelas"),
                            kelas = reader.GetString("kelas"),
                            sub = reader.GetInt32("sub"),
                            jurusan = reader.GetString("jurusan")
                        });*//*
                    }
                }*/
            }
            return mi;
        }
    }
}



