namespace ExLumina.SketchUp.API.Examples
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
            this.btnSetLocation = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRunExamples = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.clbList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnSetLocation
            // 
            this.btnSetLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetLocation.Location = new System.Drawing.Point(8, 8);
            this.btnSetLocation.Name = "btnSetLocation";
            this.btnSetLocation.Size = new System.Drawing.Size(152, 64);
            this.btnSetLocation.TabIndex = 0;
            this.btnSetLocation.Text = "Set Location";
            this.btnSetLocation.UseVisualStyleBackColor = true;
            this.btnSetLocation.Click += new System.EventHandler(this.btnSetLocation_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(8, 248);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(152, 64);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRunExamples
            // 
            this.btnRunExamples.Enabled = false;
            this.btnRunExamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunExamples.Location = new System.Drawing.Point(8, 80);
            this.btnRunExamples.Name = "btnRunExamples";
            this.btnRunExamples.Size = new System.Drawing.Size(152, 64);
            this.btnRunExamples.TabIndex = 2;
            this.btnRunExamples.Text = "Run Examples";
            this.btnRunExamples.UseVisualStyleBackColor = true;
            this.btnRunExamples.Click += new System.EventHandler(this.btnRunExamples_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.BackColor = System.Drawing.SystemColors.Window;
            this.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocation.Location = new System.Drawing.Point(192, 24);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(336, 40);
            this.lblLocation.TabIndex = 3;
            this.lblLocation.Text = "<unset>";
            // 
            // clbList
            // 
            this.clbList.CheckOnClick = true;
            this.clbList.FormattingEnabled = true;
            this.clbList.Location = new System.Drawing.Point(192, 96);
            this.clbList.Name = "clbList";
            this.clbList.Size = new System.Drawing.Size(336, 214);
            this.clbList.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 319);
            this.Controls.Add(this.clbList);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnRunExamples);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSetLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CsharpSketchUpAPI Examples";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetLocation;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRunExamples;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.CheckedListBox clbList;
    }
}

