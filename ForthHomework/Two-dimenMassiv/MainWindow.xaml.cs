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

namespace One_dimenMassiv
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

        private void AmountElMassiv_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbSum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbMulti_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        // функция одной переменной которая создаёт массив и выводит его в виде отдельного окна
        public double[] GenMas(int Len)
        {
            Random rand = new Random();
            double[] array = new double[Len];

            // создаём пустую переменную типа String, затем в неё через пробел в цикле 
            // вносим элементы массива и уже затем выводим эту переменную в MessageBox

            String Report = "";
            for (int i = 0; i < Len; i++)
            {
                double randVar = rand.Next(-100, 100);
                array[i] = rand.NextDouble() * randVar;
                if (i  % 10 == 0)
                {
                    Report += String.Format("\n|{0:0.00} ",  array[i]);
                }
                else
                {
                    Report += String.Format("|{0:0.00} ", array[i]);
                }
            }

            MessageBox.Show(Report, "Массив");
            return array;
        }


        // Функция  принимает массив, потом подсчитывает отрицательные элемент и выводит их сумму в tbSum
        public void NegEl(double[] array)
        {
            double Negative = 0;
            foreach (double element in array)
            {
                if (element < 0)
                {
                    Negative = Negative + element;
                }
            }
            tbSum.Text = String.Format("{0:0.00}", Negative);
        }


        // Функция принимает в качестве перееменной массив, затем находит минимальный элемент и максимальный 
        // и расстояние между ними, и в конце перемножает все элементы в получившемсяпромежутке
        private void BetweenMinMax(double[] array)
        {
            double Min = 25, Max = -25; // учитывая, что диапазон значений элементов массива [-20,20] можно выбрать такие значения 
            int PozMin = 0, PozMax = 0, i = -1; // также найдём позиции Max и Min
            double Multi = 1; // произведение элементов в промежутке
            foreach (double element in array)
            {
                i++; // используем эту переменную для поиска номера Min и Max-элемента в массиве
                if (element < Min)
                {
                    Min = element; PozMin = i;
                }

                if (element > Max)
                {
                    Max = element; PozMax = i;
                }
            }
          
            if (PozMax > PozMin)
                {
                    for(int j = PozMin; j < PozMax  + 1; j++)
                    {
                        Multi = Multi * array[j];
                    }
                }
                else
                {
                    for (int j = PozMax; j < PozMin + 1; j++)
                    {
                        Multi = Multi * array[j];
                    }
                }

                tbMulti.Text = String.Format("{0:0.00}", Multi);
        }


        //функция сортирует полученный массив по возрастанию
        private void SortIncrease(double[] array)
        {
            Array.Sort(array); int i = -1;
            String Report = "";
            foreach (double element in array)
            {
                i++;
                if (i % 10 == 0)
                {
                    Report += String.Format("\n|{0:0.00} ", element);
                }
                else
                {
                    Report += String.Format("|{0:0.00} ", element);
                }
            }
            
            MessageBox.Show(Report, "Рассортированный по возрастанию Массив");
        }


        private void CountUp_Click(object sender, RoutedEventArgs e)
        {

            // проверяем, ввёл ли пользователь число, если нет, то выводим сообщение об ошибке

            try
            {
                int x = int.Parse(AmountElMassiv.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Ошибка! Введите в поле целое число!");
                return;
            }
            
            if((int.Parse(AmountElMassiv.Text) > 2000) || (int.Parse(AmountElMassiv.Text) < 2))
            {
                MessageBox.Show("Неподходящая размерность массива! Попробуйте ввести какую-нибудь другую");
                return;
            }
                // Вызываем функцию, создающую массив
                int AmEl = int.Parse(AmountElMassiv.Text);
                double[] NewMas = GenMas(AmEl);

                // Вызываем функцию, считающую отрицательные элементы массива
                NegEl(NewMas);

                // Вызываем функцию, находящую произведение элементов находящихся межде максимальным и минимальным элементом
                BetweenMinMax(NewMas);

                // сортируем массив по возрастанию и выводим его в MessageBox
                SortIncrease(NewMas);
        }
    }
}
