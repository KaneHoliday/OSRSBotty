using Corp.Scripts;
using Corp.Scripts.ToA;
using Corp.Scripts.Cox;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Corp
{

    public partial class Form1 : Form
    {


        public Image screen;
        public int[] clientCoords = new int[2];

        Hitpoints hitpoints = new Hitpoints();
        CorpFlinching corp = new CorpFlinching();
        CorpBlocker corpBlock = new CorpBlocker();
        CorpLurer corpLurer = new CorpLurer();
        ToAmain toa = new ToAmain();
        Scarab scarab = new Scarab();
        Croc croc = new Croc();
        CrocBoss crocBoss = new CrocBoss();
        BabaBoss babaBoss = new BabaBoss();
        Agility agility = new Agility();
        Banking bank = new Banking();
        Peripherals mouse = new Peripherals();
        lavaRunecrafting runecrafting = new lavaRunecrafting();
        Granite granite = new Granite();
        FlyFish fish = new FlyFish();
        Teaks teak = new Teaks();
        Fireblore fireblore = new Fireblore();
        Squirk squirk = new Squirk();
        Herblore herblore = new Herblore();
        Logout_timer_extention log = new Logout_timer_extention();
        Tekton tek = new Tekton();
        ArdyAgility ardy = new ArdyAgility();
        Hunter hunter = new Hunter();
        Addyplates smithing = new Addyplates();
        Gaurdians_of_the_rift gotr = new Gaurdians_of_the_rift();

        public Form1()
        {
            InitializeComponent();
        }


        public async void findClient()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                screen = bitmap;

                for (int x = 0; x < screen.Width; x++)
                {
                    for (int y = 0; y < screen.Height; y++)
                    {
                        if (bitmap.GetPixel(x, y) == Color.FromArgb(25, 19, 5))
                        {
                            clientCoords[0] = x + 3;
                            clientCoords[1] = y + 5;
                            return;
                        }
                    }
                }
                MessageBox.Show("Cannot find client");

            }
        }

        public async void update(string script)
        {
            if (script == "corp blocker")
            {
                corpBlock.player.setHp();
            }
            if(script == "corp flincher")
            {
                corp.player.setHp();
            }
            if(script == "corp lurer")
            {
                corpLurer.player.setHp();
                corpLurer.player.setPrayer();
            }
            if(script == "Lava runes")
            {
                label3.Text = runecrafting.xpGained.ToString(); //change to an xp drop system like rs3 runemetrics
            }
            await Task.Delay(50);
            update(script);
        }

        private async void button1_Click_1(object sender, EventArgs e) //useless button
        {
            findClient();
            await Task.Delay(3000);
            corp.setCoords(clientCoords[0], clientCoords[1]);
            corp.cameraPos();
            corp.flinchTime = Int32.Parse(textBox2.Text);
            if(radioButton1.Checked)
            {
                corp.pass1 = true;
            }
            if (radioButton2.Checked)
            {
                corp.pass2 = true;
            }
            if (radioButton3.Checked)
            {
                corp.pass3 = true;
            }
            update("corp flincher");
        }

        private async void button4_Click_1(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            corpLurer.setCoords(clientCoords[0], clientCoords[1]);
            corpLurer.cameraPos();
            update("corp lurer");
            if (radioButton1.Checked)
            {
                corpLurer.pass1 = true;
            }
            if (radioButton2.Checked)
            {
                corpLurer.pass2 = true;
            }
            if (radioButton3.Checked)
            {
                corpLurer.pass3 = true;
            }
        }

        private async void button3_Click_2(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            agility.setCoords(clientCoords[0], clientCoords[1]);
            await Task.Delay(600);
            update("agility");
            agility.startScript();
        }

        private async void button5_Click_1(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            corpLurer.setCoords(clientCoords[0], clientCoords[1]);
            await Task.Delay(600);
            if (corpLurer.inv.hasItem("Prayer Potion"))
            {
                MessageBox.Show("has prayer potion");
            }
        }

        private async void button6_Click_1(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            toa.setCoords(clientCoords[0], clientCoords[1]);
            await Task.Delay(600);
            toa.startScript();
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            scarab.setCoords(clientCoords[0], clientCoords[1]);
            scarab.startScript();
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            croc.setCoords(clientCoords[0], clientCoords[1]);
            update("croc");
            croc.startScript();
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            crocBoss.setCoords(clientCoords[0], clientCoords[1]);
            crocBoss.startScript();
            crocBoss.checkAttack();
            update("croc");
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            babaBoss.setCoords(clientCoords[0], clientCoords[1]);
            babaBoss.startScript();
            update("baba");
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            fish.setCoords(clientCoords[0], clientCoords[1]);
            //update("croc");
            await Task.Delay(2000);
            fish.startScript();
        }

        private async void button16_Click_1(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            runecrafting.setCoords(clientCoords[0], clientCoords[1]);
            update("Lava runes");
            await Task.Delay(2000);
            runecrafting.startScript();
        }

        private async void blockerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            corpBlock.setCoords(clientCoords[0], clientCoords[1]);
            corpBlock.cameraPos();
            update("corp blocker");
            if (radioButton1.Checked)
            {
                corpBlock.pass1 = true;
            }
            if (radioButton2.Checked)
            {
                corpBlock.pass2 = true;
            }
            if (radioButton3.Checked)
            {
                corpBlock.pass3 = true;
            }
        }

        private async void flincherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            corp.setCoords(clientCoords[0], clientCoords[1]);
            corp.cameraPos();
            corp.flinchTime = Int32.Parse(textBox2.Text);
            if (radioButton1.Checked)
            {
                corp.pass1 = true;
            }
            if (radioButton2.Checked)
            {
                corp.pass2 = true;
            }
            if (radioButton3.Checked)
            {
                corp.pass3 = true;
            }
            update("corp flincher");
        }

        private async void lurerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            corpLurer.setCoords(clientCoords[0], clientCoords[1]);
            corpLurer.cameraPos();
            update("corp lurer");
            if (radioButton1.Checked)
            {
                corpLurer.pass1 = true;
            }
            if (radioButton2.Checked)
            {
                corpLurer.pass2 = true;
            }
            if (radioButton3.Checked)
            {
                corpLurer.pass3 = true;
            }
        }

        private async void lavaRunesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            runecrafting.setCoords(clientCoords[0], clientCoords[1]);
            update("Lava runes");
            await Task.Delay(2000);
            runecrafting.startScript();
        }

        private async void tickFlyFishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            fish.setCoords(clientCoords[0], clientCoords[1]);
            //update("croc");
            await Task.Delay(2000);
            if (radioButton4.Checked)
            {
                fish.spec = true;
            }
            fish.startScript();
        }

        private async void seersVilageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            agility.setCoords(clientCoords[0], clientCoords[1]);
            await Task.Delay(600);
            update("agility");
            agility.startScript();
        }

        private async void blockerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            corpBlock.setCoords(clientCoords[0], clientCoords[1]);
            corpBlock.cameraPos();
            update("corp blocker");
            if (radioButton1.Checked)
            {
                corpBlock.pass1 = true;
            }
            if (radioButton2.Checked)
            {
                corpBlock.pass2 = true;
            }
            if (radioButton3.Checked)
            {
                corpBlock.pass3 = true;
            }
        }

        private async void flincherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            corp.setCoords(clientCoords[0], clientCoords[1]);
            corp.cameraPos();
            corp.flinchTime = Int32.Parse(textBox2.Text);
            if (radioButton1.Checked)
            {
                corp.pass1 = true;
            }
            if (radioButton2.Checked)
            {
                corp.pass2 = true;
            }
            if (radioButton3.Checked)
            {
                corp.pass3 = true;
            }
            update("corp flincher");
        }

        private async void lurerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            corpLurer.setCoords(clientCoords[0], clientCoords[1]);
            corpLurer.cameraPos();
            update("corp lurer");
            if (radioButton1.Checked)
            {
                corpLurer.pass1 = true;
            }
            if (radioButton2.Checked)
            {
                corpLurer.pass2 = true;
            }
            if (radioButton3.Checked)
            {
                corpLurer.pass3 = true;
            }
        }

        private async void tickGraniteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            granite.setCoords(clientCoords[0], clientCoords[1]);
            //update("croc");
            if(radioButton4.Checked)
            {
                granite.spec = true;
            }
            granite.startScript();
        }

        private async void crondisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            croc.setCoords(clientCoords[0], clientCoords[1]);
            update("croc");
            croc.startScript();
        }

        private async void beetleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            scarab.setCoords(clientCoords[0], clientCoords[1]);
            scarab.startScript();
        }

        private async void crocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            crocBoss.setCoords(clientCoords[0], clientCoords[1]);
            crocBoss.startScript();
            crocBoss.checkAttack();
            update("croc");
        }

        private async void akhaPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
        }

        private async void babaBossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            babaBoss.setCoords(clientCoords[0], clientCoords[1]);
            babaBoss.startScript();
            update("baba");
        }

        private async void teaksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(600);
            teak.setCoords(clientCoords[0], clientCoords[1]);
            if (radioButton4.Checked)
            {
                teak.spec = true;
            }
            teak.startScript();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            fireblore.setCoords(clientCoords[0], clientCoords[1]);
            fireblore.startScript();
            update("fire");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void firebloreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            fireblore.setCoords(clientCoords[0], clientCoords[1]);
            fireblore.startScript();
            update("fire");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click_2(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            toa.setCoords(clientCoords[0], clientCoords[1]);
            toa.startScript();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(3000);
            ardy.setCoords(clientCoords[0], clientCoords[1]);
            ardy.startScript();
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button12_Click(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(1000);
            hunter.setCoords(clientCoords[0], clientCoords[1]);
            await Task.Delay(100);
            hunter.startScript();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private async void button13_Click_1(object sender, EventArgs e)
        {
            findClient();
            await Task.Delay(1000);
            smithing.setCoords(clientCoords[0], clientCoords[1]);
            await Task.Delay(100);
            smithing.startScript();
        }
    }
}