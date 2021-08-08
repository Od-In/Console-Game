using System;
using System.Text.RegularExpressions;

namespace Homework_03
{
    class Program
    {
        static void Main()
        {
            OutputRules(); //Вывод правил игры
            int mode = 1;

            while (mode != 3)
            {
                mode = PlayMode(); //Выбор режима игры
                switch (mode)
                {
                    case 1:

                        PVE(); //Игра с компьютером

                        break;
                    case 2:

                        PVP(); //Игра против игроков

                        break;
                }

            }
        }

        /// <summary>
        /// <c>Add_Multiply</c> Метод по формированию gameNumber, minUserTry, maxUserTry
        /// </summary>
        /// <returns>Возвращает значения gameNumber, minUserTry, maxUserTry</returns>
        private static (int gameNumber, int minUserTry, int maxUserTry) Add_Multiply()
        {
            Console.Write("Нижняя граница загаданного числа, не должна быть меньше 12 и не должна содержать недопустимые символы. \nВведите число: ");
            int minGameNumber = MinMaxValue(11);                                        //Устанавливаем нижнюю границу для gameNumber через метод MinMaxValue
            if (minGameNumber == 0)                                                     //Проверка ключевого значения для выхода в главное меню
            {
                Console.Clear();
                return (0, 0, 0);                                                       //Обнуление для выхода в главное меню
            }

            Console.Write("Верхняя граница загаданного числа, не должна быть меньше или равной нижней границы и не должна содержать недопустимые символы. \nВведите число: ");
            int maxGameNumber = MinMaxValue(minGameNumber);                             //Устанавливаем верхнюю границу для gameNumber через метод MinMaxValue
            if (maxGameNumber == 0)                                                     //Проверка ключевого значения для выхода в главное меню
            {
                Console.Clear();
                return (0, 0, 0);                                                       //Обнуление для выхода в главное меню
            }

            Random rnd = new Random();
            int gameNumber = rnd.Next(minGameNumber, maxGameNumber + 1);                //Генерация случайного значения для gameNumber в заданном диапазоне
            Console.WriteLine($"Загаданное число от {minGameNumber} до {maxGameNumber} сгенерировано");
            Console.ReadKey();
            Console.Clear();

            Console.Write("Нижняя граница выбираемого игроком числа, не должна быть меньше 1 и не должна содержать недопустимые символы. \nВведите число: ");
            int minUserTry = MinMaxValue(0);                                            //Устанавливаем нижнюю границу для userTry через метод MinMaxValue
            if (minUserTry == 0)                                                        //Проверка ключевого значения для выхода в главное меню
            {
                Console.Clear();
                return (0, 0, 0);                                                       //Обнуление для выхода в главное меню
            }

            Console.Write("Верхняя граница выбираемого игроком числа, не должна быть меньше или равной нижней границы и не должна содержать недопустимые символы. \nВведите число: ");
            int maxUserTry = MinMaxValue(minUserTry);                                   //Устанавливаем верхнюю границу для userTry через метод MinMaxValue
            if (maxUserTry == 0)                                                        //Проверка ключевого значения для выхода в главное меню
            {
                Console.Clear();
                return (0, 0, 0);                                                       //Обнуление для выхода в главное меню
            }

            Console.WriteLine($"Границы выбираемого игроком числа от {minUserTry} до {maxUserTry}");
            Console.ReadKey();
            Console.Clear();
            return (gameNumber, minUserTry, maxUserTry);
        }


