namespace DemoRestaurant.Cook
{
    partial class CookPenelForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button_orders = new System.Windows.Forms.Button();
            this.button_providers = new System.Windows.Forms.Button();
            this.button_supplie = new System.Windows.Forms.Button();
            this.button_ingridients = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Рецепты";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_orders
            // 
            this.button_orders.Location = new System.Drawing.Point(12, 12);
            this.button_orders.Name = "button_orders";
            this.button_orders.Size = new System.Drawing.Size(114, 46);
            this.button_orders.TabIndex = 1;
            this.button_orders.Text = "Заказы";
            this.button_orders.UseVisualStyleBackColor = true;
            this.button_orders.Click += new System.EventHandler(this.button_orders_Click);
            // 
            // button_providers
            // 
            this.button_providers.Location = new System.Drawing.Point(132, 64);
            this.button_providers.Name = "button_providers";
            this.button_providers.Size = new System.Drawing.Size(114, 46);
            this.button_providers.TabIndex = 2;
            this.button_providers.Text = "Поставщики";
            this.button_providers.UseVisualStyleBackColor = true;
            // 
            // button_supplie
            // 
            this.button_supplie.Location = new System.Drawing.Point(132, 12);
            this.button_supplie.Name = "button_supplie";
            this.button_supplie.Size = new System.Drawing.Size(114, 46);
            this.button_supplie.TabIndex = 3;
            this.button_supplie.Text = "Поставки";
            this.button_supplie.UseVisualStyleBackColor = true;
            // 
            // button_ingridients
            // 
            this.button_ingridients.Location = new System.Drawing.Point(12, 116);
            this.button_ingridients.Name = "button_ingridients";
            this.button_ingridients.Size = new System.Drawing.Size(114, 46);
            this.button_ingridients.TabIndex = 4;
            this.button_ingridients.Text = "Ингридиенты";
            this.button_ingridients.UseVisualStyleBackColor = true;
            // 
            // CookPenelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 173);
            this.Controls.Add(this.button_ingridients);
            this.Controls.Add(this.button_supplie);
            this.Controls.Add(this.button_providers);
            this.Controls.Add(this.button_orders);
            this.Controls.Add(this.button1);
            this.Name = "CookPenelForm";
            this.Text = "CookPenelForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_orders;
        private System.Windows.Forms.Button button_providers;
        private System.Windows.Forms.Button button_supplie;
        private System.Windows.Forms.Button button_ingridients;
    }
}