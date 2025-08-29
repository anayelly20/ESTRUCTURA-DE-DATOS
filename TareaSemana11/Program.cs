using System;
using System.Collections.Generic;
using System.Linq;

namespace TraductorBasico
{
    class Program
    {
        private static Dictionary<string, string> englishToSpanish = new Dictionary<string, string>();
        private static Dictionary<string, string> spanishToEnglish = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            Console.WriteLine("=== TRADUCTOR BÁSICO ===");
            InicializarDiccionarios();

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\n==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                
                switch (Console.ReadLine())
                {
                    case "1": TraducirFrase(); break;
                    case "2": AgregarPalabra(); break;
                    case "0": continuar = false; break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            }
        }

        static void InicializarDiccionarios()
        {
            var palabras = new Dictionary<string, string>
            {
                {"time", "tiempo"}, {"person", "persona"}, {"year", "año"}, {"way", "camino"},
                {"day", "día"}, {"thing", "cosa"}, {"man", "hombre"}, {"world", "mundo"},
                {"life", "vida"}, {"hand", "mano"}, {"part", "parte"}, {"child", "niño"},
                {"eye", "ojo"}, {"woman", "mujer"}, {"place", "lugar"}, {"work", "trabajo"},
                {"week", "semana"}, {"case", "caso"}, {"point", "punto"}, {"government", "gobierno"}
            };

            foreach (var palabra in palabras)
            {
                englishToSpanish[palabra.Key] = palabra.Value;
                spanishToEnglish[palabra.Value] = palabra.Key;
            }
        }

        static void TraducirFrase()
        {
            Console.Write("Idioma (es/en): ");
            string idioma = Console.ReadLine().ToLower();
            Console.Write("Frase: ");
            string frase = Console.ReadLine();

            var palabras = frase.Split(' ');
            var resultado = new List<string>();

            foreach (string palabra in palabras)
            {
                string palabraLimpia = new string(palabra.Where(char.IsLetter).ToArray()).ToLower();
                string puntuacion = new string(palabra.Where(c => !char.IsLetter(c)).ToArray());

                if (idioma == "en" && englishToSpanish.ContainsKey(palabraLimpia))
                    resultado.Add(englishToSpanish[palabraLimpia] + puntuacion);
                else if (idioma == "es" && spanishToEnglish.ContainsKey(palabraLimpia))
                    resultado.Add(spanishToEnglish[palabraLimpia] + puntuacion);
                else
                    resultado.Add(palabra);
            }

            Console.WriteLine($"Traducción: {string.Join(" ", resultado)}");
        }

        static void AgregarPalabra()
        {
            Console.Write("Palabra en inglés: ");
            string ingles = Console.ReadLine().ToLower();
            Console.Write("Traducción en español: ");
            string espanol = Console.ReadLine().ToLower();

            englishToSpanish[ingles] = espanol;
            spanishToEnglish[espanol] = ingles;
            Console.WriteLine("¡Palabra agregada!");
        }
    }
}