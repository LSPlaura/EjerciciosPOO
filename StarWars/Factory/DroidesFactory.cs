using StarWars.Config;
using StarWars.Models;

namespace StarWars.Factory;

public class DroidesFactory(Configuracion config)
{
    private Random _random = Random.Shared;
    private int _numDroides = config.Num_Droides;

    public void Inicializar(Droide?[,] tablero)
    {
        int contador = _numDroides;
        int fila = -1;
        int columna = -1;
        while (contador != 0)
        {
            do
            {
                fila = _random.Next(0, config.Num_Columnas);
                columna = _random.Next(0, config.Num_Columnas);
            } while (tablero[fila, columna] != null);
            
            int porcentaje = _random.Next(0, 100);
            if (porcentaje >= 0 && porcentaje <= Parámetros.AparicionSW447)
            { 
                tablero[fila, columna] = new Droide(fila, columna) { Tipo = Droide.TipoDroide.SW477 };
                
            }else if(porcentaje > Parámetros.AparicionSW447 && porcentaje <= Parámetros.AparicionSW348)
            {
                tablero[fila, columna] = new Droide(fila, columna) { Tipo = Droide.TipoDroide.SW348 };
                
            }
            else
            {
                tablero[fila, columna] = new Droide(fila, columna) { Tipo = Droide.TipoDroide.SW421 };
            }
            contador--;
        }
    }
}