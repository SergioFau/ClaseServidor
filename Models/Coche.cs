using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Spectre.Console;

namespace Classes;

public class Coche
{
    public int Id { get; }
    public string Marca { get; }
    public string Color { get; }
    public DateTime FechaEntrada { get; }
    public decimal Precio { get; }
    public bool Comprado { get;set; }
    public DateTime? FechaCompra { get;set; }
    public int? IdComprador { get;set; }
    public int Caballos { get; }

    public static List<Coche> listadoCoches{ get;set; }

    public Coche(int id, string marca, string color, DateTime fechaEntrada, decimal precio, bool comprado, DateTime? fechaCompra, int? idComprador, int caballos)
    {
        Id = id;
        Marca = marca;
        Color = color;
        FechaEntrada = fechaEntrada;
        Precio = precio;
        Comprado = comprado;
        FechaCompra = fechaCompra;
        IdComprador = idComprador;
        Caballos = caballos;
    }

    public static void comprarCoche(Coche coche, string? respuesta, string nombreUsuario)
    {
        if (respuesta != null)
        {
            if(respuesta == "S" || respuesta == "N"){
                if(respuesta == "S"){
                    if(coche.Comprado == true){
                        AnsiConsole.Markup("[underline yellow]El coche ya esta comprado[/]");
                    }
                  var usuario = Usuario.recogerUsuarioPorNombre(nombreUsuario);
                    if(coche.Precio > usuario.Dinero){
                        AnsiConsole.Markup("[underline yellow]No tienes suficiente saldo.[/]");
                    }else{
                        usuario.Dinero = usuario.Dinero - coche.Precio;
                        coche.IdComprador = usuario.Id;
                        coche.FechaCompra = DateTime.Now;
                        coche.Comprado = true;
                        AnsiConsole.Markup("[underline green]Coche comprado[/]");
                    }
                }
                if(respuesta == "N"){
                        AnsiConsole.Markup("[underline red]No has comprado el coche.[/]");
                }
            }
        }
    }

    public static string serializar(List<Coche> listadoCoches){
      string cocheJson = JsonConvert.SerializeObject(listadoCoches);
        return cocheJson;
    } 

    public static List<Coche> recogerListado(){
        return listadoCoches;
    }
        
    public static List<Coche> recogerListadoCoches(){
        string coches = recogerJsonCoches();
        List<Coche> cochesJson = deserializarCoches(coches); 
        Coche.listadoCoches = cochesJson;       
        return cochesJson;
    }

    public static string recogerJsonCoches(){
        string coches;
        //var reader = new StreamReader("C:\\Users\\sergiofau\\Desktop\\CosasSergio\\ClaseServidor\\Recursos\\Coches.json");
        var reader = new StreamReader($@"{Path.GetFullPath(Directory.GetCurrentDirectory())}/Recursos/Coches.json");
        coches = reader.ReadToEnd();
        return coches;
    }

    public static List<Coche> deserializarCoches(string coches){
        return JsonConvert.DeserializeObject<List<Coche>>(coches);
    }
}