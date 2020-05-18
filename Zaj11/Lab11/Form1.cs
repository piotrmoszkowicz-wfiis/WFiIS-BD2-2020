using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab11
{
    public partial class Form1 : Form
    {
        public class Query1ResultClass
        {
            public string name;
            public string income;

            public Query1ResultClass(string n, string i)
            {
                name = n;
                income = i;
            }
        }

        private DataClasses1DataContext db;
        public Form1()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XNamespace nsp = "http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/IndividualSurvey";
            XNamespace ns = "http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/Resume";

            var query1 = db.Persons.Select(p => new { name = p.LastName, demographics = p.Demographics });

            var val = new List<Query1ResultClass>();

            foreach (var d in query1)
            {
                var qry = from name in ((XElement)d.demographics).Descendants(nsp + "YearlyIncome")
                          select name.Value;
                foreach (var q in qry)
                {
                    val.Add(new Query1ResultClass(d.name, q));
                }
            }

            var val2 = new List<string>();

            foreach (var d in query1)
            {
                var qry = from name in ((XElement)d.demographics).Descendants(nsp + "NumberChildrenAtHome") where name.Value.Equals("5")
                          select 1;
                foreach (var q in qry)
                {
                    if (q == 1) {
                        val2.Add(d.name);
                    }
                }
            }

            var query3 = db.JobCandidates.Select(j => new { resume = j.Resume });

            var val3 = new List<string>();

            foreach (var d in query3)
            {
                XElement resumeXml = d.resume;

                var qry2 = from add in resumeXml.Elements(ns + "Address")
                          select add;

                string result = qry2.First().Element(ns + "Addr.Location").Element(ns + "Location").Element(ns + "Loc.City").Value + " " + qry2.First().Element(ns + "Addr.Street").Value;
                val3.Add(result);
            }

            dgFirst.DataSource = val.ConvertAll(x => new { name = x.name, income = x.income });
            dgSecond.DataSource = val2.ConvertAll(x => new { name = x });
            dgThird.DataSource = val3.ConvertAll(x => new { data = x });
        }
    }
}
