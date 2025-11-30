namespace Ejercicio_Nido.Models;
using static Ejercicio_Nido.Utils.Utildades;
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

    //otro constructor de serpiente para poder hacer una mangosta de tipo serpiente y que asi se puede guardwar en el array nido
    //hago que su _cuerpoContador sea 0 pera que no pueda hacer ninguna accion que le corresponda a una serpiente
    public Serpiente(int num)
    {
        Anillas[] _cuerpo = new Anillas[0];
        _cuerpoContador = 0;
    }

    public void MostrarSerpiente()
    {
        if (_cuerpoContador > 0)
        {
            for (var i = 0; i < _cuerpo.Length; i++)
            {
                if (_cuerpo[i] == Anillas.R)
                {
                    Write($"❤️");
                }else if (_cuerpo[i] == Anillas.A)
                {
                    Write($"💙");
                }else
                {
                    Write($"💚");
                }
            }
        }
    }
    
    private void CrecerCuerpos()
    {
        if (_cuerpoContador > 0)
        {
            _cuerpoContador++;
            Array.Resize(ref _cuerpo, _cuerpoContador);
            _cuerpo[_cuerpoContador - 1] = AnillaRandom();
        }
    }

    private void MudarPiel()
    {
        if (_cuerpoContador > 0)
        {
            for (var i = 0; i < _cuerpo.Length; i++)
            {
                var a = AnillaRandom();
                _cuerpo[i] = a;
            }
        }
    }
    
    private void DecrecerCuerpo()
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

    public void SerpienteVida()
    {
        if (_cuerpoContador > 0)
        {
            Crecer();
            int n = random.Next(0, 101);
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
    }

    private Anillas AnillaRandom()
    {
        var n = random.Next(0, 3);
        return (Anillas)n;
    }
}