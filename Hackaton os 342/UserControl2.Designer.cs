namespace Hackaton_os_342
{
    partial class UserControl2
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
            this.startButton = new System.Windows.Forms.Button();
            this.consumersRateTextBox = new System.Windows.Forms.TextBox();
            this.consumersRateLabel = new System.Windows.Forms.Label();
            this.producersRateTextBox = new System.Windows.Forms.TextBox();
            this.producersRateLabel = new System.Windows.Forms.Label();
            this.numberOfConsumersTextBox = new System.Windows.Forms.TextBox();
            this.numberOfConsumersLabel = new System.Windows.Forms.Label();
            this.numberOfProducersTextBox = new System.Windows.Forms.TextBox();
            this.numberOfProducersLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(247, 299);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(94, 29);
            this.startButton.TabIndex = 19;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // consumersRateTextBox
            // 
            this.consumersRateTextBox.Location = new System.Drawing.Point(375, 244);
            this.consumersRateTextBox.Name = "consumersRateTextBox";
            this.consumersRateTextBox.Size = new System.Drawing.Size(125, 27);
            this.consumersRateTextBox.TabIndex = 18;
            // 
            // consumersRateLabel
            // 
            this.consumersRateLabel.AutoSize = true;
            this.consumersRateLabel.Location = new System.Drawing.Point(79, 244);
            this.consumersRateLabel.Name = "consumersRateLabel";
            this.consumersRateLabel.Size = new System.Drawing.Size(114, 20);
            this.consumersRateLabel.TabIndex = 17;
            this.consumersRateLabel.Text = "Consumer Ratio";
            // 
            // producersRateTextBox
            // 
            this.producersRateTextBox.Location = new System.Drawing.Point(375, 195);
            this.producersRateTextBox.Name = "producersRateTextBox";
            this.producersRateTextBox.Size = new System.Drawing.Size(125, 27);
            this.producersRateTextBox.TabIndex = 16;
            // 
            // producersRateLabel
            // 
            this.producersRateLabel.AutoSize = true;
            this.producersRateLabel.Location = new System.Drawing.Point(79, 195);
            this.producersRateLabel.Name = "producersRateLabel";
            this.producersRateLabel.Size = new System.Drawing.Size(113, 20);
            this.producersRateLabel.TabIndex = 15;
            this.producersRateLabel.Text = "Producers Ratio";
            // 
            // numberOfConsumersTextBox
            // 
            this.numberOfConsumersTextBox.Location = new System.Drawing.Point(375, 146);
            this.numberOfConsumersTextBox.Name = "numberOfConsumersTextBox";
            this.numberOfConsumersTextBox.Size = new System.Drawing.Size(125, 27);
            this.numberOfConsumersTextBox.TabIndex = 14;
            // 
            // numberOfConsumersLabel
            // 
            this.numberOfConsumersLabel.AutoSize = true;
            this.numberOfConsumersLabel.Location = new System.Drawing.Point(79, 146);
            this.numberOfConsumersLabel.Name = "numberOfConsumersLabel";
            this.numberOfConsumersLabel.Size = new System.Drawing.Size(160, 20);
            this.numberOfConsumersLabel.TabIndex = 13;
            this.numberOfConsumersLabel.Text = "Number of Consumers:";
            // 
            // numberOfProducersTextBox
            // 
            this.numberOfProducersTextBox.Location = new System.Drawing.Point(375, 91);
            this.numberOfProducersTextBox.Name = "numberOfProducersTextBox";
            this.numberOfProducersTextBox.Size = new System.Drawing.Size(125, 27);
            this.numberOfProducersTextBox.TabIndex = 12;
            // 
            // numberOfProducersLabel
            // 
            this.numberOfProducersLabel.AutoSize = true;
            this.numberOfProducersLabel.Location = new System.Drawing.Point(79, 94);
            this.numberOfProducersLabel.Name = "numberOfProducersLabel";
            this.numberOfProducersLabel.Size = new System.Drawing.Size(153, 20);
            this.numberOfProducersLabel.TabIndex = 11;
            this.numberOfProducersLabel.Text = "Number of Producers:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(214, 24);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(188, 20);
            this.titleLabel.TabIndex = 10;
            this.titleLabel.Text = "Producer-Consumer Screen";
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(629, 388);
            this.Load += new System.EventHandler(this.UserControl2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startButton;
        private TextBox consumersRateTextBox;
        private Label consumersRateLabel;
        private TextBox producersRateTextBox;
        private Label producersRateLabel;
        private TextBox numberOfConsumersTextBox;
        private Label numberOfConsumersLabel;
        private TextBox numberOfProducersTextBox;
        private Label numberOfProducersLabel;
        protected internal Label titleLabel;
    }
}
