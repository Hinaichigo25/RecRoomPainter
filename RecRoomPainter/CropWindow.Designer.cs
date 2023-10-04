namespace RecRoomPainter {
    partial class CropWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BottomRightButton = new System.Windows.Forms.Button();
            this.BottomLeftButton = new System.Windows.Forms.Button();
            this.TopLeftButton = new System.Windows.Forms.Button();
            this.TopRightButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TopRightButton);
            this.panel1.Controls.Add(this.TopLeftButton);
            this.panel1.Controls.Add(this.BottomLeftButton);
            this.panel1.Controls.Add(this.BottomRightButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BottomRightButton
            // 
            this.BottomRightButton.BackColor = System.Drawing.Color.Blue;
            this.BottomRightButton.Location = new System.Drawing.Point(774, 427);
            this.BottomRightButton.Name = "BottomRightButton";
            this.BottomRightButton.Size = new System.Drawing.Size(26, 23);
            this.BottomRightButton.TabIndex = 1;
            this.BottomRightButton.UseVisualStyleBackColor = false;
            // 
            // BottomLeftButton
            // 
            this.BottomLeftButton.BackColor = System.Drawing.Color.Blue;
            this.BottomLeftButton.Location = new System.Drawing.Point(0, 427);
            this.BottomLeftButton.Name = "BottomLeftButton";
            this.BottomLeftButton.Size = new System.Drawing.Size(26, 23);
            this.BottomLeftButton.TabIndex = 2;
            this.BottomLeftButton.UseVisualStyleBackColor = false;
            // 
            // TopLeftButton
            // 
            this.TopLeftButton.BackColor = System.Drawing.Color.Blue;
            this.TopLeftButton.Location = new System.Drawing.Point(0, 0);
            this.TopLeftButton.Name = "TopLeftButton";
            this.TopLeftButton.Size = new System.Drawing.Size(26, 23);
            this.TopLeftButton.TabIndex = 3;
            this.TopLeftButton.UseVisualStyleBackColor = false;
            // 
            // TopRightButton
            // 
            this.TopRightButton.BackColor = System.Drawing.Color.Blue;
            this.TopRightButton.Location = new System.Drawing.Point(774, 0);
            this.TopRightButton.Name = "TopRightButton";
            this.TopRightButton.Size = new System.Drawing.Size(26, 23);
            this.TopRightButton.TabIndex = 4;
            this.TopRightButton.UseVisualStyleBackColor = false;
            // 
            // CropWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CropWindow";
            this.Text = "CropWindow";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BottomLeftButton;
        private System.Windows.Forms.Button BottomRightButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button TopRightButton;
        private System.Windows.Forms.Button TopLeftButton;
    }
}