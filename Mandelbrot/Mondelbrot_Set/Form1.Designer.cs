namespace Mondelbrot_Set
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Drow_Mandelbrot = new System.Windows.Forms.Button();
            this.imPict = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Auto_Scale = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imPict)).BeginInit();
            this.SuspendLayout();
            // 
            // Drow_Mandelbrot
            // 
            this.Drow_Mandelbrot.Location = new System.Drawing.Point(819, 12);
            this.Drow_Mandelbrot.Name = "Drow_Mandelbrot";
            this.Drow_Mandelbrot.Size = new System.Drawing.Size(139, 68);
            this.Drow_Mandelbrot.TabIndex = 0;
            this.Drow_Mandelbrot.Text = "Drow_Mandelbrot";
            this.Drow_Mandelbrot.UseVisualStyleBackColor = true;
            this.Drow_Mandelbrot.Click += new System.EventHandler(this.button1_Click);
            // 
            // imPict
            // 
            this.imPict.Location = new System.Drawing.Point(12, 0);
            this.imPict.Name = "imPict";
            this.imPict.Size = new System.Drawing.Size(801, 574);
            this.imPict.TabIndex = 1;
            this.imPict.TabStop = false;
            this.imPict.Click += new System.EventHandler(this.pictureBox1_Click);
            this.imPict.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Auto_Scale
            // 
            this.Auto_Scale.Location = new System.Drawing.Point(819, 86);
            this.Auto_Scale.Name = "Auto_Scale";
            this.Auto_Scale.Size = new System.Drawing.Size(139, 61);
            this.Auto_Scale.TabIndex = 2;
            this.Auto_Scale.Text = "Auto scale";
            this.Auto_Scale.UseVisualStyleBackColor = true;
            this.Auto_Scale.Click += new System.EventHandler(this.Auto_Scale_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 576);
            this.Controls.Add(this.Auto_Scale);
            this.Controls.Add(this.imPict);
            this.Controls.Add(this.Drow_Mandelbrot);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imPict)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Drow_Mandelbrot;
        private System.Windows.Forms.PictureBox imPict;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Auto_Scale;
    }
}

