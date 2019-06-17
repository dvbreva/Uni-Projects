using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator8april
{
    public partial class Form1 : Form
    {
        double result = 0;
        double memoryResult = 0;
        string operation = "";
        bool enterValue = false;
        int counter = 0;
        string firstNum, secondNum;

        public Form1()
        {
            InitializeComponent();
        }

        private void numbers_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if ((txtDisplay.Text == "0") || (enterValue))
                txtDisplay.Text = "";
            enterValue = false;

            if(b.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text = txtDisplay.Text + b.Text;
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Text;
            }
        }

        private void operators_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (result != 0)
            {
                btnEquals.PerformClick();
                enterValue = true;
                operation = b.Text;
                lblShowOperator.Text = System.Convert.ToString(result) + "    " + operation;
            }
            else
            {
                operation = b.Text;
                result = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = "";
                lblShowOperator.Text = System.Convert.ToString(result) + "    " + operation;
            }
            firstNum = lblShowOperator.Text;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            result = 0;
        }

       
        private void btnPercent_Click(object sender, EventArgs e)
        {
            double secondNum = double.Parse(txtDisplay.Text);
            secondNum = secondNum*(result / 100);
            txtDisplay.Text = (result+secondNum).ToString();
            textBoxHistory.AppendText("\n");
          //  textBoxHistory.AppendText((result + secondNum).ToString()); mi izkarva primerno cqlata stoinost na 8+8% ot 8 = 8+0,64 = 8,64
            textBoxHistory.AppendText(result+operation+secondNum+" = "+txtDisplay.Text+"\n");
            textBoxHistory.AppendText("- - - - - - - - - - - - - - - - - \n");
            textBoxHistory.AppendText("\n"); 
            btnClearHistory.Visible = true;

            
        }

        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            double secondNum = double.Parse(txtDisplay.Text);
            secondNum = (double)Math.Sqrt((double)result);
            txtDisplay.Text = secondNum.ToString();

            btnClearHistory.Visible = true;

            
              textBoxHistory.AppendText(result + " using √" + " =  " + "\n");
              textBoxHistory.AppendText("\n\t" + txtDisplay.Text + "\n\n");
              textBoxHistory.AppendText("- - - - - - - - - - - - - - - - - \n");
              textBoxHistory.AppendText("\n");
            lblHistoryText.Text = "";
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            double secondNum = double.Parse(txtDisplay.Text);
            secondNum = secondNum * secondNum;
            txtDisplay.Text = secondNum.ToString();

            btnClearHistory.Visible = true;
            textBoxHistory.AppendText("\n");
            textBoxHistory.AppendText(result + " using square " + " =  " + "\n");
            textBoxHistory.AppendText("\n\t" + txtDisplay.Text + "\n\n");
            textBoxHistory.AppendText("- - - - - - - - - - - - - - - - - \n");
            textBoxHistory.AppendText("\n");
            lblHistoryText.Text = "";
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            double secondNum = double.Parse(txtDisplay.Text);
            secondNum = 1 / secondNum;
            txtDisplay.Text = secondNum.ToString();

            btnClearHistory.Visible = true;
            textBoxHistory.AppendText(result + " using 1/x " + " =  " + "\n");
            textBoxHistory.AppendText("\n\t" + txtDisplay.Text + "\n\n");
            textBoxHistory.AppendText("- - - - - - - - - - - - - - - - - \n");
            textBoxHistory.AppendText("\n");
            lblHistoryText.Text = "";
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            double secondNum = double.Parse(txtDisplay.Text);
            secondNum = secondNum * (-1);
            txtDisplay.Text = secondNum.ToString();
        }

      

        private void btnEquals_Click(object sender, EventArgs e)
        {
            secondNum = txtDisplay.Text;
            lblShowOperator.Text = "";
            switch (operation)
            {
                case "+":
                    txtDisplay.Text = (result + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (result * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (result / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(txtDisplay.Text);

            operation = "";
            
            // tova e izkarvaneto na operaciite v istoriqta
            btnClearHistory.Visible = true;
            textBoxHistory.AppendText("\n");
            textBoxHistory.AppendText(firstNum + operation +" "  + secondNum + " =  " + "\n");
            // textBoxHistory.AppendText("\n\t" + txtDisplay.Text + "\n\n"); za da e nadqsno
            textBoxHistory.AppendText(txtDisplay.Text + "\n\n"); // za da e nalqvo
            textBoxHistory.AppendText("- - - - - - - - - - - - - - - - - \n");
            textBoxHistory.AppendText("\n");
            lblHistoryText.Text= "";
            
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            textBoxHistory.Clear();
            if (lblHistoryText.Text == "")
            {
                lblHistoryText.Text = "There is no history!";
            }
           
            txtDisplay.Text = "0";
            lblShowOperator.Text = " ";
            result = 0;
            btnClearHistory.Visible = false;
            textBoxHistory.ScrollBars = 0;
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            memoryResult = memoryResult + Double.Parse(txtDisplay.Text);
            btnMemoryRead.Enabled = true;
            btnMemoryClear.Enabled = true;
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            memoryResult = memoryResult - Double.Parse(txtDisplay.Text);
            btnMemoryRead.Enabled = true;
            btnMemoryClear.Enabled = true;
        }

        private void btnMemoryRead_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = memoryResult.ToString();
        }

        private void btnMemoryClear_Click(object sender, EventArgs e)
        {
            memoryResult = 0;
            btnMemoryRead.Enabled = false;
            btnMemoryClear.Enabled = false;
        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            this.Width = 481;
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 255;
            counter += 1;
            if (counter % 2 == 0)
            {
                this.Width = 481;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length>0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }

            if(txtDisplay.Text=="")
            {
                txtDisplay.Text = "0";
            }
        }

    }
}
