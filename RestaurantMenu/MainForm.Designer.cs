namespace RestaurantMenu
{
    partial class MainForm
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
            buildingsListBox = new ListBox();
            showMenuButton = new Button();
            menuTypeComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            buildingTypeFilterComboBox = new ComboBox();
            label3 = new Label();
            formatComboBox = new ComboBox();

            //removeDishButton = new Button();
            saveMenuButton = new Button();
            SuspendLayout();
            // 
            // buildingsListBox
            // 
            buildingsListBox.FormattingEnabled = true;
            buildingsListBox.Location = new Point(26, 100);
            buildingsListBox.Margin = new Padding(6, 8, 6, 8);
            buildingsListBox.Name = "buildingsListBox";
            buildingsListBox.Size = new Size(518, 516);
            buildingsListBox.TabIndex = 0;
            buildingsListBox.SelectedIndexChanged += buildingsListBox_SelectedIndexChanged;
            // 
            // showMenuButton
            // 
            showMenuButton.Enabled = false;
            showMenuButton.Location = new Point(559, 96);
            showMenuButton.Margin = new Padding(6, 8, 6, 8);
            showMenuButton.Name = "showMenuButton";
            showMenuButton.Size = new Size(325, 56);
            showMenuButton.TabIndex = 1;
            showMenuButton.Text = "Показать меню";
            showMenuButton.UseVisualStyleBackColor = true;
            showMenuButton.Click += showMenuButton_Click;
            // 
            // menuTypeComboBox
            // 
            menuTypeComboBox.Enabled = false;
            menuTypeComboBox.FormattingEnabled = true;
            menuTypeComboBox.Items.AddRange(new object[] { "Основное меню", "Сезонное меню" });
            menuTypeComboBox.Location = new Point(559, 170);
            menuTypeComboBox.Margin = new Padding(6, 8, 6, 8);
            menuTypeComboBox.Name = "menuTypeComboBox";
            menuTypeComboBox.Size = new Size(325, 56);
            menuTypeComboBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 60);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(136, 32);
            label1.TabIndex = 3;
            label1.Text = "Заведения:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(552, 60);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(118, 32);
            label2.TabIndex = 4;
            label2.Text = "Действия";
            // 
            // buildingTypeFilterComboBox
            // 
            buildingTypeFilterComboBox.FormattingEnabled = true;
            buildingTypeFilterComboBox.Location = new Point(26, 636);
            buildingTypeFilterComboBox.Margin = new Padding(6, 8, 6, 8);
            buildingTypeFilterComboBox.Name = "buildingTypeFilterComboBox";
            buildingTypeFilterComboBox.Size = new Size(518, 40);
            buildingTypeFilterComboBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 596);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(191, 32);
            label3.TabIndex = 6;
            label3.Text = "Фильтр по типу:";
            // 
            // formatComboBox
            // 
            formatComboBox.FormattingEnabled = true;
            formatComboBox.Location = new Point(559, 636);
            formatComboBox.Margin = new Padding(6, 8, 6, 8);
            formatComboBox.Name = "formatComboBox";
            formatComboBox.Size = new Size(322, 40);
            formatComboBox.TabIndex = 7;
            //
            // saveMenuButton
            // 
            saveMenuButton.Enabled = false;
            saveMenuButton.Location = new Point(559, 564);
            saveMenuButton.Margin = new Padding(6, 8, 6, 8);
            saveMenuButton.Name = "saveMenuButton";
            saveMenuButton.Size = new Size(325, 56);
            saveMenuButton.TabIndex = 10;
            saveMenuButton.Text = "Сохранить меню";
            saveMenuButton.UseVisualStyleBackColor = true;
            saveMenuButton.Click += saveMenuButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 720);
            Controls.Add(saveMenuButton);
            Controls.Add(removeDishButton);
            Controls.Add(addDishButton);
            Controls.Add(formatComboBox);
            Controls.Add(label3);
            Controls.Add(buildingTypeFilterComboBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuTypeComboBox);
            Controls.Add(showMenuButton);
            Controls.Add(buildingsListBox);
            Margin = new Padding(6, 8, 6, 8);
            Name = "MainForm";
            Text = "Ресторанное меню";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox buildingsListBox;
        private System.Windows.Forms.Button showMenuButton;
        private System.Windows.Forms.ComboBox menuTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox buildingTypeFilterComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox formatComboBox;
        private System.Windows.Forms.Button addDishButton;
        private System.Windows.Forms.Button removeDishButton;
        private System.Windows.Forms.Button saveMenuButton;
    }
}