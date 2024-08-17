using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using Microsoft.Win32;
using LibreHardwareMonitor.Hardware;


namespace CPUwenduhuoqu
{
    public partial class MainForm : Form
    {
        private SerialPort serialPort;
        private int timerCounter = 0;
        private float? cpuTemperature = null;
        private float? gpuTemperature = null;
        private System.Windows.Forms.Timer updateTimer;
        private bool useAida64Mode = false;
        private List<Tuple<string, string>> cpuLabels = new List<Tuple<string, string>>();
        private List<Tuple<string, string>> gpuLabels = new List<Tuple<string, string>>();
        private Tuple<string, string> chosenCpuAndGpuSensorName = null;

        public MainForm()
        {
            InitializeComponent();
        }

        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer) => computer.Traverse(this);

            public void VisitHardware(IHardware hardware)
            {
                try
                {
                    if (hardware != null)
                    {
                        hardware.Update();
                        foreach (IHardware subHardware in hardware.SubHardware)
                        {
                            subHardware.Accept(this);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hardware is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred when visiting hardware:\n {ex.Message}\nNotice Refresh Time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }

        private void MonitorUseLibreHardwareMonitor()
        {
            try
            {
                Computer computer = new Computer
                {
                    IsCpuEnabled = true,
                    IsGpuEnabled = true
                };

                computer.Open();
                computer.Accept(new UpdateVisitor());

                foreach (IHardware hardware in computer.Hardware)
                {
                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            if (hardware.HardwareType == HardwareType.Cpu)
                            {
                                cpuTemperature = sensor.Value.HasValue ? (float?)Math.Round(sensor.Value.Value, 1) : (float?)null;
                                cpuTempLabel.Invoke(new Action(() => cpuTempLabel.Text = $"CPU Temp: {cpuTemperature} °C"));
                            }
                            else if (hardware.HardwareType == HardwareType.GpuAmd || hardware.HardwareType == HardwareType.GpuNvidia)
                            {
                                gpuTemperature = sensor.Value.HasValue ? (float?)Math.Round(sensor.Value.Value, 1) : (float?)null;
                                gpuTempLabel.Invoke(new Action(() => gpuTempLabel.Text = $"GPU Temp: {gpuTemperature} °C"));
                            }
                        }
                    }
                }

                computer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Monitor:\n {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MonitorUseAida64()
        {
            if (chosenCpuAndGpuSensorName != null)
            {   
                string registryPath = @"Software\FinalWire\AIDA64\SensorValues";
                string chosenCpuValueName = chosenCpuAndGpuSensorName.Item1.Replace("Label", "Value");
                string chosenGpuValueName = chosenCpuAndGpuSensorName.Item2.Replace("Label", "Value");
                
                //获取两个温度的值
                try
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath);

                    // 检查 key 是否为 null
                    if (key == null)
                    {
                        throw new Exception("The specified registry subkey does not exist.\n" +
                            "Please check your AIDA64 configuration.");
                    }

                    string cpuTemperatureString = key.GetValue(chosenCpuValueName)?.ToString();
                    string gpuTemperatureString = key.GetValue(chosenGpuValueName)?.ToString();

                    if (cpuTemperatureString != null && gpuTemperatureString != null)
                    {
                        // 尝试将字符串转换为浮点数
                        cpuTemperature = float.Parse(cpuTemperatureString);
                        gpuTemperature = float.Parse(gpuTemperatureString);

                        // 更新 UI
                        cpuTempLabel.Invoke(new Action(() => cpuTempLabel.Text = $"CPU Temp: {cpuTemperature} °C"));
                        gpuTempLabel.Invoke(new Action(() => gpuTempLabel.Text = $"GPU Temp: {gpuTemperature} °C"));
                        notifyIcon.Text = $"CPU Temp: {cpuTemperature} °C\nGPU Temp: {gpuTemperature} °C";
                    }
                    else
                    {
                        throw new Exception("Cannot get the temperature value from the registry.\n" +
                            "Please check your AIDA64 configuration.");
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the error
                    MessageBox.Show($"Error in Monitor:\n {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Invoke(new Action(() =>
                    {
                        checkBoxUseAida64Mode.Checked = false;
                    }));
                }
            }
        }

        private void SendDataToSerialPort(string data)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error
                Console.WriteLine($"Error sending data to serial port: {ex.Message}");
                // Optionally, try to reconnect or notify the user
            }
        }

        private void InitializeOrUpdateTimer(int interval)
        {
            if (updateTimer != null)
            {
                updateTimer.Stop();
                updateTimer.Dispose();
            }

            updateTimer = new System.Windows.Forms.Timer
            {
                Interval = interval // 设置定时器间隔
            };
            updateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            updateTimer.Start();

            // 将当前的刷新时间显示在 domainUpDown 中
            int refreshTimeInSeconds = interval / 1000;
            this.domainUpDownSelectRefreshTime.SelectedItem = refreshTimeInSeconds.ToString();
        }

