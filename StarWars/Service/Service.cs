using StarWars.Config;

namespace StarWars.Service;

public class Service
{
    public Configuracion ConfiguracioValidada(int? colum, int? droides, int? tiempo)
    { 
        //control de nulos
      //si un parametro es nulo se usan los parametros por defecto
        if (colum == null)  colum = Parámetros.ColumDefault;
        if (droides == null) droides = Parámetros.DroidesDefault;;
        if(tiempo == null) tiempo = Parámetros.TiempoDefault;;
        
        //requisitos
        //si un parametro no cumple los requisitos se le asigna el parametro por defecto
        if (colum < Parámetros.MinTiempo || colum > Parámetros.MaxDroides) colum = Parámetros.ColumDefault;;
        if (droides < Parámetros.MinDroides || droides > Parámetros.MaxDroides) droides = Parámetros.DroidesDefault;;
        if (tiempo < Parámetros.MinTiempo || tiempo > Parámetros.MaxTiempo) tiempo = Parámetros.TiempoDefault;;
        
        //logica
        //si hay mas droides que celdas se les asigna los parametros por defecto
        if (colum * colum > droides)
        {
            colum = Parámetros.ColumDefault;;
            droides = Parámetros.DroidesDefault;;
        }

        var columnFin = (int)colum;
        var droidesFin = (int)droides;
        var tiempoFin = (droidesFin);
        
        return new Configuracion { Num_Columnas = columnFin, Num_Droides = droidesFin, Tiempo = tiempoFin };
    }
}