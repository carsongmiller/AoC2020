
namespace AdventOfCode2020
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
			this.btnDay1 = new System.Windows.Forms.Button();
			this.tbInputPath = new System.Windows.Forms.TextBox();
			this.btnApplyFilepath = new System.Windows.Forms.Button();
			this.btnDay2 = new System.Windows.Forms.Button();
			this.btnDay3 = new System.Windows.Forms.Button();
			this.btnDay4 = new System.Windows.Forms.Button();
			this.btnDay5 = new System.Windows.Forms.Button();
			this.btnDay6 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnDay1
			// 
			this.btnDay1.Location = new System.Drawing.Point(43, 113);
			this.btnDay1.Name = "btnDay1";
			this.btnDay1.Size = new System.Drawing.Size(109, 38);
			this.btnDay1.TabIndex = 0;
			this.btnDay1.Text = "1";
			this.btnDay1.UseVisualStyleBackColor = true;
			this.btnDay1.Click += new System.EventHandler(this.btnDay1_Click);
			// 
			// tbInputPath
			// 
			this.tbInputPath.Location = new System.Drawing.Point(43, 52);
			this.tbInputPath.Name = "tbInputPath";
			this.tbInputPath.Size = new System.Drawing.Size(332, 26);
			this.tbInputPath.TabIndex = 1;
			this.tbInputPath.Text = ".\\..\\..\\Inputs\\";
			// 
			// btnApplyFilepath
			// 
			this.btnApplyFilepath.Location = new System.Drawing.Point(381, 40);
			this.btnApplyFilepath.Name = "btnApplyFilepath";
			this.btnApplyFilepath.Size = new System.Drawing.Size(109, 38);
			this.btnApplyFilepath.TabIndex = 2;
			this.btnApplyFilepath.Text = "Apply";
			this.btnApplyFilepath.UseVisualStyleBackColor = true;
			this.btnApplyFilepath.Click += new System.EventHandler(this.btnApplyFilepath_Click);
			// 
			// btnDay2
			// 
			this.btnDay2.Location = new System.Drawing.Point(43, 157);
			this.btnDay2.Name = "btnDay2";
			this.btnDay2.Size = new System.Drawing.Size(109, 38);
			this.btnDay2.TabIndex = 3;
			this.btnDay2.Text = "2";
			this.btnDay2.UseVisualStyleBackColor = true;
			this.btnDay2.Click += new System.EventHandler(this.btnDay2_Click);
			// 
			// btnDay3
			// 
			this.btnDay3.Location = new System.Drawing.Point(43, 201);
			this.btnDay3.Name = "btnDay3";
			this.btnDay3.Size = new System.Drawing.Size(109, 38);
			this.btnDay3.TabIndex = 4;
			this.btnDay3.Text = "3";
			this.btnDay3.UseVisualStyleBackColor = true;
			this.btnDay3.Click += new System.EventHandler(this.btnDay3_Click);
			// 
			// btnDay4
			// 
			this.btnDay4.Location = new System.Drawing.Point(43, 245);
			this.btnDay4.Name = "btnDay4";
			this.btnDay4.Size = new System.Drawing.Size(109, 38);
			this.btnDay4.TabIndex = 5;
			this.btnDay4.Text = "4";
			this.btnDay4.UseVisualStyleBackColor = true;
			this.btnDay4.Click += new System.EventHandler(this.btnDay4_Click);
			// 
			// btnDay5
			// 
			this.btnDay5.Location = new System.Drawing.Point(43, 289);
			this.btnDay5.Name = "btnDay5";
			this.btnDay5.Size = new System.Drawing.Size(109, 38);
			this.btnDay5.TabIndex = 6;
			this.btnDay5.Text = "5";
			this.btnDay5.UseVisualStyleBackColor = true;
			this.btnDay5.Click += new System.EventHandler(this.btnDay5_Click);
			// 
			// btnDay6
			// 
			this.btnDay6.Location = new System.Drawing.Point(43, 333);
			this.btnDay6.Name = "btnDay6";
			this.btnDay6.Size = new System.Drawing.Size(109, 38);
			this.btnDay6.TabIndex = 7;
			this.btnDay6.Text = "6";
			this.btnDay6.UseVisualStyleBackColor = true;
			this.btnDay6.Click += new System.EventHandler(this.btnDay6_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1217, 783);
			this.Controls.Add(this.btnDay6);
			this.Controls.Add(this.btnDay5);
			this.Controls.Add(this.btnDay4);
			this.Controls.Add(this.btnDay3);
			this.Controls.Add(this.btnDay2);
			this.Controls.Add(this.btnApplyFilepath);
			this.Controls.Add(this.tbInputPath);
			this.Controls.Add(this.btnDay1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnDay1;
		private System.Windows.Forms.TextBox tbInputPath;
		private System.Windows.Forms.Button btnApplyFilepath;
		private System.Windows.Forms.Button btnDay2;
		private System.Windows.Forms.Button btnDay3;
		private System.Windows.Forms.Button btnDay4;
		private System.Windows.Forms.Button btnDay5;
		private System.Windows.Forms.Button btnDay6;
	}
}

