using System.Text;
using Ejercicio_Nido.Service;
using static System.Console;
using static Ejercicio_Nido.Utils.Utildades;

//..................................................
OutputEncoding = Encoding.UTF8;

Main();
//..................................................

// 3. MÉTODO MAIN 
void Main() {
    log.Information("----Iniciando la ejecución principal (Main).-----");
    var nido = new Nido();
    Simulacion(nido);
    log.Information("-----Ha terminado la simulación------");
}

void Simulacion(Nido nido)
{
    int ciclo = 0;
    int time = 100;
    int contadorMangosta = 0;
    
    nido.Inicializar();
    
    int serpientes = nido.ContarSerpientes();
    
    while(time > 0 && serpientes > 0)
    {
        log.Information($"-----------------------Ciclo de la simulación:{ciclo}-----------------------");
        //Lógica del primer turno
        if (time == 100)
        {
            nido.MostrarNido();
            contadorMangosta++;
            time--;
            ciclo++;
            continue;
        }
        nido.MostrarNido();
        nido.SerpienteVida();
        nido.NacenSerpientes();
        if (contadorMangosta % 10 == 0)
        {
            nido.MangostaMata();
        }
        contadorMangosta++;
        time--;
        serpientes = nido.ContarSerpientes();
        ciclo++;
        Thread.Sleep(500);
    }
}