        /// <summary>
        /// <c>OutputRules</c> Вывод правил игры
        /// </summary>
        private static void OutputRules()
        {
            Console.SetCursorPosition(CenterX("Правила игры"), CenterY(-1));            //Помещаем курсор так, чтобы текст оказался в центре экрана, затем выводим строку
            Console.WriteLine("Правила игры");
            Console.SetCursorPosition(CenterX("Загадывается рандомное число в диапазоне, введенном с клавиатуры в начале игры."), CenterY(0)); 
            Console.WriteLine("Загадывается рандомное число в диапазоне, введенном с клавиатуры в начале игры.");
            Console.SetCursorPosition(CenterX("Игроки по очереди выбирают число, диапазон которого также вводится в начале игры"), CenterY(1)); 
            Console.WriteLine("Игроки по очереди выбирают число, диапазон которого также вводится в начале игры");
            Console.SetCursorPosition(CenterX("После каждого хода выбранное число вычитается из загаданного, а остаток от загаданного выводится на экран."), CenterY(2)); 
            Console.WriteLine("После каждого хода выбранное число вычитается из загаданного, а остаток от загаданного выводится на экран.");
            Console.SetCursorPosition(CenterX("Если после хода игрока остаток от загаданного число равняется нулю, то походивший игрок оказывается победителем."), CenterY(3)); 
            Console.WriteLine("Если после хода игрока остаток от загаданного число равняется нулю, то походивший игрок оказывается победителем.");
            Console.SetCursorPosition(CenterX("Если остаток загаданного числа после хода меньше, чем минимальная граница выбираемого игроком,"), CenterY(4)); 
            Console.WriteLine("Если остаток загаданного числа после хода меньше, чем минимальная граница выбираемого игроком,");
            Console.SetCursorPosition(CenterX("то он приравнивается к минимально возможному выбираемому."), CenterY(5)); 
            Console.WriteLine("то он приравнивается к минимально возможному выбираемому.");
            Console.SetCursorPosition(CenterX("Если вы хотите выйти в главное меню, то в любой момент введите слово out."), CenterY(6)); 
            Console.WriteLine("Если вы хотите выйти в главное меню, то в любой момент введите слово out.");
            Console.ReadKey();
            Console.Clear();
        }


        /// <summary>
        /// <c>PlayMode</c> Выбор режима игры (по сути главное меню)
        /// </summary>
        /// <returns>playMode - Режим игры</returns>
        private static int PlayMode()
        {
            Console.SetCursorPosition(CenterX("Выберите режим игры:"), CenterY(0));     //Помещаем курсор так, чтобы текст оказался в центре экрана, затем выводим строку
            Console.WriteLine("Выберите режим игры:");
            Console.SetCursorPosition(CenterX("Выберите режим игры:"), CenterY(1));
            Console.WriteLine("1. Игра с компьютером");
            Console.SetCursorPosition(CenterX("Выберите режим игры:"), CenterY(2));
            Console.WriteLine("2. Игра с разумным существом :)");
            Console.SetCursorPosition(CenterX("Выберите режим игры:"), CenterY(3));
            Console.WriteLine("3. Выход из игры");
            Console.SetCursorPosition(CenterX("Выберите режим игры:"), CenterY(4));
            Console.Write("Введите 1, 2 или 3:");
            string playMode = Console.ReadLine();
            while (playMode != "1" && playMode != "2" && playMode != "3")               //Зацикливаем проверку, чтобы введенное значение было 1-3
            {
                Console.Write("Я всего-лишь глупая машина и не понимаю, что вы от меня хотите ;( \nПовторите ввод: ");
                playMode = Console.ReadLine();
            }
            Console.Clear();
            return int.Parse(playMode);
        }

        /// <summary>
        /// <c>CenterX</c> Метод для вычисления центра консоли по Х
        /// </summary>
        /// <param name="words">Строка, которую необходимо вывести в центре</param>
        private static int CenterX(string words) 
        {
            int centerX = (Console.WindowWidth / 2) - (words.Length / 2);
            return centerX;
        }

        /// <summary>
        /// <c>CenterY</c> Метод для вычисления центра консоли по Y
        /// </summary>
        /// <param name="columns">Сдвиг строки по Y</param>
        private static int CenterY(int columns) 
        {
            int centerY = (Console.WindowHeight / 2) + columns - 1;
            return centerY;
        }

        /// <summary>
        /// <c>IsNumber</c> Метод для проверки числовых данных
        /// </summary>
        /// <param name="input">Введенная строка, которую будем проверять</param>
        private static int IsNumber(string input)
        {
            int count = 0;
            Regex r = new Regex(@"[\D]");                                              //Обозначаем область допустимых значений через регулярные выражения
            Match m = r.Match(input);                                                  //Проверка на соответствие области
            while (m.Success)                                                          //Счетчик символов не являющихся цифрами
            {
                count++;
                m = m.NextMatch();
            }
            return count;
        }

