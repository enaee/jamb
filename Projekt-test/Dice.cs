using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Projekt_test
{
    class Dice
    {
        public int diceNumber;

        public Dice() { }

        public Dice(int diceNumber) {
            this.diceNumber = diceNumber;
        }

        public int getDiceNumber ()
        {
            return this.diceNumber;
        }

        public void setDiceNumber (int diceNumber)
        {
            this.diceNumber = diceNumber;
        }


    }

    class DrawnDice:Dice
    {
        public Graphics graphics;
        public Color diceColor;
        public Color circleColor;
        public Color borderColor;
        public int diceCircleRadius;
        public int diceSize;
        public int diceDiametar;

        public DrawnDice() { }

        public DrawnDice(int diceNumber)
        {
            this.diceNumber = diceNumber;
        }

        public DrawnDice(Graphics graphics,Color diceColor, Color penColor, int diceNumber)
        {
            this.graphics = graphics;
            this.diceColor = diceColor;
            this.diceNumber = diceNumber;
            this.circleColor = penColor;
            this.diceSize = 70;
            this.diceCircleRadius = diceSize / 10;
            this.diceDiametar = diceCircleRadius * 2;
            this.borderColor = Color.Gold;
        }

        public void setCircleColor(Color color)
        {
            this.circleColor = color;
        }

        public void setDiceColor(Color color)
        {
            this.diceColor = color;
        }

        public void setBorderColor(Color color)
        {
            this.borderColor = color;
        }
        public Color getCircleColor()
        {
            return this.circleColor;
        }

        public Color getDiceColor()
        {
            return this.diceColor;
        }

        public void drawDice()
        {
            SolidBrush bgBrush = new SolidBrush(this.getDiceColor());
            SolidBrush solidBrush = new SolidBrush(this.getCircleColor());

            Rectangle diceRect = new Rectangle(0, 0, this.diceSize, this.diceSize);
            this.graphics.FillRectangle(bgBrush, diceRect);

            if (this.diceNumber == 1)
            {
                drawOne(this.graphics, solidBrush);
            }
            else if (this.diceNumber == 2)
            {
                drawTwo(this.graphics, solidBrush);
            }
            else if (this.diceNumber == 3)
            {
                drawThree(this.graphics, solidBrush);
            }
            else if (this.diceNumber == 4)
            {
                drawFour(this.graphics, solidBrush);
            }
            else if (this.diceNumber == 5)
            {
                drawFive(this.graphics, solidBrush);
            }
            else
            {
                drawSix(this.graphics, solidBrush);
            }

        }

        public void drawSelectedDice()
        {
            SolidBrush bgBrush = new SolidBrush(this.getDiceColor());
            SolidBrush solidBrush = new SolidBrush(this.getCircleColor());

            Rectangle diceRect = new Rectangle(0, 0, this.diceSize, this.diceSize);
            this.graphics.FillRectangle(bgBrush, diceRect);

            

            this.graphics.DrawRectangle(new Pen(borderColor, diceCircleRadius), diceRect);

            if (this.diceNumber == 1)
            {
                drawOne(this.graphics, solidBrush);
            }
            else if (this.diceNumber == 2)
            {
                drawTwo(this.graphics, solidBrush);
            }
            else if (this.diceNumber == 3)
            {
                drawThree(this.graphics, solidBrush);
            }
            else if (this.diceNumber == 4)
            {
                drawFour(this.graphics, solidBrush);
            }
            else if (this.diceNumber == 5)
            {
                drawFive(this.graphics, solidBrush);
            }
            else
            {
                drawSix(this.graphics, solidBrush);
            }

        }

        public void drawOne(Graphics graphics, SolidBrush circleBrush)
        {
            Rectangle rect22 = new Rectangle(this.diceCircleRadius * 4, this.diceCircleRadius * 4, this.diceDiametar, this.diceDiametar);
            graphics.FillEllipse(circleBrush, rect22);
        }
        public void drawTwo(Graphics graphics, SolidBrush circleBrush)
        {
            Rectangle rect13 = new Rectangle(this.diceCircleRadius * 7, this.diceCircleRadius, this.diceDiametar, this.diceDiametar);
            Rectangle rect31 = new Rectangle(this.diceCircleRadius, this.diceCircleRadius * 7, this.diceDiametar, this.diceDiametar);
            graphics.FillEllipse(circleBrush, rect13);
            graphics.FillEllipse(circleBrush, rect31);
        }

        public void drawThree(Graphics graphics, SolidBrush circleBrush)
        {
            drawOne(graphics, circleBrush);
            drawTwo(graphics, circleBrush);
        }

        public void drawFour(Graphics graphics, SolidBrush circleBrush)
        {
            drawTwo(graphics, circleBrush);

            Rectangle rect11 = new Rectangle(this.diceCircleRadius, this.diceCircleRadius, this.diceDiametar, this.diceDiametar);
            Rectangle rect33 = new Rectangle(this.diceCircleRadius * 7, this.diceCircleRadius * 7, this.diceDiametar, this.diceDiametar);
            graphics.FillEllipse(circleBrush, rect11);
            graphics.FillEllipse(circleBrush, rect33);
        }

        public void drawFive(Graphics graphics, SolidBrush circleBrush)
        {
            drawOne(graphics, circleBrush);
            drawFour(graphics, circleBrush);
        }

        public void drawSix(Graphics graphics, SolidBrush circleBrush)
        {
            drawFour(graphics, circleBrush);

            Rectangle rect21 = new Rectangle(this.diceCircleRadius, this.diceCircleRadius * 4, this.diceDiametar, this.diceDiametar);
            Rectangle rect23 = new Rectangle(this.diceCircleRadius * 7, this.diceCircleRadius * 4, this.diceDiametar, this.diceDiametar);
            graphics.FillEllipse(circleBrush, rect21);
            graphics.FillEllipse(circleBrush, rect23);
        }



    }

    }





