using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab9
{
    public partial class Form1 : Form
    {
        private DataClasses1DataContext db;
        public Form1()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            var query1 = db.lab9s.GroupBy(v => v.DeparmentName).Select(v => new { departmentName = v.Key, maxSalary = v.Max(row => row.Rate) });
            dgFirst.DataSource = query1;

            var query2 = db
                .lab9s
                .GroupBy(v => new { v.DeparmentName })
                .Select(v => new { DeparmentName = v.Key.DeparmentName, Rate = v.Max(row => row.Rate) })
                .Join(db.lab9s, row => new { row.DeparmentName, row.Rate }, lab9 => new { lab9.DeparmentName, lab9.Rate }, (r, l) => new { departmentName = r.DeparmentName, employeeName = l.Name, rate = r.Rate })
                .OrderByDescending(row => row.rate);
            dgSecond.DataSource = query2;
        }
    }
}
