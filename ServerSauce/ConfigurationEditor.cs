using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace ServerSauce
{
    public partial class ConfigurationEditor : Form
    {
        public ConfigurationEditor()
        {
            InitializeComponent();
        }

        private void ConfigurationEditor_Load(object sender, EventArgs e)
        {
            //Create a Dictionary from config.json
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("config.json"));
            label1.Text += values["default"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("config.json");
        }
    }
}
