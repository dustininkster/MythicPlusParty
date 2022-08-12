using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MythicPlusParty
{
    public partial class frmMain : Form
    {
        public static List<Player> Players = new List<Player>();
        List<CheckBox> checkBoxes = new List<CheckBox>();
        List<ComboBox> comboBoxes = new List<ComboBox>();
        struct PlayerGroup
        {
            public Player tank;
            public Player healer;
            public Player dps1;
            public Player dps2;
            public Player dps3;
            public List<Player> sittingOut;
        }

        public frmMain()
        {
            try
            {
                StreamReader playerFile;
                playerFile = File.OpenText(@"CharacterFile.txt");
                string[] lineParse;
                while (!playerFile.EndOfStream)
                {
                    lineParse = playerFile.ReadLine().Split(',');
                    if (lineParse[0] == "PLAYER")
                    {
                        Players.Add(new Player(lineParse[1], bool.Parse(lineParse[2]), bool.Parse(lineParse[3]),bool.Parse(lineParse[4])));
                    }
                    else if (lineParse[0] == "TANK")
                    {
                        for (int i = 1; i < lineParse.Length; i++)
                        {
                            Players[Players.Count - 1].TankList.Add(new Character(lineParse[i]));
                        }
                    }
                    else if (lineParse[0] == "HEALER")
                    {
                        for (int i = 1; i < lineParse.Length; i++)
                        {
                            Players[Players.Count - 1].HealerList.Add(new Character(lineParse[i]));
                        }
                    }
                    else if (lineParse[0] == "DPS")
                    {
                        for (int i = 1; i < lineParse.Length; i++)
                        {
                            Players[Players.Count - 1].DPSList.Add(new Character(lineParse[i]));
                        }
                    }
             }

            playerFile.Close();
            }catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            InitializeComponent();
            InitializePlayerComponents();
            FillComboboxes();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewPlayer newPlayer = new frmNewPlayer();
            newPlayer.ShowDialog();
            InitializePlayerComponents();
            FillComboboxes();


        }

        private void characterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCharacter addCharacter = new frmAddCharacter();
            addCharacter.ShowDialog();
            InitializePlayerComponents();
            FillComboboxes();
        }

        private void InitializePlayerComponents()
        {
            foreach (Player player in Players)
            {
                checkBoxes.Add(new CheckBox());
                comboBoxes.Add(new ComboBox());

            }
            Point chkPoint = new Point(10, 58);
            Point cmbPoint = new Point(100, 58);
            for (int i = 0; i < Players.Count; i++)
            {
                checkBoxes[i].Location = chkPoint;
                comboBoxes[i].Location = cmbPoint;
                checkBoxes[i].Text = Players[i].Name;
                checkBoxes[i].Width = 80;
                cntPanels.Panel1.Controls.Add(checkBoxes[i]);
                cntPanels.Panel1.Controls.Add(comboBoxes[i]);

                chkPoint.Y += 25;
                cmbPoint.Y += 25;
            }
        }

        private void FillComboboxes()
        {
            for(int i =0; i < Players.Count; i++)
            {
                if(comboBoxes[i].Enabled)
                {
                    comboBoxes[i].Items.Add("Any");
                    comboBoxes[i].Items.Add("Tank");
                    comboBoxes[i].Items.Add("Healer");
                    comboBoxes[i].Items.Add("DPS");
                    comboBoxes[i].SelectedIndex = 0;
                }
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            List<Player> availablePlayers = new List<Player>();
            PlayerGroup playerGroup = new PlayerGroup();
            playerGroup.sittingOut = new List<Player>();
            for (int i =0;i < Players.Count; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    switch (comboBoxes[i].SelectedIndex)
                    {
                        case (0):
                            availablePlayers.Add(Players[i]);
                            //Any
                            break;
                        case (1):
                            playerGroup.tank = Players[i];
                            //Tank
                            break;
                        case (2):
                            playerGroup.healer = Players[i];
                            //healer
                            break;
                        case (3):
                            if (playerGroup.dps1 == null)
                                playerGroup.dps1 = Players[i];
                            else if (playerGroup.dps2 == null)
                                playerGroup.dps2 = Players[i];
                            else if (playerGroup.dps3 == null)
                                playerGroup.dps3 = Players[i];
                            //dps
                            break;
                    }
                }

            }


            var rand = new Random();

            while ((playerGroup.tank == null || playerGroup.healer == null || playerGroup.dps1 == null || playerGroup.dps2 == null || playerGroup.dps3 == null) && availablePlayers.Count > 0)
            {
                Player selected = availablePlayers[rand.Next(0, availablePlayers.Count)];

                if (playerGroup.tank == null && selected.IsTank)
                {
                    playerGroup.tank = selected;
                    availablePlayers.Remove(selected);
                }

                else if (playerGroup.healer == null && selected.IsHealer)
                {
                    playerGroup.healer = selected;
                    availablePlayers.Remove(selected);
                }

                else if (playerGroup.dps1 == null && selected.IsDPS)
                {
                    playerGroup.dps1 = selected;
                    availablePlayers.Remove(selected);
                }

                else if (playerGroup.dps2 == null && selected.IsDPS)
                {
                    playerGroup.dps2 = selected;
                    availablePlayers.Remove(selected);
                }

                else if (playerGroup.dps3 == null && selected.IsDPS)
                {
                    playerGroup.dps3 = selected;
                    availablePlayers.Remove(selected);
                }

                txtOutput.Text = "Thinking...";
            }

            foreach (Player player in availablePlayers)
            {
                playerGroup.sittingOut.Add(player);
            }


            txtOutput.Text = string.Format("Tank: {0} - {1} \n\r" + Environment.NewLine +
                "Healer: {2} - {3} \n\r" + Environment.NewLine +
                "DPS: {4} - {5} \n\r" + Environment.NewLine +
                "DPS: {6} - {7} \n\r" + Environment.NewLine +
                "DPS: {8} - {9} \n\r" + Environment.NewLine +
                "Sitting out: \n\r" + Environment.NewLine,
                playerGroup.tank.Name, playerGroup.tank.TankList[rand.Next(0,playerGroup.tank.TankList.Count)].Name,
                playerGroup.healer.Name, playerGroup.healer.HealerList[rand.Next(0,playerGroup.healer.HealerList.Count)].Name,
                playerGroup.dps1.Name, playerGroup.dps1.DPSList[rand.Next(0,playerGroup.dps1.DPSList.Count)].Name,
                playerGroup.dps2.Name, playerGroup.dps2.DPSList[rand.Next(0,playerGroup.dps2.DPSList.Count)].Name,
                playerGroup.dps3.Name, playerGroup.dps3.DPSList[rand.Next(0,playerGroup.dps3.DPSList.Count)].Name
                );

            foreach (Player player in playerGroup.sittingOut)
                txtOutput.Text += player.Name + "\n\r" + Environment.NewLine;
        }

        private void changePreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditPreferences editPreferences = new frmEditPreferences();
            editPreferences.ShowDialog();
            InitializePlayerComponents();
        }
    }
}
