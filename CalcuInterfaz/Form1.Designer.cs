namespace CalcuInterfaz
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button Men_Button;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Num0 = new Button();
            ComaBut = new Button();
            CButton = new Button();
            Igual_Button = new Button();
            Mas_Button = new Button();
            Num3 = new Button();
            Num2 = new Button();
            Num1 = new Button();
            Num6 = new Button();
            Num5 = new Button();
            Num4 = new Button();
            X_Button = new Button();
            Num9 = new Button();
            Num8 = new Button();
            Num7 = new Button();
            Div_Button = new Button();
            Par_Button = new Button();
            AC_Button = new Button();
            Ingreso = new TextBox();
            button1 = new Button();
            OutPut = new TextBox();
            Men_Button = new Button();
            SuspendLayout();
            // 
            // Men_Button
            // 
            Men_Button.BackColor = Color.FromArgb(64, 64, 64);
            Men_Button.FlatAppearance.BorderSize = 0;
            Men_Button.FlatStyle = FlatStyle.Flat;
            Men_Button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Men_Button.ForeColor = Color.White;
            Men_Button.Location = new Point(175, 216);
            Men_Button.Margin = new Padding(1);
            Men_Button.Name = "Men_Button";
            Men_Button.Size = new Size(54, 48);
            Men_Button.TabIndex = 11;
            Men_Button.Text = "-";
            Men_Button.UseVisualStyleBackColor = false;
            Men_Button.Click += agregarNumero;
            // 
            // Num0
            // 
            Num0.BackColor = Color.FromArgb(20, 20, 20);
            Num0.FlatAppearance.BorderSize = 0;
            Num0.FlatStyle = FlatStyle.Flat;
            Num0.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Num0.ForeColor = Color.White;
            Num0.Location = new Point(63, 316);
            Num0.Margin = new Padding(1);
            Num0.Name = "Num0";
            Num0.Size = new Size(54, 48);
            Num0.TabIndex = 0;
            Num0.Text = "0";
            Num0.UseVisualStyleBackColor = false;
            Num0.Click += agregarNumero;
            // 
            // ComaBut
            // 
            ComaBut.BackColor = Color.FromArgb(64, 64, 64);
            ComaBut.FlatAppearance.BorderSize = 0;
            ComaBut.FlatStyle = FlatStyle.Flat;
            ComaBut.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ComaBut.ForeColor = Color.White;
            ComaBut.Location = new Point(7, 316);
            ComaBut.Margin = new Padding(1);
            ComaBut.Name = "ComaBut";
            ComaBut.Size = new Size(54, 48);
            ComaBut.TabIndex = 1;
            ComaBut.Text = ".";
            ComaBut.UseVisualStyleBackColor = false;
            ComaBut.Click += agregarNumero;
            // 
            // CButton
            // 
            CButton.BackColor = Color.FromArgb(64, 64, 64);
            CButton.FlatAppearance.BorderSize = 0;
            CButton.FlatStyle = FlatStyle.Flat;
            CButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CButton.ForeColor = Color.White;
            CButton.Location = new Point(119, 316);
            CButton.Margin = new Padding(1);
            CButton.Name = "CButton";
            CButton.Size = new Size(54, 48);
            CButton.TabIndex = 2;
            CButton.Text = "C";
            CButton.UseVisualStyleBackColor = false;
            CButton.Click += CButton_Click;
            // 
            // Igual_Button
            // 
            Igual_Button.BackColor = SystemColors.MenuHighlight;
            Igual_Button.FlatAppearance.BorderSize = 0;
            Igual_Button.FlatStyle = FlatStyle.Flat;
            Igual_Button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Igual_Button.ForeColor = Color.White;
            Igual_Button.Location = new Point(175, 316);
            Igual_Button.Margin = new Padding(1);
            Igual_Button.Name = "Igual_Button";
            Igual_Button.Size = new Size(54, 48);
            Igual_Button.TabIndex = 3;
            Igual_Button.Text = "=";
            Igual_Button.UseVisualStyleBackColor = false;
            Igual_Button.Click += Igual_Button_Click;
            // 
            // Mas_Button
            // 
            Mas_Button.BackColor = Color.FromArgb(64, 64, 64);
            Mas_Button.FlatAppearance.BorderSize = 0;
            Mas_Button.FlatStyle = FlatStyle.Flat;
            Mas_Button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Mas_Button.ForeColor = Color.White;
            Mas_Button.Location = new Point(175, 266);
            Mas_Button.Margin = new Padding(1);
            Mas_Button.Name = "Mas_Button";
            Mas_Button.Size = new Size(54, 48);
            Mas_Button.TabIndex = 7;
            Mas_Button.Text = "+";
            Mas_Button.UseVisualStyleBackColor = false;
            Mas_Button.Click += agregarNumero;
            // 
            // Num3
            // 
            Num3.BackColor = Color.FromArgb(20, 20, 20);
            Num3.FlatAppearance.BorderSize = 0;
            Num3.FlatStyle = FlatStyle.Flat;
            Num3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Num3.ForeColor = Color.White;
            Num3.Location = new Point(119, 266);
            Num3.Margin = new Padding(1);
            Num3.Name = "Num3";
            Num3.Size = new Size(54, 48);
            Num3.TabIndex = 6;
            Num3.Text = "3";
            Num3.UseVisualStyleBackColor = false;
            Num3.Click += agregarNumero;
            // 
            // Num2
            // 
            Num2.BackColor = Color.FromArgb(20, 20, 20);
            Num2.FlatAppearance.BorderSize = 0;
            Num2.FlatStyle = FlatStyle.Flat;
            Num2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Num2.ForeColor = Color.White;
            Num2.Location = new Point(63, 266);
            Num2.Margin = new Padding(1);
            Num2.Name = "Num2";
            Num2.Size = new Size(54, 48);
            Num2.TabIndex = 5;
            Num2.Text = "2";
            Num2.UseVisualStyleBackColor = false;
            Num2.Click += agregarNumero;
            // 
            // Num1
            // 
            Num1.BackColor = Color.FromArgb(20, 20, 20);
            Num1.FlatAppearance.BorderSize = 0;
            Num1.FlatStyle = FlatStyle.Flat;
            Num1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Num1.ForeColor = Color.White;
            Num1.Location = new Point(7, 266);
            Num1.Margin = new Padding(1);
            Num1.Name = "Num1";
            Num1.Size = new Size(54, 48);
            Num1.TabIndex = 4;
            Num1.Text = "1";
            Num1.UseVisualStyleBackColor = false;
            Num1.Click += agregarNumero;
            // 
            // Num6
            // 
            Num6.BackColor = Color.FromArgb(20, 20, 20);
            Num6.FlatAppearance.BorderSize = 0;
            Num6.FlatStyle = FlatStyle.Flat;
            Num6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Num6.ForeColor = Color.White;
            Num6.Location = new Point(119, 216);
            Num6.Margin = new Padding(1);
            Num6.Name = "Num6";
            Num6.Size = new Size(54, 48);
            Num6.TabIndex = 10;
            Num6.Text = "6";
            Num6.UseVisualStyleBackColor = false;
            Num6.Click += agregarNumero;
            // 
            // Num5
            // 
            Num5.BackColor = Color.FromArgb(20, 20, 20);
            Num5.FlatAppearance.BorderSize = 0;
            Num5.FlatStyle = FlatStyle.Flat;
            Num5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Num5.ForeColor = Color.White;
            Num5.Location = new Point(63, 216);
            Num5.Margin = new Padding(1);
            Num5.Name = "Num5";
            Num5.Size = new Size(54, 48);
            Num5.TabIndex = 9;
            Num5.Text = "5";
            Num5.UseVisualStyleBackColor = false;
            Num5.Click += agregarNumero;
            // 
            // Num4
            // 
            Num4.BackColor = Color.FromArgb(20, 20, 20);
            Num4.FlatAppearance.BorderSize = 0;
            Num4.FlatStyle = FlatStyle.Flat;
            Num4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Num4.ForeColor = Color.White;
            Num4.Location = new Point(7, 216);
            Num4.Margin = new Padding(1);
            Num4.Name = "Num4";
            Num4.Size = new Size(54, 48);
            Num4.TabIndex = 8;
            Num4.Text = "4";
            Num4.UseVisualStyleBackColor = false;
            Num4.Click += agregarNumero;
            // 
            // X_Button
            // 
            X_Button.BackColor = Color.FromArgb(64, 64, 64);
            X_Button.FlatAppearance.BorderSize = 0;
            X_Button.FlatStyle = FlatStyle.Flat;
            X_Button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            X_Button.ForeColor = Color.White;
            X_Button.Location = new Point(175, 166);
            X_Button.Margin = new Padding(1);
            X_Button.Name = "X_Button";
            X_Button.Size = new Size(54, 48);
            X_Button.TabIndex = 15;
            X_Button.Text = "*";
            X_Button.UseVisualStyleBackColor = false;
            X_Button.Click += X_Button_Click;
            // 
            // Num9
            // 
            Num9.BackColor = Color.FromArgb(20, 20, 20);
            Num9.FlatAppearance.BorderSize = 0;
            Num9.FlatStyle = FlatStyle.Flat;
            Num9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Num9.ForeColor = Color.White;
            Num9.Location = new Point(119, 166);
            Num9.Margin = new Padding(1);
            Num9.Name = "Num9";
            Num9.Size = new Size(54, 48);
            Num9.TabIndex = 14;
            Num9.Text = "9";
            Num9.UseVisualStyleBackColor = false;
            Num9.Click += agregarNumero;
            // 
            // Num8
            // 
            Num8.BackColor = Color.FromArgb(20, 20, 20);
            Num8.FlatAppearance.BorderSize = 0;
            Num8.FlatStyle = FlatStyle.Flat;
            Num8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Num8.ForeColor = Color.White;
            Num8.Location = new Point(63, 166);
            Num8.Margin = new Padding(1);
            Num8.Name = "Num8";
            Num8.Size = new Size(54, 48);
            Num8.TabIndex = 13;
            Num8.Text = "8";
            Num8.UseVisualStyleBackColor = false;
            Num8.Click += agregarNumero;
            // 
            // Num7
            // 
            Num7.BackColor = Color.FromArgb(20, 20, 20);
            Num7.FlatAppearance.BorderSize = 0;
            Num7.FlatStyle = FlatStyle.Flat;
            Num7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Num7.ForeColor = Color.White;
            Num7.Location = new Point(7, 166);
            Num7.Margin = new Padding(1);
            Num7.Name = "Num7";
            Num7.Size = new Size(54, 48);
            Num7.TabIndex = 12;
            Num7.Text = "7";
            Num7.UseVisualStyleBackColor = false;
            Num7.Click += agregarNumero;
            // 
            // Div_Button
            // 
            Div_Button.BackColor = Color.FromArgb(64, 64, 64);
            Div_Button.FlatAppearance.BorderSize = 0;
            Div_Button.FlatStyle = FlatStyle.Flat;
            Div_Button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Div_Button.ForeColor = Color.White;
            Div_Button.Location = new Point(175, 116);
            Div_Button.Margin = new Padding(1);
            Div_Button.Name = "Div_Button";
            Div_Button.Size = new Size(54, 48);
            Div_Button.TabIndex = 19;
            Div_Button.Text = "/";
            Div_Button.UseVisualStyleBackColor = false;
            Div_Button.Click += agregarNumero;
            // 
            // Par_Button
            // 
            Par_Button.BackColor = Color.FromArgb(64, 64, 64);
            Par_Button.FlatAppearance.BorderSize = 0;
            Par_Button.FlatStyle = FlatStyle.Flat;
            Par_Button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Par_Button.ForeColor = Color.White;
            Par_Button.Location = new Point(119, 116);
            Par_Button.Margin = new Padding(1);
            Par_Button.Name = "Par_Button";
            Par_Button.Size = new Size(54, 48);
            Par_Button.TabIndex = 17;
            Par_Button.Text = ")";
            Par_Button.UseVisualStyleBackColor = false;
            Par_Button.Click += agregarNumero;
            // 
            // AC_Button
            // 
            AC_Button.BackColor = Color.FromArgb(64, 64, 64);
            AC_Button.FlatAppearance.BorderSize = 0;
            AC_Button.FlatStyle = FlatStyle.Flat;
            AC_Button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AC_Button.ForeColor = Color.White;
            AC_Button.Location = new Point(7, 116);
            AC_Button.Margin = new Padding(1);
            AC_Button.Name = "AC_Button";
            AC_Button.Size = new Size(54, 48);
            AC_Button.TabIndex = 16;
            AC_Button.Text = "AC";
            AC_Button.UseVisualStyleBackColor = false;
            AC_Button.Click += AC_Button_Click;
            // 
            // Ingreso
            // 
            Ingreso.BackColor = Color.FromArgb(20, 20, 20);
            Ingreso.BorderStyle = BorderStyle.None;
            Ingreso.Dock = DockStyle.Top;
            Ingreso.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            Ingreso.ForeColor = Color.White;
            Ingreso.Location = new Point(0, 0);
            Ingreso.MaxLength = 20;
            Ingreso.Multiline = true;
            Ingreso.Name = "Ingreso";
            Ingreso.ReadOnly = true;
            Ingreso.Size = new Size(236, 56);
            Ingreso.TabIndex = 20;
            Ingreso.TextAlign = HorizontalAlignment.Right;
            Ingreso.TextChanged += Resultado_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(63, 116);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(54, 48);
            button1.TabIndex = 21;
            button1.Text = "(";
            button1.UseVisualStyleBackColor = false;
            button1.Click += agregarNumero;
            // 
            // OutPut
            // 
            OutPut.BackColor = Color.FromArgb(20, 20, 20);
            OutPut.BorderStyle = BorderStyle.None;
            OutPut.Dock = DockStyle.Top;
            OutPut.Font = new Font("Calibri Light", 26.25F, FontStyle.Italic, GraphicsUnit.Point);
            OutPut.ForeColor = Color.White;
            OutPut.Location = new Point(0, 56);
            OutPut.MaxLength = 20;
            OutPut.Multiline = true;
            OutPut.Name = "OutPut";
            OutPut.ReadOnly = true;
            OutPut.Size = new Size(236, 46);
            OutPut.TabIndex = 23;
            OutPut.TextAlign = HorizontalAlignment.Right;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(25, 25, 25);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(236, 376);
            Controls.Add(OutPut);
            Controls.Add(button1);
            Controls.Add(Ingreso);
            Controls.Add(Div_Button);
            Controls.Add(Par_Button);
            Controls.Add(AC_Button);
            Controls.Add(X_Button);
            Controls.Add(Num9);
            Controls.Add(Num8);
            Controls.Add(Num7);
            Controls.Add(Men_Button);
            Controls.Add(Num6);
            Controls.Add(Num5);
            Controls.Add(Num4);
            Controls.Add(Mas_Button);
            Controls.Add(Num3);
            Controls.Add(Num2);
            Controls.Add(Num1);
            Controls.Add(Igual_Button);
            Controls.Add(CButton);
            Controls.Add(ComaBut);
            Controls.Add(Num0);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculadora";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Num0;
        private Button ComaBut;
        private Button CButton;
        private Button Igual_Button;
        private Button Mas_Button;
        private Button Num3;
        private Button Num2;
        private Button Num1;
        private Button Men_Button;
        private Button Num6;
        private Button Num5;
        private Button Num4;
        private Button X_Button;
        private Button Num9;
        private Button Num8;
        private Button Num7;
        private Button Div_Button;
        private Button Par_Button;
        private Button AC_Button;
        private TextBox Ingreso;
        private Button button1;
        private TextBox OutPut;
    }
}