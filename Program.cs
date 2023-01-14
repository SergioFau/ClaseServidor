using Classes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using Spectre.Console;

try
{    
    Console.ForegroundColor = ConsoleColor.Black;
    Console.BackgroundColor = ConsoleColor.Blue;
    List<Usuario> listadoUsuarios = new List<Usuario>();
    listadoUsuarios = Usuario.recogerListadoUsuarios();
    List<Coche> listadoCoches = new List<Coche>();
    listadoCoches = Coche.recogerListadoCoches();    
    Console.WriteLine("");
    Lineas.Pisoche();
    var dinero = Environment.GetEnvironmentVariable("dinero");
    if(dinero == "Euro"){
        Lineas.Euros();
    }
    if(dinero == "Dolar"){
        Lineas.Dolares();
    }
    Console.WriteLine(""); 
    Lineas.Bienvenido();   
    Console.WriteLine(""); 
   
    bool inicioSesion = false;
    string? variableNombre = "";
    string? variableContraseña = "";
    while (inicioSesion == false)
    {
        Console.WriteLine("");
        Console.WriteLine("Nombre:");
        variableNombre = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine("Contraseña:");
        variableContraseña = Console.ReadLine();
        Console.WriteLine("");
        inicioSesion = Usuario.inicioSesionUsuario(variableNombre, variableContraseña, listadoUsuarios);
        if (inicioSesion)
        {
            Lineas.DatosCorrectos();
        }
        else
        {
            Lineas.DatosIncorrectos();
        }
    }
    Console.WriteLine("");
    bool verListado = false;
    if (variableNombre == "Sergio")
    {
        Console.WriteLine("");
        Console.WriteLine("Bienvenido Señor " + variableNombre);
        bool repetir = false; //USAREMOS ESTA VARIABLE PARA VOLVER AL PRINCIPIO CUANDO HAYAMOS AÑADIDO ALGO
        while (repetir == false)
        {
            Console.WriteLine("");
            Console.WriteLine("Quiere añadir un coche o ver el listado");
            Console.WriteLine("");
            Console.WriteLine("1 - Añadir Coche");
            Console.WriteLine("2 - Ver Listado");
            string variablePrivado = Console.ReadLine();
            switch (variablePrivado)
            {
                case "1":
                    try
                    { 
                    Console.WriteLine("Vamos a añadir un nuevo coche");
                    Console.WriteLine("");
                    Console.WriteLine("Marca");
                    string marca = Console.ReadLine();
                    Console.WriteLine("Color");
                    string color = Console.ReadLine();
                    Console.WriteLine("Precio");
                    string precio = Console.ReadLine();
                    Console.WriteLine("Caballos");
                    string caballos = Console.ReadLine();
                    Coche cocheanadir = new Coche(listadoCoches.LastOrDefault().Id + 1, marca, color, DateTime.Now, Convert.ToDecimal(precio), false, null, null, Int32.Parse(caballos));
                    listadoCoches.Add(cocheanadir);
                    Console.WriteLine("");
                    AnsiConsole.Markup("[underline green]Coche añadido[/]");
                    }
                    catch(Exception ex)
                    {                    
                        AnsiConsole.Markup("[underline red]Ha habido un error a la hora de añadir el coche[/]");
                        Console.WriteLine("");
                        AnsiConsole.Markup("[underline red]"+ex.Message+"[/]");
                        LogController.WriteLog("Ha habido un error a la hora de añadir el coche: " + ex.Message);
                        Console.WriteLine("");
                    }     
                   
                    break;
                case "2":
                    verListado = true;
                    repetir = true;
                    break;
            }
        }
    }
    if (variableNombre == "Alex")
    {
        verListado = true;
    }
    Console.WriteLine("Bienvenido Usuario " + variableNombre);
    while (verListado == true)
    {
        Console.WriteLine("");               
        Lineas.ListadoCochesTexto();
                /*foreach (var coche in listadoCoches)
                {
                    Console.WriteLine("Id: " + coche.Id + " Coche: " + coche.Marca);
                }*/
                Menu.ListadoCoches();
                Console.WriteLine("");
                Console.WriteLine("Si quiere ver los detalles del coche, indique el Id del coche");
                Console.WriteLine("Si quiere filtrar pulsa 0");
                string numeroListadoCoche = "0";
                numeroListadoCoche = Console.ReadLine();
                try{
                if (numeroListadoCoche == "0")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Escribe el texto para filtrarlo (solo marcas)");
                    string textoFiltro = "";
                    textoFiltro = Console.ReadLine();
                    Menu.ListadoCochesFiltro(textoFiltro);                   
                    
                    Console.WriteLine("");
                    Console.WriteLine("Si quiere ver los detalles del coche, indique el id del coche");
                    Console.WriteLine("");

                    string numeroListadoCocheFiltrado = "0";
                    numeroListadoCocheFiltrado = Console.ReadLine();
                    foreach (var coche2 in listadoCoches.Where(x => x.Id.ToString() == numeroListadoCocheFiltrado))
                    {
                        if (coche2 != null)
                        {
                            Console.WriteLine("Coche: " + coche2.Marca);
                            Console.WriteLine("Color: " + coche2.Color);
                            Console.WriteLine("Fecha Entrada : " + coche2.FechaEntrada);
                            Console.WriteLine("Precio: " + coche2.Precio);
                            Console.WriteLine("Caballos: " + coche2.Caballos);
                            Console.WriteLine("Comprado: " + (coche2.Comprado == false ? "No" : "Si"));
                            Console.WriteLine("");
                            Console.WriteLine("¿Quieres comprar este coche?");
                            Console.WriteLine("S - Si");
                            Console.WriteLine("N - No");
                            string comprarCocheString = "";
                            comprarCocheString = Console.ReadLine();
                            Coche.comprarCoche(coche2, comprarCocheString, variableNombre);
                            Console.WriteLine("");
                        }
                    }
                }                           
                else
                {
                    foreach (var coche in listadoCoches.Where(x => x.Id.ToString() == numeroListadoCoche))
                    {
                        if (coche != null)
                        {
                            Console.WriteLine("Coche: " + coche.Marca);
                            Console.WriteLine("Color: " + coche.Color);
                            Console.WriteLine("Fecha Entrada : " + coche.FechaEntrada);
                            Console.WriteLine("Precio: " + coche.Precio);
                            Console.WriteLine("Caballos: " + coche.Caballos);
                            Console.WriteLine("Comprado: " + (coche.Comprado == false ? "No" : "Si"));
                            Console.WriteLine("");
                            Console.WriteLine("¿Quieres comprar este coche?");
                            Console.WriteLine("S - Si");
                            Console.WriteLine("N - No");
                            string comprarCocheString = "";
                            comprarCocheString = Console.ReadLine();
                            Coche.comprarCoche(coche, comprarCocheString, variableNombre);
                            Console.WriteLine("");
                        }
                    }
                }
               }catch(Exception ex){
                AnsiConsole.Markup("[underline red]"+ex.Message+"[/]");
                LogController.WriteLog(ex.Message);
               }
        
    }
    Console.Clear();
}
catch(Exception ex){
                AnsiConsole.Markup("[underline red]"+ex.Message+"[/]");
                LogController.WriteLog(ex.Message);
}