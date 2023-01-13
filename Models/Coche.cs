using System;

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

    
    public static string comprarCoche(Coche coche, string? respuesta, string nombreUsuario)
    {
        string inicio = "";
        if (respuesta != null)
        {
            if(respuesta == "S" || respuesta == "N"){
                if(respuesta == "S"){
                    if(coche.Comprado == true){
                        inicio = "El coche ya esta comprado";
                        return inicio;
                    }
                  var usuario = Usuario.recogerUsuarioPorNombre(nombreUsuario);
                    if(coche.Precio > usuario.Dinero){
                        inicio = "No tienes suficiente saldo.";
                    }else{
                        usuario.Dinero = usuario.Dinero - coche.Precio;
                        coche.IdComprador = usuario.Id;
                        coche.FechaCompra = DateTime.Now;
                        coche.Comprado = true;
                        inicio = "Coche comprado";
                    }

                }
                if(respuesta == "N"){
                    inicio = "No has comprado el coche.";
                }
            }
        }

        return inicio;
    }
}