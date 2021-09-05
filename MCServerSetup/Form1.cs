using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MCServerSetup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += (s, e) =>
            {
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            ServerPath.Text = folder.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG files(*.png)|*png";
            openFileDialog.Title = "Choose an icon for server";
            openFileDialog.Multiselect = false;
            openFileDialog.ShowDialog();
            iconPath.Text = openFileDialog.FileName;
        }
        static string settings = @"
enable-jmx-monitoring=false
rcon.port=25575
gamemode=
enable-command-block=
enable-query=false
level-name=world
motd= 
query.port=25565
pvp=
difficulty=
network-compression-threshold=256
require-resource-pack=false
max-tick-time=60000
use-native-transport=true
max-players=
online-mode=
enable-status=true
allow-flight=false
broadcast-rcon-to-ops=true
view-distance=10
server-ip=
resource-pack-prompt=
allow-nether=true
server-port=
enable-rcon=false
sync-chunk-writes=true
op-permission-level=4
prevent-proxy-connections=false
resource-pack=
entity-broadcast-range-percentage=100
rcon.password=
player-idle-timeout=0
debug=false
force-gamemode=false
rate-limit=0
hardcore=
white-list=false
broadcast-console-to-ops=true
spawn-npcs=true
spawn-animals=true
snooper-enabled=true
function-permission-level=2
text-filtering-config=
spawn-monsters=true
enforce-whitelist=false
resource-pack-sha1=
spawn-protection=16
max-world-size=29999984
";
        static string _settings = _settings;
        private void button4_Click(object sender, EventArgs e)
        {
  

            Directory.CreateDirectory($"{ServerPath.Text}\\{ServerName.Text}");
            string version = comboBox1.SelectedItem.ToString().Replace(" (Forge only)", "");
            File.Create($"{ServerPath.Text}\\{ServerName.Text}\\eula.txt").Close();
            File.WriteAllText($"{ServerPath.Text}\\{ServerName.Text}\\eula.txt", "eula=true");

            if (iconPath.Text.Replace(" ", "") != "")
                File.Copy(iconPath.Text, $"{ServerPath.Text}\\{ServerName.Text}\\server-icon.png", true);

            string download = "";

            switch (core.SelectedItem)
            {
                case "Spigot":
                    switch (version)
                    {

                        case "1.17.1":
                            download = SpigotLinks.one_seventeen_one;
                            break;

                        case "1.17":
                            download = SpigotLinks.one_seventeen;
                            break;

                        case "1.16.5":
                            download = SpigotLinks.one_sixteen_five;
                            break;

                        case "1.16.4":
                            download = SpigotLinks.one_sixteen_four;
                            break;

                        case "1.16.3":
                            download = SpigotLinks.one_sixteen_three;
                            break;

                        case "1.16.2":
                            download = SpigotLinks.one_sixteen_two;
                            break;

                        case "1.16.1":
                            download = SpigotLinks.one_sixteen_one;
                            break;

                        case "1.15.2":
                            download = SpigotLinks.one_fifteen_two;
                            break;

                        case "1.15.1":
                            download = SpigotLinks.one_fifteen_one;
                            break;

                        case "1.15":
                            download = SpigotLinks.one_fifteen;
                            break;

                        case "1.14.4":
                            download = SpigotLinks.one_fourteen_four;
                            break;

                        case "1.14.3":
                            download = SpigotLinks.one_fourteen_three;
                            break;

                        case "1.14.2":
                            download = SpigotLinks.one_fourteen_two;
                            break;

                        case "1.14.1":
                            download = SpigotLinks.one_fourteen_one;
                            break;

                        case "1.14":
                            download = SpigotLinks.one_fourteen;
                            break;

                        case "1.13.2":
                            download = SpigotLinks.one_thirteen_two;
                            break;

                        case "1.13.1":
                            download = SpigotLinks.one_thirteen_one;
                            break;

                        case "1.13":
                            download = SpigotLinks.one_thirteen;
                            break;

                        case "1.12.2":
                            download = SpigotLinks.one_twelve_two;
                            break;

                        case "1.12.1":
                            download = SpigotLinks.one_twelve_one;
                            break;

                        case "1.12":
                            download = SpigotLinks.one_twelve;
                            break;

                        case "1.11.2":
                            download = SpigotLinks.one_eleven_two;
                            break;

                        case "1.11.1":
                            download = SpigotLinks.one_eleven_one;
                            break;

                        case "1.11":
                            download = SpigotLinks.one_eleven;
                            break;

                        case "1.10.2":
                            download = SpigotLinks.one_ten_two;
                            break;

                        case "1.10":
                            download = SpigotLinks.one_ten;
                            break;

                        case "1.9.4":
                            download = SpigotLinks.one_nine_four;
                            break;

                        case "1.9.2":
                            download = SpigotLinks.one_nine_two;
                            break;

                        case "1.9":
                            download = SpigotLinks.one_nine;
                            break;

                        case "1.8.8":
                            download = SpigotLinks.one_eight_eight;
                            break;

                        case "1.8.7":
                            download = SpigotLinks.one_eight_seven;
                            break;

                        case "1.8.6":
                            download = SpigotLinks.one_eight_six;
                            break;

                        case "1.8.5":
                            download = SpigotLinks.one_eight_five;
                            break;

                        case "1.8.4":
                            download = SpigotLinks.one_eight_four;
                            break;

                        case "1.8.3":
                            download = SpigotLinks.one_eight_three;
                            break;

                        case "1.8":
                            download = SpigotLinks.one_eight;
                            break;

                        case "1.7.10":
                            download = SpigotLinks.one_seven_ten;
                            break;

                    }//определяет какую версию скачивать
                    break;
                case "Vanilla":
                    switch (version)
                    {
                        case "1.18_experimental-snapshot-5":
                            download = VanillaLinks.one_eighteen_exp5;
                            break;

                        case "1.18_experimental-snapshot-4":
                            download = VanillaLinks.one_eighteen_exp4;
                            break;

                        case "1.18_experimental-snapshot-3":
                            download = VanillaLinks.one_eighteen_exp3;
                            break;

                        case "1.18_experimental-snapshot-2":
                            download = VanillaLinks.one_eighteen_exp2;
                            break;

                        case "1.18_experimental-snapshot-1":
                            download = VanillaLinks.one_eighteen_exp1;
                            break;


                        case "1.17.1":
                            download = VanillaLinks.one_seventeen_one;
                            break;

                        case "1.17":
                            download = VanillaLinks.one_seventeen;
                            break;

                        case "1.16.5":
                            download = VanillaLinks.one_sixteen_five;
                            break;

                        case "1.16.4":
                            download = VanillaLinks.one_sixteen_four;
                            break;

                        case "1.16.3":
                            download = VanillaLinks.one_sixteen_three;
                            break;

                        case "1.16.2":
                            download = VanillaLinks.one_sixteen_two;
                            break;

                        case "1.16.1":
                            download = VanillaLinks.one_sixteen_one;
                            break;

                        case "1.15.2":
                            download = VanillaLinks.one_fifteen_two;
                            break;

                        case "1.15.1":
                            download = VanillaLinks.one_fifteen_one;
                            break;

                        case "1.15":
                            download = VanillaLinks.one_fifteen;
                            break;

                        case "1.14.4":
                            download = VanillaLinks.one_fourteen_four;
                            break;

                        case "1.14.3":
                            download = VanillaLinks.one_fourteen_three;
                            break;

                        case "1.14.2":
                            download = VanillaLinks.one_fourteen_two;
                            break;

                        case "1.14.1":
                            download = VanillaLinks.one_fourteen_one;
                            break;

                        case "1.14":
                            download = VanillaLinks.one_fourteen;
                            break;

                        case "1.13.2":
                            download = VanillaLinks.one_thirteen_two;
                            break;

                        case "1.13.1":
                            download = VanillaLinks.one_thirteen_one;
                            break;

                        case "1.13":
                            download = VanillaLinks.one_thirteen;
                            break;

                        case "1.12.2":
                            download = VanillaLinks.one_twelve_two;
                            break;

                        case "1.12.1":
                            download = VanillaLinks.one_twelve_one;
                            break;

                        case "1.12":
                            download = VanillaLinks.one_twelve;
                            break;

                        case "1.11.2":
                            download = VanillaLinks.one_eleven_two;
                            break;

                        case "1.11.1":
                            download = VanillaLinks.one_eleven_one;
                            break;

                        case "1.11":
                            download = VanillaLinks.one_eleven;
                            break;

                        case "1.10.2":
                            download = VanillaLinks.one_ten_two;
                            break;

                        case "1.10":
                            download = VanillaLinks.one_ten;
                            break;

                        case "1.9.4":
                            download = VanillaLinks.one_nine_four;
                            break;

                        case "1.9.2":
                            download = VanillaLinks.one_nine_two;
                            break;

                        case "1.9":
                            download = VanillaLinks.one_nine;
                            break;

                        case "1.8.8":
                            download = VanillaLinks.one_eight_eight;
                            break;

                        case "1.8.7":
                            download = VanillaLinks.one_eight_seven;
                            break;

                        case "1.8.6":
                            download = VanillaLinks.one_eight_six;
                            break;

                        case "1.8.5":
                            download = VanillaLinks.one_eight_five;
                            break;

                        case "1.8.4":
                            download = VanillaLinks.one_eight_four;
                            break;

                        case "1.8.3":
                            download = VanillaLinks.one_eight_three;
                            break;

                        case "1.8":
                            download = VanillaLinks.one_eight;
                            break;

                        case "1.7.10":
                            download = VanillaLinks.one_seven_ten;
                            break;

                    }
                    break;

            }

            _settings = settings;
            _settings = _settings.Replace("gamemode=", "gamemode="+comboBox2.SelectedItem.ToString().ToLower());
            _settings = _settings.Replace("motd=", $"motd={textBox8.Text}");
            _settings = _settings.Replace("difficulty=", $"difficulty={textBox8.Text.ToLower()}");
            _settings = _settings.Replace("pvp=","pvp="+comboBox7.Text.ToLower());
            _settings = _settings.Replace("enable-command-block=", "enable-command-block=" + comboBox3.Text.ToLower());
            _settings = _settings.Replace("hardcore=", "hardcore=" + comboBox5.Text.ToLower());
            _settings = _settings.Replace("online-mode=", "online-mode=" + comboBox6.Text.ToLower());
            _settings = _settings.Replace("max-players=", "max-players=" + maxPlayers.Value);
            _settings = _settings.Replace("server-port=", "server-port=" + ServerPort.Value);
            if(ip1.Text.Replace(" ","") != "" && ip2.Text.Replace(" ", "") != "" && ip3.Text.Replace(" ", "") != "" && ip4.Text.Replace(" ", "") != "")
                _settings = _settings.Replace("server-ip=", $"server-ip={ip1.Text}.{ip2.Text}.{ip3.Text}.{ip4.Text}");

            File.Create($"{ServerPath.Text}\\{ServerName.Text}\\server.properties").Close();
            File.WriteAllText($"{ServerPath.Text}\\{ServerName.Text}\\server.properties", _settings);

                File.Create($"{ServerPath.Text}\\{ServerName.Text}\\start.bat").Close();
                string bat = $"timeout /t 3\njava -Xmx{MaxRAM.Value}M -Xms{MaxRAM.Value}M -jar server.jar";
                if (nogui.Checked)
                    bat += " nogui";
                bat += "\npause";
                File.WriteAllText($"{ServerPath.Text}\\{ServerName.Text}\\start.bat", bat);
            serverPath = ServerPath.Text;
            servername = ServerName.Text;

            ServerDownload server = new ServerDownload(download, $"{ServerPath.Text}\\{ServerName.Text}\\server.jar");

            web.DownloadFileCompleted += (s, a) =>
            {
                server.Close();
                button3.Enabled = true;
                button5.Enabled = true;
                MessageBox.Show("The server is configured.\nYou can open the server folder, and start the server by double-clicking \"start.bat\"\nApp made by DimDima09", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                serverBuilt = true;
            };
            server.ShowDialog();
        }
        public static string serverPath, servername;

        public static bool batchChanged = false, propChanged = false, serverBuilt = false, iconChanged = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (propChanged && serverBuilt)
                button6.Enabled = true;

            if (batchChanged && serverBuilt)
                button7.Enabled = true;

            if (iconChanged && serverBuilt)
                button8.Enabled = true;

            if(core.Text == "Spigot")
                groupBox8.Enabled = true;
            else
                groupBox8.Enabled = false;

            if (core.Text == "Forge")
                groupBox9.Enabled = true;
            else
                groupBox9.Enabled = false;

        }
        private void ServerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ServerPath_TextChanged(object sender, EventArgs e)
        {

        }
       public static WebClient web = new WebClient();

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(serverPath + "\\" + servername + "\\server.properties");
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serverBuilt)
                propChanged = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                propChanged = true;
        }

        private void MaxRAM_ValueChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                batchChanged = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            File.Copy(iconPath.Text, $"{ServerPath.Text}\\{ServerName.Text}\\server-icon.png", true);
            iconChanged = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // errorProvider1.SetError(core, "Currently, no configuration and versions are available for the \"Vanilla\" and \"Forge\" cores. =(");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ZIP files(*.zip)|*.zip";
            openFileDialog.Title = "Choose datapacks for server world";
            openFileDialog.Multiselect = true;
            openFileDialog.ShowDialog();
            foreach (var item in openFileDialog.FileNames)
                textBox1.Text += item + Environment.NewLine;
        }

        private void nogui_CheckedChanged(object sender, EventArgs e)
        {

            if (serverBuilt)
                batchChanged = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            batchChanged = false;
            string bat = $"java -Xmx{MaxRAM.Value}M -Xms{MaxRAM.Value}M -jar server.jar";
            if (nogui.Checked)
                bat += " nogui";
            bat += "\npause";
            File.WriteAllText($"{ServerPath.Text}\\{ServerName.Text}\\start.bat", bat);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            propChanged = false;
            _settings = settings;
            _settings = _settings.Replace("gamemode=", "gamemode=" + comboBox2.SelectedItem.ToString().ToLower());
            _settings = _settings.Replace("motd=", $"motd={textBox8.Text}");
            _settings = _settings.Replace("difficulity=", $"difficulity={textBox8.Text.ToLower()}");
            _settings = _settings.Replace("pvp=", "pvp=" + comboBox7.SelectedItem.ToString().ToLower());
            _settings = _settings.Replace("enable-command-block=", "enable-command-block=" + comboBox3.Text.ToLower());
            _settings = _settings.Replace("hardcore=", "hardcore=" + comboBox5.Text.ToLower());
            _settings = _settings.Replace("online-mode=", "online-mode=" + comboBox6.Text.ToLower());
            _settings = _settings.Replace("max-players=", "max-players=" + maxPlayers.Value);
            _settings = _settings.Replace("server-port=", "server-port=" + ServerPort.Value);
            if (ip1.Text.Replace(" ","") != "" &&
                ip2.Text.Replace(" ", "") != "" &&
                ip3.Text.Replace(" ", "") != "" &&
                ip4.Text.Replace(" ", "") != "")
                _settings = _settings.Replace("server-ip=", $"server-ip={ip1.Text}.{ip2.Text}.{ip3.Text}.{ip4.Text}");

            File.WriteAllText($"{ServerPath.Text}\\{ServerName.Text}\\server.properties", _settings);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start(serverPath + "\\" + servername + "");
        }
    }
    public class SpigotLinks
    {
        //1.17.*
        public const string one_seventeen_one = "https://download.getbukkit.org/spigot/spigot-1.17.1.jar";
        public const string one_seventeen = "https://download.getbukkit.org/spigot/spigot-1.17.jar";
        //1.16.*
        public const string one_sixteen_five = "https://cdn.getbukkit.org/spigot/spigot-1.16.5.jar";
        public const string one_sixteen_four = "https://cdn.getbukkit.org/spigot/spigot-1.16.4.jar";
        public const string one_sixteen_three = "https://cdn.getbukkit.org/spigot/spigot-1.16.3.jar";
        public const string one_sixteen_two = "https://cdn.getbukkit.org/spigot/spigot-1.16.2.jar";
        public const string one_sixteen_one = "https://cdn.getbukkit.org/spigot/spigot-1.16.1.jar";
        //1.15.*
        public const string one_fifteen_two = "https://cdn.getbukkit.org/spigot/spigot-1.15.2.jar";
        public const string one_fifteen_one = "https://cdn.getbukkit.org/spigot/spigot-1.15.1.jar";
        public const string one_fifteen = "https://cdn.getbukkit.org/spigot/spigot-1.15.jar";
        //1.14.*
        public const string one_fourteen_four = "https://cdn.getbukkit.org/spigot/spigot-1.14.4.jar";
        public const string one_fourteen_three = "https://cdn.getbukkit.org/spigot/spigot-1.14.3.jar";
        public const string one_fourteen_two = "https://cdn.getbukkit.org/spigot/spigot-1.14.2.jar";
        public const string one_fourteen_one = "https://cdn.getbukkit.org/spigot/spigot-1.14.1.jar";
        public const string one_fourteen = "https://cdn.getbukkit.org/spigot/spigot-1.14.jar";
        //1.13.*
        public const string one_thirteen_two = "https://cdn.getbukkit.org/spigot/spigot-1.13.2.jar";
        public const string one_thirteen_one = "https://cdn.getbukkit.org/spigot/spigot-1.13.1.jar";
        public const string one_thirteen = "https://cdn.getbukkit.org/spigot/spigot-1.13.jar";
        //1.12.*
        public const string one_twelve_two = "https://cdn.getbukkit.org/spigot/spigot-1.12.2.jar";
        public const string one_twelve_one = "https://cdn.getbukkit.org/spigot/spigot-1.12.1.jar";
        public const string one_twelve = "https://cdn.getbukkit.org/spigot/spigot-1.12.jar";
        //1.11.*
        public const string one_eleven_two = "https://cdn.getbukkit.org/spigot/spigot-1.11.2.jar";
        public const string one_eleven_one = "https://cdn.getbukkit.org/spigot/spigot-1.11.1.jar";
        public const string one_eleven = "https://cdn.getbukkit.org/spigot/spigot-1.11.jar";
        //1.10.*
        public const string one_ten_two = "https://cdn.getbukkit.org/spigot/spigot-1.10.2-R0.1-SNAPSHOT-latest.jar";
        public const string one_ten = "https://cdn.getbukkit.org/spigot/spigot-1.10-R0.1-SNAPSHOT-latest.jar";
        //1.9.*
        public const string one_nine_four = "https://cdn.getbukkit.org/spigot/spigot-1.9.4-R0.1-SNAPSHOT-latest.jar";
        public const string one_nine_two = "https://cdn.getbukkit.org/spigot/spigot-1.9.2-R0.1-SNAPSHOT-latest.jar";
        public const string one_nine = "https://cdn.getbukkit.org/spigot/spigot-1.9-R0.1-SNAPSHOT-latest.jar";
        //1.8.*
        public const string one_eight_eight = "https://cdn.getbukkit.org/spigot/spigot-1.8.8-R0.1-SNAPSHOT-latest.jar";
        public const string one_eight_seven = "https://cdn.getbukkit.org/spigot/spigot-1.8.7-R0.1-SNAPSHOT-latest.jar";
        public const string one_eight_six = "https://cdn.getbukkit.org/spigot/spigot-1.8.6-R0.1-SNAPSHOT-latest.jar";
        public const string one_eight_five = "https://cdn.getbukkit.org/spigot/spigot-1.8.5-R0.1-SNAPSHOT-latest.jar";
        public const string one_eight_four = "https://cdn.getbukkit.org/spigot/spigot-1.8.4-R0.1-SNAPSHOT-latest.jar";
        public const string one_eight_three = "https://cdn.getbukkit.org/spigot/spigot-1.8.3-R0.1-SNAPSHOT-latest.jar";
        public const string one_eight = "https://cdn.getbukkit.org/spigot/spigot-1.8-R0.1-SNAPSHOT-latest.jar";
        //1.7.10
        public const string one_seven_ten = "https://cdn.getbukkit.org/spigot/spigot-1.7.10-SNAPSHOT-b1657.jar";
    }
    public class VanillaLinks
    {
        //1.18-exp
        public const string one_eighteen_exp5 = "https://launcher.mojang.com/v1/objects/6680fe47a8d599193219f155d7d878feb05bfeb3/server.jar";
        public const string one_eighteen_exp4 = "https://launcher.mojang.com/v1/objects/ac942062c6b0bf5da61ed2c7b701a13a01462c63/server.jar";
        public const string one_eighteen_exp3 = "https://launcher.mojang.com/v1/objects/cbe106c19f5072222ce54039aa665a8aaf97097d/server.jar";
        public const string one_eighteen_exp2 = "https://launcher.mojang.com/v1/objects/9fa3fd2939f9785bafc6a0a3507c3c967fbeafed/server.jar";
        public const string one_eighteen_exp1 = "https://launcher.mojang.com/v1/objects/6680fe47a8d599193219f155d7d878feb05bfeb3/server.jar";
        //1.17.*
        public const string one_seventeen_one = "https://launcher.mojang.com/v1/objects/a16d67e5807f57fc4e550299cf20226194497dc2/server.jar";
        public const string one_seventeen = "https://launcher.mojang.com/v1/objects/0a269b5f2c5b93b1712d0f5dc43b6182b9ab254e/server.jar";
        //1.16.*
        public const string one_sixteen_five = "https://launcher.mojang.com/v1/objects/35139deedbd5182953cf1caa23835da59ca3d7cd/server.jar";
        public const string one_sixteen_four = "https://launcher.mojang.com/v1/objects/35139deedbd5182953cf1caa23835da59ca3d7cd/server.jar";
        public const string one_sixteen_three = "https://launcher.mojang.com/v1/objects/f02f4473dbf152c23d7d484952121db0b36698cb/server.jar";
        public const string one_sixteen_two = "https://launcher.mojang.com/v1/objects/a412fd69db1f81db3f511c1463fd304675244077/server.jar";
        public const string one_sixteen_one = "https://launcher.mojang.com/v1/objects/a412fd69db1f81db3f511c1463fd304675244077/server.jar";
        //1.15.*
        public const string one_fifteen_two = "https://launcher.mojang.com/v1/objects/4d1826eebac84847c71a77f9349cc22afd0cf0a1/server.jar";
        public const string one_fifteen_one = "https://launcher.mojang.com/v1/objects/4d1826eebac84847c71a77f9349cc22afd0cf0a1/server.jar";
        public const string one_fifteen = "https://launcher.mojang.com/v1/objects/e9f105b3c5c7e85c7b445249a93362a22f62442d/server.jar";
        //1.14.*
        public const string one_fourteen_four = "https://launcher.mojang.com/v1/objects/d0d0fe2b1dc6ab4c65554cb734270872b72dadd6/server.jar";
        public const string one_fourteen_three = "https://launcher.mojang.com/v1/objects/d0d0fe2b1dc6ab4c65554cb734270872b72dadd6/server.jar";
        public const string one_fourteen_two = "https://launcher.mojang.com/v1/objects/808be3869e2ca6b62378f9f4b33c946621620019/server.jar";
        public const string one_fourteen_one = "https://launcher.mojang.com/v1/objects/ed76d597a44c5266be2a7fcd77a8270f1f0bc118/server.jar";
        public const string one_fourteen = "https://launcher.mojang.com/v1/objects/f1a0073671057f01aa843443fef34330281333ce/server.jar";
        //1.13.*
        public const string one_thirteen_two = "https://launcher.mojang.com/v1/objects/3737db93722a9e39eeada7c27e7aca28b144ffa7/server.jar";
        public const string one_thirteen_one = "https://launcher.mojang.com/v1/objects/fe123682e9cb30031eae351764f653500b7396c9/server.jar";
        public const string one_thirteen = "https://launcher.mojang.com/mc/game/1.13/server/d0caafb8438ebd206f99930cfaecfa6c9a13dca0/server.jar";
        //1.12.*
        public const string one_twelve_two = "https://launcher.mojang.com/mc/game/1.12.2/server/886945bfb2b978778c3a0288fd7fab09d315b25f/server.jar";
        public const string one_twelve_one = "https://launcher.mojang.com/mc/game/1.12.1/server/561c7b2d54bae80cc06b05d950633a9ac95da816/server.jar";
        public const string one_twelve = "https://launcher.mojang.com/mc/game/1.12/server/8494e844e911ea0d63878f64da9dcc21f53a3463/server.jar";
        //1.11.*
        public const string one_eleven_two = "https://launcher.mojang.com/mc/game/1.11.2/server/f00c294a1576e03fddcac777c3cf4c7d404c4ba4/server.jar";
        public const string one_eleven_one = "https://launcher.mojang.com/mc/game/1.11.1/server/1f97bd101e508d7b52b3d6a7879223b000b5eba0/server.jar";
        public const string one_eleven = "https://launcher.mojang.com/mc/game/1.11/server/48820c84cb1ed502cb5b2fe23b8153d5e4fa61c0/server.jar";
        //1.10.*
        public const string one_ten_two = "https://launcher.mojang.com/mc/game/1.10.2/server/3d501b23df53c548254f5e3f66492d178a48db63/server.jar";
        public const string one_ten = "https://launcher.mojang.com/mc/game/1.10/server/a96617ffdf5dabbb718ab11a9a68e50545fc5bee/server.jar";
        //1.9.*
        public const string one_nine_four = "https://launcher.mojang.com/mc/game/1.9.4/server/edbb7b1758af33d365bf835eb9d13de005b1e274/server.jar";
        public const string one_nine_two = "https://launcher.mojang.com/mc/game/1.9.2/server/2b95cc7b136017e064c46d04a5825fe4cfa1be30/server.jar";
        public const string one_nine = "https://launcher.mojang.com/mc/game/1.9/server/b4d449cf2918e0f3bd8aa18954b916a4d1880f0d/server.jar";
        //1.8.*
        public const string one_eight_eight = "https://launcher.mojang.com/mc/game/1.8.8/server/5fafba3f58c40dc51b5c3ca72a98f62dfdae1db7/server.jar";
        public const string one_eight_seven = "https://launcher.mojang.com/mc/game/1.8.7/server/35c59e16d1f3b751cd20b76b9b8a19045de363a9/server.jar";
        public const string one_eight_six = "https://launcher.mojang.com/mc/game/1.8.6/server/2bd44b53198f143fb278f8bec3a505dad0beacd2/server.jar";
        public const string one_eight_five = "https://launcher.mojang.com/mc/game/1.8.5/server/ea6dd23658b167dbc0877015d1072cac21ab6eee/server.jar";
        public const string one_eight_four = "https://launcher.mojang.com/mc/game/1.8.4/server/dd4b5eba1c79500390e0b0f45162fa70d38f8a3d/server.jar";
        public const string one_eight_three = "https://launcher.mojang.com/mc/game/1.8.3/server/163ba351cb86f6390450bb2a67fafeb92b6c0f2f/server.jar";
        public const string one_eight = "https://launcher.mojang.com/mc/game/1.8/server/a028f00e678ee5c6aef0e29656dca091b5df11c7/server.jar";
        //1.7.10
        public const string one_seven_ten = "https://launcher.mojang.com/mc/game/1.7.10/server/952438ac4e01b4d115c5fc38f891710c4941df29/server.jar";
    }
}
