using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GJJCallingSys.Models;

namespace GJJCallingSys
{
    public partial class MainForm : Form
    {
        //List<ConnConfg> connConfgs = new GetConfigurations().GetConfigurationsFromXml("Conf\\Application.xml");

        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Set the default layout of the mainform
        /// </summary>
        private void SetMainFormLayout()
        {
            SplitContainer splitcontainer = new SplitContainer();


        }
    }
}
