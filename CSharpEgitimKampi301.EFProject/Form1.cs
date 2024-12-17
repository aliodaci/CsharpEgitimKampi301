using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEfDbEntities db = new EgitimKampiEfDbEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            var values = db.TblGuides.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblGuide guide = new TblGuide();
            guide.GuideId = int.Parse(txtId.Text);
            guide.GuideName=textBox1.Text;
            guide.GuideSurname=txtSurname.Text;
            db.TblGuides.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla kaydedildi.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var removeValue=db.TblGuides.Find(id);
            db.TblGuides.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla silindi.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(txtId.Text);
            var updateValue=db.TblGuides.Find(id);
            updateValue.GuideName=textBox1.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellendi.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var values = db.TblGuides.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource=values;
        }
    }
}
