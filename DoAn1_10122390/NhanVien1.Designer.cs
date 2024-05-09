namespace DoAn1_10122390
{
    partial class NhanVien1
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
            this.tbtimkiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // tbtimkiem
            // 
            this.tbtimkiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.tbtimkiem.BorderRadius = 10;
            this.tbtimkiem.BorderThickness = 2;
            this.tbtimkiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbtimkiem.DefaultText = "";
            this.tbtimkiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbtimkiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbtimkiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbtimkiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbtimkiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbtimkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbtimkiem.ForeColor = System.Drawing.Color.Black;
            this.tbtimkiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbtimkiem.Location = new System.Drawing.Point(51, 26);
            this.tbtimkiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbtimkiem.Name = "tbtimkiem";
            this.tbtimkiem.PasswordChar = '\0';
            this.tbtimkiem.PlaceholderForeColor = System.Drawing.Color.Black;
            this.tbtimkiem.PlaceholderText = "";
            this.tbtimkiem.SelectedText = "";
            this.tbtimkiem.Size = new System.Drawing.Size(374, 33);
            this.tbtimkiem.TabIndex = 38;
            // 
            // NhanVien1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbtimkiem);
            this.Name = "NhanVien1";
            this.Text = "NhanVien";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbtimkiem;
    }
}