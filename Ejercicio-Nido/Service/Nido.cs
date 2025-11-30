using Ejercicio_Nido.Models;
namespace Ejercicio_Nido.Service;
using static Ejercicio_Nido.Utils.Utildades;
using static System.Console;

public class Nido
{
    private Serpiente?[] _nido = new Serpiente?[20];
    private Serpiente _mangosta = new Serpiente(5);

    public void MostrarNido()
    {
        log.Information("--Mostrando el nido 🪹");
        for (var i = 0; i < _nido.Length; i++)
        {
            if (_nido[i] is { } algo)
            {
                Write("Serpiente:");
                algo.MostrarSerpiente();
                WriteLine();
            }
            else
            {
                Write($"[ ]");
                WriteLine();
            }
        }

        log.Information("--Se ha terminado de mostrar el nido 🪹");
        ContarSerpientes();
        Thread.Sleep(500);
    }

    public void Inicializar()
    {
        log.Information("Inicializando el nido 🪹");
        //int numSerpientes = random.Next(3, 16);
        int numSerpientes = 5;

        while (numSerpientes > 0)
        {
            int indice = random.Next(0, 20);
            _nido[indice] = new Serpiente();
            numSerpientes--;
        }

        log.Information("Se ha inicializado el nido 🪹");
    }

    private int InsertarMangosta()
    {
        log.Information("--Insertando mangosta 🦀");
        int indice = -1;
        var prob = random.Next(0, 101);
        if (prob >= 0 && prob <= 50)
        {
            var posiciones = PosicionesVacias();
            indice = random.Next(0, posiciones.Length);
            _nido[indice] = _mangosta;
            log.Information($"--Mangosta insertada en la posición: {indice} 🦀");
        }
        else
        {
            log.Information($"--Mangosta no se ha podido meter en el nido!!! 😀");
        }

        return indice;
    }

    public void MangostaMata()
    {
        int mangostaPosicion = InsertarMangosta();
        var posiciones = PosicionesOcupadas();
        int serpientesMorir = random.Next(0, 5);
        var serpientesSeleccionadas = PosicionesSerpientes(serpientesMorir, posiciones);
        int numMuertas = 0;

        if (mangostaPosicion != -1)
        {
            log.Information($"Mangosta 🦀 tiene que matar💀 a: {serpientesMorir} 🐍");

            while (serpientesMorir > 0)
            {
                for (var i = 0; i < serpientesSeleccionadas.Length; i++)
                {
                    int prob = random.Next(0, 101);
                    if ((prob >= 0 && prob <= 20))
                    {
                        int indice = serpientesSeleccionadas[i];
                        _nido[indice] = null;
                        numMuertas++;
                        log.Information($"Mangosta ha matado a la serpiente de la posición {indice}.... 💀💀");

                    }
                    else
                    {
                        log.Information($"--La serpiente ha sobrevivido!!!!");
                    }

                    serpientesMorir--;
                }
            }

            _nido[mangostaPosicion] = null;
            log.Information($"--La mangosta se ha ido, pero volverá... 🦀");
        }
    }

    private int[] PosicionesSerpientes(int serpientes, int[] posiciones)
    {
        //log.Information("Eligiendo que serpientes van a morir...");
        int indice1 = -1;
        int indiceReal = -1;
        bool isUsado;
        int contador = 0;
        int[] indicesUsados = new int[serpientes];

        while (serpientes > 0)
        {
            do
            {
                indice1 = random.Next(0, posiciones.Length);
                indiceReal = posiciones[indice1];
                isUsado = IsIndiceUsado(indiceReal, indicesUsados);
            } while (isUsado);

            indicesUsados[contador] = indiceReal;
            contador++;
            
            serpientes--;
        }

        //Console.WriteLine(string.Join(", ", serpientesAMorir));
        // Console.WriteLine(string.Join(", ", posiciones));
        // Console.WriteLine(string.Join(", ", indicesUsados));
        //log.Information("--Serpientes a morir elegidas...");
        return indicesUsados;
    }

