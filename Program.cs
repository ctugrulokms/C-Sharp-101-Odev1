using System;

namespace odev1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> int_list;
            List<string> str_list;
            string sentence;
            Methods methods = new();

            // 1. soru
            Console.Write("Lütfen pozitif bir sayı giriniz: ");
            int number_count = Console.ReadLine()!.ParseNew();
            
            int_list = methods.ProcessInputNTimes(number_count, 2);

            methods.Write(int_list);

            // 2. soru
            Console.Write("Lütfen pozitif iki sayı giriniz: ");
            number_count = Console.ReadLine()!.ParseNew();
            int divider = Console.ReadLine()!.ParseNew();

            int_list = methods.ProcessInputNTimes(number_count, divider);

            methods.Write(int_list);

            // 3. soru
            Console.Write("Lütfen pozitif bir sayı giriniz: ");
            number_count = Console.ReadLine()!.ParseNew();

            str_list = methods.ProcessInputNTimes(number_count);

            string[] str_arr = str_list.ToArray();
            str_list = str_arr.Reverse().ToList();

            methods.Write(str_list);

            // 4. soru
            Console.Write("Lütfen bir cümle yazınız: ");
            sentence = Console.ReadLine()!;

            List<string> word_list = sentence.Split(" ").ToList<string>();
            Console.WriteLine("There are " + word_list.Count() + " words in this sentence.");

            sentence = sentence.Replace(" ",String.Empty);
            char[] char_arr = sentence.ToCharArray(); 
            List<char> letter_list = char_arr.ToList();
            Console.WriteLine("There are " + letter_list.Count() + " letters in this sentence.");
            methods.Write(letter_list);
        }
    }

    class Methods
    {
        public List<string> ProcessInputNTimes(int number)
        {
            List<string> list = new List<string>();
    
            for(int i = 0; i < number; i++)
            {
                Console.Write("Lütfen bir kelime giriniz(" + (number-i) + " tane kaldı): ");
                string temp = Console.ReadLine()!;
                list.Add(temp);
            }
            return list;
        }
        public List<int> ProcessInputNTimes(int number, int divider)
        {
            List<int> list = new List<int>();

            for(int i = 0; i < number; i++)
            {
                Console.Write("Lütfen pozitif bir sayı giriniz(" + (number-i) + " tane kaldı): ");
                int temp = Console.ReadLine()!.ParseNew();

                if(temp == divider || temp % divider == 0)
                    list.Add(temp);
            }
            return list;            
        }

        public void Write(List<int> list)
        {
            Console.WriteLine("********************");
            foreach(int item in list)
                Console.Write(item + " ");
            Console.WriteLine("");
            Console.WriteLine("********************");
        }

        public void Write(List<string> list)
        {
            Console.WriteLine("********************");
            foreach(string item in list)
                Console.Write(item + " ");
            Console.WriteLine("");
            Console.WriteLine("********************");
        }

        public void Write(List<char> list)
        {
            Console.WriteLine("********************");
            foreach(char item in list)
                Console.Write(item + " ");
            Console.WriteLine("");
            Console.WriteLine("********************");
        }

    }

    public static class Extension
    {
        public static int ParseNew(this string param)
        {
            int value = 0;
            try
            {
                value = int.Parse(param);
                if(value <= 0)
                    throw new MyException();
                
            }
            catch (MyException ex)
            {
                ex.NegativeArgumentException();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }

            return value;
        }
    }

    public class MyException : ApplicationException
    {
        public void NegativeArgumentException()
        {
            Console.WriteLine("This input is smaller than or equal to 0.");
        }
    }
}
