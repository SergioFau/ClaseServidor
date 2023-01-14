APLICACIÓN DE CONSOLA CREADA POR SERGIO FAU

Es una consola donde tu puedes:

1 - Iniciar Sesión (tienes un admin y un usuario normal)
Admin -> Nombre: Sergio Contraseña: 123

2- Existe la posibilidad siendo admin de añadir nuevos coches y de ver el listado de los que ya existen.

3- Llevamos un registro de algunos errores mediante los cuales salen reflejados en un fichero de logs (la ruta esta puesta para mi local)
File.AppendAllText("C:\\Users\\sergiofau\\Desktop\\CosasSergio\\ClaseServidor\\RutaLog\\NombreLog.txt", sb.ToString());

4- Tras mostrar el listado de coches, puedes o bien entrar dentro de una ficha del coche en especifico o puedes filtrar a traves del nombre de las marcas.
Ej: Escribimos Ferr y aparecera el id 1 -> Ferrari.

5- Una vez dentro de la ficha del coche, puedes comprarlo, eso provoca que el coche pase a estar comprado y se comprobara si el dinero de la persona es suficiente para comprar el coche (se descuenta el dinero del coche al saldo del usuario)

6- Se ha creado una variable de entorno mediante la cual, alteramos los valores de los coches y el dinero de los usuarios.

7- El estilo de la consola ha sido modificado con la libreria Spectre.Console, tambien se ha añadido unos modelos donde se almacenan frases o metodos.

8- Los datos de los usuarios y los coches son sacados de unos json que se encuentran en la carpeta recursos
