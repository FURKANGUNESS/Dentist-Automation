using System;
using System.Collections.Generic;
using ConsoleApp1.Entities.Abstract;

namespace ConsoleApp1
{
    // Konsoldan girdi almak, mesajlar bastırmak bilgiler vermek için yardımcı static class oluşturulur.
    public static class Helper
    {
        // Belli bir aralıkta sayısal değer alır, hata durumunda null döner
        public static int? GetNumericInput(int min, int max)
        {
            int input;
            
            var status = int.TryParse(Console.ReadLine(), out input);

            if (!status)
            {
                Console.WriteLine("Girilen değer sayı olmak zorundadır.");
                return null;
            }

            if (input < min || input > max)
            {
                Console.WriteLine($"Girilen değer [{min}, {max}] aralığında olmalıdır.");
                return null;
            }

            return input;
        }

        // Menüler arası geçişleri yapmak için oluşturulan var3 metod
        public static int? MenuInput(string title, List<string> subTitles)
        {
            Console.WriteLine($"--{title}--\n");

            var index = 1;
            foreach (var subTitle in subTitles)
            {
                Console.WriteLine($"{index++} - {subTitle}");
            }
            Console.Write("\nBir Seçim Giriniz: ");

            var input =  GetNumericInput(1, subTitles.Count);
            
            Console.Clear();

            return input;
        }

        // Tek bir metinsel veri almaya olanak sağlayan metod
        public static string SingleTextInput(string title)
        {
            Console.Write($"{title} : ");
            var input = Console.ReadLine();
            Console.Clear();
            return input;
        }
        
        // Çok adet sayısal veri almaya olanak sağlayan metod
        public static List<string> MultiTextInput(string title, List<string> inputTitles)
        {
            Console.WriteLine($"--{title}--\n");
            
            var inputs = new List<string>();
            var index = 1;
            foreach (var inputTitle in inputTitles)
            {
                Console.Write($"{index++} - {inputTitle} : ");
                var input = Console.ReadLine();
                inputs.Add(input);
            }

            Console.Clear();

            return inputs;
        }

        // Seçim yaptırma fonksiyonu
        // Parametre olarak T tipinde liste alır ve bunları rakamlarla eşleştirir, kullanıcının girdiği sayıya
        // denk gelen liste elemanını döndürür.
        public static T MakeSelection<T>(string title, List<T> entities)
            where T : Entity
        {
            Console.WriteLine($"--{title}--");
            
            var dictionary = CreateSelectionDictionary(entities);
            var index = 1;

            foreach (var entity in entities)
            {
                Console.WriteLine($"{index++} - {entity}");
            }
            
            Console.Write("\nBir Seçim Giriniz: ");

            var input = GetNumericInput(1, entities.Count);

            if (input == null)
            {
                return null;
            }

            return dictionary[input.Value];
        }
        
        // Yukarıdaki fonksiyonun yardımcı fonksiyonudur
        private static Dictionary<int, T> CreateSelectionDictionary<T>(List<T> entities)
            where T : Entity
        {
            var dictionary = new Dictionary<int, T>();
            var index = 1;

            foreach (var entity in entities)
            {
                dictionary[index++] = entity;
            }

            return dictionary;
        }
    }
}