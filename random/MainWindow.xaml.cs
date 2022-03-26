using System;
using System.IO;
using System.Windows;

namespace random
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getNum_Click(object sender, RoutedEventArgs e)
        {
            log.Text = "";
            Random random = new Random();
            int Class_Num = Convert.ToInt32(Classnum.Text), num, count = 0;
            int[,] total = new int[3, 100];
            for (int i = 0; i < total.GetLength(0); i++)
            {
                for (int j = 0; j < total.GetLength(1); j++)
                {
                    total[i, j] = 0;
                }
            }
            StreamWriter sw = new StreamWriter("result.txt");
            int c = 0;
            do
            {
                while (count < Class_Num)
                {
                    num = random.Next(0, Class_Num);
                    if (total[2, num] == 0 && num != c)
                    {
                        total[2, num] = 1;
                        total[1, c] = num + 1;
                        count++;
                        break;
                    }
                }
                c++;

            } while (c <= Class_Num);
            StreamWriter swe;
            for (int p = 1; p < 2; p++)
            {
                for (int q = 0; q < Class_Num; q++)
                {
                    swe = new StreamWriter("number-" + (q + 1) + ".txt");
                    log.Text += (q + 1) + "번의 마니또는 " + total[p, q] + "번 입니다.\n";
                    sw.WriteLine((q + 1) + "번의 마니또는 " + total[p, q] + "번 입니다.");
                    swe.WriteLine((q + 1) + "번의 마니또는 " + total[p, q] + "번 입니다.");
                    swe.Close();
                }
            }
            sw.Close();
        }
    }
}
