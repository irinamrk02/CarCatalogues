namespace CarСatalogues
{
    partial class FormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            this.buttonAutopart = new System.Windows.Forms.Button();
            this.buttonCars = new System.Windows.Forms.Button();
            this.buttonMaker = new System.Windows.Forms.Button();
            this.buttonShops = new System.Windows.Forms.Button();
            this.buttonClients = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAutopart
            // 
            this.buttonAutopart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonAutopart.Font = new System.Drawing.Font("Roboto Light", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAutopart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAutopart.Location = new System.Drawing.Point(5, 140);
            this.buttonAutopart.Name = "buttonAutopart";
            this.buttonAutopart.Size = new System.Drawing.Size(360, 65);
            this.buttonAutopart.TabIndex = 3;
            this.buttonAutopart.Text = "Автозапчасти";
            this.buttonAutopart.UseVisualStyleBackColor = false;
            this.buttonAutopart.Click += new System.EventHandler(this.ButtonAutopart_Click);
            // 
            // buttonCars
            // 
            this.buttonCars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonCars.Font = new System.Drawing.Font("Roboto Light", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCars.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCars.Location = new System.Drawing.Point(5, 211);
            this.buttonCars.Name = "buttonCars";
            this.buttonCars.Size = new System.Drawing.Size(360, 65);
            this.buttonCars.TabIndex = 4;
            this.buttonCars.Text = "Автомобили";
            this.buttonCars.UseVisualStyleBackColor = false;
            this.buttonCars.Click += new System.EventHandler(this.ButtonCars_Click);
            // 
            // buttonMaker
            // 
            this.buttonMaker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonMaker.Font = new System.Drawing.Font("Roboto Light", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMaker.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMaker.Location = new System.Drawing.Point(5, 282);
            this.buttonMaker.Name = "buttonMaker";
            this.buttonMaker.Size = new System.Drawing.Size(360, 65);
            this.buttonMaker.TabIndex = 5;
            this.buttonMaker.Text = "Производители";
            this.buttonMaker.UseVisualStyleBackColor = false;
            this.buttonMaker.Click += new System.EventHandler(this.ButtonMaker_Click);
            // 
            // buttonShops
            // 
            this.buttonShops.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonShops.Font = new System.Drawing.Font("Roboto Light", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShops.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonShops.Location = new System.Drawing.Point(5, 353);
            this.buttonShops.Name = "buttonShops";
            this.buttonShops.Size = new System.Drawing.Size(360, 65);
            this.buttonShops.TabIndex = 6;
            this.buttonShops.Text = "Магазины";
            this.buttonShops.UseVisualStyleBackColor = false;
            this.buttonShops.Click += new System.EventHandler(this.ButtonShops_Click);
            // 
            // buttonClients
            // 
            this.buttonClients.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonClients.Font = new System.Drawing.Font("Roboto Light", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClients.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonClients.Location = new System.Drawing.Point(5, 424);
            this.buttonClients.Name = "buttonClients";
            this.buttonClients.Size = new System.Drawing.Size(360, 65);
            this.buttonClients.TabIndex = 7;
            this.buttonClients.Text = "Клиенты";
            this.buttonClients.UseVisualStyleBackColor = false;
            this.buttonClients.Click += new System.EventHandler(this.ButtonClients_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.White;
            this.buttonBack.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonBack.Location = new System.Drawing.Point(272, 3);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(93, 30);
            this.buttonBack.TabIndex = 9;
            this.buttonBack.Text = "Выйти";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // buttonOrder
            // 
            this.buttonOrder.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonOrder.Font = new System.Drawing.Font("Roboto Light", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonOrder.Location = new System.Drawing.Point(5, 496);
            this.buttonOrder.Name = "buttonOrder";
            this.buttonOrder.Size = new System.Drawing.Size(360, 65);
            this.buttonOrder.TabIndex = 10;
            this.buttonOrder.Text = "Заказы";
            this.buttonOrder.UseVisualStyleBackColor = false;
            this.buttonOrder.Click += new System.EventHandler(this.ButtonOrder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarСatalogues.Properties.Resources.header_ru;
            this.pictureBox1.Location = new System.Drawing.Point(8, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(371, 568);
            this.Controls.Add(this.buttonOrder);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonClients);
            this.Controls.Add(this.buttonShops);
            this.Controls.Add(this.buttonMaker);
            this.Controls.Add(this.buttonCars);
            this.Controls.Add(this.buttonAutopart);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню администратора";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAutopart;
        private System.Windows.Forms.Button buttonCars;
        private System.Windows.Forms.Button buttonMaker;
        private System.Windows.Forms.Button buttonShops;
        private System.Windows.Forms.Button buttonClients;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonOrder;
    }
}