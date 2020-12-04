using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Two_dimenMassiv
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MeanHeight_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MeanWidth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbHeight_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbWidth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbNumLines_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbBigNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NumLines_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BigNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // функция двух переменных  которая создаёт двумерный массив и выводит его в виде отдельного окна
        public int[,] GenMas(int Height, int Wid)
        {
            Random rand = new Random();
            int[,] array = new int[Height, Wid];

            // создаём пустую переменную типа String, затем в неё через пробел в цикле 
            // вносим элементы массива и уже затем выводим эту переменную в MessageBox

            String Report = "";
            for (int i = 0; i < Height; i++)
            {
                // Выводим массив на экран
                for (int j = 0; j < Wid; j++)
                {
                    array[i, j] = rand.Next(-50, 50);
                    if (j % Wid == 0)
                    {
                        Report += string.Format("\n\n|{0} ", array[i, j]);
                    }
                    else
                    {
                        Report += string.Format("|{0} ", array[i, j]);
                    }
                }
            }

            MessageBox.Show(Report, "Двумерный неотсортированный массив");
            return array;
        }
      
        private void StringNoOh(int[,] array, int Height, int Wid)
        {
            int counter = Height;
           
            for (int i = 0; i < Height; i++)
            {
                // Выводим массив на экран
                for (int j = 0; j < Wid; j++)
                {
                    // если находим в строке ноль, тогда уменьшаем кол-во строк без нуля 
                    // и переходим к следующей строке
                    if (array[i,j] == 0 )
                    {
                        counter--;
                        break; 
                    }
                }
            }
            NumLines.Text = counter.ToString();
        }

        private void IterantMax(int[,] array, int Height, int Wid)
        {
            int counter = Height;
            bool check = false;
            int max = -1000;
            for (int i = 0; i < Height; i++)
            {
                // Выводим массив на экран
                for (int j = 0; j < Wid; j++)
                {
                    for (int i1 = 0; i1 < Height; i1++)
                    {
                        for (int j1 = 0; j1 < Wid; j1++)
                        { // заново перебираем элементы в массиве в поисках повторяющегося
                            if ((i != i1) && (j != j1) && (array[i, j] == array[i1, j1]))
                            {
                                check = true;
                            }
                            if (check)
                            {
                                if (array[i, j] > max)
                                { max= array[i, j]; }
                            }
                         }
                    }
                }
            }
            if (max == -1000)
            {
                MessageBox.Show("В массиве нет повторяющихся элементов");
            }
            else
            {
                BigNumber.Text = max.ToString();
            }
            NumLines.Text = counter.ToString();
        }

        private void GenDoubleMas_Click(object sender, RoutedEventArgs e)
        {
            // проверка того, что ввёл пользователь
            try
            {
                int x = int.Parse(MeanHeight.Text);
                int y = int.Parse(MeanWidth.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка! Введите в поля целые числа!");
                return ;
            }

            // создаём двумерный массив
            int HEl = int.Parse(MeanHeight.Text);
            int WEl = int.Parse(MeanWidth.Text);
            int[,] NewMas = GenMas(HEl, WEl);

            // ищем строки без нулей с помощью функции
            StringNoOh(NewMas, HEl, WEl);
            IterantMax(NewMas, HEl, WEl);
        }

   
    }
}
