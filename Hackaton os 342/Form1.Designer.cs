namespace Hackaton_os_342
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.numberOfProducersLabel = new System.Windows.Forms.Label();
            this.numberOfProducersTextBox = new System.Windows.Forms.TextBox();
            this.numberOfConsumersLabel = new System.Windows.Forms.Label();
            this.numberOfConsumersTextBox = new System.Windows.Forms.TextBox();
            this.producersRateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(309, 36);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(188, 20);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Producer-Consumer Screen";
            this.titleLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // numberOfProducersLabel
            // 
            this.numberOfProducersLabel.AutoSize = true;
            this.numberOfProducersLabel.Location = new System.Drawing.Point(145, 121);
            this.numberOfProducersLabel.Name = "numberOfProducersLabel";
            this.numberOfProducersLabel.Size = new System.Drawing.Size(153, 20);
            this.numberOfProducersLabel.TabIndex = 1;
            this.numberOfProducersLabel.Text = "Number of Producers:";
            // 
            // numberOfProducersTextBox
            // 
            this.numberOfProducersTextBox.Location = new System.Drawing.Point(441, 118);
            this.numberOfProducersTextBox.Name = "numberOfProducersTextBox";
            this.numberOfProducersTextBox.Size = new System.Drawing.Size(125, 27);
            this.numberOfProducersTextBox.TabIndex = 2;
            // 
            // numberOfConsumersLabel
            // 
            this.numberOfConsumersLabel.AutoSize = true;
            this.numberOfConsumersLabel.Location = new System.Drawing.Point(145, 173);
            this.numberOfConsumersLabel.Name = "numberOfConsumersLabel";
            this.numberOfConsumersLabel.Size = new System.Drawing.Size(160, 20);
            this.numberOfConsumersLabel.TabIndex = 3;
            this.numberOfConsumersLabel.Text = "Number of Consumers:";
            // 
            // numberOfConsumersTextBox
            // 
            this.numberOfConsumersTextBox.Location = new System.Drawing.Point(441, 173);
            this.numberOfConsumersTextBox.Name = "numberOfConsumersTextBox";
            this.numberOfConsumersTextBox.Size = new System.Drawing.Size(125, 27);
            this.numberOfConsumersTextBox.TabIndex = 4;
            // 
            // producersRateLabel
            // 
            this.producersRateLabel.AutoSize = true;
            this.producersRateLabel.Location = new System.Drawing.Point(145, 232);
            this.producersRateLabel.Name = "producersRateLabel";
            this.producersRateLabel.Size = new System.Drawing.Size(160, 20);
            this.producersRateLabel.TabIndex = 5;
            this.producersRateLabel.Text = "Number of Consumers:";
            this.producersRateLabel.Click += new System.EventHandler(this.producersRateLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.producersRateLabel);
            this.Controls.Add(this.numberOfConsumersTextBox);
            this.Controls.Add(this.numberOfConsumersLabel);
            this.Controls.Add(this.numberOfProducersTextBox);
            this.Controls.Add(this.numberOfProducersLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal Label titleLabel;
        private Label numberOfProducersLabel;
        private TextBox numberOfProducersTextBox;
        private Label numberOfConsumersLabel;
        private TextBox numberOfConsumersTextBox;
        private Label producersRateLabel;
    }
}