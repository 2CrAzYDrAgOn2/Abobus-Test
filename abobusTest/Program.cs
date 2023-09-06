public class MyData
{
    private bool myBoolean;
    private string myString;

    public MyData(bool myBoolean, string myString)
    {
        this.myBoolean = myBoolean;
        this.myString = myString;
    }

    public bool IsMyBoolean()
    {
        return myBoolean;
    }

    public void SetMyBoolean(bool myBoolean)
    {
        this.myBoolean = myBoolean;
    }

    public string GetMyString()
    {
        return myString;
    }

    public void SetMyString(string myString)
    {
        this.myString = myString;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Запуск программы...");
        MyData[] busPlaces = new MyData[30];

        for (int i = 0; i < busPlaces.Length; i++)
        {
            busPlaces[i] = new MyData(false, "");
        }

        while (true)
        {
            Console.WriteLine("Введите 1, чтобы посмотреть все места в автобусе.");
            Console.WriteLine("Введите 2, чтобы забронировать место в автобусе.");
            Console.WriteLine("Введите 3, чтобы разбронировать место в автобусе.");
            Console.WriteLine("Введите 4, чтобы выйти из программы.");
            string statement = Console.ReadLine();

            switch (statement)
            {
                case "1":
                    int count = 1, trueCount = 0, falseCount = 0;
                    foreach (MyData place in busPlaces)
                    {
                        Console.WriteLine(count + " " + place.IsMyBoolean() + " " + place.GetMyString());
                        count++;
                        if (place.IsMyBoolean())
                        {
                            trueCount++;
                        }
                        else
                        {
                            falseCount++;
                        }
                    }
                    Console.WriteLine("Мест свободно: " + falseCount + "\nМест занято: " + trueCount);
                    break;

                case "2":
                    Console.WriteLine("Введите номер места, которое вы хотели бы забронировать: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Введите фамилию человека: ");
                    string placeName = CapitalizeFirstLetter(Console.ReadLine());
                    if (index >= 0 && index < busPlaces.Length)
                    {
                        if (!busPlaces[index].IsMyBoolean())
                        {
                            busPlaces[index].SetMyBoolean(true);
                            busPlaces[index].SetMyString(placeName);
                            Console.WriteLine("Место под номером " + (index + 1) + " забронировано человеком с фамилией " + placeName + ".");
                        }
                        else
                        {
                            Console.WriteLine("Место под номером " + (index + 1) + " уже забронировано человеком с фамилией " + placeName + ".");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введен недопустимый номер места.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Введите номер места, которое вы хотели бы разбронировать: ");
                    int indexUn = int.Parse(Console.ReadLine()) - 1;
                    if (indexUn >= 0 && indexUn < busPlaces.Length)
                    {
                        if (busPlaces[indexUn].IsMyBoolean())
                        {
                            busPlaces[indexUn].SetMyBoolean(false);
                            busPlaces[indexUn].SetMyString("");
                            Console.WriteLine("Место под номером " + (indexUn + 1) + " разбронировано.");
                        }
                        else
                        {
                            Console.WriteLine("Место под номером " + (indexUn + 1) + " не занято");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введен недопустимый номер места.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Выход из программы...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Неправильный ввод. Пожалуйста, выберите один из вариантов (1-4).");
                    break;
            }
        }
    }

    public static string CapitalizeFirstLetter(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }
        string firstLetter = char.ToUpper(text[0]).ToString();
        string restOfText = text.Substring(1).ToLower();
        return firstLetter + restOfText;
    }
}