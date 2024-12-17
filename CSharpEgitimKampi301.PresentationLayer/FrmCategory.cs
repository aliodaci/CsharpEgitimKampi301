using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource=categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category= new Category();
            category.CategoryName=txtCategoriName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Ekleme başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtCategoriId.Text);
            var deletedValues = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Silme Başaralı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            int updateId = int.Parse(txtCategoriId.Text);
            var updatedValues=_categoryService.TGetById(updateId);
            updatedValues.CategoryName= txtCategoriName.Text;
            updatedValues.CategoryStatus = true;
            _categoryService.TUpdate(updatedValues);
        }

        private void btnGetId_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoriId.Text);
            var getByIdValues=_categoryService.TGetById(id);
            dataGridView1.DataSource=getByIdValues;
        }
    }
}
