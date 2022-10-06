namespace ImgCreator
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Analyze = new System.Windows.Forms.Button();
            this.btn_LoadFile = new System.Windows.Forms.Button();
            this.btn_PickImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Analyze
            // 
            this.btn_Analyze.Location = new System.Drawing.Point(12, 12);
            this.btn_Analyze.Name = "btn_Analyze";
            this.btn_Analyze.Size = new System.Drawing.Size(90, 33);
            this.btn_Analyze.TabIndex = 0;
            this.btn_Analyze.Text = "Analyze Images";
            this.btn_Analyze.UseVisualStyleBackColor = true;
            this.btn_Analyze.Click += new System.EventHandler(this.btn_Analyze_Click);
            // 
            // btn_LoadFile
            // 
            this.btn_LoadFile.Location = new System.Drawing.Point(109, 12);
            this.btn_LoadFile.Name = "btn_LoadFile";
            this.btn_LoadFile.Size = new System.Drawing.Size(86, 32);
            this.btn_LoadFile.TabIndex = 1;
            this.btn_LoadFile.Text = "Load Data File";
            this.btn_LoadFile.UseVisualStyleBackColor = true;
            // 
            // btn_PickImage
            // 
            this.btn_PickImage.Location = new System.Drawing.Point(202, 12);
            this.btn_PickImage.Name = "btn_PickImage";
            this.btn_PickImage.Size = new System.Drawing.Size(77, 32);
            this.btn_PickImage.TabIndex = 2;
            this.btn_PickImage.Text = "Select Image";
            this.btn_PickImage.UseVisualStyleBackColor = true;
            this.btn_PickImage.Click += new System.EventHandler(this.btn_PickImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 306);
            this.Controls.Add(this.btn_PickImage);
            this.Controls.Add(this.btn_LoadFile);
            this.Controls.Add(this.btn_Analyze);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Analyze;
        private System.Windows.Forms.Button btn_LoadFile;
        private System.Windows.Forms.Button btn_PickImage;
    }
}

