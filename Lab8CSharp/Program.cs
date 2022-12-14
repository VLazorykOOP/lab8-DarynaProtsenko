//1.9 - gmail
using System.Text.RegularExpressions;

StreamReader filein1 = new StreamReader("D:\\CSharp\\8\\1.txt");
string text1 = filein1.ReadToEnd();
Console.WriteLine(text1);
filein1.Close();
string pattern = @"^[\w.+\-]+@gmail\.com";
MatchCollection matches1 = Regex.Matches(text1, pattern, RegexOptions.Multiline);
Console.WriteLine("Matches: " + matches1.Count);
var gmails = new List<string>();
foreach (Match match in matches1)
{
    gmails.Add(match.Value);
}
Console.WriteLine("1. Нічого не змінювати");
Console.WriteLine("2. Видалити email.");
Console.WriteLine("3. Замінити email.");
int.TryParse(Console.ReadLine(), out var input);
switch (input)
{
    case 1:
        {
            break;
        }
    case 2:
        {
            Console.WriteLine($"Розмір масиву: {gmails.Count}");
            Console.WriteLine("Виберіть, який індекс видалити: ");
            int.TryParse(Console.ReadLine(), out var toRemove);
            gmails.RemoveAt(toRemove);
            break;
        }
    case 3:
        {
            Console.WriteLine($"Розмір масиву: {gmails.Count}");
            Console.WriteLine("Виберіть, який індекс змінити: ");
            int.TryParse(Console.ReadLine(), out var toChange);
            Console.WriteLine("Введіть нову дату: ");
            gmails[toChange] = Console.ReadLine();
            break;
        }
}
var fileout = new StreamWriter(new FileStream("D:\\CSharp\\8\\1out.txt",
    FileMode.Create,
    FileAccess.Write));
foreach (string gmail in gmails)
{
    fileout.WriteLine(gmail);
}
fileout.Close();
Console.WriteLine();
//2.9. Замінити всі шістнадцяткові цифри ('0', '1', ..., '9', 'a'-'f' ) на знак '+';
StreamReader filein2 = new StreamReader("D:\\CSharp\\8\\2.txt");
string text2 = filein2.ReadToEnd();
Console.WriteLine($"Original text: {text2}");
filein2.Close();
string pattern2ForEdit = @"0|1|2|3|4|5|6|7|8|9|a|b|c|d|e|f";
string text2Edited = Regex.Replace(text2, pattern2ForEdit, "+");
Console.WriteLine($"Text edited: {text2Edited}");
var fileout2 = new StreamWriter(new FileStream("D:\\CSharp\\8\\2out.txt",
    FileMode.Create,
    FileAccess.Write));
fileout2.WriteLine(text2Edited);
fileout2.Close();
Console.WriteLine();
//3.9. Задано текст, слова в якому розділені пробілами і розділовими
//знаками.Розробити програму, яка в словах непарної довжини
//цього тексту вилучає середню літеру.
StreamReader filein3 = new StreamReader("D:\\CSharp\\8\\3.txt");
string text3 = filein3.ReadToEnd();
Console.WriteLine($"Original text: {text3}");
filein3.Close();
string patternForWords = @"\w+";
MatchCollection matches3 = Regex.Matches(text3, patternForWords, RegexOptions.Multiline);
Console.WriteLine("Matches: " + matches3.Count);
var words = new List<string>();
foreach (Match match in matches3)
{
    if((match.Value.Length % 2) == 1)
    {
        int center = match.Value.Length / 2;
        words.Add(match.Value.Remove(center, 1));
    }
    else
    {
        words.Add(match.Value);
    }
}
var result3 = "";
foreach(var word in words)
{
    result3 += word;
    result3 += " ";
}
Console.WriteLine("Result: " + result3);
var fileout3 = new StreamWriter(new FileStream("D:\\CSharp\\8\\3out.txt",
    FileMode.Create,
    FileAccess.Write));
fileout3.WriteLine(result3);
fileout3.Close();
Console.WriteLine();
//4.9. Дана послідовність із n дійсних чисел. Записати всі ці числа у
//файл.Вивести на екран всі компоненти файлу з непарними
//номерами, більші заданого числа. 
Console.WriteLine("Введіть n: ");
int.TryParse(Console.ReadLine(), out var n);
var numbers = new List<double>();
for (var i = 0; i < n; i++)
{
    numbers.Add(int.Parse(Console.ReadLine()));
}
var fileout4 = new BinaryWriter(new FileStream("D:\\CSharp\\8\\4.bin",
    FileMode.Create,
    FileAccess.Write));
foreach (double number in numbers)
{
    fileout4.Write(number);
}
fileout4.Close();
BinaryReader filein4 = new BinaryReader(new FileStream("D:\\CSharp\\8\\4.bin", FileMode.Open));
Console.WriteLine("Введіть число: ");
int.TryParse(Console.ReadLine(), out var num);
var readNumbers = new List<double>();
for (var i = 0; i < numbers.Count; i++)
{
    readNumbers.Add(filein4.ReadDouble());
    if (i % 2 == 1 && readNumbers.Last() > num) Console.WriteLine(readNumbers.Last());
}
