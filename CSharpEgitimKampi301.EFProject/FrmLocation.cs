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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEfDbEntities db = new EgitimKampiEfDbEntities();
        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.TblGuides.Select(x => new
            {
                FullName= x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var values=db.TblLocations.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblLocation location = new TblLocation();
            location.Capacity=Convert.ToByte(numericUpDown1.Value.ToString());
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.Price=decimal.Parse(txtPrice.Text);
            location.DayNight=txtDayNight.Text;
            location.GuideId = Convert.ToInt32(cmbGuide.SelectedValue.ToString());
            db.TblLocations.Add(location);
            db.SaveChanges();
            MessageBox.Show("Başarıyla eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var deleteValue = db.TblLocations.Find(id);
            db.TblLocations.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Başarıyla silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValues= db.TblLocations.Find(id);
            updateValues.DayNight = txtDayNight.Text;
            updateValues.Price = decimal.Parse(txtPrice.Text);
            updateValues.Capacity = byte.Parse(numericUpDown1.Value.ToString());
            updateValues.City = txtCity.Text;
            updateValues.Country = txtCountry.Text;
            updateValues.GuideId=int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Başarıyla güncellendi");

        }
    }
}
