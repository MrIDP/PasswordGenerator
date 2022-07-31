using System;

namespace MyTestC_App
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                bigLetters = new char[26],
                symbols = new char[7] { '-', '\'', '"', '!', '.', ',', '?' };
            for (int i = 0; i < letters.Length - 1; i++)
            {
                bigLetters[i] = Convert.ToChar(letters[i].ToString().ToUpper());
            }
            Random random = new Random();
            byte min = 6, max = 20 + 1, countSymbols = Convert.ToByte(random.Next(min, max));
            string password = "";
            byte _checker = 0, letterChecker = 0, numberChecker = 0;
            bool isNumber = false;
            for (int i = 0; i <= countSymbols; i++)
            {
                switch (random.Next(0, 5))
                {
                    case 1:
                        password += random.Next(0, 10);
                        break;
                    case 2:
                        password += letters[random.Next(0, letters.Length - 1)];
                        break;
                    case 3:
                        password += bigLetters[random.Next(0, bigLetters.Length - 1)];
                        break;
                    case 4:
                        password += symbols[random.Next(0, symbols.Length - 1)];
                        break;
                    default:
                        password += "_";
                        break;
                }
                //любые две цифры подряд недопустимы.
                if (char.IsNumber(password, i))
                {
                    if (isNumber == true)
                    {
                        switch (random.Next(0, 3))
                        {
                            case 1:
                                password = password.Remove(i, 1);
                                password = password.Insert(i, Convert.ToString(letters[random.Next(0, letters.Length - 1)]));
                                break;
                            case 2:
                                password = password.Remove(i, 1);
                                password = password.Insert(i, Convert.ToString(bigLetters[random.Next(0, bigLetters.Length - 1)]));
                                break;
                            default:
                                password = password.Remove(i, 1);
                                password = password.Insert(i, Convert.ToString(symbols[random.Next(0, symbols.Length - 1)]));
                                break;
                        }
                        isNumber = false;
                    }
                    else isNumber = true;
                }
                else isNumber = false;
                //должен быть ровно один символ подчеркивания, 
                if (password[i] == '_')
                {
                    _checker += 1;
                    if (_checker > 1)
                    {
                        switch (random.Next(0, 3))
                        {
                            case 1:
                                password = password.Remove(i, 1);
                                password = password.Insert(i, Convert.ToString(letters[random.Next(0, letters.Length - 1)]));
                                break;
                            case 2:
                                password = password.Remove(i, 1);
                                password = password.Insert(i, Convert.ToString(bigLetters[random.Next(0, bigLetters.Length - 1)]));
                                break;
                            default:
                                password = password.Remove(i, 1);
                                password = password.Insert(i, Convert.ToString(symbols[random.Next(0, symbols.Length - 1)]));
                                break;
                        }
                        _checker -= 1;
                    }
                }
                //хотя бы две заглавных буквы,
                if (char.IsUpper(password, i))
                {
                    letterChecker += 1;
                }
                //не более 5 цифр,
                if (char.IsNumber(password, i))
                {
                    numberChecker += 1;
                    if (numberChecker > 5)
                    {
                        switch (random.Next(0, 3))
                        {
                            case 1:
                                password = password.Remove(i, 1);
                                password = password.Insert(i, Convert.ToString(letters[random.Next(0, letters.Length - 1)]));
                                break;
                            case 2:
                                password = password.Remove(i, 1);
                                password = password.Insert(i, Convert.ToString(bigLetters[random.Next(0, bigLetters.Length - 1)]));
                                break;
                            default:
                                password = password.Remove(i, 1);
                                password = password.Insert(i, Convert.ToString(symbols[random.Next(0, symbols.Length - 1)]));
                                break;
                        }
                        numberChecker -= 1;
                    }
                }
            }
            if (letterChecker < 2)
            {
                int i = 0;
                while ((letterChecker != 2) || (i == 20))
                {
                    if (Convert.ToString(password.ToCharArray(i, 1)) != "_")
                    {
                        password = password.Remove(i);
                        password = 
                        password.Insert(i, Convert.ToString(bigLetters[random.Next(0, bigLetters.Length - 1)]));
                        letterChecker += 1;
                        i += 1;
                    }
                }
            }
            if (_checker == 0)
            {
                password = password.Remove(password.Length - 1);
                password += '_';
            }
            Console.WriteLine(password);
        }
    }
}
