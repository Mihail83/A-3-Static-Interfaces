using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_Static_Interface
{
    public partial class Practice
    {
        /// <summary>
        /// AL3-P1/3. Создать класс UniqueItem c числовым полем Id. 
        /// Каждый раз, когда создается новый экземпляр данного класса, 
        /// его идентификатор должен увеличиваться на 1 относительно последнего созданного. 
        /// Приложение должно поддерживать возможность начать идентификаторы с любого числа. 
        /// </summary>
        public static void AL3_P1_3()
        {
            UniqueItem idCounter= new UniqueItem();
            idCounter.SetId(0);
            for (int i = 0; i < 50; i++)
            {
                idCounter = new UniqueItem();
            }
            Console.WriteLine(idCounter.Counter); 
        }
        /// <summary>
        /// AL3-P2/3. Отредактировать консольное приложение Printer. 
        /// Заменить базовый абстрактный класс на интерфейс.
        /// </summary>
        public static void AL3_P2_3()
        {

        }


        /// <summary>
        /// AL3-P3/3. Создайте обобщенный метод GuessType<T>(T item), 
        /// который будет принимать переменную обобщенного типа и выводить на консоль, 
        /// что это за тип был передан.
        /// </summary>
        public static void AL3_P3_3()
        {
            //string test = "Hello";
            //int test = -15;
            //Double test = 1.1591;
            //decimal test = 1.01591m;
            //float test = 4.286f;
             DateTime test = DateTime.Now;
            // UniqueItem test = new UniqueItem();

            var guessType = new GuessTypeClass();
            guessType.GuessType(test);
        }

    }
    public class UniqueItem
    {
        private static int _counter;
        public int Counter
        {
            get
            {
                return _counter;
            }
        }

        public UniqueItem()
        {
            _counter++;
        }

        static UniqueItem()
        {
            _counter = 0;
        }

        public void SetId(int number) => _counter = number;
    }

    // AL3-P3/3.////////////////////////////////////////////////////////////////////////////////
    public class GuessTypeClass
    {
        public void GuessType<T>(T item)
        {
            Type type = item.GetType();
           
            switch (type.Name)
            {
                case  "String" :                     
                    Console.WriteLine($" Тип:  {type.Name},  количество символов  -  {(item as String).Length}");
                    break;

                case "Int32":
                    Int32 number = Convert.ToInt32(item);
                    string answer;
                    if (number < 0)
                    {
                        answer = "отрицательное";
                    }
                    else
                    {
                        answer = "положительное";
                    }
                    Console.Write($" Тип:  {type.Name},  {answer} "); 
                    break;

                case "Double":
                case "Single":
                case "Decimal":
                    var floatPoint = Convert.ToDecimal(item);                              
                    while (floatPoint - (long)floatPoint !=0)
                    {
                        floatPoint *= 10;                        
                    }
                    long floatlong = (long)floatPoint;
                    int counter = 0;
                    while (floatlong>0)
                    {
                        floatlong /= 10;
                        counter++;
                    }
                                    //   ((int)Math.Log10(floatTemp) + 1);
                                    //   floatPoint.ToString().Length;
                    Console.WriteLine($"{type.Name},   количество значимых цифр  -  {counter}");
                    break;
                case "DateTime":
                    Console.WriteLine($"{type.Name} -  {Convert.ToDateTime(item)}   это дата и время  ");
                    break;

                default:
                    Console.WriteLine("непонятная хрень");
                    break;
            }
        }
    }
}
