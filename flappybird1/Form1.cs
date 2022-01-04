using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappybird1
{
    public partial class Form1 : Form
    {


        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        { 
            FlappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if(pipeBottom.Left<-150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if(pipeTop.Left<-180)
            {
                pipeTop.Left = 950;
                score++;
            }

            if(FlappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(ground.Bounds) || FlappyBird.Top < -25
                )
            {
                endGame();
            }


            if (score > 5)
            {
                pipeSpeed = 15;
            }

            if (FlappyBird.Top < -25)
            {
                endGame();
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode==Keys.Space)
            {
                gravity = -15;
            }



        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over! ";
        }

    }
}



































-----------------------------------------------------
using System;

namespace EpicBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] hero = { "Bambalbi", "Spider man", "Batman", "Doo-Skooby" };
            string[] enemy = { "Adolf", "Armagedon", "Broodmother", "Meepo", "Fucking slave", "Gachi Muchi" };
            string[] weapon = { "awp", "knife", "glock", "m4a1", "desert eagle", "Carbine Rifle", "Assault Rifle" };

            string randomhero = GetRandomCharacter(hero);
            string randomenemy = GetRandomCharacter(enemy);
            string randomweapon_hero = GetWeapon(weapon);
            string randomweapon_enemy = GetWeapon(weapon);

            Console.WriteLine($"Your random hero is {randomhero} and his weapon is {randomweapon_hero}");
            Console.WriteLine($"Your random enemy is {randomenemy} and his weapon is {randomweapon_enemy}");

        }
        public static string GetRandomCharacter(string[] someArray)
        {
            return someArray[GetRandomIndexForArray(someArray)];
        } 
        public static string GetWeapon(string[] weapon)
        {
            Random rnd = new Random();
            int random_Index = rnd.Next(0, weapon.Length);

            return weapon[random_Index];
        }
        public static int GetRandomIndexForArray(string[] someArray)
        {
            Random rnd = new Random();
            return rnd.Next(0, someArray.Length)
        }
    }
}
