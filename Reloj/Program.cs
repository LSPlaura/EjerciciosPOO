using System;
using RelojY;

//Comprobando que hace time
Reloj.Instancia.Time(6, 38, 32);
Console.WriteLine($"{Reloj.Instancia.ToString()}");

//Comprobando que hace EstablecerHora
Reloj.Instancia.EstablecerHora(23);
Console.WriteLine($"{Reloj.Instancia.ToString()}");

//Comprobando que hace EstablecerMinutos
Reloj.Instancia.EstablecerMinutos(22);
Console.WriteLine($"{Reloj.Instancia.ToString()}");

//Comprobando que hace EstablecerSegundos
Reloj.Instancia.EstablecerSegundos(11);
Console.WriteLine($"{Reloj.Instancia.ToString()}");

//Tratando de acabar con la pila para comprobar si funciona
Reloj.Instancia.Time(1, 11, 22);
Console.WriteLine($"{Reloj.Instancia.ToString()}");
Reloj.Instancia.Time(2, 11, 22);
Console.WriteLine($"{Reloj.Instancia.ToString()}");

//La pila ya no funciona
Reloj.Instancia.Time(3, 11, 22);
Console.WriteLine($"{Reloj.Instancia.ToString()} la pila no funciona, la hora se ha parado");

//Recargar
Reloj.Instancia.RecargaPila(5);
Reloj.Instancia.Time(7, 55, 55);
Console.WriteLine($"{Reloj.Instancia.ToString()}");