        /// <summary>
        /// <c>MinMaxValue</c> Метод ввода минимального и максимального значений
        /// </summary>
        /// <param name="numberKey">Ключевое значение, меньше которого возвращаемое значение быть не может</param>
        /// <returns>minMaxValue - Минимальное или максимальное значение</returns>
        private static int MinMaxValue(int numberKey)
        {
            string minMaxValue = Console.ReadLine();
            if (minMaxValue == "out")                                                  //Проверяем на наличие ключевой фразы
            {
                Console.Clear();
                return 0;                                                              //Обнуление для выхода в главное меню
            }

            int count = IsNumber(minMaxValue);                                         //Количество символов не являющихся цифрами. А ниже зацикливаем проверку
            while (count > 0 || minMaxValue == "" || int.Parse(minMaxValue) < numberKey + 1)
            {
                Console.Write("Число не соответствует условиям. Пожалуйста, введите число повторно: ");
                minMaxValue = Console.ReadLine();
                count = IsNumber(minMaxValue);
            }
            return int.Parse(minMaxValue);
        }

        /// <summary>
        /// <c>PlayerNumber</c> Метод ввода количества игроков
        /// </summary>
        /// <returns>playerNumber - Количество игроков</returns>
        private static int PlayerNumber()
        {
            Console.Write("Введите количество игроков: ");
            string playerNumber = Console.ReadLine();
            if (playerNumber == "out")                                                  //Проверяем на наличие ключевой фразы
            {
                Console.Clear();
                return 0;                                                               //Обнуление для выхода в главное меню
            }

            int count = IsNumber(playerNumber);
            while (count > 0 || playerNumber == "" || int.Parse(playerNumber) < 2)      //Зацикливаем ввод и проверку
            {
                Console.Write("Число игроков не может быть меньше 2 или содержать недопустимые символы. \nПожалуйста, введите число игроков повторно: ");
                playerNumber = Console.ReadLine();
                count = IsNumber(playerNumber);
            }
            Console.Clear();
            return int.Parse(playerNumber);
        }

