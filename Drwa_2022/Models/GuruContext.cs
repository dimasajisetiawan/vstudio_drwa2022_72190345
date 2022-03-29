using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Drwa_2022.Models
{
    public class GuruContext : DbContext
    {
        public GuruContext(DbContextOptions<GuruContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        //public GuruContext(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //}

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = sibaru; Uid = root; Pwd = ");
        }

        public List<GuruItem> GetAllGuru()
        {
            List<GuruItem> list = new List<GuruItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GuruItem()
                        {
                            id = reader.GetInt32("id_guru"),
                            rfid = reader.GetString("rfid"),
                            nip = reader.GetString("nip"),
                            nama = reader.GetString("nama_guru"),
                            alamat = reader.GetString("alamat"),
                            status = reader.GetInt32("status_guru")
                        });
                    }
                }
            }
            return list;
        }

        public List<GuruItem> GetGuru(string nip)
        {
            List<GuruItem> list = new List<GuruItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM guru WHERE nip = @nip", conn);
                cmd.Parameters.AddWithValue("@nip", nip);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GuruItem()
                        {
                            id = reader.GetInt32("id_guru"),
                            rfid = reader.GetString("rfid"),
                            nip = reader.GetString("nip"),
                            nama = reader.GetString("nama_guru"),
                            alamat = reader.GetString("alamat"),
                            status = reader.GetInt32("status_guru")
                        });
                    }
                }
            }
            return list;
        }
        public GuruItem AddGuru(GuruItem gi)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into guru (rfid,nip,nama_guru,alamat,status_guru) values (@rfid, @nip, @nama, @alamat, @status) ", conn);
                cmd.Parameters.AddWithValue("@rfid", gi.rfid);
                cmd.Parameters.AddWithValue("@nip", gi.nip);
                cmd.Parameters.AddWithValue("@nama", gi.nama);
                cmd.Parameters.AddWithValue("@alamat", gi.alamat);
                cmd.Parameters.AddWithValue("@status", gi.status);

                cmd.ExecuteReader();
                /*using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        *//*list.Add(new GuruItem()
                        {
                            id = reader.GetInt32("id_kelas"),
                            kelas = reader.GetString("kelas"),
                            sub = reader.GetInt32("sub"),
                            jurusan = reader.GetString("jurusan")
                        });*//*
                    }
                }*/
            }
            return gi;
        }
    }
}
