using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wyprawa
{
    public partial class Form1 : Form
    {
        private Game game;
        private Random random = new Random();


        public Form1()
        {
            InitializeComponent();
            game = new Game(new Rectangle(78, 57, 520, 235));
            game.NewLevel(random);
            UpdateCharacters();
        }

        private void UpdateCharacters()
        {
            playerPictureBox.Location = game.PlayerLocation;
            playerHitPoints.Text = game.PlayerHitPoints.ToString();
            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    batPictureBox.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        batPictureBox.Visible = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghost)
                {
                    ghostPictureBox.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    ghostPictureBox.Location = enemy.Location;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
                
            }
            if (!showBat)
            {
                batPictureBox.Visible = false;
                batHitPoints.Text = "-";
            }
            else
                batPictureBox.Visible = true;
            if (!showGhost)
            {
                ghostPictureBox.Visible = false;
                ghostHitPoints.Text = "-";
            }
            else
                ghostPictureBox.Visible = true;
            if (!showGhoul)
            {
                ghoulPictureBox.Visible = false;
                ghoulHitPoints.Text = "-";
            }
            else
                ghostPictureBox.Visible = true;

            swordPictureBox.Visible = false;
            bowPictureBox.Visible = false;
            macePictureBox.Visible = false;
            blueElixirPictureBox.Visible = false;
            redElixirPictureBox.Visible = false;

            Control weaponControl = null;
            switch (game.WeaponInRoom.Name)
            {
                case "Miecz":
                    weaponControl = swordPictureBox; break;
                case "Łuk":
                    weaponControl = bowPictureBox; break;
                case "Buława":
                    weaponControl = macePictureBox; break;
                case "Niebieski eliksir":
                    weaponControl = blueElixirPictureBox; break;
                case "Czerwony eliksir":
                    weaponControl = redElixirPictureBox; break;
            }

            foreach (string weapon in game.PlayerWeapons)
            {
                switch (weapon)
                {
                    case "Miecz":
                        swordInInvPictureBox.Visible = true; break;
                    case "Łuk":
                        bowInInvPictureBox.Visible = true; break;
                    case "Buława":
                        maceInInvPictureBox.Visible = true; break;
                    case "Niebieski eliksir":
                        blueElixInInvPictureBox.Visible = true; break;
                    case "Czerwony eliksir":
                        redElixInInvPictureBox.Visible = true; break;
                }
            }
            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;
            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("Zostałeś zabity");
                Application.Exit();
            }
            if (enemiesShown < 1)
            {
                MessageBox.Show("Pokonałeś przeciwników na tym poziomie");
                game.NewLevel(random);
                UpdateCharacters();
            }


        }

        private void moveLeftButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void moveRightButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void attackLeftButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void attackDownButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void attackRightButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void attackUpButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void swordInInvPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Miecz"))
                equipWeapon("Miecz");
        }

        

        private void bowInInvPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Łuk"))
                equipWeapon("Łuk");
        }

        private void maceInInvPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Buława"))
                equipWeapon("Buława");

        }

        private void blueElixInInvPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Niebieski eliksir"))
                equipWeapon("Niebieski eliksir");
        }

        private void redElixInInvPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Czerwony eliksir"))
                equipWeapon("Czerwony eliksir");
        }

        private void equipWeapon(string weaponName)
        {
            swordInInvPictureBox.BorderStyle = BorderStyle.None;
            bowInInvPictureBox.BorderStyle = BorderStyle.None;
            maceInInvPictureBox.BorderStyle = BorderStyle.None;
            blueElixInInvPictureBox.BorderStyle = BorderStyle.None;
            redElixInInvPictureBox.BorderStyle = BorderStyle.None;
            switch (weaponName)
            {
                case "Miecz":
                    swordInInvPictureBox.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case "Łuk":
                    bowInInvPictureBox.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case "Buława":
                    maceInInvPictureBox.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case "Niebieski eliksir":
                    blueElixInInvPictureBox.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case "Czerwony eliksir":
                    redElixInInvPictureBox.BorderStyle = BorderStyle.FixedSingle;
                    break;
            }
        }
    }
}
