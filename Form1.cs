using KnapsackProblem01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithmForm
{
    public partial class Form1 : Form
    {

        public GeneticAlgorithm currentAlgorithm { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            //Create new geneticalgorithm when button is pressed, take information for construction from the elements of the interface
            if (currentAlgorithm == null)
            {
                currentAlgorithm = new GeneticAlgorithm((string)datasets.Text, (int)(popCount.Value), (double)mrate.Value, (double)mstrength.Value, (int)mselectiondown.Value, (int)mselectionup.Value);
                btnStep.Enabled = true;
                btnresetalgo.Enabled = true;
                consolebox.Text += currentAlgorithm.GenerationalLog;
            }
           
            for (int i = 0; i < iterationCount.Value; i++)
            {

                lblBestThisGen.Text = currentAlgorithm.getBestInCurrentGeneration().TotalProfit.ToString();
                IterationNumber.Text = currentAlgorithm.CurrentIterationNumber.ToString();
                lblBestBagEver.Text = currentAlgorithm.getBestBagEver().TotalProfit.ToString();

                currentAlgorithm.buildNextGeneration();
                currentAlgorithm.proceedToNextGeneration();

                consolebox.Text += currentAlgorithm.GenerationalLog;
            }
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            lblBestThisGen.Text = currentAlgorithm.getBestInCurrentGeneration().TotalProfit.ToString();
            IterationNumber.Text = currentAlgorithm.CurrentIterationNumber.ToString();
            lblBestBagEver.Text = currentAlgorithm.getBestBagEver().TotalProfit.ToString();

            currentAlgorithm.buildNextGeneration();
            currentAlgorithm.proceedToNextGeneration();

            consolebox.Text += currentAlgorithm.GenerationalLog;
        }

        private void btnclearconsole_Click(object sender, EventArgs e)
        {
            consolebox.Text = "";
        }

        private void btnresetalgo_Click(object sender, EventArgs e)
        {
            currentAlgorithm = null;
            lblBestThisGen.Text = "-";
            IterationNumber.Text = "-";
            lblBestBagEver.Text = "-";
            consolebox.Clear();
            btnStep.Enabled = false;
            btnresetalgo.Enabled = false;

        }

        
    }
}
