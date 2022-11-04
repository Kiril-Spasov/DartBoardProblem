using System;
using System.Windows.Forms;

namespace DartBoardProblem
{
    public partial class FormDartBoard : Form
    {
        public FormDartBoard()
        {
            InitializeComponent();
        }

        /*
         Darts thrown at a dart board land in different REGIONS of the board and a VALUE or score is 
        assigned. The total score is the sum of the values scored for each toss. The two views of the dart 
        board below show the regions on the board and the corresponding values or score.
        Assume that regions 2, 3, and 4 are each three times more likely to be hit as region 1. Write a 
        program that simulates the tossing of darts until the score first equals or exceeds 1000 -- when the 
        game ends.
         */
        private void BtnStart_Click(object sender, EventArgs e)
        {
            LstResult.Items.Clear();
            Random r = new Random();
            int[] regionCount = new int[5];
            int[] regionPointsValue = new int[5] { 0, 7, 5, 3, 1 };
            int toss = 0;
            int region;
            int tossCounter = 0;
            int points = 0;

            do
            {
                //Probability to hit region 1 is 1 out of 10,
                //regions 2,3 and 4 are 3/10. 
                toss = r.Next(1, 11);

                if (toss == 1)
                {
                    region = 1;
                }
                else if (toss <= 4)
                {
                    region = 2;
                }
                else if (toss <= 7)
                {
                    region = 3;
                }
                else
                {
                    region = 4;
                }
                regionCount[region]++;
                points += regionPointsValue[region];
                tossCounter++;
            }
            while (points <= 1000);

            LstResult.Items.Add("Region \t Hits \t Count" + Environment.NewLine);
            for (int i = 1; i <= 4; i++)
            {
                LstResult.Items.Add(i + "\t" + regionCount[i] + "\t" + regionCount[i] * regionPointsValue[i] + Environment.NewLine);
            }
            LstResult.Items.Add("We have reached 1000 points after " + tossCounter + " tosses.");

        }
    }
}
