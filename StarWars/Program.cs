
//....................................

using System.Text;
using System.Text.RegularExpressions;
using StarWars.Config;
using StarWars.Service;
using static System.Console;

//....................................

Console.Title = "POO-StarWars: antidroides";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

//...................................

Main(args);
Console.WriteLine("\n👋 Presiona una tecla para salir...");
Console.ReadKey();
return;
//....................................

void Main(string?[]? args)
{
    Service service = new Service();
    var configuracion = ValidarArgs(args, service);
}

Configuracion ValidarArgs(string?[]? args, Service service)
{
    if(args != null && args.Length == 3)
    {
        int? columnas = BuscarValorEnArgs(args, "num_columnas");

        int? droides = BuscarValorEnArgs(args, "num_droides");

        int? tiempo = BuscarValorEnArgs(args, "tiempo");
        
        return service.ConfiguracioValidada(columnas, droides, tiempo);
    }

    return PedirConfiguracion(service);
}

int? BuscarValorEnArgs(string?[] args, string buscar)
{
    var buscarLimpio = buscar.ToLower().Trim();
    for (var i = 0; i < args.Length; i++) 
    {
        if (args[i] != null)
        {
            var parts = args[i]!.Split(':');
            if (parts.Length == 2)
            {
                var claveActual = parts[0].ToLower().Trim();
                if (claveActual == buscarLimpio && int.TryParse(parts[1].Trim(), out int num)) return num ;
            }
        }
    }
    return null;
}

Configuracion PedirConfiguracion(Service service)
{
    var regexColumn = new Regex(@"^[56789]$");
    var regexDroides = new Regex(@"^\d{1,2}$");
    var regexTiempo = new Regex(@"^\d{3}$");
    
    WriteLine("--Ejecutando la personalización de la configuración");
    
    WriteLine("Inserta los valores de columna:");
    var colum = ReadLine();
    while (string.IsNullOrEmpty(colum) || !regexColumn.IsMatch(colum))
    {
        WriteLine("Ha habido algún error, inténtalo de nuevo.");
        WriteLine($"Recuerda que los límites son: {Parámetros.MaxColum}-{Parámetros.MinColum}");
        colum = ReadLine();
    }
    WriteLine("--Tablero establecido con éxito");
    
    WriteLine("Inserta el número de droides deseado:");
    var droides = ReadLine();
    while (string.IsNullOrEmpty(droides) || !regexDroides.IsMatch(droides))
    {
        WriteLine("Ha habido algún error, inténtalo de nuevo.");
        WriteLine($"Recuerda que los límites son: {Parámetros.MaxDroides}-{Parámetros.MinDroides}");
        droides = ReadLine();
    }
    WriteLine("--Droides establecidos con éxito");
    
    WriteLine("Inserta el tiempo deseado:");
    var tiempo = ReadLine();
    while (string.IsNullOrEmpty(tiempo) || !regexTiempo.IsMatch(tiempo))
    {
        WriteLine("Ha habido algún error, inténtalo de nuevo.");
        WriteLine($"Recuerda que los límites son: {Parámetros.MaxTiempo}-{Parámetros.MinTiempo}");
        tiempo = ReadLine();
    }
    WriteLine("--Tiempo establecido con éxito");
    
    var columInt = int.Parse(colum);
    var droidesInt = int.Parse(droides);
    var tiempoInt = int.Parse(tiempo);

    var configuracion = service.ConfiguracioValidada(columInt, droidesInt, tiempoInt);
    return configuracion;
}