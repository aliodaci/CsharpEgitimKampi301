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
    public partial class FrmStatistic : Form
    {
        public FrmStatistic()
        {
            InitializeComponent();
        }
        EgitimKampiEfDbEntities db=new EgitimKampiEfDbEntities();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmStatistic_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text=db.TblLocations.Count().ToString();
            lblSumCapacity.Text=db.TblLocations.Sum(x=>x.Capacity).ToString();
            lblGuideCount.Text=db.TblGuides.Count().ToString();
            lblAvargeCapacity.Text=db.TblLocations.Average(x=>x.Capacity).ToString();
            lblLocationPrice.Text = Convert.ToDecimal(db.TblLocations.Average(x => x.Price)).ToString("0,000") + "\u20BA";
            
            int lastCountryId = db.TblLocations.Max(x => x.LocationId);
            lblLastCountryName.Text=db.TblLocations.Where(x=>x.LocationId==lastCountryId).Select(y=>y.Country).FirstOrDefault();
        
            lblCapadociyaCapacity.Text=db.TblLocations.Where(x=>x.City=="Kapadokya").Select(y=>(byte)y.Capacity).FirstOrDefault().ToString();
            lblturkiyeCapacityAvg.Text=db.TblLocations.Where(x=>x.Country=="Türkiye").Average(y=>y.Capacity).ToString();
        
            var romaGuideId=db.TblLocations.Where(x=>x.City=="Roma").Select(y=>y.GuideId).FirstOrDefault();
            lblRomaGuide.Text=db.TblGuides.Where(x=>x.GuideId==romaGuideId).Select(y=>y.GuideName+" "+y.GuideSurname).FirstOrDefault().ToString();
        
            var maxCapacity=db.TblLocations.Max(x=>x.Capacity);
            lblMaxCapacityLocation.Text=db.TblLocations.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();

            var maxPrice=db.TblLocations.Max(x=>x.Price);
            lblMaxPriceLocation.Text=db.TblLocations.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault()?.ToString();

            var guideIdKumruOdaci = db.TblGuides.Where(x => x.GuideName == "Kumru" && x.GuideSurname == "Odacı").Select(y => y.GuideId).FirstOrDefault();
            lblKumruTurLocation.Text=db.TblLocations.Where(x=>x.GuideId==guideIdKumruOdaci).Count().ToString();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
