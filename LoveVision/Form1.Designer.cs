namespace LoveVision
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
            this.start_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.record_btn = new System.Windows.Forms.Button();
            this.playback_btn = new System.Windows.Forms.Button();
            this.autoDetect_btn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(13, 27);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(82, 31);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(101, 27);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(82, 31);
            this.stop_btn.TabIndex = 1;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.Stop_btn_Click);
            // 
            // record_btn
            // 
            this.record_btn.Location = new System.Drawing.Point(189, 27);
            this.record_btn.Name = "record_btn";
            this.record_btn.Size = new System.Drawing.Size(91, 31);
            this.record_btn.TabIndex = 3;
            this.record_btn.Text = "Start Recording";
            this.record_btn.UseVisualStyleBackColor = true;
            this.record_btn.Click += new System.EventHandler(this.record_btn_Click);
            // 
            // playback_btn
            // 
            this.playback_btn.Location = new System.Drawing.Point(286, 27);
            this.playback_btn.Name = "playback_btn";
            this.playback_btn.Size = new System.Drawing.Size(82, 29);
            this.playback_btn.TabIndex = 4;
            this.playback_btn.Text = "Playback";
            this.playback_btn.UseVisualStyleBackColor = true;
            this.playback_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playback_btn_MouseDown);
            this.playback_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.playback_btn_MouseUp);

            // 
            // autoDetect_btn
            // 
            this.autoDetect_btn.Location = new System.Drawing.Point(374, 29);
            this.autoDetect_btn.Name = "autoDetect_btn";
            this.autoDetect_btn.Size = new System.Drawing.Size(82, 29);
            this.autoDetect_btn.TabIndex = 5;
            this.autoDetect_btn.Text = "Auto Detect";
            this.autoDetect_btn.UseVisualStyleBackColor = true;
            this.autoDetect_btn.Click += new System.EventHandler(this.AutoDetect_btn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(613, 92);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(182, 433);
            this.listBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(613, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Whats Going On";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 534);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.autoDetect_btn);
            this.Controls.Add(this.playback_btn);
            this.Controls.Add(this.record_btn);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button playback_btn;
        private System.Windows.Forms.Button record_btn;
        private System.Windows.Forms.Button autoDetect_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

