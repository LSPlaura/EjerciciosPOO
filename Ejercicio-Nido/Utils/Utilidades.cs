using Serilog;
using Serilog.Core;
namespace Ejercicio_Nido.Utils;
public static class Utildades
{ 
        //porque no me deja poner el var
        public static Random random = Random.Shared;
        public static Logger log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
}