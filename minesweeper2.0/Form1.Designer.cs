
namespace minesweeper2._0
{
    partial class Menu
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
            this.width = new System.Windows.Forms.TextBox();
            this.generate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mines = new System.Windows.Forms.TextBox();
            this.density = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(57, 42);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(100, 20);
            this.width.TabIndex = 0;
            this.width.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // generate
            // 
            this.generate.Enabled = false;
            this.generate.Location = new System.Drawing.Point(67, 118);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(75, 23);
            this.generate.TabIndex = 1;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height:";
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(57, 67);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(100, 20);
            this.height.TabIndex = 4;
            this.height.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mines:";
            // 
            // mines
            // 
            this.mines.Location = new System.Drawing.Point(57, 92);
            this.mines.Name = "mines";
            this.mines.Size = new System.Drawing.Size(100, 20);
            this.mines.TabIndex = 6;
            this.mines.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // density
            // 
            this.density.Location = new System.Drawing.Point(187, 67);
            this.density.Name = "density";
            this.density.Size = new System.Drawing.Size(100, 20);
            this.density.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mine Density";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 178);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.density);
            this.Controls.Add(this.mines);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.height);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.width);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mines;
        private System.Windows.Forms.ProgressBar density;
        private System.Windows.Forms.Label label4;
    }
}

