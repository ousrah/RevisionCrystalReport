using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace RevisionCrystalReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void imprimer(ReportClass cr, string chemain="",string filtre = "")
        {
            cr.SetDatabaseLogon("sa", "P@ssw0rd");
            if (chemain!="")
                cr.SetParameterValue("chemain", chemain);

            frmImpression f = new frmImpression(cr, filtre);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imprimer(new lstProduits());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filtre = "{produit.designation_produit} like '*" + textBox1.Text + "*'";
            imprimer(new ficheProduit(), Application.StartupPath + @"\photos\", filtre);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filtre = "{client.Nom_client} like '*" + textBox2.Text + "*'";

            imprimer(new etiquette(),"",filtre);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            imprimer(new Prd_Cat());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            imprimer(new nbPrdCat());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string filtre = "{commande.id_commande} = " + textBox3.Text;

            imprimer(new facture(), "", filtre);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            imprimer(new facture());

        }
    }
}
