namespace Image_Filter
{
    partial class Form1
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
            this.AddImage = new System.Windows.Forms.Button();
            this.base_image = new System.Windows.Forms.PictureBox();
            this.filtered_image = new System.Windows.Forms.PictureBox();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Blue_Filter = new System.Windows.Forms.Button();
            this.Green_Filter = new System.Windows.Forms.Button();
            this.Red_Filter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GreyScale_Button = new System.Windows.Forms.Button();
            this.DFT_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IDFT_Button = new System.Windows.Forms.Button();
            this.Fourier_Image = new System.Windows.Forms.PictureBox();
            this.filter_name = new System.Windows.Forms.Label();
            this.trans_name = new System.Windows.Forms.Label();
            this.HighPass_Button = new System.Windows.Forms.Button();
            this.IDFT_HP_Button = new System.Windows.Forms.Button();
            this.Pencil_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.base_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtered_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fourier_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // AddImage
            // 
            this.AddImage.Location = new System.Drawing.Point(55, 36);
            this.AddImage.Name = "AddImage";
            this.AddImage.Size = new System.Drawing.Size(109, 23);
            this.AddImage.TabIndex = 0;
            this.AddImage.Text = "Choose Image";
            this.AddImage.UseVisualStyleBackColor = true;
            this.AddImage.Click += new System.EventHandler(this.AddImage_Click);
            // 
            // base_image
            // 
            this.base_image.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.base_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.base_image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.base_image.Location = new System.Drawing.Point(12, 112);
            this.base_image.Name = "base_image";
            this.base_image.Size = new System.Drawing.Size(256, 256);
            this.base_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.base_image.TabIndex = 1;
            this.base_image.TabStop = false;
            // 
            // filtered_image
            // 
            this.filtered_image.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.filtered_image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filtered_image.Location = new System.Drawing.Point(304, 112);
            this.filtered_image.Name = "filtered_image";
            this.filtered_image.Size = new System.Drawing.Size(256, 256);
            this.filtered_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.filtered_image.TabIndex = 2;
            this.filtered_image.TabStop = false;
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "openFileDialog1";
            // 
            // Blue_Filter
            // 
            this.Blue_Filter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Blue_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Blue_Filter.Location = new System.Drawing.Point(308, 399);
            this.Blue_Filter.Name = "Blue_Filter";
            this.Blue_Filter.Size = new System.Drawing.Size(75, 23);
            this.Blue_Filter.TabIndex = 3;
            this.Blue_Filter.Text = "Blue";
            this.Blue_Filter.UseVisualStyleBackColor = false;
            this.Blue_Filter.Click += new System.EventHandler(this.Blue_Filter_Click);
            // 
            // Green_Filter
            // 
            this.Green_Filter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Green_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Green_Filter.Location = new System.Drawing.Point(484, 399);
            this.Green_Filter.Name = "Green_Filter";
            this.Green_Filter.Size = new System.Drawing.Size(75, 23);
            this.Green_Filter.TabIndex = 4;
            this.Green_Filter.Text = "Green";
            this.Green_Filter.UseVisualStyleBackColor = false;
            this.Green_Filter.Click += new System.EventHandler(this.Green_Filter_Click);
            // 
            // Red_Filter
            // 
            this.Red_Filter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Red_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Red_Filter.Location = new System.Drawing.Point(396, 399);
            this.Red_Filter.Name = "Red_Filter";
            this.Red_Filter.Size = new System.Drawing.Size(75, 23);
            this.Red_Filter.TabIndex = 5;
            this.Red_Filter.Text = "Red";
            this.Red_Filter.UseVisualStyleBackColor = false;
            this.Red_Filter.Click += new System.EventHandler(this.Red_Filter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filter Types";
            // 
            // GreyScale_Button
            // 
            this.GreyScale_Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GreyScale_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GreyScale_Button.Location = new System.Drawing.Point(396, 428);
            this.GreyScale_Button.Name = "GreyScale_Button";
            this.GreyScale_Button.Size = new System.Drawing.Size(75, 23);
            this.GreyScale_Button.TabIndex = 7;
            this.GreyScale_Button.Text = "GreyScale";
            this.GreyScale_Button.UseVisualStyleBackColor = false;
            this.GreyScale_Button.Click += new System.EventHandler(this.GreyScale_Button_Click);
            // 
            // DFT_Button
            // 
            this.DFT_Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DFT_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DFT_Button.Location = new System.Drawing.Point(596, 399);
            this.DFT_Button.Name = "DFT_Button";
            this.DFT_Button.Size = new System.Drawing.Size(75, 23);
            this.DFT_Button.TabIndex = 8;
            this.DFT_Button.Text = "DFT";
            this.DFT_Button.UseVisualStyleBackColor = false;
            this.DFT_Button.Click += new System.EventHandler(this.DFT_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Original Image";
            // 
            // IDFT_Button
            // 
            this.IDFT_Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.IDFT_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IDFT_Button.Location = new System.Drawing.Point(686, 399);
            this.IDFT_Button.Name = "IDFT_Button";
            this.IDFT_Button.Size = new System.Drawing.Size(75, 23);
            this.IDFT_Button.TabIndex = 10;
            this.IDFT_Button.Text = "IDFT";
            this.IDFT_Button.UseVisualStyleBackColor = false;
            this.IDFT_Button.Click += new System.EventHandler(this.IDFT_Button_Click);
            // 
            // Fourier_Image
            // 
            this.Fourier_Image.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Fourier_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fourier_Image.Location = new System.Drawing.Point(596, 112);
            this.Fourier_Image.Name = "Fourier_Image";
            this.Fourier_Image.Size = new System.Drawing.Size(256, 256);
            this.Fourier_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Fourier_Image.TabIndex = 11;
            this.Fourier_Image.TabStop = false;
            // 
            // filter_name
            // 
            this.filter_name.AutoSize = true;
            this.filter_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_name.Location = new System.Drawing.Point(305, 92);
            this.filter_name.Name = "filter_name";
            this.filter_name.Size = new System.Drawing.Size(97, 17);
            this.filter_name.TabIndex = 12;
            this.filter_name.Text = "Filtered Image";
            // 
            // trans_name
            // 
            this.trans_name.AutoSize = true;
            this.trans_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trans_name.Location = new System.Drawing.Point(593, 92);
            this.trans_name.Name = "trans_name";
            this.trans_name.Size = new System.Drawing.Size(131, 17);
            this.trans_name.TabIndex = 13;
            this.trans_name.Text = "Transformed Image";
            // 
            // HighPass_Button
            // 
            this.HighPass_Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HighPass_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HighPass_Button.Location = new System.Drawing.Point(776, 399);
            this.HighPass_Button.Name = "HighPass_Button";
            this.HighPass_Button.Size = new System.Drawing.Size(75, 23);
            this.HighPass_Button.TabIndex = 14;
            this.HighPass_Button.Text = "High Pass";
            this.HighPass_Button.UseVisualStyleBackColor = false;
            this.HighPass_Button.Click += new System.EventHandler(this.HighPass_Button_Click);
            // 
            // IDFT_HP_Button
            // 
            this.IDFT_HP_Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.IDFT_HP_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IDFT_HP_Button.Location = new System.Drawing.Point(595, 428);
            this.IDFT_HP_Button.Name = "IDFT_HP_Button";
            this.IDFT_HP_Button.Size = new System.Drawing.Size(129, 23);
            this.IDFT_HP_Button.TabIndex = 15;
            this.IDFT_HP_Button.Text = "IDFT After High Pass";
            this.IDFT_HP_Button.UseVisualStyleBackColor = false;
            this.IDFT_HP_Button.Click += new System.EventHandler(this.IDFT_HP_Button_Click);
            // 
            // Pencil_Button
            // 
            this.Pencil_Button.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Pencil_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pencil_Button.Location = new System.Drawing.Point(730, 428);
            this.Pencil_Button.Name = "Pencil_Button";
            this.Pencil_Button.Size = new System.Drawing.Size(122, 23);
            this.Pencil_Button.TabIndex = 16;
            this.Pencil_Button.Text = "Pencil Sketch";
            this.Pencil_Button.UseVisualStyleBackColor = false;
            this.Pencil_Button.Click += new System.EventHandler(this.Pencil_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(891, 481);
            this.Controls.Add(this.Pencil_Button);
            this.Controls.Add(this.IDFT_HP_Button);
            this.Controls.Add(this.HighPass_Button);
            this.Controls.Add(this.trans_name);
            this.Controls.Add(this.filter_name);
            this.Controls.Add(this.Fourier_Image);
            this.Controls.Add(this.IDFT_Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DFT_Button);
            this.Controls.Add(this.GreyScale_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Red_Filter);
            this.Controls.Add(this.Green_Filter);
            this.Controls.Add(this.Blue_Filter);
            this.Controls.Add(this.filtered_image);
            this.Controls.Add(this.base_image);
            this.Controls.Add(this.AddImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.base_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtered_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fourier_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddImage;
        private System.Windows.Forms.PictureBox base_image;
        private System.Windows.Forms.PictureBox filtered_image;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button Blue_Filter;
        private System.Windows.Forms.Button Green_Filter;
        private System.Windows.Forms.Button Red_Filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GreyScale_Button;
        private System.Windows.Forms.Button DFT_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button IDFT_Button;
        private System.Windows.Forms.PictureBox Fourier_Image;
        private System.Windows.Forms.Label filter_name;
        private System.Windows.Forms.Label trans_name;
        private System.Windows.Forms.Button HighPass_Button;
        private System.Windows.Forms.Button IDFT_HP_Button;
        private System.Windows.Forms.Button Pencil_Button;
    }
}

