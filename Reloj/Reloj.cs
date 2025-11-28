namespace RelojY;

public class Reloj
{
    private string _hora { get; set; } = "00";
    private string _minutos { get; set; } = "00";
    private string _segundos{ get; set; } = "00";
    private double _pila { get; set; } = 3;
    
    private static readonly Reloj _instancia = new Reloj();
    public static Reloj Instancia => _instancia;

    public void Time(int hora, int minutos, int segundos)
    {
        if (_pila > 0)
        {
            string hour = RevisarHora(hora);
            string minutes = RevisarMinutosYSegundos(minutos);
            string seconds = RevisarMinutosYSegundos(segundos);

            _hora = hour;
            _minutos = minutes;
            _segundos = seconds;
        }
        else
        {
            Console.WriteLine("La pila ya no funciona, recárgala");
        }

        _pila--;

    }
    
    public void EstablecerHora(int hora)
    {
        if (_pila > 0)
        {
            string hour = RevisarHora(hora);
            _hora = hour;
        }
        else
        {
            Console.WriteLine("La pila ya no funciona, recárgala");
        }

        _pila -= 0.33;

    }
    
    public void EstablecerMinutos(int minutos)
    {
        if (_pila > 0)
        {
            string minutes = RevisarMinutosYSegundos(minutos);
            _minutos = minutes;
        }
        else
        {
            Console.WriteLine("La pila ya no funciona, recárgala");
        }

        _pila -= 0.33;

    }
    
    public void EstablecerSegundos(int segundos)
    {
        if (_pila > 0)
        {
            string seconds = RevisarMinutosYSegundos(segundos);
            _minutos = seconds;
        }
        else
        {
            Console.WriteLine("La pila ya no funciona, recárgala");
        }

        _pila -= 0.33;

    }
    
    
    private string RevisarHora(int hora)
    {
        string horaString = "";
        if (hora < 0 || hora > 24)
        {
            throw new ArgumentOutOfRangeException();
        }
        
        if (hora < 10 && hora > 0)
        {
            horaString = "0" + hora;
        }
        else
        {
            horaString += hora;
        }
        
        return horaString;
    }
    
    private string RevisarMinutosYSegundos(int tiempo)
    {
        string tiempoString = "";
        if (tiempo < 0 || tiempo > 60)
        {
            throw new ArgumentOutOfRangeException();
        }
        
        if (tiempo < 10 && tiempo > 0)
        {
            tiempoString = "0" + tiempo;
        }
        else
        {
            tiempoString += tiempo;
        }

        return tiempoString;
    }

    public void RecargaPila(double numRecargas)
    {
        _pila = numRecargas;
    }
    
    public override string ToString() {
        return $"[La hora es: {_hora}/{_minutos}/{_segundos}]";
    }
}
