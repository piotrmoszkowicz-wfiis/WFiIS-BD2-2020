namespace Lab11
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
            this.dgFirst = new System.Windows.Forms.DataGridView();
            this.dgSecond = new System.Windows.Forms.DataGridView();
            this.dgThird = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgThird)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFirst
            // 
            this.dgFirst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFirst.Location = new System.Drawing.Point(12, 12);
            this.dgFirst.Name = "dgFirst";
            this.dgFirst.Size = new System.Drawing.Size(945, 150);
            this.dgFirst.TabIndex = 0;
            // 
            // dgSecond
            // 
            this.dgSecond.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSecond.Location = new System.Drawing.Point(12, 188);
            this.dgSecond.Name = "dgSecond";
            this.dgSecond.Size = new System.Drawing.Size(945, 150);
            this.dgSecond.TabIndex = 1;
            // 
            // dgThird
            // 
            this.dgThird.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgThird.Location = new System.Drawing.Point(12, 371);
            this.dgThird.Name = "dgThird";
            this.dgThird.Size = new System.Drawing.Size(945, 150);
            this.dgThird.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 533);
            this.Controls.Add(this.dgThird);
            this.Controls.Add(this.dgSecond);
            this.Controls.Add(this.dgFirst);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgThird)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFirst;
        private System.Windows.Forms.DataGridView dgSecond;
        private System.Windows.Forms.DataGridView dgThird;
    }
}

