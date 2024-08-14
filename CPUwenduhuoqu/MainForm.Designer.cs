using System.Drawing;
using System.Windows.Forms;

namespace CPUwenduhuoqu
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cpuTempLabel = new System.Windows.Forms.Label();
            this.gpuTempLabel = new System.Windows.Forms.Label();
            this.comboBoxSerialPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.checkBoxUseAida64Mode = new System.Windows.Forms.CheckBox();
            this.comboBoxChooseCpuMonitor = new System.Windows.Forms.ComboBox();
            this.comboBoxChooseGpuMonitor = new System.Windows.Forms.ComboBox();
            this.labelNoticeCpuMonitor = new System.Windows.Forms.Label();
            this.labelNoticeGpuMonitor = new System.Windows.Forms.Label();
            this.buttonUseChosenMonitor = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusAida64CpuMonitor = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusAida64GpuMonitor = new System.Windows.Forms.ToolStripStatusLabel();
            this.domainUpDownSelectRefreshTime = new System.Windows.Forms.DomainUpDown();
            this.buttonConfirmRefreshTime = new System.Windows.Forms.Button();
            this.labelNoticeRefreshTimeAdjustmentWindow = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cpuTempLabel
            // 
            this.cpuTempLabel.AutoSize = true;
            this.cpuTempLabel.Location = new System.Drawing.Point(18, 12);
            this.cpuTempLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cpuTempLabel.Name = "cpuTempLabel";
            this.cpuTempLabel.Size = new System.Drawing.Size(98, 18);
            this.cpuTempLabel.TabIndex = 0;
            this.cpuTempLabel.Text = "CPU Temp: ";
            // 
            // gpuTempLabel
            // 
            this.gpuTempLabel.AutoSize = true;
            this.gpuTempLabel.Location = new System.Drawing.Point(18, 48);
            this.gpuTempLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gpuTempLabel.Name = "gpuTempLabel";
            this.gpuTempLabel.Size = new System.Drawing.Size(98, 18);
            this.gpuTempLabel.TabIndex = 1;
            this.gpuTempLabel.Text = "GPU Temp: ";
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPorts.FormattingEnabled = true;
            this.comboBoxSerialPorts.Location = new System.Drawing.Point(13, 84);
            this.comboBoxSerialPorts.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            this.comboBoxSerialPorts.Size = new System.Drawing.Size(180, 26);
            this.comboBoxSerialPorts.TabIndex = 2;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(218, 78);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(112, 36);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(353, 89);
            this.labelConnectionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(116, 18);
            this.labelConnectionStatus.TabIndex = 4;
            this.labelConnectionStatus.Text = "Disconnected";
            // 
            // checkBoxUseAida64Mode
            // 
            this.checkBoxUseAida64Mode.AutoSize = true;
            this.checkBoxUseAida64Mode.Location = new System.Drawing.Point(12, 177);
            this.checkBoxUseAida64Mode.Name = "checkBoxUseAida64Mode";
            this.checkBoxUseAida64Mode.Size = new System.Drawing.Size(376, 22);
            this.checkBoxUseAida64Mode.TabIndex = 5;
            this.checkBoxUseAida64Mode.Text = "Use AIDA64 to get hardware information";
            this.checkBoxUseAida64Mode.UseVisualStyleBackColor = true;
            this.checkBoxUseAida64Mode.CheckedChanged += new System.EventHandler(this.checkBox_useAida64Mode);
            // 
            // comboBoxChooseCpuMonitor
            // 
            this.comboBoxChooseCpuMonitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseCpuMonitor.Enabled = false;
            this.comboBoxChooseCpuMonitor.ForeColor = System.Drawing.Color.Black;
            this.comboBoxChooseCpuMonitor.FormattingEnabled = true;
            this.comboBoxChooseCpuMonitor.Location = new System.Drawing.Point(12, 247);
            this.comboBoxChooseCpuMonitor.Name = "comboBoxChooseCpuMonitor";
            this.comboBoxChooseCpuMonitor.Size = new System.Drawing.Size(193, 26);
            this.comboBoxChooseCpuMonitor.TabIndex = 7;
            // 
            // comboBoxChooseGpuMonitor
            // 
            this.comboBoxChooseGpuMonitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseGpuMonitor.Enabled = false;
            this.comboBoxChooseGpuMonitor.ForeColor = System.Drawing.Color.Black;
            this.comboBoxChooseGpuMonitor.FormattingEnabled = true;
            this.comboBoxChooseGpuMonitor.Location = new System.Drawing.Point(262, 247);
            this.comboBoxChooseGpuMonitor.Name = "comboBoxChooseGpuMonitor";
            this.comboBoxChooseGpuMonitor.Size = new System.Drawing.Size(188, 26);
            this.comboBoxChooseGpuMonitor.TabIndex = 7;
            // 
            // labelNoticeCpuMonitor
            // 
            this.labelNoticeCpuMonitor.AutoSize = true;
            this.labelNoticeCpuMonitor.ForeColor = System.Drawing.Color.Gray;
            this.labelNoticeCpuMonitor.Location = new System.Drawing.Point(17, 216);
            this.labelNoticeCpuMonitor.Name = "labelNoticeCpuMonitor";
            this.labelNoticeCpuMonitor.Size = new System.Drawing.Size(188, 18);
            this.labelNoticeCpuMonitor.TabIndex = 8;
            this.labelNoticeCpuMonitor.Text = "Choose a CPU Monitor";
            // 
            // labelNoticeGpuMonitor
            // 
            this.labelNoticeGpuMonitor.AutoSize = true;
            this.labelNoticeGpuMonitor.ForeColor = System.Drawing.Color.Gray;
            this.labelNoticeGpuMonitor.Location = new System.Drawing.Point(262, 216);
            this.labelNoticeGpuMonitor.Name = "labelNoticeGpuMonitor";
            this.labelNoticeGpuMonitor.Size = new System.Drawing.Size(188, 18);
            this.labelNoticeGpuMonitor.TabIndex = 9;
            this.labelNoticeGpuMonitor.Text = "Choose a GPU Monitor";
            // 
            // buttonUseChosenMonitor
            // 
            this.buttonUseChosenMonitor.Enabled = false;
            this.buttonUseChosenMonitor.Location = new System.Drawing.Point(470, 239);
            this.buttonUseChosenMonitor.Name = "buttonUseChosenMonitor";
            this.buttonUseChosenMonitor.Size = new System.Drawing.Size(122, 40);
            this.buttonUseChosenMonitor.TabIndex = 10;
            this.buttonUseChosenMonitor.Text = "Confirm";
            this.buttonUseChosenMonitor.UseVisualStyleBackColor = true;
            this.buttonUseChosenMonitor.Click += new System.EventHandler(this.buttonUseChosenMonitor_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusAida64CpuMonitor,
            this.toolStripStatusAida64GpuMonitor});
            this.statusStrip.Location = new System.Drawing.Point(0, 283);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(673, 31);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusAida64CpuMonitor
            // 
            this.toolStripStatusAida64CpuMonitor.ForeColor = System.Drawing.Color.Gray;
            this.toolStripStatusAida64CpuMonitor.Name = "toolStripStatusAida64CpuMonitor";
            this.toolStripStatusAida64CpuMonitor.Size = new System.Drawing.Size(202, 24);
            this.toolStripStatusAida64CpuMonitor.Text = "AIDA64 CPU Monitor: ";
            // 
            // toolStripStatusAida64GpuMonitor
            // 
            this.toolStripStatusAida64GpuMonitor.ForeColor = System.Drawing.Color.Gray;
            this.toolStripStatusAida64GpuMonitor.Name = "toolStripStatusAida64GpuMonitor";
            this.toolStripStatusAida64GpuMonitor.Size = new System.Drawing.Size(203, 24);
            this.toolStripStatusAida64GpuMonitor.Text = "AIDA64 GPU Monitor: ";
            // 
            // domainUpDownSelectRefreshTime
            // 
            this.domainUpDownSelectRefreshTime.Location = new System.Drawing.Point(265, 139);
            this.domainUpDownSelectRefreshTime.Name = "domainUpDownSelectRefreshTime";
            this.domainUpDownSelectRefreshTime.Size = new System.Drawing.Size(185, 28);
            this.domainUpDownSelectRefreshTime.TabIndex = 12;
            // 
            // buttonConfirmRefreshTime
            // 
            this.buttonConfirmRefreshTime.Location = new System.Drawing.Point(470, 130);
            this.buttonConfirmRefreshTime.Name = "buttonConfirmRefreshTime";
            this.buttonConfirmRefreshTime.Size = new System.Drawing.Size(122, 40);
            this.buttonConfirmRefreshTime.TabIndex = 13;
            this.buttonConfirmRefreshTime.Text = "Confirm";
            this.buttonConfirmRefreshTime.UseVisualStyleBackColor = true;
            this.buttonConfirmRefreshTime.Click += new System.EventHandler(this.buttonConfirmRefreshTime_Click);
            // 
            // labelNoticeRefreshTimeAdjustmentWindow
            // 
            this.labelNoticeRefreshTimeAdjustmentWindow.AutoSize = true;
            this.labelNoticeRefreshTimeAdjustmentWindow.Location = new System.Drawing.Point(10, 141);
            this.labelNoticeRefreshTimeAdjustmentWindow.Name = "labelNoticeRefreshTimeAdjustmentWindow";
            this.labelNoticeRefreshTimeAdjustmentWindow.Size = new System.Drawing.Size(242, 18);
            this.labelNoticeRefreshTimeAdjustmentWindow.TabIndex = 14;
            this.labelNoticeRefreshTimeAdjustmentWindow.Text = "Select Refresh Time(3-30s)";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "Hardware Monitor";
            this.notifyIcon.Icon = Properties.Resources.MainIcon;
            this.notifyIcon.Visible = false;
            this.notifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            


            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 314);
            this.Controls.Add(this.labelNoticeRefreshTimeAdjustmentWindow);
            this.Controls.Add(this.buttonConfirmRefreshTime);
            this.Controls.Add(this.domainUpDownSelectRefreshTime);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonUseChosenMonitor);
            this.Controls.Add(this.labelNoticeGpuMonitor);
            this.Controls.Add(this.labelNoticeCpuMonitor);
            this.Controls.Add(this.comboBoxChooseGpuMonitor);
            this.Controls.Add(this.comboBoxChooseCpuMonitor);
            this.Controls.Add(this.checkBoxUseAida64Mode);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxSerialPorts);
            this.Controls.Add(this.gpuTempLabel);
            this.Controls.Add(this.cpuTempLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Hardware Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MaximizeBox = false;
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label cpuTempLabel;
        private System.Windows.Forms.Label gpuTempLabel;
        private System.Windows.Forms.ComboBox comboBoxSerialPorts;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.CheckBox checkBoxUseAida64Mode;
        private System.Windows.Forms.ComboBox comboBoxChooseCpuMonitor;
        private System.Windows.Forms.ComboBox comboBoxChooseGpuMonitor;
        private System.Windows.Forms.Label labelNoticeCpuMonitor;
        private System.Windows.Forms.Label labelNoticeGpuMonitor;
        private System.Windows.Forms.Button buttonUseChosenMonitor;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusAida64CpuMonitor;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusAida64GpuMonitor;
        private System.Windows.Forms.DomainUpDown domainUpDownSelectRefreshTime;
        private System.Windows.Forms.Button buttonConfirmRefreshTime;
        private System.Windows.Forms.Label labelNoticeRefreshTimeAdjustmentWindow;
        private NotifyIcon notifyIcon;
    }
}
