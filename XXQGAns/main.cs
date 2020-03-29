using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;

namespace XXQGAns
{
    public partial class main : Form
    {
        #region 以下为数据库查找代码
        //以下为数据库查找代码
        MySqlConnection SQLCon;
        MySqlCommand SQLCmd;
        string ques = "null", ans = "null", op = "null";
        private void daanuptable_refresh() 
        {
            string nowid;
            string searchStr = "select max(id) from daanup";   //xxqgup表中最大
            SQLCmd = new MySqlCommand(searchStr, SQLCon);
            nowid = SQLCmd.ExecuteScalar().ToString();
            label7.Text = nowid;
        }
        private void daanup_refresh()
        {
            string searchStr = "select * from daan";   //xxqg表中数据
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchStr, SQLCon);
            DataTable a = new DataTable();
            adapter.Fill(a);
            this.dataGridView1.DataSource = a;
            dataGridView1.Columns[0].HeaderText = "题号";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "题目";
            dataGridView1.Columns[1].Width = 355;
            dataGridView1.Columns[2].HeaderText = "答案";
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor= System.Drawing.Color.Red;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].HeaderText = "选项";
            dataGridView1.Columns[3].Width = 350;
            dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            string nowid;
            string nowidStr = "select max(id) from daan";   //xxqgup表中最大
            SQLCmd = new MySqlCommand(nowidStr, SQLCon);
            nowid = SQLCmd.ExecuteScalar().ToString();
            daannum.Text = nowid;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (newques.Text != string.Empty && newans.Text != string.Empty && newop.Text != string.Empty)
            {
                ques = newques.Text;
                ans = newans.Text;
                op = newop.Text;
                
                //MySqlDataAdapter adapter = new MySqlDataAdapter(searchStr, SQLCon);
                try
                {
                    string insertStr = "insert into daanup(ques,ans,op) values('" + ques + "','" + ans + "','" + op + "')";
                    SQLCmd = new MySqlCommand(insertStr, SQLCon);
                    SQLCmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
                    daanuptable_refresh();
                    //button1_Click(sender,e);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
                }
            }
            else { 
                MessageBox.Show("问题/答案/选项均不能为空", "提示", MessageBoxButtons.OK); 
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            daanup_refresh();
        }
        
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出?", "提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.OK)   //如果单击“是”按钮
            {
                e.Cancel = false;                 //关闭窗体
                SQLCon.Close();
                System.Environment.Exit(0);
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;                  //不执行操作
            }
        }
        private void inputtext_KeyDown(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Enter)//判断回
            {
                //MessageBox.Show("123", "提示", MessageBoxButtons.OK);
                this.search_Click(sender, e);//触发按钮事件
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            string str = "";
            if (inputtext.Text != "")
            {
                str = "where ques like '%" + inputtext.Text+ "%'";
                //daannum.Text = str;
            }
                
            try
            {
                string searchStr = ("select * from daan " + str);
                MySqlDataAdapter adapter = new MySqlDataAdapter(searchStr, SQLCon);
                DataTable a = new DataTable();
                adapter.Fill(a);
                this.dataGridView1.DataSource = a;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
        #endregion

        public main()//主函数
        {
            InitializeComponent();
            inputtext.AutoSize = false;
            inputtext.Height = 50;
            ocrout.AutoSize = false;
            ocrout.Height = 50;
            newques.AutoSize = false;
            newques.Height = 50;
            newop.AutoSize = false;
            newop.Height = 50;
            newans.AutoSize = false;
            newans.Height = 50;
            string connetStr = "server=IP;user=xxqg;password=passwd;database=xxqg;sslMode=none;";
            SQLCon = new MySqlConnection(connetStr);
            try
            {
                SQLCon.Open(); //连接数据库
                state.Text = "已连接";
                state.ForeColor = Color.FromArgb(0, 255, 0);
                daanup_refresh();
                daanuptable_refresh();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);     //显示错误信息
            }
            this.inputtext.KeyDown += new KeyEventHandler(inputtext_KeyDown);
            //添加dll引用失败处理
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            releaseRes();
            //初始化OCR
            this.ocrTools = new OcrTools();

        }
        #region 以下为投屏代码
        //以下为投屏代码
        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int LWA_ALPHA = 0;

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(
        IntPtr hwnd,
        int nIndex,
        uint dwNewLong
        );

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(
        IntPtr hwnd,
        int nIndex
        );

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(
        IntPtr hwnd,
        int crKey,
        int bAlpha,
        int dwFlags
        );

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private readonly Process stdoutProcess = new Process();
        private readonly Process stdinProcess = new Process();
        private StreamPipe RePipe;
        private CastType castType = CastType.Internal;
        private bool isCastingValue = false;

        private bool isCasting
        {
            get => isCastingValue;
            set
            {
                isCastingValue = value;
                stopCastButton.Enabled = value; 
            }
        }

        private enum CastType
        {
            Internal,
            Single
        }

        private readonly DeviceInfoData deviceInfoData = new DeviceInfoData(); // device info form adb
        private readonly DeviceInfoData instartDeviceInfoData = new DeviceInfoData(); // device info at start cast

        private double castMbitRate = 30; // 16M适中

        public static NamedPipeClientStream client;
        private void startCastSingleButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("关于独立窗口模式\n\n尝试解决部分手机无法投屏或者分辨率出错问题，因为弹出外部播放器窗口相比内建可控性更差，画面旋转及分辨率自适应已被禁用。\n\n投屏窗口可随意拖动，双击最大化。" , "提示");
            castType = CastType.Single;
            //ShowConfigDialog();
            StartCastAction();
            startCastSingleButton.Enabled = false;
            startCastButton.Enabled = false;
        }
        private void startCastButton_Click(object sender, EventArgs e)
        {
            castType = CastType.Internal;
            castMbitRate = 30;
            //ShowConfigDialog();
            StartCastAction();
            startCastSingleButton.Enabled = false;
        }
        private void ShowConfigDialog()
        {
            string inputText = string.Empty;
            try
            {
                inputText = Interaction.InputBox("请输入投屏码率（Mbps）：\r\n\r\n<10：适合互联网传输\r\n<30：适合一般手机通过USB传输\r\n<100：适合编码能力强的手机通过家庭局域网（百兆）内传输\r\n<=200：适合编码能力超强的手机通过USB传输\r\n\r\n建议值：30", "准备投屏", $"{castMbitRate}", -1, -1);
                castMbitRate = double.Parse(inputText);
                if (castMbitRate <= 0 || castMbitRate > 200)
                {
                    MessageBox.Show("码率（Mbps）必须大于0且不超过200", "警告");
                }
                else
                {
                    StartCastAction();
                }
            }
            catch
            {
                if (inputText.Length > 0)
                {
                    MessageBox.Show("请输入正确的码率（Mbps）", "警告");
                }
            }
        }
        private void StartCastAction()
        {
            StopCast();
            if (UpdateScreenDeviceInfo())
            {
                StartCast();
            }
            else
            {
                MessageBox.Show("找不到任何设备或模拟器", "警告");
            }
        }

        private void StartCast()
        {
            StdOut();
            StdIn();
            RePipe = new StreamPipe(stdoutProcess.StandardOutput.BaseStream, stdinProcess.StandardInput.BaseStream);
            RePipe.Connect();
            instartDeviceInfoData.deviceVmode = deviceInfoData.deviceVmode; // 记录播放时的横竖屏状态（是否竖屏）
            isCasting = true;
            heartTimer.Enabled = true;
            //startCastButton.Enabled = false;
            startCastSingleButton.Enabled = false;
            startCastButton.Enabled = false;
            if (castType == CastType.Single) 
                nosigalLabel.Text = "投屏中 (｀・ω・´)";
        }

        private void StopCast() //结束投屏
        {
            try
            {
                try
                {
                    stdoutProcess.Exited -= StdIOProcess_Exited;
                    // stdoutProcess.OutputDataReceived -= new DataReceivedEventHandler(StdOutProcessOutDataReceived);
                    stdoutProcess.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("无法关闭StdOUT，" + ex.Message);
                }
                try
                {
                    stdinProcess.Exited -= StdIOProcess_Exited;
                    // stdinProcess.OutputDataReceived -= new DataReceivedEventHandler(StdInProcessOutDataReceived);
                    stdinProcess.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("无法关闭StdIN，" + ex.Message);
                }
                RePipe.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("无法断开管道重定向，" + ex.Message);
            }
            heartTimer.Enabled = false;
            isCasting = false;
            nosigalLabel.Text = "无信号\nNo signal";
            startCastButton.Enabled = true;
            startCastSingleButton.Enabled = true;
        }

        public void SetPenetrate(IntPtr useHandle, bool flag = true)
        {
            uint style = GetWindowLong(useHandle, GWL_EXSTYLE);
            if (flag)
            {
                SetWindowLong(useHandle, GWL_EXSTYLE, style | WS_EX_TRANSPARENT | WS_EX_LAYERED);
            }
            else
            {
                SetWindowLong(useHandle, GWL_EXSTYLE, style & ~(WS_EX_TRANSPARENT | WS_EX_LAYERED));
            }

            SetLayeredWindowAttributes(useHandle, 0, 100, LWA_ALPHA);
        }

        private void StdOut()
        {
            //stdoutProcess.OutputDataReceived -= new DataReceivedEventHandler(StdOutProcessOutDataReceived);
            // https://developer.android.com/studio/releases/platform-tools.html
            stdoutProcess.StartInfo.FileName = System.AppDomain.CurrentDomain.BaseDirectory + @"lib\adb\adb.exe";
            stdoutProcess.StartInfo.Arguments = $"exec-out \"while true;do screenrecord --bit-rate={(int)(castMbitRate * 1000000)} --output-format=h264 --size {deviceInfoData.deviceWidth.ToString()}x{deviceInfoData.deviceHeight.ToString()} - ;done\""; // 
            stdoutProcess.StartInfo.UseShellExecute = false;
            stdoutProcess.StartInfo.RedirectStandardOutput = true;
            stdoutProcess.StartInfo.CreateNoWindow = true;
            stdoutProcess.EnableRaisingEvents = true;
            stdoutProcess.Exited += StdIOProcess_Exited;
            stdoutProcess.Start();
            if (stdinProcess.StartInfo.FileName.Length != 0)
            {
                stdinProcess.CancelOutputRead();
                stdinProcess.Close();
            }
            //stdoutProcess.OutputDataReceived += new DataReceivedEventHandler(StdOutProcessOutDataReceived);
        }

        private void StdOutProcessOutDataReceived(object sender, DataReceivedEventArgs e)
        {

        }

        private void ADBSentKey(string keycode)
        {
            new Thread(delegate ()
            {
                Process process = new Process();
                process.StartInfo.FileName = System.AppDomain.CurrentDomain.BaseDirectory + @"lib\adb\adb.exe";
                process.StartInfo.Arguments = "shell input keyevent " + keycode;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                process.Start();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
            }).Start();
        }

        private string ADBResult(string args)
        {
            Process process = new Process();
            process.StartInfo.FileName = System.AppDomain.CurrentDomain.BaseDirectory + @"lib\adb\adb.exe";
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            process.Start();
            //while (!process.StandardOutput.EndOfStream)
            //{
            //    Console.WriteLine(process.StandardOutput.ReadLine());
            //}
            //process.WaitForExit();
            string result = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadLine();
            process.Close();
            return error + result;
        }

        private void StdIn()
        {
            string widArg;
            switch (castType)
            {
                case CastType.Internal:
                    widArg = $"--wid={screenBox.Handle.ToInt64().ToString()}";
                    break;
                case CastType.Single:
                    widArg = default;
                    break;
                default:
                    widArg = default;
                    break;
            }
            string release_args = "--input-default-bindings=no --osd-level=0";
#if DEBUG
            release_args = default;
#endif
            string mpv_full_args = $"--title=\"Mirror Caster Source\" --no-taskbar-progress --hwdec=auto --opengl-glfinish=yes --opengl-swapinterval=0 --d3d11-sync-interval=0 --fps={deviceInfoData.deviceRefreshRate} --no-audio --framedrop=decoder --no-correct-pts --speed=1.01 --profile=low-latency --no-config --no-border {release_args} -no-osc {widArg} -";
            Console.WriteLine("MPV ARGS:\r\n" + mpv_full_args);
            stdinProcess.StartInfo.FileName = System.AppDomain.CurrentDomain.BaseDirectory + @"lib\mpv\mpv.exe";
            stdinProcess.StartInfo.Arguments = mpv_full_args;
            //stdinProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            stdinProcess.StartInfo.UseShellExecute = false;
            stdinProcess.StartInfo.RedirectStandardOutput = true;
            stdinProcess.StartInfo.RedirectStandardInput = true;
            stdinProcess.StartInfo.CreateNoWindow = true;
            stdinProcess.EnableRaisingEvents = true;
            stdinProcess.Exited += StdIOProcess_Exited;
            stdinProcess.Start();
            stdinProcess.BeginOutputReadLine();
            //stdinProcess.OutputDataReceived += new DataReceivedEventHandler(StdInProcessOutDataReceived);
        }

        private void StdIOProcess_Exited(object sender, EventArgs e)
        {
            Console.WriteLine("StdIO管道被关闭，关闭投屏");
            Invoke(new Action(StopCast)); // 结束投屏需要修改UI，所以Invoke
        }

        private void StdInProcessOutDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    SetParent(stdinProcess.MainWindowHandle, screenBox.Handle);
                    SetPenetrate(stdinProcess.MainWindowHandle, true);
                    SetParent(stdinProcess.MainWindowHandle, Handle);
                    // window, x, y, width, height, repaint
                    MoveWindow(stdinProcess.MainWindowHandle, screenBox.Location.X, screenBox.Location.Y, screenBox.Width, screenBox.Height, false);
                }));
            }
            catch { }
        }
       
        private void main_Resize(object sender, EventArgs e)
        {
            //MoveWindow(stdinProcess.MainWindowHandle, screenBox.Location.X, screenBox.Location.Y, screenBox.Width, screenBox.Height, false);
        }

        private void stopCastButton_Click(object sender, EventArgs e)
        {
            StopCast();
        }

     

        private bool UpdateScreenDeviceInfo()
        {
            string str = ADBResult("shell \"dumpsys window displays && dumpsys SurfaceFlinger\"").ToLower();
            if (str.StartsWith("error: no devices/emulators found") || str.StartsWith("error: more than one device/emulator"))
            {
                return false; //MessageBox.Show("找不到任何设备或模拟器", "警告");
            }
            // Console.WriteLine(str);
            Regex regexSize = new Regex(@"\s+cur=(?<width>[0-9]*)x(?<height>[0-9]*?)\s+", RegexOptions.Multiline);
            Match matchSize = regexSize.Match(str);
            Regex regexRefreshRate = new Regex(@"\s+refresh-rate.+?(?<refreshRate>[0-9]*\.{0,1}[0-9]*?)\s*fps\s+", RegexOptions.Multiline);
            Match matchRefreshRate = regexRefreshRate.Match(str);
            if (matchSize.Success)
            {
                Console.WriteLine("Size成功");
                try
                {
                    int width = int.Parse(matchSize.Groups["width"].Value); //宽
                    int height = int.Parse(matchSize.Groups["height"].Value); //高
                    bool vmode = true; //垂直
                    if (width > height)
                    {
                        vmode = false; //水平
                    }

                    string strFormat = string.Format("{0}*{1},是否垂直:{2}", width, height, vmode.ToString());
                    Console.WriteLine(strFormat);
                    deviceInfoData.deviceWidth = width;
                    deviceInfoData.deviceHeight = height;
                    deviceInfoData.deviceVmode = vmode;
                }
                catch { }
            }
            if (matchRefreshRate.Success)
            {
                try
                {
                    Console.WriteLine("RefreshRate成功");
                    double refreshRate = double.Parse(matchRefreshRate.Groups["refreshRate"].Value);
                    string strFormat = string.Format("刷新率:{0}", refreshRate);
                    Console.WriteLine(strFormat);
                    deviceInfoData.deviceRefreshRate = refreshRate;
                }
                catch { }
            }
            return true;
        }

        private void HeartTimer_Tick(object sender, EventArgs e)
        {
            if (UpdateScreenDeviceInfo())
            {
                if (instartDeviceInfoData.deviceVmode != deviceInfoData.deviceVmode)
                {
                    if (castType == CastType.Internal) StartCastAction(); // 如果设备info切换则重新连接（为了转换分辨率）
                }
            }
            else
            {
                heartTimer.Enabled = false;
                MessageBox.Show("设备已断开连接", "警告");
                StopCast();
            }
        }
        #endregion
        #region 以下为OCR代码
        //以下为ocr代码
        private void ocrbtn_Click(object sender, EventArgs e)
        {
            ScreenCapture();
            toClipboard = true;//复制结果到剪贴板
        }
        OcrTools ocrTools;

        //Resources.resx文件中dll引用路径处理
        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }
        string thisfile = System.AppDomain.CurrentDomain.BaseDirectory + "Snapshot.dll";
        private void releaseRes() //释放截图dll
        {
            
            //ocrout.Text = thisfile;
            if (System.IO.File.Exists("Snapshot.dll"))
            {
                //存在文件，啥都不干
            }
            else
            {
                try
                {
                    //释放资源文件中的Dll以供调用
                    FileStream snapdll = new FileStream("Snapshot.dll", System.IO.FileMode.Create);
                    snapdll.Write(Properties.Resources.Snapshot, 0, Properties.Resources.Snapshot.Length);
                    snapdll.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("请检查当前程序目录是否包含Snapshot.dll\n" + e.ToString());
                }
            }
        }

        bool appendMode = false;        //追加模式
        bool toClipboard = true;        //输出至剪切板

        public class DLL
        {
            [DllImport("Snapshot.dll", EntryPoint = "PrScrn")]
            public static extern int PrScrn(); //截图方法
        }

        private void message(string mess, Color color)
        {
            this.label14.Text = mess;
            this.label14.ForeColor = color;
        }

        private void CopyClipboard()
        {
            if (toClipboard)
            {
                Clipboard.SetText(this.ocrout.Text);
            }
        }

        private void ScreenCapture()
        {
            if (!appendMode)
            {
                this.ocrout.Text = "";
            }
            if (DLL.PrScrn() == 1)
            {
                if (Clipboard.ContainsImage())
                {
                    message("处理截图中...", Color.Green);
                    Image SnapImg = Clipboard.GetImage();
                    MemoryStream ImgStream = new MemoryStream(0);
                    if (SnapImg != null)
                    {
                        try
                        {
                            SnapImg.Save(ImgStream, ImageFormat.Jpeg);
                            List<string> tempResult = ocrTools.accurateBasic(ImgStream);
                            foreach (string line in tempResult)
                            {
                                this.ocrout.AppendText(line + Environment.NewLine);
                            }
                            message("识别完成！", Color.Green);
                            CopyClipboard();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("处理截图文件流失败！" + err.ToString());
                        }

                    }
                    else
                    {
                        message("错误，无法获取截图", Color.Red);
                    }
                    ImgStream.Close();
                }
                else
                {
                    message("错误，无法捕获截图", Color.Red);
                }
            }
            else
            {
                message("用户取消截图", Color.Red);
            }
        }


        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            //处理拖动文件
            Array aryFiles = ((System.Array)e.Data.GetData(DataFormats.FileDrop));
            if (!appendMode)
            {
                this.ocrout.Text = "";
            }
            bool singleFileFlag = false;
            if (aryFiles.Length == 1)
            {
                singleFileFlag = true;
            }
            for (int i = 0; i < aryFiles.Length; i++)
            {
                List<string> tempResult;
                string curFilePath = aryFiles.GetValue(i).ToString();
                string curFileName = Path.GetFileName(curFilePath);
                string extension = Path.GetExtension(curFilePath).ToLower();
                //message("正在处理 " + curFileName+ '\t' + (i + 1).ToString() + '/' + aryFiles.Length.ToString(), Color.Green);
                if (extension == ".jpg" || extension == ".png" || extension == ".bmp")
                {
                    try
                    {
                        tempResult = this.ocrTools.accurateBasic(curFilePath);
                        if (!singleFileFlag)
                        {
                            this.ocrout.AppendText("[" + (i + 1).ToString() + "] " + curFileName + "：");
                            this.ocrout.AppendText(Environment.NewLine + Environment.NewLine);
                        }
                        foreach (string line in tempResult)
                        {
                            this.ocrout.AppendText(line + Environment.NewLine);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("处理图片失败\n" + err.ToString());
                    }
                }
                else
                {
                    this.ocrout.AppendText("[" + (i + 1).ToString() + "] " + curFileName + "：" + "格式不支持！" + Environment.NewLine);
                }
                this.ocrout.AppendText(Environment.NewLine + Environment.NewLine);

            }
            message("转换完成", Color.Green);
            CopyClipboard();
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;                 //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }


        public void OnHotkey(int HotkeyID) //设置热键的行为
        {
            if (HotkeyID == Hotkey.Hotkey1)
            {
                ScreenCapture();
            }

        }

        Hotkey hotkey;

        private void label10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://qg.zyqq.top/");
        }



        #endregion

        #region 加载事件
        private void main_FormClosed(object sender, FormClosedEventArgs e) //关闭窗口事件
        {
            //反注册热键
            hotkey.UnregisterHotkeys();
            StopCast();
        }
        private void main_Load(object sender, EventArgs e) //窗口加载事件
        {

            //this.comboBox1.SelectedIndex = 0;
            stopCastButton.Enabled = false;
            hotkey = new Hotkey(this.Handle);
            try
            {
                Hotkey.Hotkey1 = hotkey.RegisterHotkey(Keys.A, Hotkey.KeyFlags.MOD_ALT); //定义快键(Alt + A)
                hotkey.OnHotkey += new HotkeyEventHandler(OnHotkey);
            }
            catch (Exception)
            {
                MessageBox.Show("绑定全局热键失败：Alt + A 热键被占用");
            }
        }

        #endregion

    }
}
