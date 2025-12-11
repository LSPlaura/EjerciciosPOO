namespace StarWars.Models;

public class Droide
{
    private Random _random = Random.Shared;

    public enum TipoDroide
    {
        SW348,
        SW477,
        SW421
    }
    
    public required TipoDroide Tipo { get; init; }
    
    public int EnergiaMax { get; init; }
    private int _energiaActual;
    
    public int PosicionFila { get; set; }
    public int PosicionColumna { get; set; }

    private int _defensa;
    private int _velocidad;
    private int _esquivar;

    //hacer
    public bool destruido;

    /// <summary>
    /// Constructor que establece las características del droides (campos) según sdu tipo
    /// </summary>
    public Droide(int fila, int columna)
    {
        if (Tipo == TipoDroide.SW348)
        {
            EnergiaMax = 50;
            _defensa = 8;
            _velocidad = _random.Next(8);
        }
        
        if (Tipo == TipoDroide.SW421)
        {
            EnergiaMax = 100;
            _defensa = _random.Next(9, 12);
            _velocidad = _random.Next(5);
        }

        if (Tipo == TipoDroide.SW477)
        {
            EnergiaMax = _random.Next(100, 150);
            _defensa = 4;
            _velocidad = _random.Next(10, 30);
            _esquivar = _velocidad;
        }
        _energiaActual = EnergiaMax;
        PosicionFila = fila;
        PosicionColumna = columna;
    }

    /// <summary>
    /// Método para mover el droide a una posición random
    /// </summary>
    /// <param name="array"></param>
    /// <param name="fila"></param>
    /// <param name="columna"></param>
    public int[] Mover(Droide?[,] array, int fila, int columna)
    {
        //mirar más adelante
        int[][] posicionesVacias = new int[8][];
        int contador = 0;
        for (var i = fila - 1; i == i + 1; i++)
        {
            for (var j = columna - 1; j == j + 1; j++)
            {
                if (i >= 0 && i <= Config.Configuracion && j >= 0 && j <= Config.Configuracion && array[i, j] == null)
                {
                    posicionesVacias[contador] = new int[]
                    {
                        fila,
                        columna
                    };
                }
            }
        }

        int indice = _random.Next(contador);
        var pocicion = posicionesVacias[indice];

        return pocicion;
    }
}