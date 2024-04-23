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

namespace FGIS.Views
{
    public partial class Request : Form
    {
        Result_HTTP result_HTTP = new Result_HTTP();
        Result Save = new Result();
        static HttpClient httpClient = new HttpClient();
        Result_HTTP person = new Result_HTTP();
        List_Item HTTP = new List_Item();
        List_Item HTTP_Save = new List_Item();
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
                HTTP_Save.items = Save.items;
            }
            Request_HTTP(mit_number.Text,mi_modification.Text, verification_date_start.Text, verification_date_end.Text);
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
                        HTTP_Save = await JsonSerializer.DeserializeAsync<List_Item>(fs);
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
                        catch(Exception ex) 
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
                                for (int k = 0; k < Convert.ToInt32(HTTP_Save.items.Count); k++)
                                {
                                    if (HTTP_Save.items[k].mit_number == HTTP.items[j].mit_number && HTTP_Save.items[k].mi_modification == HTTP.items[j].mi_modification && HTTP_Save.items[k].org_title == HTTP.items[j].org_title && HTTP_Save.items[k].verification_date == HTTP.items[j].verification_date)
                                    {
                                        add = false;
                                    }
                                }
                                if (add == true)
                                {
                                    HTTP_Save.items.Add(HTTP.items[j]);
                                }
                            }
                        }
                    }
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    await JsonSerializer.SerializeAsync<List_Item>(fs, HTTP_Save, options);
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
        }
    }
}
