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
    public partial class FrmProducts : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public FrmProducts()
        {
            _productService = new ProductManager(new EfProductDal());
            _categoryService=new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }
       
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtProductId.Text);
            var values=_productService.TGetById(id);
            _productService.TDelete(values);
            MessageBox.Show("Silme işlemi başarılı");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product=new Product();
            product.CategoryId = int.Parse(cmbCategori.SelectedValue.ToString());
            product.ProductPrice=decimal.Parse(txtProductPrice.Text);
            product.ProductName=txtProductName.Text;
            product.ProductDescription=txtProductDesc.Text;
            product.ProductInStock=int.Parse(txtProductStock.Text);
            _productService.TInsert(product);
            MessageBox.Show("Ürün başarıyla eklendi.");
        }

        private void btnGetId_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var values=_productService.TGetById(id);
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id= int.Parse(txtProductId.Text);
            var values = _productService.TGetById(id);
            values.CategoryId = int.Parse(cmbCategori.SelectedValue.ToString()) ;
            values.ProductDescription=txtProductDesc.Text;
            values.ProductPrice=Decimal.Parse(txtProductPrice.Text);
            values.ProductInStock = int.Parse(txtProductStock.Text);
            values.ProductName=txtProductName.Text;
            _productService.TUpdate(values);
            MessageBox.Show("Güncelleme Başarılı");
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            var values=_categoryService.TGetAll();
            cmbCategori.DataSource = values;
            cmbCategori.DisplayMember = "CategoryName";
            cmbCategori.ValueMember = "CategoryId";
        }
    }
}