    private bool IsIndiceUsado(int indice, int[] array)
    {
        bool isUsado = false;
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] == indice)
            {
                isUsado = true;
            }
        }

        return isUsado;
    }

    public void NacenSerpientes()
    {
        log.Information($"--Iniciando el nacimiento de serpientes 🪺");
        //num calcula cuantas serpientes pueden nacer 1-3
        int num = random.Next(1, 4);
        log.Information($"--Nº de serpientes 🐍 que pueden nacer {num} 🍼");
        int numNacidas = 0;

        //el bucle se encarga de que se haga tantas num veces

        do
        {
            //log.Information($"(Serpientes naciendo!!!)");
            int celdasVacias = PosicionesVaciasContador();
            if (celdasVacias == 0)
            {
                break;
            }

            //prob calcula si esas serpeintes nacen o no
            int prob = random.Next(0, 101);

            if (prob >= 0 && prob <= 20)
            {
                int celdaVacia = CeldaVacia();
                _nido[celdaVacia] = new Serpiente();
                numNacidas++;
            }

            num--;
        } while (num != 0);

        log.Information($"--Serpientes nacidas: {numNacidas} 🍼");

    }

    //La primera celda vacia que encuentre
    private int CeldaVacia()
    {
        //log.Information($"Calculando celda vacía");
        for (var i = 0; i < _nido.Length; i++)
        {
            if (_nido[i] is null)
            {
                return i;
            }
        }

        log.Error("No encuentra ninguna posicion vacia");
        return -1;
    }

    //Todas las celdas vacias para poder sortear en cual se va a spawnear la mangosta
    private int PosicionesVaciasContador()
    {
        //log.Information("Empezando: PosicionesVaciasContador");
        int contador = 0;
        for (var i = 0; i < _nido.Length; i++)
        {
            if (_nido[i] is null)
            {
                contador++;
            }
        }

        //log.Information("Saliendo: PosicionesVaciasContador");
        return contador;
    }

    private int[] PosicionesVacias()
    {
        int contador = 0;
        //log.Information("Empezando: PosicionesVacias");
        int num = PosicionesVaciasContador();
        int[] posiciones = new int[num];

        for (var i = 0; i < _nido.Length; i++)
        {
            if (_nido[i] == null)
            {
                posiciones[contador] = i;
                contador++;
            }
        }

        //log.Information("Saliendo: PosicionesVacias");
        return posiciones;
    }

    private int PosicionesOcupadasContador()
    {
        //log.Information("Empezando: PosicionesOcupadasContador");
        int contador = 0;
        for (var i = 0; i < _nido.Length; i++)
        {
            if (_nido[i] is { } serpiente)
            {
                contador++;
            }
        }

        //log.Information("Saliendo: PosicionesOcupadasContador");
        return contador;
    }

    private int[] PosicionesOcupadas()
    {
        //log.Information("Empezando: PosicionesOcupadas");
        int num = PosicionesOcupadasContador();
        int[] posiciones = new int[num];
        int contador = 0;

        for (var i = 0; i < _nido.Length; i++)
        {
            if (_nido[i] != null)
            {
                posiciones[contador] = i;
                contador++;
            }
        }

        // Console.WriteLine(string.Join(", ", posiciones));
        // log.Information("Saliendo: PosicionesOcupadas");
        return posiciones;
    }

    public int ContarSerpientes()
    {
        //log.Information($"(Contando serpientes)");
        int num = 0;
        for (var i = 0; i < _nido.Length; i++)
        {
            if (_nido[i] is { } serpiente && serpiente != _mangosta)
            {
                num++;
            }
        }

        //log.Information($"(Serpientes contadas)");
        log.Information($"--Hay: {num} serpientes🐍");
        return num;

    }

    public void SerpienteVida()
    {
        log.Information($"--Serpientes viviendo su vida (creciendo) 🐾👯‍♀️");
        for (var i = 0; i < _nido.Length; i++)
        {
            if (_nido[i] is { } serpiente)
            {
                serpiente.SerpienteVida();
                MuerteSerpiente(i);
                //log.Information($"{serpiente._vida}");
            }
        }
        //log.Information($"(Serpiente viviendo su vida)");
    }

    private void MuerteSerpiente(int i)
    {
        if (_nido[i]?._cuerpoContador == 0)
        {
            _nido[i] = null;
            log.Information($"--Una serpiente ha muerto de vejez 💀");
        }
    }
}
