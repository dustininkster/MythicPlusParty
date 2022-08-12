using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MythicPlusParty
{
    public partial class frmAddCharacter : Form
    {
        public frmAddCharacter()
        {
            InitializeComponent();
            foreach (Player player in frmMain.Players)
                cmbPlayer.Items.Add(player.Name);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (chkTank.Checked)
            {
                frmMain.Players[cmbPlayer.SelectedIndex].TankList.Add(new Character(txtName.Text));
                frmMain.Players[cmbPlayer.SelectedIndex].IsTank = true;
            }
            if (chkHealer.Checked)
            {
                frmMain.Players[cmbPlayer.SelectedIndex].HealerList.Add(new Character(txtName.Text));
                frmMain.Players[cmbPlayer.SelectedIndex].IsHealer = true;
            }
            if (chkDPS.Checked)
            {
                frmMain.Players[cmbPlayer.SelectedIndex].DPSList.Add(new Character(txtName.Text));
                frmMain.Players[cmbPlayer.SelectedIndex].IsDPS = true;
            }
            FileWriter.Save();
            this.Close();
        }
    }
}
