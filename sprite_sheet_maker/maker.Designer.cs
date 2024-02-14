namespace sprite_sheet_maker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox_dir = new TextBox();
            button_dir = new Button();
            textBox_col = new TextBox();
            button_make = new Button();
            label6 = new Label();
            label_result = new Label();
            comboBox_type = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 34);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Source Directory";
            // 
            // textBox_dir
            // 
            textBox_dir.Location = new Point(147, 31);
            textBox_dir.Name = "textBox_dir";
            textBox_dir.Size = new Size(230, 23);
            textBox_dir.TabIndex = 1;
            // 
            // button_dir
            // 
            button_dir.Location = new Point(383, 29);
            button_dir.Name = "button_dir";
            button_dir.Size = new Size(75, 25);
            button_dir.TabIndex = 2;
            button_dir.Text = "browse...";
            button_dir.UseVisualStyleBackColor = true;
            button_dir.Click += button_dir_Click;
            // 
            // textBox_col
            // 
            textBox_col.Location = new Point(148, 95);
            textBox_col.Name = "textBox_col";
            textBox_col.Size = new Size(67, 23);
            textBox_col.TabIndex = 4;
            textBox_col.Text = "10";
            // 
            // button_make
            // 
            button_make.Location = new Point(217, 206);
            button_make.Name = "button_make";
            button_make.Size = new Size(160, 83);
            button_make.TabIndex = 11;
            button_make.Text = "Make Sprite Sheet";
            button_make.UseVisualStyleBackColor = true;
            button_make.Click += button_make_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 152);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 13;
            label6.Text = "Result : ";
            // 
            // label_result
            // 
            label_result.Location = new Point(148, 151);
            label_result.Name = "label_result";
            label_result.Size = new Size(456, 23);
            label_result.TabIndex = 14;
            label_result.Text = "Drag && drop files or directories";
            // 
            // comboBox_type
            // 
            comboBox_type.FormattingEnabled = true;
            comboBox_type.Items.AddRange(new object[] { "Columns", "Rows" });
            comboBox_type.Location = new Point(24, 95);
            comboBox_type.Name = "comboBox_type";
            comboBox_type.Size = new Size(101, 23);
            comboBox_type.TabIndex = 15;
            comboBox_type.Text = "Select Type";
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 320);
            Controls.Add(comboBox_type);
            Controls.Add(label_result);
            Controls.Add(label6);
            Controls.Add(button_make);
            Controls.Add(textBox_col);
            Controls.Add(button_dir);
            Controls.Add(textBox_dir);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Maker";
            Load += Form1_Load;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_dir;
        private Button button_dir;
        private TextBox textBox_col;
        private Button button_make;
        private Label label6;
        private Label label_result;
        private ComboBox comboBox_type;
    }
}
