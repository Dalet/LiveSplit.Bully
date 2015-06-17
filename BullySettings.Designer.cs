namespace LiveSplit.Bully
{
    partial class BullySettings
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbIGT = new System.Windows.Forms.GroupBox();
            this.tlpIGT = new System.Windows.Forms.TableLayoutPanel();
            this.rbNoLoads = new System.Windows.Forms.RadioButton();
            this.rbIGT = new System.Windows.Forms.RadioButton();
            this.tlpMain.SuspendLayout();
            this.gbIGT.SuspendLayout();
            this.tlpIGT.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.gbIGT, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Location = new System.Drawing.Point(7, 7);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpMain.Size = new System.Drawing.Size(462, 48);
            this.tlpMain.TabIndex = 0;
            // 
            // gbIGT
            // 
            this.gbIGT.AutoSize = true;
            this.gbIGT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbIGT.Controls.Add(this.tlpIGT);
            this.gbIGT.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbIGT.Location = new System.Drawing.Point(3, 3);
            this.gbIGT.Name = "gbIGT";
            this.gbIGT.Size = new System.Drawing.Size(456, 42);
            this.gbIGT.TabIndex = 5;
            this.gbIGT.TabStop = false;
            this.gbIGT.Text = "Game time";
            // 
            // tlpIGT
            // 
            this.tlpIGT.AutoSize = true;
            this.tlpIGT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpIGT.BackColor = System.Drawing.Color.Transparent;
            this.tlpIGT.ColumnCount = 2;
            this.tlpIGT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpIGT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpIGT.Controls.Add(this.rbNoLoads, 0, 0);
            this.tlpIGT.Controls.Add(this.rbIGT, 1, 0);
            this.tlpIGT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpIGT.Location = new System.Drawing.Point(3, 16);
            this.tlpIGT.Name = "tlpIGT";
            this.tlpIGT.RowCount = 1;
            this.tlpIGT.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpIGT.Size = new System.Drawing.Size(450, 23);
            this.tlpIGT.TabIndex = 4;
            // 
            // rbNoLoads
            // 
            this.rbNoLoads.AutoSize = true;
            this.rbNoLoads.Checked = true;
            this.rbNoLoads.Location = new System.Drawing.Point(3, 3);
            this.rbNoLoads.Name = "rbNoLoads";
            this.rbNoLoads.Size = new System.Drawing.Size(67, 17);
            this.rbNoLoads.TabIndex = 0;
            this.rbNoLoads.TabStop = true;
            this.rbNoLoads.Text = "No loads";
            this.rbNoLoads.UseVisualStyleBackColor = true;
            // 
            // rbIGT
            // 
            this.rbIGT.AutoSize = true;
            this.rbIGT.Location = new System.Drawing.Point(228, 3);
            this.rbIGT.Name = "rbIGT";
            this.rbIGT.Size = new System.Drawing.Size(82, 17);
            this.rbIGT.TabIndex = 1;
            this.rbIGT.Text = "Ingame time";
            this.rbIGT.UseVisualStyleBackColor = true;
            // 
            // BullySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "BullySettings";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(476, 487);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.gbIGT.ResumeLayout(false);
            this.gbIGT.PerformLayout();
            this.tlpIGT.ResumeLayout(false);
            this.tlpIGT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbIGT;
        private System.Windows.Forms.TableLayoutPanel tlpIGT;
        private System.Windows.Forms.RadioButton rbNoLoads;
        private System.Windows.Forms.RadioButton rbIGT;
    }
}
