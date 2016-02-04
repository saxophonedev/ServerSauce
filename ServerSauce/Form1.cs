//System namespace
using System;
//Generic Collection namespace
using System.Collections.Generic;
//IO namespace
using System.IO;
//Forms namespace
using System.Windows.Forms;
//Json.NET namespace (from Nuget)
using Newtonsoft.Json;
//ServerSauce
//Copyright (c) Móricz Gergő 2016 | All Rights Reserved.
namespace ServerSauce
{
    //Form1 Class
    public partial class Form1 : Form
    {
        public Form1()
        {
            //INITIALIZECOMPONENTRULEZ!!!!1111ONEONE111ONE~~~~~~~
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Calling ConfigurationEditor
            new ConfigurationEditor().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Checking for file existance
            if (!File.Exists("config.json"))
            {
                //Creating file
                File.WriteAllText("config.json", "{\n   \"default\": \"default.json\"\n}");
            }
            //Creating config dictionary
            Dictionary<string, string> config = new Dictionary<string, string>();
            try
            {
                //Deserializing config.json
                config = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("config.json"));
                //Moved this here because of a bug...
                //Checking existance of the file in the entry "default"
                if (!File.Exists(config["default"]))
                {
                    File.WriteAllText(config["default"], "{\n\"name\": \"default\",\n\"address\": \"defa.ult\",\n\"username\": \"default\",\n\"password\": \"default\"\n}");
                }
            } catch //Catching exceptions
            {
                //Message
                MessageBox.Show("Your config JSON is not valid. Delete the JSON which has the \"default\" entry, so we can recreate it.", "ServerSauce FATAL ERROR");
                //Exiting from the app
                Application.Exit();
            }
            //Creating data dictionary.
            Dictionary<string, string> datas = new Dictionary<string, string>();
            try
            {
                //Deserializing the file in the entry "default" of the config file.
                datas = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(config["default"]));
            }
            catch
            {
                //Message
                MessageBox.Show("Your data JSON is not valid. Delete the JSON which has the server data, so we can recreate it.", "ServerSauce FATAL ERROR");
            }
            try
            {
                //Displaying server name
                label1.Text += datas["name"];
            }
            catch
            {
                //Message
                MessageBox.Show("The \"name\" entry is missing from your data JSON. Delete the JSON which has the server data, so we can recreate it.", "ServerSauce");
                //Exit
                Application.Exit();
            }
            try
            {
                //Displaying server address
                label2.Text += datas["address"];
            }
            catch
            {
                //Message
                MessageBox.Show("The \"address\" entry is missing from your data JSON.", "ServerSauce");
                //Exit
                label2.Visible = false;
            }
            try
            {
                //Displaying server username
                label3.Text += datas["username"];
            }
            catch
            {
                //Message
                MessageBox.Show("The \"username\" entry is missing from your data JSON.", "ServerSauce");
                //Hide
                label3.Visible = false;
            }
            try
            {
                //Displaying server password
                label4.Text += datas["password"];
            }
            catch
            {
                //Message
                MessageBox.Show("The \"password\" entry is missing from your data JSON.", "ServerSauce");
                //Hide
                label4.Visible = false;
            }
        }
    }
}
