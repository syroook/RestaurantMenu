using Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RestaurantMenu
{
    public partial class AddDishForm : Form
    {
        public string DishType => dishTypeComboBox.SelectedItem?.ToString();
        public string DishName => dishNameTextBox.Text;
        public decimal DishPrice => decimal.Parse(dishPriceNumericUpDown.Value.ToString());

        public AddDishForm()
        {
            InitializeComponent();
            dishTypeComboBox.Items.AddRange(new object[]
            {
                "Закуски",
                "Горячее Блюдо",
                "Салат",
                "Напитки",
                "Десерт",
                "Завтрак"
            });
            dishTypeComboBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DishName))
            {
                MessageBox.Show("Введите название блюда", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DishPrice <= 0)
            {
                MessageBox.Show("Цена должна быть положительной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AddDishForm_Load(object sender, EventArgs e)
        {

        }
    }



}
