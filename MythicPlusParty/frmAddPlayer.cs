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
    public partial class frmNewPlayer : Form
    {
        public frmNewPlayer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                Player player = new Player(txtName.Text,false,false,false);
                frmMain.Players.Add(player);
            }
            FileWriter.Save();
            this.Close();
        }
    }

    public static class FileWriter
    {
        public static void Save()
        {
             try
             {
                StreamWriter playerFile;
                playerFile = File.CreateText(@"CharacterFile.txt");

                foreach(Player player in frmMain.Players)
                {
                    playerFile.WriteLine("PLAYER," + player.Name + "," + player.IsTank + "," + player.IsHealer + "," + player.IsDPS);
                    playerFile.Write("TANK");
                    foreach (Character character in player.TankList)
                        playerFile.Write("," + character.Name);
                    playerFile.WriteLine();
                    playerFile.Write("HEALER");
                    foreach(Character character in player.HealerList)
                        playerFile.Write(","+character.Name);
                    playerFile.WriteLine();
                    playerFile.Write("DPS");
                    foreach (Character character in player.DPSList)
                        playerFile.Write(","+character.Name);
                    playerFile.WriteLine();
                }
                playerFile.Close();
             }
             catch (Exception ex)
             {
                MessageBox.Show(ex.Message);
             }
        }

    }
}
