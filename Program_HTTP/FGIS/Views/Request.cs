using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using FGIS.Models;
using System.Net.Http.Json;
using System.Data.SQLite;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;
using System.Data.Entity.Infrastructure;

namespace FGIS.Views 
{
    public partial class Request : Form
    {
        Result_HTTP result_HTTP = new Result_HTTP();
        Result Save = new Result();
        static HttpClient httpClient = new HttpClient();
        Result_HTTP person = new Result_HTTP();
        List_Item HTTP = new List_Item();
        List_Item Result = new List_Item();
        bool True = true;
        int size;
        int ID_DB;
        int[] ID_MASS = new int[1] { 0 };

        public Request()
        {
            InitializeComponent();
        }
        private async void HTTP_LOAD_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new("result.json", FileMode.OpenOrCreate))
            {
                Save = await JsonSerializer.DeserializeAsync<Result>(fs);
                HTTP.items = Save.items;
                Result.items = Save.items;
            }
            Request_HTTP(mit_number.Text, mi_modification.Text, verification_date_start.Text, verification_date_end.Text);
        }
        private void Request_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 11; i++)
            {
                DataGridViewTextBoxColumn Column;
                Column = new System.Windows.Forms.DataGridViewTextBoxColumn
                {
                    ReadOnly = true
                };
                switch (i)
                {
                    case 0:
                        Column.HeaderText = "№";
                        break;
                    case 1:
                        Column.HeaderText = "vri_id";
                        break;
                    case 2:
                        Column.HeaderText = "org_title";
                        break;
                    case 3:
                        Column.HeaderText = "mit_number";
                        break;
                    case 4:
                        Column.HeaderText = "mit_title";
                        break;
                    case 5:
                        Column.HeaderText = "mit_notation";
                        break;
                    case 6:
                        Column.HeaderText = "mi_modification";
                        break;
                    case 7:
                        Column.HeaderText = "mi_number";
                        break;
                    case 8:
                        Column.HeaderText = "verification_date";
                        break;
                    case 9:
                        Column.HeaderText = "valid_date";
                        break;
                    case 10:
                        Column.HeaderText = "result_docnum";
                        break;
                    case 11:
                        Column.HeaderText = "applicability";
                        break;
                }
                dataGridView_HTTP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Column });
            }
            Load_BD_Result();
        }
        private async void Request_HTTP(string mit_number, string mi_modification, string verification_date_start, string verification_date_end)
        {
            HTTP.items.Clear();
            using (FileStream fs = new("result.json", FileMode.OpenOrCreate))
            {
                Save = await JsonSerializer.DeserializeAsync<Result>(fs);
            }
            string Http_request;
            if (mit_number != "")
            {
                Http_request = $"https://fgis.gost.ru/fundmetrology/eapi/vri?mit_number={mit_number}";
                if (mi_modification != "")
                {
                    Http_request += $"&mi_modification={mi_modification}";
                }
                if (verification_date_start != "")
                {
                    Http_request += $"&verification_date_start={verification_date_start}";
                }
                if (verification_date_end != "")
                {
                    Http_request += $"&verification_date_end={verification_date_end}";
                }
                using (FileStream fs = new("save_HTTP.json", FileMode.OpenOrCreate))
                {
                    try
                    {
                        Result = await JsonSerializer.DeserializeAsync<List_Item>(fs);
                    }
                    catch { }
                }
                using (FileStream fs = new("save_HTTP.json", FileMode.Create))
                {
                    int start = 0;
                    float percent;
                    do
                    {
                        try
                        {
                            var response = await httpClient.GetAsync($"{Http_request}&start={start}&rows={100}");
                            person = await response.Content.ReadFromJsonAsync<Result_HTTP>();
                        }
                        catch (Exception ex)
                        {

                            if (ex.Message == "'<' is an invalid start of a value. Path: $ | LineNumber: 0 | BytePositionInLine: 0.")
                            {

                            }
                            if (ex.Message == "Этот хост неизвестен. (fgis.gost.ru:443)")
                            {
                                MessageBox.Show("Нет доступа к интернету");
                                return;
                            }
                            else
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }
                        try
                        {
                            if (Convert.ToInt32(person.result.count) > 100)
                            {
                                start = start + 100;
                            }
                            else
                            {
                                start = start + Convert.ToInt32(person.result.count);
                            }
                            percent = start;
                            percent = percent / Convert.ToInt32(person.result.count) * 100;
                            Loading.Text = $"[{percent.ToString("0")}%]";
                        }
                        catch { }
                    } while (start < person.result.count);
                    for (int i = 0; i < Convert.ToInt32(person.result.items.Count); i++)
                    {
                        var add = true;
                        try
                        {
                            for (int j = 0; j < Convert.ToInt32(HTTP.items.Count); j++)
                            {
                                if (person.result.items[i].mit_number == HTTP.items[j].mit_number && person.result.items[i].mi_modification == HTTP.items[j].mi_modification && person.result.items[i].org_title == HTTP.items[j].org_title && person.result.items[i].verification_date == HTTP.items[j].verification_date)
                                {
                                    add = false;
                                }
                                if (person.result.items[i].mit_number == HTTP.items[j].mit_number && person.result.items[i].mi_modification == HTTP.items[j].mi_modification && person.result.items[i].org_title == HTTP.items[j].org_title && person.result.items[i].verification_date != HTTP.items[j].verification_date)
                                {
                                    add = false;
                                    int date1 = 0, date2 = 0;
                                    for (int index = 6; index < 10; index++)
                                    {
                                        date1 = Convert.ToInt32(HTTP.items[j].verification_date[index]);
                                        date2 = Convert.ToInt32(person.result.items[i].verification_date[index]);
                                    }
                                    if (date1 <= date2)
                                    {
                                        for (int index = 3; index < 5; index++)
                                        {
                                            date1 = Convert.ToInt32(HTTP.items[j].verification_date[index]);
                                            date2 = Convert.ToInt32(person.result.items[i].verification_date[index]);
                                        }
                                        if (date1 == date2)
                                        {
                                            for (int index = 0; index < 2; index++)
                                            {
                                                date1 = Convert.ToInt32(HTTP.items[j].verification_date[index]);
                                                date2 = Convert.ToInt32(person.result.items[i].verification_date[index]);
                                            }
                                            if (date1 < date2)
                                            {
                                                HTTP.items[j].verification_date = person.result.items[i].verification_date;
                                            }
                                        }
                                        else if (date1 < date2)
                                        {
                                            HTTP.items[j].verification_date = person.result.items[i].verification_date;
                                        }
                                    }
                                }
                            }
                        }
                        catch { }
                        if (add == true)
                        {
                            HTTP.items.Add(person.result.items[i]);
                            for (int j = 0; j < Convert.ToInt32(HTTP.items.Count); j++)
                            {
                                add = true;
                                for (int k = 0; k < Convert.ToInt32(Result.items.Count); k++)
                                {
                                    if (Result.items[k].mit_number == HTTP.items[j].mit_number && Result.items[k].mi_modification == HTTP.items[j].mi_modification && Result.items[k].org_title == HTTP.items[j].org_title && Result.items[k].verification_date == HTTP.items[j].verification_date)
                                    {
                                        add = false;
                                    }
                                }
                                if (add == true)
                                {
                                    Result.items.Add(HTTP.items[j]);
                                }
                            }
                        }
                    }
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    await JsonSerializer.SerializeAsync<List_Item>(fs, Result, options);
                }
            }
            dataGridView_HTTP.Rows.Clear();
            int id = 1;
            foreach (var item in HTTP.items)
            {
                dataGridView_HTTP.Rows.Add(id++,
                                         item.vri_id,
                                         item.org_title,
                                         item.mit_number,
                                         item.mit_title,
                                         item.mit_notation,
                                         item.mi_modification,
                                         item.mi_number,
                                         item.verification_date,
                                         item.valid_date,
                                         item.result_docnum,
                                         item.applicability);
            }
            MessageBox.Show("Поиск завершён");
            DataBase_INSERT();
        }
        private void DataBase_INSERT()
        {
            DataBase_DELETE();
            string connectionString = "Data Source=Test.db;";
            using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
            {
                foreach (var item in Result.items)
                {
                    string sqlQuery;
                    sqlConnection.Open();
                    sqlQuery = $"INSERT INTO Result(vri_id,org_title,mit_number,mit_title, mit_notation,mi_modification,mi_number," +
                                $"verification_date,valid_date,result_docnum,applicability)" +
                                $" VALUES ('{item.vri_id}','{item.org_title}','{item.mit_number}','{item.mit_title}','{item.mit_notation}','{item.mi_modification}'," +
                                $"'{item.mi_number}','{item.verification_date}','{item.valid_date}','{item.result_docnum}','{item.applicability}')";
                    string cmd = sqlQuery;
                    SQLiteCommand command = new SQLiteCommand(cmd, sqlConnection);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    sqlConnection.Close();
                }
            }
        }
        private void DataBase_DELETE()
        {
            string connectionString = "Data Source=Test.db;";
            using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
            {
                string sqlQuery;
                sqlConnection.Open();
                sqlQuery = $"DELETE FROM Result";
                string cmd = sqlQuery;
                SQLiteCommand command = new SQLiteCommand(cmd, sqlConnection);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                sqlConnection.Close();
            }
        }

        private void Select_SQL_Click(object sender, EventArgs e)
        {
            int DATE = 0;
            string sqlQuery = "";
            sqlQuery = $"SELECT ID FROM ARG WHERE date_start = '{Date_start_SQL.Text}' AND date_end = '{Date_end_SQL.Text}' AND " +
                    $" mit_number = '{mit_number_SQL.Text}' AND mi_modification = '{mi_modification_SQL.Text}' ";
            BD(sqlQuery, 3);
            if (True == true)
            {
                try
                {
                    DATE = Convert.ToInt32(Date_start_SQL.Text);
                }
                catch
                {
                }
                if (Date_end_SQL.Text != "" && Date_start_SQL.Text != "" && mi_modification_SQL.Text != "" && mit_number_SQL.Text != "")
                {
                    sqlQuery = $"SELECT * FROM Result WHERE verification_date LIKE '%{DATE}' AND  " +
                        $" mit_number = '{mit_number_SQL.Text}' AND mi_modification = '{mi_modification_SQL.Text}' ";
                    for (int i = DATE + 1; i <= Convert.ToInt32(Date_end_SQL.Text); i++)
                    {
                        sqlQuery += $"OR verification_date LIKE '%{i}' AND  " +
                        $" mit_number = '{mit_number_SQL.Text}' AND mi_modification = '{mi_modification_SQL.Text}' ";

                    }
                }
                else if (mi_modification_SQL.Text == "" && mit_number_SQL.Text != "")
                {
                    if (Date_end_SQL.Text != "" && Date_start_SQL.Text != "")
                    {
                        sqlQuery = $"SELECT * FROM Result WHERE verification_date LIKE '%{DATE}' AND  " +
                        $" mit_number = '{mit_number_SQL.Text}' ";
                        for (int i = DATE + 1; i <= Convert.ToInt32(Date_end_SQL.Text); i++)
                        {
                            sqlQuery += $"OR verification_date LIKE '%{i}' AND  " +
                            $" mit_number = '{mit_number_SQL.Text}' ";
                        }
                    }
                    else if (Date_end_SQL.Text == "" && Date_start_SQL.Text != "")
                    {
                        sqlQuery = $"SELECT * FROM Result WHERE verification_date LIKE '%{DATE}' AND  " +
                        $" mit_number = '{mit_number_SQL.Text}' ";
                        for (int i = DATE + 1; i <= DATE + 10; i++)
                        {
                            sqlQuery += $"OR verification_date LIKE '%{i}' AND  " +
                            $" mit_number = '{mit_number_SQL.Text}' ";
                        }
                        DATE += 10;
                        Date_end_SQL.Text = DATE.ToString();
                    }
                    else if (Date_end_SQL.Text != "" && Date_start_SQL.Text == "")
                    {
                        sqlQuery = $"SELECT * FROM Result WHERE verification_date LIKE '%{DATE}' AND  " +
                        $" mit_number = '{mit_number_SQL.Text}' ";
                        for (int i = 0; i <= Convert.ToInt32(Date_end_SQL.Text); i++)
                        {
                            sqlQuery += $"OR verification_date LIKE '%{i}' AND  " +
                            $" mit_number = '{mit_number_SQL.Text}' ";
                        }
                    }
                    else if (Date_end_SQL.Text == "" && Date_start_SQL.Text == "")
                    {
                        sqlQuery = $"SELECT * FROM Result WHERE mit_number = '{mit_number_SQL.Text}' ";
                    }
                }
                else if (Date_end_SQL.Text == "" && Date_start_SQL.Text == "" && mi_modification_SQL.Text != "" && mit_number_SQL.Text == "")
                {
                    sqlQuery = $"SELECT * FROM Result WHERE mi_modification = '{mi_modification_SQL.Text}' ";
                }
                BD(sqlQuery, 2);
                sqlQuery = $"INSERT INTO ARG (mit_number, mi_modification, date_start, date_end)" +
                $" VALUES ('{mit_number_SQL.Text}','{mi_modification_SQL.Text}','{Date_start_SQL.Text}','{Date_end_SQL.Text}')";
                BD(sqlQuery, 0);
                sqlQuery = $"SELECT ID FROM ARG WHERE date_start = '{Date_start_SQL.Text}' AND date_end = '{Date_end_SQL.Text}' AND " +
                     $" mit_number = '{mit_number_SQL.Text}' AND mi_modification = '{mi_modification_SQL.Text}' ";
                BD(sqlQuery, 3);
                for (int i = 0; i < size; i++)
                {
                    sqlQuery = $"INSERT INTO ID_Results (ID_ARG, ID_Result) VALUES ('{ID_DB}','{ID_MASS[i]}')";
                    BD(sqlQuery, 0);
                }
            }
            if (True == false)
            {
                sqlQuery = $"SELECT ID_Result FROM ID_Results WHERE ID_ARG = '{ID_DB}'";
                BD(sqlQuery, 4);
                sqlQuery = $"SELECT * FROM Result WHERE ID = '{ID_MASS[0]}'";
                for (int i = 1; i < size; i++)
                {
                    sqlQuery += $"OR ID = '{ID_MASS[i]}'";
                }
                BD(sqlQuery, 2);
            }
        }
        private void BD(string sqlQuery, int i)
        {
            try
            {
                string connectionString = "Data Source=Test.db;";
                using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
                {
                    sqlConnection.Open();
                    string cmd = sqlQuery;
                    SQLiteCommand command = new SQLiteCommand(cmd, sqlConnection);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    // Вывод на грид
                    switch (i)
                    {
                        case 1:
                            dataGridView_SQL.DataSource = dt;
                            break;
                        case 2:
                            dataGridView_SQL.DataSource = dt;
                            ID_MASS = new int[dt.Rows.Count];
                            size = dt.Rows.Count;
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                ID_MASS[j] = Convert.ToInt32(dt.Rows[j].ItemArray[0]);
                            }
                            if (dt.Rows.Count == 0)
                            {
                                ID_MASS = new int[1];
                                ID_MASS[0] = 0;
                                size = 1;
                            }
                            break;
                        case 3:
                            dataGridView_SQL.DataSource = dt;
                            if (dt.Rows.Count > 0)
                            {
                                True = false;
                                ID_DB = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                            }
                            else if (dt.Rows.Count == 0)
                            {
                                True = true;
                                ID_MASS = new int[1];
                                ID_MASS[0] = 0;
                                size = 1;
                            }
                            break;
                        case 4:
                            if (dt.Rows.Count > 0)
                            {
                                ID_MASS = new int[dt.Rows.Count];
                                size = dt.Rows.Count;
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    ID_MASS[j] = Convert.ToInt32(dt.Rows[j].ItemArray[0]);
                                }
                            }
                            if (dt.Rows.Count == 0)
                            {
                                ID_MASS = new int[1];
                                ID_MASS[0] = 0;
                                size = 1;
                            }
                            break;
                        case 5:
                            if (dt.Rows.Count > 0)
                            {
                                for (i = 0; i < dt.Rows.Count; i++)
                                {
                                    ID_DB = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                                    mit_number_SQL.Text = dt.Rows[i].ItemArray[1].ToString();
                                    mi_modification_SQL.Text = dt.Rows[i].ItemArray[2].ToString();
                                    Date_start_SQL.Text = dt.Rows[i].ItemArray[3].ToString();
                                    Date_end_SQL.Text = dt.Rows[i].ItemArray[4].ToString();
                                }
                            }
                            break;
                    }
                    sqlConnection.Close();
                }
            }
            catch
            {
            }
        }
        private void Load_BD_Result()
        {
            string sqlQuery = "SELECT * FROM Result";
            BD(sqlQuery, 1);
            sqlQuery = "SELECT * FROM ARG";
            BD(sqlQuery, 5);
            sqlQuery = $"SELECT ID_Result FROM ID_Results WHERE ID_ARG = '{ID_DB}'";
            BD(sqlQuery, 4);
            sqlQuery = $"SELECT * FROM Result WHERE ID = '{ID_MASS[0]}'";
            for (int i = 1; i < size; i++)
            {
                sqlQuery += $"OR ID = '{ID_MASS[i]}'";
            }
            BD(sqlQuery, 2);
        }

        private void SELECT_ALL_Click(object sender, EventArgs e)
        {
            string sqlQuery = $"SELECT * FROM Result";
            BD(sqlQuery, 1);
        }
    }
}
