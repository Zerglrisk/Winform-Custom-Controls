using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_Custom_Controls;

namespace Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            checkBoxListView1.Items.Add(new ListViewItem(new String[] { "true", "test1", "test1-1" }));
            checkBoxListView1.Items.Add(new ListViewItem(new String[] { "", "test2", "test2-1" }));
            checkBoxListView1.Items.Add(new ListViewItem(new String[] { "", "test3", "test3-1" }));

        }

    }
}
