using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public static int oWins = 0;
        public static int xWins = 0;
        public static int lRuch = 0;
        public static bool Ruch = true;
        public Form1()
        {
            InitializeComponent();
            if (Ruch)
            {
                lblRuch.Text = "O";
                
            }
            else
            {
                lblRuch.Text = "X";
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(Ruch)
            {
                b.Text = "O";
               
            }
            else
            {
                b.Text = "X";
               
            }
            
            b.Enabled = false;
            Ruch = !Ruch;
            if (Ruch)
            {
                lblRuch.Text = "O";

            }
            else
            {
                lblRuch.Text = "X";
            }
            lRuch++;
            win();
            
        }

        private void win()
        {
            Button b = new Button();
            

            bool hasWiner = false;
            if(btn1.Text == btn2.Text && btn2.Text == btn3.Text && !btn1.Enabled)
            {
                hasWiner = true;
            }
            else if(btn4.Text == btn5.Text && btn5.Text == btn6.Text && !btn4.Enabled)
            {
                hasWiner = true;

            }
            else if(btn7.Text == btn8.Text && btn8.Text == btn9.Text && !btn7.Enabled)
            {
                hasWiner = true;

            }
            else if(btn1.Text == btn4.Text && btn4.Text == btn7.Text && !btn1.Enabled)
            {
                hasWiner = true;

            }
            else if(btn2.Text == btn5.Text && btn5.Text == btn8.Text && !btn2.Enabled)
            {
                hasWiner = true;

            }
            else if(btn3.Text == btn6.Text && btn6.Text == btn9.Text && !btn3.Enabled)
            {
                hasWiner = true;

            }
            else if(btn1.Text == btn5.Text && btn5.Text == btn9.Text && !btn1.Enabled)
            {
                hasWiner = true;

            }
            else if(btn3.Text == btn5.Text && btn5.Text == btn7.Text && !btn3.Enabled)
            {
                hasWiner = true;

            }

            if(hasWiner)
            {
                if (Ruch)
                {
                    xWins++;
                    lblX.Text = xWins.ToString();
                }
                else
                {
                    oWins++;
                    lblO.Text = oWins.ToString();
                }
                DialogResult dialogResult = MessageBox.Show($"Wygrywa {(Ruch ? "X" : "O")}! \nJeszcze raz?","win", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Retry();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
                b.Enabled = false;
                
            }
            else if (lRuch == 9 && hasWiner == false)
            {
                DialogResult dialogResult = MessageBox.Show($"Remis!\nJeszcze raz?", "win", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Retry();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
                b.Enabled = false;
            }


        }
        private void Retry()
        {
            
            foreach (Control c in Controls)
            {
                try { 
                Button b = (Button)c;
                b.Enabled = true;
                b.Text = string.Empty;
                lRuch = 0;
                Ruch = true;
                }
                catch { }
            }
        }

        
    }
}
