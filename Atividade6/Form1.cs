using System.Drawing.Text;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;


namespace Atividade6
{
    public partial class Form1 : Form
    {

        private double? numA = null;
        private double? numB = null;
        private string? opperation = null;
        private double? result = null;

        // para o manejo do storage
        private double?[] storage = new double?[10];
        private int? position = null;
        private bool msFlag = false;
        private bool mrFlag = false;


        public Form1()
        {
            InitializeComponent();

            // chama a funcao de atualizar o storage ao iniciar o programa
            updateStorage();
        }

        // created by hand -> "="
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (numB == null)
            {
                numB = double.Parse(textBox1.Text);
            }

            if (numA == null || numB == null)
            {
                return;
            }

            switch (opperation)
            {
                case "+":
                    result = numA + numB;
                    break;

                case "-":
                    result = numA - numB;
                    break;

                case "*":
                    result = numA * numB;
                    break;

                case "÷":
                    if (numB == 0)
                    {
                        result = null;
                    }
                    result = numA / numB;
                    break;

                case "√":
                    result = Math.Pow((double)numA, 1 / (double)numB);
                    break;

                case "^":
                    result = Math.Pow((double)numA, (double)numB);
                    break;

                case "sin":
                    result = Math.Sin((double)numA * Math.PI / 180);
                    break;

                case "cos":
                    result = Math.Cos((double)numA * Math.PI / 180);
                    break;

                case "tan":
                    result = Math.Tan((double)numA * Math.PI / 180);
                    break;

            }

            if (opperation == "sin" || opperation == "cos" || opperation == "tan")
            {
                textBox2.Text += " = ";

            }
            else
            {
                textBox2.Text += numB.ToString() + " = ";

            }

            richTextBox1.Text += textBox2.Text + result + "\n";

            textBox1.Text = result.ToString();
            numA = null;
            numB = null;
        }

        // created by hand
        private void btnDigitClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            // se o MS for clicado, o próximo click corresponderá ao local do storage onde será armazenado o valor
            if (msFlag == true && textBox1.Text != "")
            {
                position = int.Parse(button.Text);
                storage[(int)position] = int.Parse(textBox1.Text);
                updateStorage();
                msFlag = false;
                return;
            }

            if (mrFlag == true)
            {
                position = int.Parse(button.Text);
                textBox1.Text = storage[(int)position].ToString();
                mrFlag = false;
                return;

            }

            if (result != null)
            {
                textBox1.Text = null;
                textBox2.Text = null;
                result = null;
            }


            textBox1.Text += button.Text;
        }

        // created by hand
        private void btnC_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            numA = null;
            numB = null;
            opperation = null;

        }

        // created by hand
        private void btnCE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        // created by hand
        private void btnOperationClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (result != null)
            {
                textBox2.Text = null;
                result = null;
            }


            if (numA == null)
            {
                numA = double.Parse(textBox1.Text);

            }
            else
            {
                numB = double.Parse(textBox1.Text);
            }

            textBox2.Text += textBox1.Text;

            switch (button.Text)
            {
                case "√x":
                    numB = 2;
                    opperation = "√";
                    break;

                case "ʸ√x":
                    opperation = "√";
                    break;

                case "xʸ":
                    opperation = "^";
                    break;

                case "x²":
                    numB = 2;
                    opperation = "^";
                    break;

                case "sin":
                case "cos":
                case "tan":
                    opperation = button.Text;
                    numB = 0;
                    break;


                default:
                    opperation = button.Text;
                    break;

            }

            textBox2.Text += " " + opperation + " ";
            textBox1.Text = null;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInversor_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text.Substring(0, 1) == "-")
                {
                    textBox1.Text = textBox1.Text.Substring(1);
                    return;

                }
                textBox1.Text = "-" + textBox1.Text;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = !richTextBox1.Visible;
            btnHistoryClear.Visible = richTextBox1.Visible;
            btnStorage.Visible = richTextBox1.Visible;
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            msFlag = true;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            mrFlag = true;

        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                storage[i] = null;

            }

            updateStorage();
        }

        private void btnHistoryClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void btnStorage_Click(object sender, EventArgs e)
        {
            richTextBox2.Visible = !richTextBox2.Visible;
        }

        private void updateStorage()
        {
            richTextBox2.Text = "";
            for(int i = 0; i < 10; i++)
            {
                richTextBox2.Text += i.ToString() + ": " + storage[i].ToString() + "\n";
            }
        }
    }
}
