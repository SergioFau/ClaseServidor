namespace Classes;
using Spectre.Console;

class Menu {

public static void ListadoCoches(){
    List<Coche> listadoCochesMostrar = Coche.recogerListado();
    var table = new Table();
    // Add some columns
    table.AddColumn("Id");
    table.AddColumn("Marca");
    table.AddColumn("Color");
    table.AddColumn("FechaEntrada");
    table.AddColumn("Precio");
    table.AddColumn("Caballos");
    table.AddColumn("Comprado");
    table.AddColumn("FechaCompra");
    table.AddColumn("IdComprador");
    foreach (var coche in listadoCochesMostrar)
    {
        table.AddRow(coche.Id.ToString(), coche.Marca.ToString(), coche.Color.ToString(), coche.FechaEntrada.ToString(), coche.Precio.ToString(), coche.Caballos.ToString(), coche.Comprado.ToString(), coche.FechaCompra.ToString(), coche.IdComprador.ToString());
    }

// Render the table to the console
AnsiConsole.Write(table);

    }

public static void ListadoCochesFiltro(string textoFiltro){
    List<Coche> listadoCochesMostrar = Coche.recogerListado();
    var table = new Table();
    // Add some columns
    table.AddColumn("Id");
    table.AddColumn("Marca");
    table.AddColumn("Color");
    table.AddColumn("FechaEntrada");
    table.AddColumn("Precio");
    table.AddColumn("Caballos");
    table.AddColumn("Comprado");
    table.AddColumn("FechaCompra");
    table.AddColumn("IdComprador");
    foreach (var coche in listadoCochesMostrar)
    {
         if (coche != null)
            {
                if (coche.Marca.Contains(textoFiltro))
                {
                    table.AddRow(coche.Id.ToString(), coche.Marca.ToString(), coche.Color.ToString(), coche.FechaEntrada.ToString(), coche.Precio.ToString(), coche.Caballos.ToString(), coche.Comprado.ToString(), coche.FechaCompra.ToString(), coche.IdComprador.ToString());
                }
            }
    }

// Render the table to the console
AnsiConsole.Write(table);

}
}