        private void InitializeDomainUpDown()
        {
            string[] refreshTimeOptions = Enumerable.Range(3, 28).Select(i => i.ToString()).ToArray();
            Array.Reverse(refreshTimeOptions);
            this.domainUpDownSelectRefreshTime.Items.AddRange(refreshTimeOptions);
            int currentIntervalInSeconds = this.updateTimer.Interval / 1000;
            int index = Array.IndexOf(refreshTimeOptions, currentIntervalInSeconds.ToString());
            if (index >= 0)
                this.domainUpDownSelectRefreshTime.SelectedIndex = index;
            else
                this.domainUpDownSelectRefreshTime.SelectedIndex = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeOrUpdateTimer(5000);
            LoadSettings();
            RefreshSerialPorts();
            InitializeDomainUpDown();
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
            {
                new MenuItem("Exit Program", OnExit)
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void MainForm_FormMinimized(object sender, FormClosedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {   
            if (useAida64Mode)
            {
                Task.Run(() => MonitorUseAida64());
            }
            else
            {
                Task.Run(() => MonitorUseLibreHardwareMonitor());
            }

            Task.Run(() =>
            {
                if (timerCounter % 2 == 0)
                {
                    // Send CPU temperature
                    if (cpuTemperature.HasValue)
                    {
                        SendDataToSerialPort($"CPU{cpuTemperature.Value.ToString("F1")}");
                    }
                }
                else
                {
                    // Send GPU temperature
                    if (gpuTemperature.HasValue)
                    {
                        SendDataToSerialPort($"GPU{gpuTemperature.Value.ToString("F1")}");
                    }
                }

                timerCounter++;
            });
        }

        private void RefreshSerialPorts()
        {
            comboBoxSerialPorts.Items.Clear();
            comboBoxSerialPorts.Items.AddRange(SerialPort.GetPortNames());
        }

        private bool LoadSettings()
        {
            bool settingsLoadedSuccessfully = true;

            string refreshIntervalValue = ConfigurationManager.AppSettings["RefreshInterval"];
            if (int.TryParse(refreshIntervalValue, out int refreshInterval))
            {
                this.updateTimer.Interval = refreshInterval;
                this.domainUpDownSelectRefreshTime.SelectedItem = (refreshInterval / 1000).ToString();
            }
            
            else
                settingsLoadedSuccessfully = false;

            string selectedSensor = ConfigurationManager.AppSettings["SelectedSensor"];
            if (!string.IsNullOrEmpty(selectedSensor))
            {
                var sensorParts = selectedSensor.Split(',');
                if (sensorParts.Length == 2)
                {
                    this.chosenCpuAndGpuSensorName = new Tuple<string, string>(sensorParts[0], sensorParts[1]);
                    toolStripStatusAida64Monitor();
                }
                else
                    settingsLoadedSuccessfully = false;
            }
            else
                settingsLoadedSuccessfully = false;

            string useAida64Mode = ConfigurationManager.AppSettings["useAida64Mode"];
            if (!string.IsNullOrEmpty(useAida64Mode))
            {
                checkBoxUseAida64Mode.Checked = bool.Parse(useAida64Mode);
            }
            else
                settingsLoadedSuccessfully = false;
            return settingsLoadedSuccessfully;
        }


        private void SaveSettings()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["RefreshInterval"].Value = this.updateTimer.Interval.ToString();

            if (this.chosenCpuAndGpuSensorName != null)
            {
                config.AppSettings.Settings["SelectedSensor"].Value = $"{this.chosenCpuAndGpuSensorName.Item1},{this.chosenCpuAndGpuSensorName.Item2}";
            }

            if(checkBoxUseAida64Mode.Checked)
                config.AppSettings.Settings["useAida64Mode"].Value = "true";
            else
                config.AppSettings.Settings["useAida64Mode"].Value = "false";

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }

            if (comboBoxSerialPorts.SelectedItem != null)
            {
                serialPort = new SerialPort(comboBoxSerialPorts.SelectedItem.ToString())
                {
                    BaudRate = 115200
                };

                try
                {
                    serialPort.Open();
                    labelConnectionStatus.Text = "Connected";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    labelConnectionStatus.Text = "Disconnected";
                }
            }
        }

        private void checkBox_useAida64Mode(object sender, EventArgs e)
        {
            bool aida64ModeIsApplicable = false;
            if (checkBoxUseAida64Mode.Checked)
            {
                if (LoadSensorsIntoComboBox())
                    aida64ModeIsApplicable = true;
            }
            checkBoxUseAida64Mode.Checked = aida64ModeIsApplicable;
            if (aida64ModeIsApplicable)
            {
                useAida64Mode = true;
                comboBoxChooseCpuMonitor.Enabled = true;
                comboBoxChooseGpuMonitor.Enabled = true;
                labelNoticeCpuMonitor.ForeColor = Color.Black;
                labelNoticeGpuMonitor.ForeColor = Color.Black;
                buttonUseChosenMonitor.Enabled = true;
                toolStripStatusAida64CpuMonitor.ForeColor = Color.Black;
                toolStripStatusAida64GpuMonitor.ForeColor = Color.Black;
                toolStripStatusAida64Monitor();
            }
            else
            {
                useAida64Mode = false;
                comboBoxChooseCpuMonitor.Enabled = false;
                comboBoxChooseGpuMonitor.Enabled = false;
                buttonUseChosenMonitor.Enabled = false;
                labelNoticeCpuMonitor.ForeColor = Color.Gray;
                labelNoticeGpuMonitor.ForeColor = Color.Gray;
                labelNoticeCpuMonitor.Text = "Choose a CPU Monitor";
                labelNoticeGpuMonitor.Text = "Choose a GPU Monitor";
                toolStripStatusAida64CpuMonitor.ForeColor = Color.Gray;
                toolStripStatusAida64GpuMonitor.ForeColor = Color.Gray;
            }
        }
        private bool LoadSensorsIntoComboBox()
        {
            cpuLabels.Clear();
            gpuLabels.Clear();

            try
            {
                string registryPath = @"Software\FinalWire\AIDA64\SensorValues";
                RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath);

                if (key != null)
                {
                    foreach (string sensorName in key.GetValueNames())
                    {
                        if (sensorName.StartsWith("Label", StringComparison.OrdinalIgnoreCase))
                        {
                            string value = key.GetValue(sensorName).ToString();

                            if (sensorName.StartsWith("Label.TC", StringComparison.OrdinalIgnoreCase))
                            {
                                cpuLabels.Add(new Tuple<string, string>(sensorName, value));
                            }
                            else if (sensorName.StartsWith("Label.TG", StringComparison.OrdinalIgnoreCase))
                            {
                                gpuLabels.Add(new Tuple<string, string>(sensorName, value));
                            }
                        }
                    }
                }

                if (cpuLabels.Count == 0 && gpuLabels.Count == 0)
                {
                    throw new Exception("No sensors found in the registry.");
                }

                comboBoxChooseCpuMonitor.Items.Clear();
                comboBoxChooseGpuMonitor.Items.Clear();

                // 将 cpuLabels 和 gpuLabels 中每个元素的 Item2 的数据添加到相应的 ComboBox 中
                foreach (Tuple<string, string> cpuLabel in cpuLabels)
                    comboBoxChooseCpuMonitor.Items.Add(cpuLabel.Item2);
                foreach (Tuple<string, string> gpuLabel in gpuLabels)
                    comboBoxChooseGpuMonitor.Items.Add(gpuLabel.Item2);
            }
            catch (Exception ex)
            {
                // 错误处理
                MessageBox.Show($"An error occurred when loading sensors:\n {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void buttonUseChosenMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedCpuMonitor = comboBoxChooseCpuMonitor.SelectedItem?.ToString();
                string selectedGpuMonitor = comboBoxChooseGpuMonitor.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedCpuMonitor) || string.IsNullOrEmpty(selectedGpuMonitor))
                {
                    MessageBox.Show("Please select valid CPU and GPU monitors.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // 退出方法
                }

                chosenCpuAndGpuSensorName = new Tuple<string, string>(cpuLabels[comboBoxChooseCpuMonitor.SelectedIndex].Item1, gpuLabels[comboBoxChooseGpuMonitor.SelectedIndex].Item1);

                //MessageBox.Show("Monitors have been successfully chosen.\n" +
                //    "CPU Monitor: " + selectedCpuMonitor + '\n'+
                //    "GPU Monitor: " + selectedGpuMonitor, "Selection Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                toolStripStatusAida64Monitor();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripStatusAida64Monitor()
        {
            if (chosenCpuAndGpuSensorName != null)
            {
                var cpuLabel = cpuLabels.FirstOrDefault(label => label.Item1 == chosenCpuAndGpuSensorName.Item1);
                if (cpuLabel != null)
                    toolStripStatusAida64CpuMonitor.Text = "CPU Temp Monitor: " + cpuLabel.Item2;
                else
                    toolStripStatusAida64CpuMonitor.Text = "CPU Temp Monitor: Not Found";
                var gpuLabel = gpuLabels.FirstOrDefault(label => label.Item1 == chosenCpuAndGpuSensorName.Item2);
                if (gpuLabel != null)
                    toolStripStatusAida64GpuMonitor.Text = "GPU Temp Monitor: " + gpuLabel.Item2;
                else
                    toolStripStatusAida64GpuMonitor.Text = "GPU Temp Monitor: Not Found";
            }
            else
            {
                toolStripStatusAida64CpuMonitor.Text = "CPU Temp Monitor: Not Selected";
                toolStripStatusAida64GpuMonitor.Text = "GPU Temp Monitor: Not Selected";
            }
        }

        private void buttonConfirmRefreshTime_Click(object sender, EventArgs e)
        {
            int selectedRefreshTime = int.Parse(this.domainUpDownSelectRefreshTime.Text);

            if (selectedRefreshTime < 3 || selectedRefreshTime > 30)
            {
                MessageBox.Show("Please select a refresh time between 3 and 30 seconds.",
                    "Invalid Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Set {selectedRefreshTime} seconds as the refresh time.",
                    "Selection Confirmed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                InitializeOrUpdateTimer(selectedRefreshTime * 1000);
                RefreshSerialPorts();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon.Visible = true;
            }
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.notifyIcon.Visible = false;
        }


        private void OnExit(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }
    }
}
