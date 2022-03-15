using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drwa_2022.Models
{
    public class KelasContext:DbContext
    {
        public KelasContext(DbContextOptions<KelasContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        //public KelasContext(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //}

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = sibaru; Uid = root; Pwd = ");
        }

        public List<KelasItem> GetAllSiswa()
        {
            List<KelasItem> list = new List<KelasItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM kelas", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KelasItem()
                        {
                            id = reader.GetInt32("id_kelas"),
                            kelas = reader.GetString("kelas"),
                            sub = reader.GetInt32("sub"),
                            jurusan = reader.GetString("jurusan")
                        });
                    }
                }
            }
            return list;
        }

        public List<KelasItem> GetSiswa(string id)
        {
            List<KelasItem> list = new List<KelasItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM kelas WHERE id_kelas = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KelasItem()
                        {
                            id = reader.GetInt32("id_kelas"),
                            kelas = reader.GetString("kelas"),
                            sub = reader.GetInt32("sub"),
                            jurusan = reader.GetString("jurusan")
                        });
                    }
                }
            }
            return list;
        }
    }
}
