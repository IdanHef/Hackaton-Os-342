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
            this.producersRateTextBox = new System.Windows.Forms.TextBox();
            this.consumersRateLabel = new System.Windows.Forms.Label();
            this.consumersRateTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
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
            this.numberOfProducersTextBox.TextChanged += new System.EventHandler(this.numberOfProducersTextBox_TextChanged);
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
            this.producersRateLabel.Location = new System.Drawing.Point(145, 222);
            this.producersRateLabel.Name = "producersRateLabel";
            this.producersRateLabel.Size = new System.Drawing.Size(113, 20);
            this.producersRateLabel.TabIndex = 5;
            this.producersRateLabel.Text = "Producers Ratio";
            // 
            // producersRateTextBox
            // 
            this.producersRateTextBox.Location = new System.Drawing.Point(441, 222);
            this.producersRateTextBox.Name = "producersRateTextBox";
            this.producersRateTextBox.Size = new System.Drawing.Size(125, 27);
            this.producersRateTextBox.TabIndex = 6;
            // 
            // consumersRateLabel
            // 
            this.consumersRateLabel.AutoSize = true;
            this.consumersRateLabel.Location = new System.Drawing.Point(145, 271);
            this.consumersRateLabel.Name = "consumersRateLabel";
            this.consumersRateLabel.Size = new System.Drawing.Size(114, 20);
            this.consumersRateLabel.TabIndex = 7;
            this.consumersRateLabel.Text = "Consumer Ratio";
            // 
            // consumersRateTextBox
            // 
            this.consumersRateTextBox.Location = new System.Drawing.Point(441, 271);
            this.consumersRateTextBox.Name = "consumersRateTextBox";
            this.consumersRateTextBox.Size = new System.Drawing.Size(125, 27);
            this.consumersRateTextBox.TabIndex = 8;
            this.consumersRateTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(353, 352);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(94, 29);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 438);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.consumersRateTextBox);
            this.Controls.Add(this.consumersRateLabel);
            this.Controls.Add(this.producersRateTextBox);
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
        private TextBox producersRateTextBox;
        private Label consumersRateLabel;
        private TextBox consumersRateTextBox;
        private Button startButton;

    }
}