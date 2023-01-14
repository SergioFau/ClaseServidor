namespace Classes;
using Spectre.Console;

class Lineas {

    public static void Pisoche(){
    AnsiConsole.Write(new FigletText("PISOCHE").Color(Color.Green));
    }

    public static void ListadoCochesTexto(){
    AnsiConsole.Write(new FigletText("LISTADO DE COCHES").Color(Color.Yellow));
    }

    public static void Bienvenido(){
    AnsiConsole.Write(new Markup("[bold]Bienvenido a la tienda de Pisoche, donde se venden coches.[/]"));
    Console.WriteLine("");
    AnsiConsole.Write(new Markup("[bold]Primero de todo tenemos que iniciar sesión[/]"));
    }
    public static void DatosCorrectos(){
    AnsiConsole.Markup("[underline green]Datos Correctos[/]");
    }
    public static void DatosIncorrectos(){
    AnsiConsole.Markup("[underline red]Datos Incorrectos[/]");
    }
}
