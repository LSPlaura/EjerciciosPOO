namespace Ejer_Serpinte;
using static System.Console;

public class Serpiente
{
    public int _cuerpoContador { get; private set; } = 1;
    private Anillas[] _cuerpo = new Anillas[1];
    public int _vida { get; private set; }  = 0;

    private enum Anillas{
        R,
        V,
        A
    }

    public Serpiente()
    {
        var anilla = AnillaRandom();
        _cuerpo[0] = anilla;
    }

    public void MostrarSerpiente()
    {
        for (var i = 0; i < _cuerpo.Length; i++)
        {
            if (_cuerpo[i] == Anillas.R)
            {
                Write($"[❤️]");
            }
            if (_cuerpo[i] == Anillas.A)
            {
                Write($"[💙]");
            }
            if (_cuerpo[i] == Anillas.V)
            {
                Write($"[💚]");
            }
        }
    }
    
    public void CrecerCuerpos()
    {
        _cuerpoContador++;
        Array.Resize(ref _cuerpo, _cuerpoContador);
        _cuerpo[_cuerpoContador - 1] = AnillaRandom();
    }

    public void MudarPiel()
    {
        for (var i = 0; i < _cuerpo.Length; i++)
        {
            var a = AnillaRandom();
            _cuerpo[i] = a;
        }
    }
    
    public void DecrecerCuerpo()
    {
        _cuerpoContador -=1;
        if (_cuerpoContador > 0)
        {
            Array.Resize(ref _cuerpo, _cuerpoContador);
        }
    }
    
    public void Crecer ()
    {
        _vida++;
    }

    public void Juego()
    {
        Crecer();
        int n = CalcularRandom();
            if (_vida >= 0 && _vida <= 10 || n >= 0 && n <= 80 )
            {
                CrecerCuerpos();
            } else
            {
                MudarPiel();
            }
            if (_vida > 10 || n >= 0 && n <= 90 )
            {
                DecrecerCuerpo();
            } else
            {
                MudarPiel();
            }
    }

    private Anillas AnillaRandom()
    {
        var random = Random.Shared;
        var n = random.Next(0, 3);
        return (Anillas)n;
    }
    
    int CalcularRandom()
    {
        var random = Random.Shared;
        return random.Next(0, 100);
    }
    
}