using System;
 
namespace FigurasGeometricas
{
    public class Circulo
    {
        private double radio;
 
        public Circulo(double radio)
        {
            this.radio = radio;
        }
 
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }
 
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
 
        public void MostrarInformacion()
        {
            Console.WriteLine("=== INFORMACIÓN DEL CÍRCULO ===");
            Console.WriteLine($"Radio: {radio:F2}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
            Console.WriteLine();
        }
    }
 
    public class Cuadrado
    {
        private double lado;
 
        public Cuadrado(double lado)
        {
            this.lado = lado;
        }
 
        public double CalcularArea()
        {
            return lado * lado;
        }
 
        public double CalcularPerimetro()
        {
            return 4 * lado;
        }
 
        public void MostrarInformacion()
        {
            Console.WriteLine("=== INFORMACIÓN DEL CUADRADO ===");
            Console.WriteLine($"Lado: {lado:F2}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
            Console.WriteLine();
        }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PROGRAMA DE FIGURAS GEOMÉTRICAS ===");
            Console.WriteLine();
 
            // Circulo
            Console.Write("Ingrese el radio del círculo: ");
            double radio = Convert.ToDouble(Console.ReadLine());
            Circulo circulo = new Circulo(radio);
            circulo.MostrarInformacion();
 
            // Cuadrado
            Console.Write("Ingrese el lado del cuadrado: ");
            double lado = Convert.ToDouble(Console.ReadLine());
            Cuadrado cuadrado = new Cuadrado(lado);
            cuadrado.MostrarInformacion();
 
            Console.WriteLine("=== FIN DEL PROGRAMA ===");
        }
    }
}
 




