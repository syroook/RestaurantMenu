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
    public partial class RemoveDishForm : Form
    {
        public Dish SelectedDish => dishesListBox.SelectedItem as Dish;

        public RemoveDishForm(System.Collections.Generic.IEnumerable<Dish> dishes)
        {
            InitializeComponent();
            foreach (var dish in dishes)
            {
                dishesListBox.Items.Add(dish);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (SelectedDish == null)
            {
                MessageBox.Show("Выберите блюдо для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
