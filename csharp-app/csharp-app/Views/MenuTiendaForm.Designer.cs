using csharp_app.Views.Components;

namespace csharp_app.Views
{
    partial class MenuTiendaForm
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
            sideBar1 = new SideBarControl();
            dashboardControl1 = new DashboardControl();
            dashboardHeaderControl1 = new DashboardHeaderControl();
            subscriptionBadgeControl1 = new SubscriptionBadgeControl();
            SuspendLayout();
            // 
            // sideBar1
            // 
            sideBar1.BackColor = Color.White;
            sideBar1.Location = new Point(12, 12);
            sideBar1.Name = "sideBar1";
            sideBar1.Size = new Size(305, 855);
            sideBar1.TabIndex = 0;
            sideBar1.Load += sideBar1_Load;
            // 
            // dashboardControl1
            // 
            dashboardControl1.AutoScroll = true;
            dashboardControl1.Location = new Point(323, 106);
            dashboardControl1.Name = "dashboardControl1";
            dashboardControl1.Size = new Size(767, 770);
            dashboardControl1.TabIndex = 1;
            dashboardControl1.Load += dashboardControl1_Load;
            // 
            // dashboardHeaderControl1
            // 
            dashboardHeaderControl1.BackColor = Color.Transparent;
            dashboardHeaderControl1.Location = new Point(339, 23);
            dashboardHeaderControl1.Name = "dashboardHeaderControl1";
            dashboardHeaderControl1.Size = new Size(372, 68);
            dashboardHeaderControl1.TabIndex = 2;
            dashboardHeaderControl1.TitleColor = Color.FromArgb(30, 30, 40);
            dashboardHeaderControl1.TitleFont = new Font("Segoe UI", 14F, FontStyle.Bold);
            dashboardHeaderControl1.Load += dashboardHeaderControl1_Load;
            // 
            // subscriptionBadgeControl1
            // 
            subscriptionBadgeControl1.BackColor = Color.Transparent;
            subscriptionBadgeControl1.BadgeColor = Color.FromArgb(239, 246, 255);
            subscriptionBadgeControl1.BorderColor = Color.FromArgb(191, 219, 254);
            subscriptionBadgeControl1.ExpirationDate = new DateTime(2025, 12, 31, 0, 0, 0, 0);
            subscriptionBadgeControl1.Location = new Point(815, 23);
            subscriptionBadgeControl1.Name = "subscriptionBadgeControl1";
            subscriptionBadgeControl1.Padding = new Padding(12, 6, 12, 6);
            subscriptionBadgeControl1.Prefix = "";
            subscriptionBadgeControl1.Size = new Size(251, 45);
            subscriptionBadgeControl1.TabIndex = 3;
            subscriptionBadgeControl1.TextColor = Color.FromArgb(30, 30, 50);
            // 
            // MenuTiendaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1090, 879);
            Controls.Add(subscriptionBadgeControl1);
            Controls.Add(dashboardHeaderControl1);
            Controls.Add(dashboardControl1);
            Controls.Add(sideBar1);
            Name = "MenuTiendaForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private SideBarControl sideBar1;
        private DashboardControl dashboardControl1;
        private DashboardHeaderControl dashboardHeaderControl1;
        private SubscriptionBadgeControl subscriptionBadgeControl1;
    }
}