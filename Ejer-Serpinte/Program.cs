using System.Text;
using static System.Console;
using Ejer_Serpinte;
using Serilog;
using Serilog.Sinks.SystemConsole;

const string linea = "--------------------------------------";


//..................................................
var random = Random.Shared;
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
OutputEncoding = Encoding.UTF8;
var serpiente1 = new Serpiente();
Main(serpiente1);

//..................................................
void Main(Serpiente serpiente)
{
    Juego(serpiente);
}
void Juego(Serpiente serpiente)
{
    int tiempo = 60;
    int ciclos = 0;
    int cuerpo = serpiente1._cuerpoContador;
    WriteLine($"Comienza la vida de la serpiente");
    while (tiempo>0 && cuerpo >= 1)
    {
        WriteLine("");
        WriteLine("");
        WriteLine("--Serpiente🐍:");
        serpiente1.MostrarSerpiente();
        serpiente.Juego();
        tiempo--;
        ciclos++;
        WriteLine("");
        WriteLine(linea);
        WriteLine($"--La serpiente tiene {serpiente._vida} años 🐍");
        cuerpo = serpiente1._cuerpoContador;
        WriteLine($"--La serpiente tiene {cuerpo} anillas 👌");
        WriteLine(linea);
        
        Thread.Sleep(400);
        Clear();
    }
    WriteLine(linea);
    WriteLine("--La serpiente ha perdido todo el cuerpo, ha muerto 💀!!!!");
    WriteLine($"--Número de ciclos: {ciclos}");
    WriteLine(linea);
}