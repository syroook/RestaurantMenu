namespace RestaurantMenu
{
    partial class AddDishForm
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
        private void InitializeComponent()
        {
            dishTypeComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            dishNameTextBox = new TextBox();
            label3 = new Label();
            dishPriceNumericUpDown = new NumericUpDown();
            addButton = new Button();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dishPriceNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // dishTypeComboBox
            // 
            dishTypeComboBox.FormattingEnabled = true;
            dishTypeComboBox.Location = new Point(26, 60);
            dishTypeComboBox.Margin = new Padding(6, 8, 6, 8);
            dishTypeComboBox.Name = "dishTypeComboBox";
            dishTypeComboBox.Size = new Size(518, 40);
            dishTypeComboBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 20);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 32);
            label1.TabIndex = 1;
            label1.Text = "Тип блюда:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 120);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(204, 32);
            label2.TabIndex = 2;
            label2.Text = "Название блюда:";
            // 
            // dishNameTextBox
            // 
            dishNameTextBox.Location = new Point(26, 160);
            dishNameTextBox.Margin = new Padding(6, 8, 6, 8);
            dishNameTextBox.Name = "dishNameTextBox";
            dishNameTextBox.Size = new Size(518, 39);
            dishNameTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 220);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(76, 32);
            label3.TabIndex = 4;
            label3.Text = "Цена:";
            // 
            // dishPriceNumericUpDown
            // 
            dishPriceNumericUpDown.DecimalPlaces = 2;
            dishPriceNumericUpDown.Location = new Point(26, 260);
            dishPriceNumericUpDown.Margin = new Padding(6, 8, 6, 8);
            dishPriceNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            dishPriceNumericUpDown.Name = "dishPriceNumericUpDown";
            dishPriceNumericUpDown.Size = new Size(520, 39);
            dishPriceNumericUpDown.TabIndex = 5;
            // 
            // addButton
            // 
            addButton.Location = new Point(26, 320);
            addButton.Margin = new Padding(6, 8, 6, 8);
            addButton.Name = "addButton";
            addButton.Size = new Size(244, 56);
            addButton.TabIndex = 6;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(302, 320);
            cancelButton.Margin = new Padding(6, 8, 6, 8);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(244, 56);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // AddDishForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 406);
            Controls.Add(cancelButton);
            Controls.Add(addButton);
            Controls.Add(dishPriceNumericUpDown);
            Controls.Add(label3);
            Controls.Add(dishNameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dishTypeComboBox);
            Margin = new Padding(6, 8, 6, 8);
            Name = "AddDishForm";
            Text = "Добавить блюдо";
            Load += AddDishForm_Load;
            ((System.ComponentModel.ISupportInitialize)dishPriceNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox dishTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dishNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown dishPriceNumericUpDown;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
    }
}