        /// <summary>
        /// <c>PVE</c> Метод режима игры с компьютером
        /// </summary>
        private static void PVE()
        {
            int gameNumber = 1;
            string revansh = "1";
            int minUserTry, maxUserTry, userTry;

            while (gameNumber != 0 || revansh != "0")                                   //Играем до тех пор, пока кто-то не победит и пока в конце не будет выбран выход из игры
            {
                int difficult = Difficult();                                            //Выбор уровня сложности компа
                if (difficult == 0)                                                     //Проверка ключевого значения для выхода в главное меню
                {
                    Console.Clear();
                    return;                                                             //Выход в главное меню
                }

                (gameNumber, minUserTry, maxUserTry) = Add_Multiply();                  //Установка значений gameNumber, minUserTry, maxUserTry
                if (gameNumber == 0)                                                    //Проверка ключевого значения для выхода в главное меню
                {
                    Console.Clear();
                    return;                                                             //Выход в главное меню
                }

                Console.Write("Введите 1, если хотите ходить первым, или 2, если хотите ходить вторым: ");
                string step = Console.ReadLine();
                if (step == "out")                                                      //Проверяем на наличие ключевой фразы
                {
                    Console.Clear();
                    return;                                                             //Выход в главное меню
                }

                while (step != "1" && step != "2")                                      //Зацикливаем проверку
                {
                    Console.Write("Я всего-лишь глупая машина и не понимаю, что вы от меня хотите ;( \nПовторите ввод: ");
                    step = Console.ReadLine();
                }
                Console.Clear();

                int stepInt = int.Parse(step);
                while (gameNumber != 0)                                                  //Цикл самой игры
                {
                    if (stepInt == 1)                                                    //Ход игрока
                    {
                        if (gameNumber < minUserTry) gameNumber = minUserTry;            //Если вдруг остаток загаданного числа стал меньше минимальной границы числа вводимого игроком

                        Console.Write("Ваш ход. Введите число: ");
                        userTry = InputUserTry(minUserTry, maxUserTry, gameNumber);      //Ввод числа
                        if (userTry == 999999999)                                        //Проверка ключевого значения для выхода в главное меню
                        {
                            Console.Clear();
                            return;                                                      //Выход в главное меню
                        }

                        gameNumber -= userTry;
                        if (gameNumber == 0)                                             //Проверка выиграл ли игрок
                        {
                            revansh = Win("Игрок");                                      //Вызов метода с выводом победы и выбором проведения реванш или выходом в главное меню
                            break;
                        }
                        stepInt++;
                        Console.Write($"Остаток: {gameNumber}");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else                                                                 //Ход компьютера
                    {
                        if (gameNumber < minUserTry) gameNumber = minUserTry;            //Если вдруг остаток загаданного числа стал меньше минимальной границы числа вводимого игроком

                        gameNumber = Computer(difficult, minUserTry, maxUserTry, gameNumber); //Вызов метода с высчитыванием gameNumber и логикой компа в зависимости от выбранного уровня сложности
                        if (gameNumber == 0)                                             //Проверка выиграл ли компьютер
                        {
                            revansh = Win("Компьютер");                                  //Вызов метода с выводом победы и выбором проведения реванш или выходом в главное меню
                            break;
                        }
                        stepInt--;
                        Console.Write("Компьютер сделал ход.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
            }
        }

        /// <summary>
        /// <c>PVP</c> Метод режима игры с другими игроками
        /// </summary>
        private static void PVP()
        {
            int gameNumber = 1;
            string revansh = "1";
            int playerNumber = PlayerNumber();
            if (playerNumber == 0)
            {
                Console.Clear();
                return;                                                                   //Выход в главное меню
            }
            int minUserTry, maxUserTry, userTry;
            string[] arrayPlayers = new string[playerNumber];
            for (int i = 0; i < playerNumber; i++)                                        //Вводим массив имен игроков
            {
                Console.Write($"Введите имя {i + 1} игрока: ");
                arrayPlayers[i] = Console.ReadLine();
                if (arrayPlayers[i] == "out")                                             //Проверяем на наличие ключевой фразы
                {
                    Console.Clear();
                    return;                                                               //Выход в главное меню
                }

                while (arrayPlayers[i] == "")                                             //Т.к. здесь имеется в виду ник, а не реальное имя, то ограничимся проверкой на пустоту
                {
                    Console.Write($"Имя не может быть пустым. \nПовторите ввод имени {i + 1} игрока: ");
                    arrayPlayers[i] = Console.ReadLine();
                }
                Console.Clear();
            }

            while (gameNumber != 0 || revansh != "0")                                      //Играем до тех пор, пока кто-то не победит и пока в конце не будет выбран выход из игры
            {
                (gameNumber, minUserTry, maxUserTry) = Add_Multiply();                     //Установка значений gameNumber, minUserTry, maxUserTry
                if (gameNumber == 0)                                                       //Проверка ключевого значения для выхода в главное меню
                {
                    Console.Clear();
                    return;                                                                //Выход в главное меню
                }

                while (gameNumber != 0)                                                    //Цикл самой игры
                {
                    foreach (string i in arrayPlayers)                                     //Перебор массива игроков
                    {
                        if (gameNumber < minUserTry) gameNumber = minUserTry;              //Если вдруг остаток загаданного числа стал меньше минимальной границы числа вводимого игроком
                        Console.Write($"Ходит игрок {i}\nВведите число от {minUserTry} до {maxUserTry}: ");
                        userTry = InputUserTry(minUserTry, maxUserTry, gameNumber);        //Ввод числа
                        if (userTry == 999999999)                                          //Проверка ключевого значения для выхода в главное меню
                        {
                            Console.Clear();
                            return;                                                        //Выход в главное меню
                        }

                        gameNumber -= userTry;
                        if (gameNumber == 0)                                               //Проверка победи ли текущий игрок
                        {
                            revansh = Win(i);                                              //Вызов метода с выводом победы и выбором проведения реванш или выходом в главное меню
                            break;                                                         //Прерывание перебора массива, тк кто-то победил
                        }
                        Console.Write($"Остаток: {gameNumber}");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// <c>Difficult</c> Метод Выбора сложности компьютера
        /// </summary>
        /// <returns>difficult - Сложность компьютера</returns>
        private static int Difficult()
        {
            Console.SetCursorPosition(CenterX("Выберите уровень сложность компьютера"), CenterY(0));
            Console.WriteLine("Выберите уровень сложность компьютера");
            Console.SetCursorPosition(CenterX("0. Стандартная сложность компьютера"), CenterY(1));
            Console.WriteLine("1. Стандартная сложность компьютера");
            Console.SetCursorPosition(CenterX("1. Хардкор! Только хардкор!"), CenterY(2));
            Console.WriteLine("2. Хардкор! Только хардкор!");
            Console.SetCursorPosition(CenterX("Введите 1 или 2: "), CenterY(3));
            Console.Write("Введите 1 или 2: ");
            string difficult = Console.ReadLine();
            if (difficult == "out") return 0;                                             //Обнуление для выхода в главное меню
            while (difficult != "1" && difficult != "2")                                  //Зацикливаем проверку
            {
                Console.Write("Я всего-лишь глупая машина и не понимаю, что вы от меня хотите ;( \nПовторите ввод: ");
                difficult = Console.ReadLine();
            }
            Console.Clear();
            return int.Parse(difficult);
        }

        /// <summary>
        /// <c>Computer</c> Метод поведения компьютера в зависимости от выбранного уровня сложности
        /// </summary>
        /// <param name="difficult">Уровень сложности компьютера</param>
        /// <param name="gameNumber">Остаток загаданного числа</param>
        /// <param name="maxUserTry">Нижняя граница вводимого игроком числа</param>
        /// <param name="minUserTry">Верхняя граница вводимого игроком числа</param>
        /// <returns>gameNumber - Остаток загаданного числа</returns>
        private static int Computer(int difficult, int minUserTry, int maxUserTry, int gameNumber)
        {
            Random rnd = new Random();
            int computerTry = rnd.Next(minUserTry, maxUserTry + 1);                       //Ввод рандомного значения компьютера
            int failCounter = 1;
            if (difficult == 1)                                                           //Если выбрана стандартная сложность
            {
                while (computerTry > gameNumber)                                          //Если рандомное значение больше остатка, то компьютер просто вводит новое рандомное значение
                {
                    if (failCounter == 3)                                                 //После 3 попыток, он пропускает ход
                    {
                        computerTry = 0;
                        break;
                    }
                    computerTry = rnd.Next(minUserTry, computerTry);                      //Новое рандомное значение
                    failCounter++;
                }
            }
            else                                                                          //Если выбран сложный уровень сложности, то комп приближает свои шансы к 50/50
            {
                if (maxUserTry > gameNumber && gameNumber != minUserTry)                  //Если верхняя граница выбираемого числа больше остатка и если остаток не равен минимальной границе,
                {                                                                         //то устанавливаем границы для рандомайзера такие, чтобы шанс победить был 50/50
                    maxUserTry = gameNumber + 1;
                    minUserTry = gameNumber - 1;
                    computerTry = rnd.Next(minUserTry, maxUserTry);
                }
                else                                                                      //Иначе если остаток равен нижней границе выбираемого, то дабы у компа не было 100% шанса,
                {                                                                         //поведение такое же, как и у обычного компа, простой перебор с 3 попытками
                    while (computerTry > gameNumber)
                    {
                        if (failCounter == 3)
                        {
                            computerTry = 0;
                            break;
                        }
                        computerTry = rnd.Next(minUserTry, computerTry);
                        failCounter++;
                    }
                }
            }
            gameNumber -= computerTry;                                                    //Если условия не выполняются, то самое 1 значение просто вычитается из остатка
            return gameNumber;
        }

        /// <summary>
        /// <c>InputUserTry</c> Метод ввода числа игроком
        /// </summary>
        /// <param name="gameNumberKey">Остаток загаданного числа</param>
        /// <param name="maxNumberKey">Верхняя граница вводимого игроком числа</param>
        /// <param name="minNumberKey">Нижняя граница вводимого игроком числа</param>
        /// <returns>numberString - Введенное игроком число</returns>
        private static int InputUserTry(int minNumberKey, int maxNumberKey, int gameNumberKey) //Метод ввода чисел
        {
            string numberString = Console.ReadLine();                                    //Присваиваем переменной значение введенное с клавиатуры
            if (numberString == "out") return 999999999;                                 //Установка значения для выхода в главное меню
            int count = IsNumber(numberString);                                          //Проверяем методом IsNumber являются ли символы цифрами
            int failCount = 1;
                                                                                         //Зацикливаем ввод и проверку, а также проверяем диапозон
            while (count > 0 || numberString == "" || int.Parse(numberString) > maxNumberKey || int.Parse(numberString) < minNumberKey || gameNumberKey < int.Parse(numberString)) 
            {                                                                            //Проверка, если введенное число больше остатка
                if (count == 0 && numberString != "" && gameNumberKey < int.Parse(numberString) && int.Parse(numberString) < maxNumberKey && int.Parse(numberString) > minNumberKey)
                {
                    if (failCount == 1)
                    {
                        Console.Write($"Победа близка. Ваше число больше остатка.\nУ вас осталось 2 попытки. \nПопробуйте еще раз: ");
                    }
                    else if (failCount == 2)
                    {
                        Console.Write($"Победа близка. Ваше число больше остатка.\nУ вас осталась 1 попытка. \nПопробуйте еще раз: ");
                    }
                    else
                    {
                        Console.WriteLine("Ваши попытки закончились. Вы пропускаете ход.");
                        return 0;
                    }
                    numberString = Console.ReadLine();
                    count = IsNumber(numberString);
                    failCount++;
                }
                else                                                                      //Проверка для всех остальных случаев
                {
                    if (failCount == 1)
                    {
                        Console.Write($"Число не может быть меньше {minNumberKey}, больше {maxNumberKey} или содержать недопустимые символы. \nУ вас осталось 2 попытки. \nВведите число повторно: ");
                    }
                    else if (failCount == 2)
                    {
                        Console.Write($"Число не может быть меньше {minNumberKey}, больше {maxNumberKey} или содержать недопустимые символы. \nУ вас осталась 1 попытка. \nВведите число повторно: ");
                    }
                    else
                    {
                        Console.WriteLine("Ваши попытки закончились. Вы пропускаете ход.");
                        return 0;
                    }
                    numberString = Console.ReadLine();
                    count = IsNumber(numberString);
                    failCount++;
                }
            }
            return int.Parse(numberString);
        }

        /// <summary>
        /// <c>Win</c> Метод отображения победы и выбор взять реванш или выйти в главное меню
        /// </summary>
        /// <param name="playerName">Имя игрока или компьютера, кто победил</param>
        /// <returns>revansh - Выбор реванша или выход в главное меню</returns>
        private static string Win(string playerName)
        {
            Console.Clear();
            Console.SetCursorPosition(CenterX("Поздравляю!"), CenterY(0));                //Помещаем курсор так, чтобы текст оказался в центре экрана, затем выводим строку
            Console.WriteLine("Поздравляю!");
            Console.SetCursorPosition(CenterX($"Победил {playerName}"), CenterY(1));
            Console.WriteLine($"Победил {playerName}");
            Console.SetCursorPosition(CenterX($"Победил {playerName}"), CenterY(4));
            Console.WriteLine("1. Сыграть еще раз");
            Console.SetCursorPosition(CenterX($"Победил {playerName}"), CenterY(5));
            Console.WriteLine("0. Выйти в главное меню");
            Console.SetCursorPosition(CenterX($"Победил {playerName}"), CenterY(6));
            Console.Write("Введите 1 или 0: ");
            string revansh = Console.ReadLine();
            while (revansh != "1" && revansh != "0")                                      //Зацикливаем проверку
            {
                Console.Write("Я всего-лишь глупая машина и не понимаю, что вы от меня хотите ;( \nПовторите ввод: ");
                revansh = Console.ReadLine();
            }
            Console.Clear();
            return revansh;
        }
    }
}

