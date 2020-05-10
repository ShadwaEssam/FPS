namespace Graphics
{
    partial class GraphicsForm
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
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(0, 0);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(765, 439);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
            this.simpleOpenGlControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.simpleOpenGlControl1_KeyPress);
            this.simpleOpenGlControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(821, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 39);
            this.button1.TabIndex = 22;
            this.button1.Text = "Send Data to GPU";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(793, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Specular Exponent:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(931, 211);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(53, 22);
            this.textBox5.TabIndex = 20;
            this.textBox5.Text = "50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(794, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Attenuation:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(884, 150);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 18;
            this.textBox4.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(794, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Blue:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(849, 97);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(135, 22);
            this.textBox3.TabIndex = 16;
            this.textBox3.Text = "0.06";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(794, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Green:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(849, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(135, 22);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "0.03";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(794, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Red:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(849, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 22);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "0.1";
            // 
            // GraphicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 439);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Name = "GraphicsForm";
            this.Text = "Graphics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphicsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

