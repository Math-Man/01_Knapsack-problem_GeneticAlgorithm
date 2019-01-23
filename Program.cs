using GeneticAlgorithmForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnapsackProblem01
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //GeneticAlgorithm g = new GeneticAlgorithm("E:\\Documents\\Visual Studio 2015\\Projects\\KnapsackProblem01\\KnapsackProblem01\\DATA\\Instance_100_995.txt", 25, 0.05, 0.5, 10, 15);
        }
    }
}


