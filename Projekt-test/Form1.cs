using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting;
using IronPython.Runtime;
using Microsoft.Scripting.Hosting;
using System.IO;

namespace Projekt_test

//Pravila za bodovanje preuzeta sa:
//https://geek.hr/e-kako/zabava/kako-se-igra-jamb/
{
    public partial class Form1 : Form
    {
        Color diceColor, penColor, borderColor;
        DrawnDice[] rolledDices;
        Boolean[] selectedDices;
        int[] rolledNumbers;
        Random r;
        DrawnDice dice1, dice2, dice3, dice4, dice5;
        Boolean firstRoll, secondRoll;
        int upperScore, lowerScore, movesLeft;

        ScriptEngine pyEngine = null;
        ScriptScope pyScope = null;


        public Form1()
        {
            pyEngine = Python.CreateEngine();
            pyScope = pyEngine.CreateScope();
            InitializeComponent();

            
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            ScriptSource scr = pyEngine.CreateScriptSourceFromFile("..\\..\\pyfile.py");
            scr.Execute(pyScope);
            diceColor = Color.White;
            penColor = Color.Black;
            borderColor = Color.Gold;

            //mora se inicirati svih 5 jer su na različitim pictureboxovima
            dice1 = new DrawnDice(this.pictureBox1.CreateGraphics(), diceColor, penColor, 1);
            dice2 = new DrawnDice(this.pictureBox2.CreateGraphics(), diceColor, penColor, 1);
            dice3 = new DrawnDice(this.pictureBox3.CreateGraphics(), diceColor, penColor, 1);
            dice4 = new DrawnDice(this.pictureBox4.CreateGraphics(), diceColor, penColor, 1);
            dice5 = new DrawnDice(this.pictureBox5.CreateGraphics(), diceColor, penColor, 1);

            rolledDices = new DrawnDice[5] { dice1, dice2, dice3, dice4, dice5 };
            selectedDices = new Boolean[5] { false, false, false, false, false };
            rolledNumbers = new int[5] { 1, 1, 1, 1, 1 };
            r = new Random();
            firstRoll = true;
            secondRoll = false;
            upperScore = 0;
            lowerScore = 0;
            movesLeft = 12;
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            if (firstRoll)
            {
                //nije odabrana kockica
                for (int i = 0; i < 5; i++)
                {
                    selectedDices[i] = false;
                }
               
                //generiraj sve nove kockice
                foreach (int i in Enumerable.Range(0, 5))
                {
                    int rnd = r.Next(1, 7);
                    rolledDices[i].setDiceNumber(rnd);
                    rolledNumbers[i] = rnd;
                }
                firstRoll = false;
                secondRoll = true;
            }
            else if (secondRoll)
            {
                foreach (int i in Enumerable.Range(0, 5))
                {
                    if (!selectedDices[i])
                    {
                        int rnd = r.Next(1, 7);
                        rolledDices[i].setDiceNumber(rnd);
                        rolledNumbers[i] = rnd;
                    }

                }

                secondRoll = false;
            }
            else
            {
                foreach (int i in Enumerable.Range(0, 5))
                {
                    if (!selectedDices[i])
                    {
                        int rnd = r.Next(1, 7);
                        rolledDices[i].setDiceNumber(rnd);
                        rolledNumbers[i] = rnd;
                        selectedDices[i] = true;
                    }
                }
                this.buttonRoll.Enabled = false;
                firstRoll = true;
                
            }
            drawDice();
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diceColor = Color.White;
            penColor = Color.Black;
            borderColor = Color.Gold;
            drawDice();
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diceColor = Color.Black;
            penColor = Color.White;
            borderColor = Color.Gold;
            drawDice();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            diceColor = Color.DarkRed;
            penColor = Color.White;
            borderColor = Color.Gold;
            drawDice();
        }


        private void drawDice()
        {
            foreach (int i in Enumerable.Range(0, 5))
            {
                rolledDices[i].setCircleColor(penColor);
                rolledDices[i].setDiceColor(diceColor);
                rolledDices[i].setBorderColor(borderColor);
                if (!selectedDices[i])
                {
                    rolledDices[i].drawDice();
                }
                else
                {
                    rolledDices[i].drawSelectedDice();
                }
            }
         }




        private void button1_Click(object sender, EventArgs e)
        {
            dynamic sumOnes = pyScope.GetVariable("sumOnes");
            int sumOfOnes = sumOnes(rolledNumbers);
            upperScore += sumOfOnes;
            this.label1.Text = sumOfOnes.ToString();
            this.button1.Enabled = false;
            afterMove();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dynamic sumTwo = pyScope.GetVariable("sumTwo");
            this.label2.Text = sumTwo(rolledNumbers).ToString();
            this.button2.Enabled = false;
            upperScore += sumTwo(rolledNumbers);
            afterMove();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            dynamic sumThree = pyScope.GetVariable("sumThree");
            this.label3.Text = sumThree(rolledNumbers).ToString();
            this.button3.Enabled = false;
            upperScore += sumThree(rolledNumbers);
            afterMove();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dynamic sumFour = pyScope.GetVariable("sumFour");
            this.label4.Text = sumFour(rolledNumbers).ToString();
            this.button4.Enabled = false;
            upperScore += sumFour(rolledNumbers);
            afterMove();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            dynamic sumFive = pyScope.GetVariable("sumFive");
            this.label5.Text = sumFive(rolledNumbers).ToString();
            this.button5.Enabled = false;
            upperScore += sumFive(rolledNumbers);
            afterMove();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            dynamic sumSix = pyScope.GetVariable("sumSix");
            this.label6.Text = sumSix(rolledNumbers).ToString();
            this.button6.Enabled = false;
            upperScore += sumSix(rolledNumbers);
            afterMove();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            dynamic sumThreeOfKind = pyScope.GetVariable("sumThreeOfKind");
            this.label9.Text = sumThreeOfKind(rolledNumbers).ToString();
            this.button11.Enabled = false;
            lowerScore += sumThreeOfKind(rolledNumbers);
            afterMove();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            dynamic sumFourOfKind = pyScope.GetVariable("sumFourOfKind");
            this.label10.Text = sumFourOfKind(rolledNumbers).ToString();
            this.button12.Enabled = false;
            lowerScore += sumFourOfKind(rolledNumbers);
            afterMove();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            dynamic sumFull = pyScope.GetVariable("sumFull");
            this.label11.Text = sumFull(rolledNumbers).ToString();
            this.button13.Enabled = false;
            lowerScore += sumFull(rolledNumbers);
            afterMove();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            dynamic sumSmallScale = pyScope.GetVariable("sumSmallScale");
            this.label12.Text = sumSmallScale(rolledNumbers).ToString();
            this.button14.Enabled = false;
            lowerScore += sumSmallScale(rolledNumbers);
            afterMove();
        }



        private void button15_Click(object sender, EventArgs e)
        {
            dynamic sumLargeScale = pyScope.GetVariable("sumLargeScale");
            this.label13.Text = sumLargeScale(rolledNumbers).ToString();
            this.button15.Enabled = false;
            lowerScore += sumLargeScale(rolledNumbers);
            afterMove();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            dynamic sumYamb = pyScope.GetVariable("sumYamb");
            this.label14.Text = sumYamb(rolledNumbers).ToString();
            this.button16.Enabled = false;
            lowerScore += sumYamb(rolledNumbers);
            afterMove();       
        }
        private void afterMove ()
        {
            if (upperScore >= 60) { upperScore += 30; }
            this.labelScoreUpper.Text = upperScore.ToString();
            this.labelScoreLower.Text = lowerScore.ToString();

            firstRoll = true;
            this.buttonRoll.Enabled = true;

            movesLeft -= 1;
            int total = upperScore + lowerScore;
            if (movesLeft == 0)
            {
                this.labelTheEnd.Text = "Total Score: " + total.ToString();
                this.buttonNewGame.Visible = true;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(selectedDices[0])
            {
                selectedDices[0] = false;
            } else
            {
                selectedDices[0] = true;
            }
            drawDice();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (selectedDices[1])
            {
                selectedDices[1] = false;
            }
            else
            {
                selectedDices[1] = true;
            }
            drawDice();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (selectedDices[2])
            {
                selectedDices[2] = false;
            }
            else
            {
                selectedDices[2] = true;
            }
            drawDice();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (selectedDices[3])
            {
                selectedDices[3] = false;
            }
            else
            {
                selectedDices[3] = true;
            }
            drawDice();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (selectedDices[4])
            {
                selectedDices[4] = false;
            }
            else
            {
                selectedDices[4] = true;
            }
            drawDice();
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lowerScore = 0;
            upperScore = 0;
            movesLeft = 12;

            this.labelTheEnd.Text = "";
            this.buttonNewGame.Visible = false;

            foreach (Dice d in rolledDices)
            {
                d.setDiceNumber(1);
            }
            for (int i = 0; i < 5; i++)
            {
                selectedDices[i] = false;
            }
            drawDice();
            this.label1.Text = " ";
            this.label2.Text = " ";
            this.label3.Text = " ";
            this.label4.Text = " ";
            this.label5.Text = " ";
            this.label6.Text = " ";
            this.label9.Text = " ";
            this.label10.Text = " ";
            this.label11.Text = " ";
            this.label12.Text = " ";
            this.label13.Text = " ";
            this.label14.Text = " ";
            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.button3.Enabled = true;
            this.button4.Enabled = true;
            this.button5.Enabled = true;
            this.button6.Enabled = true;
            this.button16.Enabled = true;
            this.button15.Enabled = true;
            this.button14.Enabled = true;
            this.button13.Enabled = true;
            this.button11.Enabled = true;
            this.button12.Enabled = true;

            this.labelScoreUpper.Text = "0";
            this.labelScoreLower.Text = "0";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }


}
