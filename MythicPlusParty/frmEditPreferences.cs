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
    public partial class frmEditPreferences : Form
    {
        public frmEditPreferences()
        {
            InitializeComponent();
            InitializePlayerPreferences();
        }


        const int ELEMENTS_ACROSS = 4;
        Control[,] controls = new Control[frmMain.Players.Count, ELEMENTS_ACROSS];
        private void InitializePlayerPreferences()
        {
            Point location = new Point(0,0);
            
            for (int x = 0; x < frmMain.Players.Count; x++)
            {
                this.Height += 50;
                splitContainer.SplitterDistance += 50;
                location.Y += 50;
                location.X = 10;

                for(int y = 0; y < ELEMENTS_ACROSS; y++)
                {
                    if (y == 0)
                    {
                        controls[x, y] = new Label();
                        controls[x, y].Location = location;
                        controls[x, y].Text = frmMain.Players[x].Name;
                    }
                    else
                    {
                        CheckBox checkBox = new CheckBox();
                        checkBox.Location = location;
                        switch(y)
                        {
                            case 1:
                                checkBox.Text = "Tank";
                                checkBox.Checked = frmMain.Players[x].IsTank;
                                break;
                            case 2:
                                checkBox.Text = "Healer";
                                checkBox.Checked = frmMain.Players[x].IsHealer;
                                break;
                            case 3:
                                checkBox.Text = "DPS";
                                checkBox.Checked = frmMain.Players[x].IsDPS;
                                break;
                        }
                        controls[x, y] = checkBox;
                    }
                    controls[x, y].Width = 80;
                    splitContainer.Panel1.Controls.Add(controls[x, y]);
                    location.X += 80;
                }
                
            }



        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < frmMain.Players.Count; i++)
            {
                CheckBox tankCheck = (CheckBox)controls[i, 1];
                if (frmMain.Players[i].TankList.Count > 0 && tankCheck.Checked)
                    frmMain.Players[i].IsTank = true;
                else if (!(frmMain.Players[i].TankList.Count > 0) && tankCheck.Checked)
                    MessageBox.Show("No tank character found for " + frmMain.Players[i].Name);
                else
                    frmMain.Players[i].IsTank = false;

                CheckBox healerCheck = (CheckBox)controls[i, 2];
                if (frmMain.Players[i].HealerList.Count > 0)
                {
                    frmMain.Players[i].IsHealer = healerCheck.Checked;
                }
                else if (!(frmMain.Players[i].TankList.Count >0) && healerCheck.Checked)
                    MessageBox.Show("No healer character found for " + frmMain.Players[i].Name);
                else
                    frmMain.Players[i].IsHealer = false;

                CheckBox dpsCheck = (CheckBox)controls[i, 3];
                if (frmMain.Players[i].DPSList.Count > 0)
                {
                    frmMain.Players[i].IsDPS = dpsCheck.Checked;
                }
                else if (!(frmMain.Players[i].TankList.Count >0) && dpsCheck.Checked)
                    MessageBox.Show("No DPS character found for " + frmMain.Players[i].Name);
                else
                    frmMain.Players[i].IsDPS = false;
            }
            FileWriter.Save();
            this.Close();
        }
    }
}
