using System;

namespace MyGamblingHeadFirst
{
    internal class Player
    {
        public string Name;
        public int Cash;    // в полях хранятся имя парня и сумма денег у него в кармане

        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = 0.75;
            Player player = new Player() { Name = "The player", Cash = 100 };
            Console.WriteLine("Welcome to the casino. The odds ara " + odds);
            while (player.Cash>0)
            {
                player.WriteMyInfo();
                Console.Write("How much do you want to bed: ");
                string howMuch = Console.ReadLine();
                if(int.TryParse(howMuch, out int amount))
                {
                    int pot = player.GiveCash(amount*2);
                    
                    if (pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            int winnings = pot; 
                            player.ReceiveCash(winnings);
                            Console.WriteLine("You win " + pot);
                        }
                        else
                        {
                            Console.WriteLine("Bad luck, you lose");
                            player.GiveCash(amount);
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Please enter a valid number");
                    }
                    
                    
                }
            }
            Console.WriteLine("The house always wins.");
        }
        /// <summary>
        /// Выводит значение моих полей Name и Cash на консоль.
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks.");
            // иногда бывает нужно приказать объекту выполнить некоторую операцию- например, вывести описание этого объекта на консоль.
        }
        /// <summary>
        /// Выдает часть моих денег, удаляя их из кармана ( или выводит на консоль сообщение о том, что денег недостаточно.
        /// </summary>
        /// <param name="amount">Выдаваемая сумма</param>
        /// <returns>
        /// Сумма денег, взятая из кармана, или 0, если денег не хватает
        /// </returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't a valid amount.");
            }
            if (amount > Cash)
            {
                Console.WriteLine(Name + " says: " + " I don't have enough cash to give you " + amount);
                return 0;
            }
            Cash -= amount;
            return amount;
        }
        /// <summary>
        /// Получает деньги, добавляя их в мой карман (или выводит сообщение на консоль, если сумма недействительна).
        /// </summary>
        /// <param name="amount"> Получаемая сумма</param>
        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + "isn't an amount I'll take");
            }
            else
            {
                Cash += amount;
               
            }
        }
        // Методы ReceiveCash и GiveCash проверяют, что сумма , которую требуется выдавать или получить действительна.
        // это делается для того, чтобы нельзя было вызвать метод получения денег с отрицательным значением, что привело бы к потере средств.
    }
}
