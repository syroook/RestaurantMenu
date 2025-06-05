namespace RestaurantMenu
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// private System.Windows.Forms.Button addDishButton;
        private System.Windows.Forms.Button addDishButton;
        private System.Windows.Forms.Button removeDishButton;

        private void InitializeComponent()
        {
            menuDataGridView = new DataGridView();
            dishTypeFilterComboBox = new ComboBox();
            label1 = new Label();
            closeButton = new Button();
            addDishButton = new Button();
            removeDishButton = new Button();
            ((System.ComponentModel.ISupportInitialize)menuDataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuDataGridView
            // 
            menuDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            menuDataGridView.Location = new Point(26, 100);
            menuDataGridView.Margin = new Padding(6, 8, 6, 8);
            menuDataGridView.Name = "menuDataGridView";
            menuDataGridView.RowHeadersWidth = 51;
            menuDataGridView.Size = new Size(1026, 657);
            menuDataGridView.TabIndex = 0;
            // 
            // dishTypeFilterComboBox
            // 
            dishTypeFilterComboBox.FormattingEnabled = true;
            dishTypeFilterComboBox.Location = new Point(26, 36);
            dishTypeFilterComboBox.Margin = new Padding(6, 8, 6, 8);
            dishTypeFilterComboBox.Name = "dishTypeFilterComboBox";
            dishTypeFilterComboBox.Size = new Size(518, 40);
            dishTypeFilterComboBox.TabIndex = 1;
            dishTypeFilterComboBox.SelectedIndexChanged += dishTypeFilterComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, -4);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(166, 32);
            label1.TabIndex = 2;
            label1.Text = "Фильтр блюд:";
            // 
            // closeButton
            // 
            closeButton.Location = new Point(676, 28);
            closeButton.Margin = new Padding(6, 8, 6, 8);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(195, 56);
            closeButton.TabIndex = 3;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // addDishButton
            // 
            addDishButton.Location = new Point(26, 786);
            addDishButton.Margin = new Padding(5, 6, 5, 6);
            addDishButton.Name = "addDishButton";
            addDishButton.Size = new Size(244, 60);
            addDishButton.TabIndex = 0;
            addDishButton.Text = "Добавить блюдо";
            addDishButton.Click += addDishButton_Click;
            // 
            // removeDishButton
            // 
            removeDishButton.Location = new Point(300, 786);
            removeDishButton.Margin = new Padding(5, 6, 5, 6);
            removeDishButton.Name = "removeDishButton";
            removeDishButton.Size = new Size(244, 60);
            removeDishButton.TabIndex = 1;
            removeDishButton.Text = "Удалить блюдо";
            removeDishButton.Click += removeDishButton_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1481, 953);
            Controls.Add(addDishButton);
            Controls.Add(removeDishButton);
            Controls.Add(closeButton);
            Controls.Add(label1);
            Controls.Add(dishTypeFilterComboBox);
            Controls.Add(menuDataGridView);
            Margin = new Padding(6, 8, 6, 8);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)menuDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion
        private System.Windows.Forms.DataGridView menuDataGridView;
        private System.Windows.Forms.ComboBox dishTypeFilterComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
    }
}