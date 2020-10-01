using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; //for generating a MessageBox upon encountering an error
using HRIS.Teaching;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace HRIS.Database
{
    abstract class Agency
    {
        private static bool reportingErrors = false;

        //These would not be hard coded in the source file normally, but read from the application's settings (and, ideally, with some amount of basic encryption applied)
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }
        public static List<TeachingStaff> LoadAll()
        {
            List<TeachingStaff> staff = new List<TeachingStaff>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name from staff", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    staff.Add(new TeachingStaff { ID = rdr.GetInt32(0), Name = rdr.GetString(1) + " " + rdr.GetString(2) });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading staff", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return staff;
        }
        public static List<Consultation> LoadConsultation(int id)
        {
            List<Consultation> work = new List<Consultation>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select day, start, end from consultation where staff_id=?id", conn);
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    work.Add(new Consultation
                    {
                        Day = ParseEnum<DayOfWeek>(rdr.GetString(0)),
                        Start = rdr.GetTimeSpan(1),
                        End = rdr.GetTimeSpan(2)
                    });
                }
            }
            catch (MySqlException e)
            {
                ReportError("loading consultation hours", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return work;
        }
        private static void ReportError(string msg, Exception e)
        {
            if (reportingErrors)
            {
                MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
