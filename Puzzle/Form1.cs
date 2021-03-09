using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pexoso
{
    public partial class Form1 : Form
    {

        public int[] cisla = new int[367];
        Random rnd = new Random();
        public bool opened = false;
        public int fnumber = 0, snumber = 0, score = 0,clicked=0;
        

        private void timer1_Tick(object sender, EventArgs e)
        {

            
        }

        public Form1()
        {
            InitializeComponent();
            generate_numbers();
            
        }


        private void generate_numbers() {
            int random_cislo = 0;
            
            int rnd_cislo = 1;
            while (rnd_cislo < 18)
            {
                back:
                random_cislo = rnd.Next(1, 37);
                
                if (cisla[random_cislo] == 0)
                {
                    cisla[random_cislo] = rnd_cislo;
                   
                }
                else { goto back; }
                back2:
                random_cislo = rnd.Next(1, 37);
                if (cisla[random_cislo] == 0)
                {
                    cisla[random_cislo] = rnd_cislo;
                    
                }
                else { goto back2; }
                rnd_cislo++;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            label1.Text = clicked.ToString();
            label2.Text = score.ToString();
            string buttonText = ((Button)sender).Name;
            
            buttonText = buttonText.Substring(6);
            int buttonTex_in = Int32.Parse(buttonText);
           
            if (opened == true) { snumber = buttonTex_in; if (cisla[fnumber] == cisla[snumber] && snumber != fnumber) { score++; ((Button)sender).Visible = false; string tt = "button" + fnumber; this.Controls[tt].Visible = false; opened = false; }
                else {
                    string tt = "button"+ fnumber;
                    this.Controls[tt].Text = "";
                    fnumber = 0; snumber = 0;
                    opened = false;
                }
                
            }
            if (opened == false) { fnumber = buttonTex_in; ((Button)sender).Text = cisla[buttonTex_in].ToString(); opened = true; }
            clicked++;
            label1.Text = clicked.ToString();
            label2.Text = score.ToString();
            if (score == 18) { MessageBox.Show("Vyhráli jste s početem " + clicked + " kliknutí"); }
        }
    }
}
