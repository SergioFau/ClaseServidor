using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Classes;

public class Usuario
{
    public int Id { get; }
    public string Nombre { get; }
    public string Contraseña { get; }
    public decimal Dinero { get; set; }
    public bool Administrador { get; }
    public DateTime FechaCreacion { get; }

    public static List<Usuario> listaUsuarios = new List<Usuario>();

    public Usuario(int id, string nombre, string contraseña, decimal dinero, bool administrador, DateTime fechaCreacion)
    {
        Id = id;
        Nombre = nombre;
        Contraseña = contraseña;
        Dinero = dinero;
        Administrador = administrador;
        FechaCreacion = fechaCreacion;
    }
/*
    public static void anadirUsuarioLista(Usuario usuario)
    {
        listaUsuarios.Add(usuario);
    }*/

    public static bool inicioSesionUsuario(string? nombre, string? contraseña, List<Usuario> listaUsuarios)
    {
        bool inicio = false;
        if (nombre != null && contraseña != null)
        {
            foreach (var usuario in listaUsuarios)
            {              
                if (usuario.Nombre == nombre && usuario.Contraseña == contraseña)
                {
                    inicio = true;
                }
            }
        }
        return inicio;
    }

    public static Usuario recogerUsuarioPorNombre(string nombre){
        foreach(var usuario in listaUsuarios){
            if(usuario.Nombre == nombre){
                return usuario;
            }
        }
        return null;
    } 
    /*
    public static string serializar(List<Usuario> listadoUsuarios){
      string usuarioJson = JsonConvert.SerializeObject(listadoUsuarios);
        return usuarioJson;
    }   
*/
    
    public static List<Usuario> recogerListadoUsuarios(){
        string personas = recogerJsonPersonas();
        List<Usuario> usuariosJson = deserializarUsuarios(personas); 
        listaUsuarios = usuariosJson;
        return usuariosJson;
    }

    public static string recogerJsonPersonas(){
        string personas;
        //var reader = new StreamReader("C:\\Users\\sergiofau\\Desktop\\CosasSergio\\ClaseServidor\\Recursos\\Usuarios.json");
        var reader = new StreamReader($@"{Path.GetFullPath(Directory.GetCurrentDirectory())}/Recursos/Usuarios.json");
        personas = reader.ReadToEnd();
        return personas;
    }
    public static List<Usuario> deserializarUsuarios(string personas){
        return JsonConvert.DeserializeObject<List<Usuario>>(personas);
    }

}

