namespace Aflevering4
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
            tlfnrBox = new TextBox();
            navnBox = new TextBox();
            adresseBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            ReadButton = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // tlfnrBox
            // 
            tlfnrBox.Location = new Point(33, 50);
            tlfnrBox.Name = "tlfnrBox";
            tlfnrBox.Size = new Size(100, 23);
            tlfnrBox.TabIndex = 0;
            // 
            // navnBox
            // 
            navnBox.Location = new Point(33, 106);
            navnBox.Name = "navnBox";
            navnBox.Size = new Size(100, 23);
            navnBox.TabIndex = 1;
            // 
            // adresseBox
            // 
            adresseBox.Location = new Point(33, 164);
            adresseBox.Name = "adresseBox";
            adresseBox.Size = new Size(100, 23);
            adresseBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 32);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 3;
            label1.Text = "tlfnr";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 88);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 4;
            label2.Text = "Navn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 146);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 5;
            label3.Text = "Adresse";
            // 
            // button1
            // 
            button1.Location = new Point(33, 227);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ReadButton
            // 
            ReadButton.Location = new Point(114, 227);
            ReadButton.Name = "ReadButton";
            ReadButton.Size = new Size(75, 23);
            ReadButton.TabIndex = 7;
            ReadButton.Text = "Read";
            ReadButton.UseVisualStyleBackColor = true;
            ReadButton.Click += ReadButton_Click;
            // 
            // button3
            // 
            button3.Location = new Point(195, 227);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(276, 227);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 9;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(357, 227);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 10;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(438, 226);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 11;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 261);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(ReadButton);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(adresseBox);
            Controls.Add(navnBox);
            Controls.Add(tlfnrBox);
            Name = "Form1";
            Text = "KundeCRUD";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tlfnrBox;
        private TextBox navnBox;
        private TextBox adresseBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button ReadButton;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}
