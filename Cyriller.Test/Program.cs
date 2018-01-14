using Cyriller.Model;
using System;

namespace Cyriller.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем генератор случайных чисел.
            Random rand = new Random();

            // Создаем склонятор чисел.
            CyrNumber number = new CyrNumber();

            {
                // Склоняем случайное число.
                CyrResult result = number.Decline(5300);
                Console.WriteLine(result.ToRussianStringDictionary());
            }

            {
                // Склоняем случайное количество рублей.
                // Так же можно использовать классы `CyrNumber.EurCurrency`, `CyrNumber.UsdCurrency` и `CyrNumber.YuanCurrency`.
                // Либо создать свой класс унаследовав его от `CyrNumber.Currency`.
                CyrNumber.Currency currency = new CyrNumber.RurCurrency();
                CyrResult result = number.Decline((decimal)5300, currency);
            }

            {
                // Создаем коллекцию всех существительных.
                CyrNounCollection nouns = new CyrNounCollection();

                // Получаем существительное из коллекции используя точное совпадение.
                CyrNoun noun = nouns.Get("компьютер", GetConditionsEnum.Strict);

                // Упаковываем существительное для склонения количества.
                CyrNumber.Item item = new CyrNumber.Item(noun);

                // Склоняем случайное количество компьютеров.
                CyrResult result = number.Decline(rand.Next(0, 100), item);
            }

            // Выбираем правильное склонение существительного в зависимости от количества.
            string name = number.Case(rand.Next(0, 100), "компьютер", "компьютера", "компьютеров");
        }
    }
}
