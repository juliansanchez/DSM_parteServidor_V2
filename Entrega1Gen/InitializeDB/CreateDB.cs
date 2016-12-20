
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entrega1GenNHibernate.EN.GrayLine;
using Entrega1GenNHibernate.CEN.GrayLine;
using Entrega1GenNHibernate.CAD.GrayLine;

// añado referencia a CP
using Entrega1GenNHibernate.CP.GrayLine;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes
                // creamos las entidades, las Cad y los CEN para realizar operaciones
                // Inicializamos valores de los objetos que vamos a crear

                #region Usuario/administrador

                IUsuarioCAD _IUsuarioCAD = new UsuarioCAD ();
                UsuarioEN usuario1EN, usuario2adminEN, usuario3EN = new UsuarioEN ();
                UsuarioCEN usuarioCEN = new UsuarioCEN (_IUsuarioCAD);

                // Usuario ADMINISTRADOR
                IAdministradorCAD _IAdministradorCAD = new AdministradorCAD ();
                AdministradorEN administradorEN = new AdministradorEN ();
                AdministradorCEN administradorCEN = new AdministradorCEN (_IAdministradorCAD);


                // Inicializamos los atributos de las clases
                //Usuario1
                usuario1EN = new UsuarioEN ();
                usuario1EN.Email = "emailUsu1";
                usuario1EN.Nombre = "Cliente1Nombre";
                usuario1EN.Edad = 18;
                usuario1EN.Fecha_alta = DateTime.Today;
                usuario1EN.Foto = @"http://www.webconsultas.com/sites/default/files/styles/encabezado_articulo/public/articulos/perfil-resilencia.jpg?itok=iQzjOtzd";
                usuario1EN.Bibliografia = "Soy el primer usuario de esta web y parece que puede molar";
                usuario1EN.Baneado = false;
                usuario1EN.Contrasenya = "12345";



                //Usuario2
                usuario2adminEN = new UsuarioEN ();
                usuario2adminEN.Email = "emailUsu2";
                usuario2adminEN.Nombre = "Cliente2Nombre";
                usuario2adminEN.Edad = 18;
                usuario2adminEN.Fecha_alta = DateTime.Today;
                usuario2adminEN.Foto = @"http://www.sintetia.com/wp-content/uploads/2012/05/Foto-perfil.jpg";
                usuario2adminEN.Bibliografia = "Soy el Admin de esta web y parece que puede molar";
                usuario2adminEN.Baneado = false;
                usuario2adminEN.Contrasenya = "1234";

                //Usuario3
                usuario3EN = new UsuarioEN ();
                usuario3EN.Email = "emailUsu3";
                usuario3EN.Nombre = "Cliente3Nombre";
                usuario3EN.Edad = 24;
                usuario3EN.Fecha_alta = DateTime.Today;
                usuario3EN.Foto = @"https://www.socialtools.me/blog/wp-content/uploads/2016/04/foto-de-perfil.jpg";
                usuario3EN.Bibliografia = "Soy un usuario 3 y pienso que soy un crack";
                usuario3EN.Baneado = false;
                usuario3EN.Contrasenya = "12345ABCD";

                // registro de usuarios
                var usu1 = usuarioCEN.Registrarse (usuario1EN.Nombre, usuario1EN.Contrasenya, usuario1EN.Email, usuario1EN.Edad, usuario1EN.Fecha_alta, usuario1EN.Foto, usuario1EN.Bibliografia, usuario1EN.Baneado, 0);
                // administrador
                var admin1 = administradorCEN.New_ (usuario2adminEN.Nombre, usuario2adminEN.Contrasenya, usuario2adminEN.Email, usuario2adminEN.Edad, usuario2adminEN.Fecha_alta, usuario2adminEN.Foto, usuario2adminEN.Bibliografia, usuario2adminEN.Baneado, 0);
                // Tercer usuario
                var usu3 = usuarioCEN.Registrarse (usuario3EN.Nombre, usuario3EN.Contrasenya, usuario3EN.Email, usuario3EN.Edad, usuario3EN.Fecha_alta, usuario3EN.Foto, usuario3EN.Bibliografia, usuario3EN.Baneado, 0);

                #endregion

                #region Categoria
                // categorias

                ICategoriaCAD _ICategoriaCAD = new CategoriaCAD ();
                CategoriaEN categoria_1EN = new CategoriaEN ();
                CategoriaEN categoria_2EN = new CategoriaEN ();
                CategoriaEN categoria_3EN = new CategoriaEN ();
                CategoriaEN categoria_4EN = new CategoriaEN ();
                CategoriaEN categoria_5EN = new CategoriaEN ();
                CategoriaCEN categoriaCEN = new CategoriaCEN (_ICategoriaCAD);

                /* Creamos las categorias y almacenamos su OID */
                categoria_1EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.aventura;
                var cat1 = categoriaCEN.New_ (categoria_1EN.Nombre_categoria);
                categoria_2EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.fantasia;
                var cat2 = categoriaCEN.New_ (categoria_2EN.Nombre_categoria);
                categoria_3EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.misterio;
                var cat3 = categoriaCEN.New_ (categoria_3EN.Nombre_categoria);
                categoria_4EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.romance;
                var cat4 = categoriaCEN.New_ (categoria_4EN.Nombre_categoria);
                categoria_5EN.Nombre_categoria = Entrega1GenNHibernate.Enumerated.GrayLine.Tipo_categoriaEnum.terror;
                var cat5 = categoriaCEN.New_ (categoria_5EN.Nombre_categoria);

                /* Creamos dos listas de categorias para los diferentes libros */
                System.Collections.Generic.List<int> listaCategorias = new List<int>();
                System.Collections.Generic.List<int> listaCategorias2 = new List<int>();

                listaCategorias.Add (cat1);
                listaCategorias.Add (cat3);

                listaCategorias2.Add (cat2);
                listaCategorias2.Add (cat4);
                listaCategorias2.Add (cat5);

                #endregion

                #region Libro
                // Libros
                /* Creamos los libros y uno de ellos de pago */
                ILibroCAD _ILibroCAD = new LibroCAD ();
                IPagoCAD _IPagoCAD = new PagoCAD ();
                IGratuitoCAD _IGratuitoCAD = new GratuitoCAD ();
                GratuitoEN libro1EN = new GratuitoEN ();
                GratuitoEN libro2EN = new GratuitoEN ();
                PagoEN libro3EN = new PagoEN ();
                PagoEN libro4EN = new PagoEN ();

                GratuitoCEN gratuitoCEN = new GratuitoCEN (_IGratuitoCAD);
                PagoCEN PagoCEN = new PagoCEN (_IPagoCAD);

                LibroCEN libroCEN = new LibroCEN ();

                //Libro 1 ----PUBLICADO
                // libro1EN = new LibroEN();
                libro1EN.Titulo = "El Quijote";
                libro1EN.Portada = @"http://listas.eleconomista.es/system/lists/000/003/990/medium/quijopor.jpg?1447029044";
                libro1EN.Descripcion = "Novela de Cervantes";
                libro1EN.Fecha = DateTime.Today;
                libro1EN.Publicado = true;
                libro1EN.Baneado = false;
                libro1EN.Num_denuncias = 0;

                /*Libro 2*/
                // libro2EN = new LibroEN();
                libro2EN.Titulo = "El Castigo";
                libro2EN.Portada = @"http://3.bp.blogspot.com/-sTfJtm6oT6g/UXHJg8st8kI/AAAAAAAABEQ/DUBdoSQ9Urw/s1600/castigo_divino_med.jpg";
                libro2EN.Descripcion = "Novela de Pedrito";
                libro2EN.Fecha = DateTime.Today;
                libro2EN.Publicado = true;
                libro2EN.Baneado = false;
                libro2EN.Num_denuncias = 0;

                //Libro 3 ---- De Pago
                // libro3EN = new PagoEN();
                libro3EN.Titulo = "Libro de Pago";
                libro3EN.Portada = @"http://1.bp.blogspot.com/-DjtcEjvGgiU/URhRiN8ae4I/AAAAAAAAB0Y/dgMU3SOCxOk/s1600/Libro-que-sonr%C3%ADe.jpg";
                libro3EN.Descripcion = "Novela de Cervantes de Pago";
                libro3EN.Fecha = DateTime.Today;
                libro3EN.Publicado = true;
                libro3EN.Baneado = false;
                libro3EN.Num_denuncias = 0;
                libro3EN.Precio = 12;
                libro3EN.Pagado = false;


                //Libro 4 ----PUBLICADO
                libro4EN.Titulo = "El Don apacible";
                libro4EN.Portada = @"https://clubdecatadores.files.wordpress.com/2012/10/el-don-apacible-libro-3-mijac3adl-shc3b3lojov.jpg";
                libro4EN.Descripcion = "Novela Rusa de Mihayl Sholoyov";
                libro4EN.Fecha = DateTime.Today;
                libro4EN.Publicado = true;
                libro4EN.Baneado = false;
                libro4EN.Num_denuncias = 0;

                // lista de usuarios
                // creamos listas de usuarios y categorias para crear los libros
                System.Collections.Generic.List<String> listaUsuarios = new List<string>();
                listaUsuarios.Add (usuario1EN.Email);
                CapituloCAD _ICapituloCAD = new CapituloCAD ();
                /* Se crean dos libros gratuitos y uno de pago
                 * Se guardan sus OIDS para inicializar la bbdd */
                int idLibro1 = gratuitoCEN.New_ (libro1EN.Titulo, libro1EN.Portada, libro1EN.Descripcion, libro1EN.Fecha, libro1EN.Publicado, usu1, listaCategorias, libro1EN.Baneado, libro1EN.Num_denuncias, 0, 0);
                int idLibro2 = gratuitoCEN.New_ (libro2EN.Titulo, libro2EN.Portada, libro2EN.Descripcion, libro2EN.Fecha, libro2EN.Publicado, admin1, listaCategorias, libro2EN.Baneado, libro2EN.Num_denuncias, 0, 0);
                int idLibro3 = PagoCEN.New_ (libro3EN.Titulo, libro3EN.Portada, libro3EN.Descripcion, libro3EN.Fecha, libro3EN.Publicado, usu1, listaCategorias, libro3EN.Baneado, libro3EN.Num_denuncias, 0, 0, 9, false);
                int idLibro4 = PagoCEN.New_ (libro4EN.Titulo, libro4EN.Portada, libro4EN.Descripcion, libro4EN.Fecha, libro4EN.Publicado, usu3, listaCategorias2, libro4EN.Baneado, libro4EN.Num_denuncias, 0, 0, 9, false);

                #endregion
                /* Se crean 4 capitulos, los dos primeros para un libro gratuito
                 * y los dos segundo para un libro de pago */
                #region Capitulo
                // Composicion
                CapituloEN capituloEN = new CapituloEN ();
                CapituloCEN capituloCEN = new CapituloCEN ();

                //Capitulo  1
                capituloEN.Id_capitulo = 1;
                capituloEN.Nombre = "Capitulo 1 - La amenaza Fantasma";
                capituloEN.Numero = 1;
                capituloEN.Contenido = "Este capitulo es el primero del libro 1";

                capituloEN.Editando = false;

                var cap1 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro1, capituloEN.Editando);


                //capitulo 2
                capituloEN.Id_capitulo = 2;
                capituloEN.Nombre = "Capitulo 2 - Ya vendr�n tiempos mejores";
                capituloEN.Numero = 2;
                capituloEN.Contenido = "Este segundo capitulo es del libro 1";
                // capituloEN.Libro = libro1EN;
                // capituloEN.Usuario = usuario1EN;
                capituloEN.Editando = false;

                var cap2 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro1, true);


                //capitulo 3
                capituloEN.Id_capitulo = 3;
                capituloEN.Nombre = "Capitulo3 - Puta Bida";
                capituloEN.Numero = 3;
                capituloEN.Contenido = "Este capitulo 3 es del libro pago";
                // capituloEN.Libro = libro3EN;
                // capituloEN.Usuario = usuario1EN;
                capituloEN.Editando = true;
                var cap3 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro3, true);

                //capitulo 4
                capituloEN = new CapituloEN ();
                capituloEN.Id_capitulo = 4;
                capituloEN.Nombre = "Capitulo 4 - ararar";
                capituloEN.Numero = 3;
                capituloEN.Contenido = "Este es el segundo capitulo del libro de pago";
                // capituloEN.Libro = libro3EN;
                // capituloEN.Usuario = usuario1EN;
                capituloEN.Editando = true;
                var cap4 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro3, true);

                #endregion

                #region Comentario

                IComentarioCAD _IComentarioCAD = new ComentarioCAD ();
                ComentarioEN comentarioEN = new ComentarioEN ();
                ComentarioCEN comentarioCEN = new ComentarioCEN (_IComentarioCAD);


                /* Inicializamos datos de comentarios */
                // Comentario 1
                comentarioEN.Texto_comentario = "Mola mucho este libro!!!";
                comentarioEN.Baneado = false;
                var comentario1 = comentarioCEN.New_ (comentarioEN.Texto_comentario, idLibro1, comentarioEN.Baneado, 0, DateTime.Today, usu1);

                // Comentario 2
                comentarioEN.Texto_comentario = "Mola mucho este libro otra vez!!!";
                comentarioEN.Baneado = false;

                var comentario2 = comentarioCEN.New_ (comentarioEN.Texto_comentario, idLibro1, comentarioEN.Baneado, 0, DateTime.Today, usu3);


                // Comentario 3
                comentarioEN.Texto_comentario = "Este libro me ha emocionado como ninguno";
                comentarioEN.Baneado = false;

                var comentario3 = comentarioCEN.New_ (comentarioEN.Texto_comentario, idLibro2, comentarioEN.Baneado, 0, DateTime.Today, usu1);

                // Comentario 4
                comentarioEN.Texto_comentario = "Soy lo peor, no me he enterado de la mitad. Muy bueno";
                comentarioEN.Baneado = false;

                var comentario4 = comentarioCEN.New_ (comentarioEN.Texto_comentario, idLibro1, comentarioEN.Baneado, 0, DateTime.Today, usu1);

                #endregion


                #region Valoracion


                ValoracionCAD _IValoracionCAD = new ValoracionCAD ();
                ValoracionCEN valoracionCEN = new ValoracionCEN (_IValoracionCAD);
                

                LibroCP libroCP = new LibroCP ();

                libroCP.Valorar (idLibro1, 5, usu1);
                libroCP.Valorar (idLibro1, 10, usu3);
                libroCP.Valorar (idLibro1, 7, usu1);


                


                var notaMEdia1 = _ILibroCAD.ReadOIDDefault (idLibro1).NotaMediaValoracion;
                System.Console.WriteLine ("La media de valoracion del libro es: " + notaMEdia1);

                var numVal = _ILibroCAD.ReadOIDDefault(idLibro1).ContValoraciones;
                System.Console.WriteLine("Han valorado un numero de usuarios de: " + numVal);


                #endregion


                #region Pruebas

                // llamadas paa comprobar de lectura read all
                var r = usuarioCEN.ReadAll (0, 10);
                var l = gratuitoCEN.VerLibrosGratuitos (0, 10);
                var p = PagoCEN.VerLibrosPago (0, 10);
                var mostrarLibros = libroCEN.VerLibreria (0, 10);
                var mostrarLibro = libroCEN.VerLibro (idLibro1);
                var c = capituloCEN.ReadAll (0, 10);

                /* Iniciar sesion */
                System.Console.WriteLine ("Inicia sesion?: " + usuarioCEN.IniciarSesion (usuario2adminEN.Email, usuario2adminEN.Contrasenya));

                // ruba buscar libro
                var prueba_filtrolibro = libroCEN.BuscarLibro ("El Quijote");

                // comprobar Ver libro de pago
                var librosPago = PagoCEN.VerLibrosPago (0, -1);
                // comprobar capitulos de libro
                CapituloCP capituloCP = new CapituloCP ();

                /* Pruebas para ver los comentarios publicados y no baneados */
                IList<ComentarioEN> listaComentarios = comentarioCEN.VerComentarios (0, 10);

                #region visualizaciones

                // Para visualizar el contenido de cada comentario
                if (listaComentarios != null) {
                        foreach (ComentarioEN comentarios in listaComentarios) {
                                // System.Console.WriteLine (comentarios.Texto_comentario.ToString ());
                        }
                }

                /* Creamos una lista de capitulos del libro del id pasado por parametro */
                IList<CapituloEN> listCapitulos = capituloCP.LeerCapitulo (idLibro1);

                // Para visualizar el contenido de cada capitulo
                if (listCapitulos != null) {
                        foreach (CapituloEN capitulo in listCapitulos) {
                                // System.Console.WriteLine(capitulo.Contenido.ToString());
                        }
                }

                /* Creamos una lista de categorias del libro del id pasado por parametro */
                IList<CategoriaEN> listCategorias = categoriaCEN.VerCategorias (0, 10);
                // Para visualizar el contenido de categorias. Se muestran todas
                if (listCategorias != null) {
                        foreach (CategoriaEN categorias in listCategorias) {
                                // System.Console.WriteLine (categorias.Nombre_categoria.ToString ());
                        }
                }
                #endregion

                #region readfilters
                /* Creamos una lista de Libros paar ver su categoria pasada por parametro */
                /* La categoria cat1 tiene tres libros t cat2 solo uno */
                IList<LibroEN> listLibros = libroCEN.BuscarLibroPorCategoria (cat1);
                IList<LibroEN> listLibros2 = libroCEN.BuscarLibroPorCategoria (cat2);

                // Para visualizar las categorias de los libros
                if (listLibros != null) {
                        foreach (LibroEN libros in listLibros) {
                                System.Console.WriteLine ("Libros de la categoria aventuras: " + libros.Titulo.ToString ());
                        }
                }


                /* Creamos una lista de Usuarios para ver todos los que se llaman igual */

                IList<UsuarioEN> listUsuarios = usuarioCEN.BuscarUsuario ("Cliente1Nombre");


                // Para visualizar las categorias de los libros
                if (listUsuarios != null) {
                        foreach (UsuarioEN usuarios in listUsuarios) {
                                System.Console.WriteLine ("Los usuarios son: " + usuarios.Nombre.ToString ());
                        }
                }


                /* Creamos una lista de comentarios para ver todos los coemntarios ordenados por fecha del libro */

                IList<ComentarioEN> listComentarios = comentarioCEN.ComentariosLibro (idLibro1);


                // Para visualizar las categorias de los libros
                if (listComentarios != null) {
                        foreach (ComentarioEN comentarios in listComentarios) {
                                System.Console.WriteLine ("Los comentarios son: " + comentarios.Texto_comentario.ToString ());
                                //System.Console.WriteLine("Los comentarios son: " + comentarios.Usuario.ToString());
                                System.Console.WriteLine ("Persona que realiza el comentario:" + _IComentarioCAD.ReadOIDDefault (comentarios.Id).Usuario.Email);
                        }
                }


                /* Creamos una lista de valoraciones para ver todas las valoraciones de un libro */

                IList<ValoracionEN> listValoracion = valoracionCEN.ValoracionesLibro (idLibro1);


                // Para visualizar las categorias de los libros
                if (listValoracion != null) {
                        foreach (ValoracionEN valoraciones in listValoracion) {
                                // System.Console.WriteLine("Los comentarios son: " + valoraciones.Texto_comentario.ToString());

                                System.Console.WriteLine ("Valoraciones de libro1:" + _IValoracionCAD.ReadOIDDefault (valoraciones.Id).Puntuacion);
                        }
                }


                /* Creamos una lista de LIBROS para ver LOS 6 MEJORES */

                IList<LibroEN> listmejoreslibros = libroCEN.MejoresLibros ();


                // Para visualizar las categorias de los libros
                if (listmejoreslibros != null) {
                        foreach (LibroEN libros in listmejoreslibros) {
                                System.Console.WriteLine ("mejores libros:" + _ILibroCAD.ReadOIDDefault (libros.Id_libro).Titulo);
                        }
                }

                #endregion


                /* Prueba para bannear usuario. Se le paa el OID del usuario1EN y lo bannea*/
                //_IUsuarioCAD.ReadOIDDefault (usu1);
                /*                usuarioCEN.BanearUsuario (usuario1EN.Email);
                 *          var usuBaneado = _IUsuarioCAD.ReadOIDDefault (usu1).Baneado;
                 *
                 *            System.Console.WriteLine ("El usuario " + _IUsuarioCAD.ReadOIDDefault (usu1).Nombre.ToString () + " debe estar baneado: " + usuBaneado);
                 */
                /* Leemos el OID del libro y lo denunciamos 4 veces
                 * EL libro se banea con 4 denuncias */
                // _ILibroCAD.ReadOIDDefault (idLibro1);

                libroCEN.Denunciar (idLibro1);
                libroCEN.Denunciar (idLibro1);
                libroCEN.Denunciar (idLibro1);
                libroCEN.Denunciar (idLibro1);

                var er = _ILibroCAD.ReadOIDDefault (idLibro1).Num_denuncias;
                var v = _ILibroCAD.ReadOIDDefault (idLibro1).Baneado;
                System.Console.WriteLine ("Este libro debe tener 4 denuncia: " + er);
                System.Console.WriteLine ("Con 4 denuncias debe de estar baneado: " + v);


                /* Ver un capitulo de un libro */
                libroCEN.VerLibro (idLibro1);

                CapituloCEN cen = new CapituloCEN ();
                CapituloEN capituloDevuelto = new CapituloEN ();
                cen.VerCapitulo (cap1);
                CapituloEN capituloPrueba = new CapituloEN ();

                capituloPrueba = cen.VerCapitulo (cap1);
                System.Console.WriteLine ("Le paso el capitulo 1: " + capituloPrueba.Nombre);

                /* Probar modificar atributos de Libro */
                LibroEN libroEN = _ILibroCAD.ReadOIDDefault (idLibro1);
                string cadena = "Nueva descripcion del Quijote";
                libroCEN.CambiarDescripcion (idLibro1, cadena);
                var dede = _ILibroCAD.ReadOIDDefault (idLibro1).Descripcion;
                System.Console.WriteLine ("Se modifica la descripcion del libro?: " + dede);


                libroCEN.CambiarTitulo (idLibro1, "El quijote version 2");
                var modifTitulo = _ILibroCAD.ReadOIDDefault (idLibro1).Titulo;
                System.Console.WriteLine ("Se modifica la descripcion del libro?: " + modifTitulo);

                libroCEN.Publicar (idLibro2, false);
                System.Console.WriteLine ("Ponemos el libro 2 no publicado: " + _ILibroCAD.ReadOIDDefault (idLibro2).Titulo + "esta  publicado?: " + _ILibroCAD.ReadOIDDefault (idLibro2).Publicado);

                libroCEN.CambiarPortada (idLibro3, "https://2.bp.blogspot.com/-O-97fthl61U/V49_--zr3pI/AAAAAAAAAPQ/dSvemDk4fmEey8HsyjPSmg-4by7kF7ZvgCLcB/s1600/Elprincipito.jpg");
                System.Console.WriteLine ("Nueva portada del libro " + _ILibroCAD.ReadOIDDefault (idLibro3).Titulo + " Es la nueva: " + _ILibroCAD.ReadOIDDefault (idLibro3).Portada);

                /* Modifier de comentarios */
                comentarioCEN.EditarComentario (comentario1, "Modifico el comentario 1 ");
                System.Console.WriteLine ("Edito comentario 1 " + _IComentarioCAD.ReadOIDDefault (comentario1).Texto_comentario);

                /* Modifier de usuario */
                System.Console.WriteLine ("Nombre del usuario 1 antes: " + _IUsuarioCAD.ReadOIDDefault (usu1).Nombre);
                usuarioCEN.CambiarNombre (usu1, "Juan Usuario 1");
                System.Console.WriteLine ("Nombre del usuario 1 despues: " + _IUsuarioCAD.ReadOIDDefault (usu1).Nombre);

                System.Console.WriteLine ("Contraseña del usuario 1 antes: " + _IUsuarioCAD.ReadOIDDefault (usu1).Contrasenya);
                usuarioCEN.CambiarContrasenya (usu1, "123456789");
                System.Console.WriteLine ("Contra del usuario 1 despues: " + _IUsuarioCAD.ReadOIDDefault (usu1).Contrasenya.ToString ());


                /* Pagar libro */

                PagoCEN.Pagar (idLibro4, true);
                System.Console.WriteLine ("Pagado ¿si o no? " + _IPagoCAD.ReadOIDDefault (idLibro4).Pagado);


                /*System.Console.WriteLine ("Foto del usuario 1 antes: " + _IUsuarioCAD.ReadOIDDefault (usu1).Foto);
                 * usuarioCEN.CambiarFoto (usu1, "http://geroabai.com/upload/entradas/650_img_222_nafarroa-bai-irunea-propone-ampliar-el-perfil-de-los-destinatarios-de-las-viviendas-municipales.jpg");
                 * System.Console.WriteLine ("Foto del usuario 1 despues: " + _IUsuarioCAD.ReadOIDDefault (usu1).Foto);*/

                System.Console.WriteLine ("Bilbiografia del usuario 1 antes: " + _IUsuarioCAD.ReadOIDDefault (usu1).Bibliografia);
                usuarioCEN.CambiarBibliografia (usu1, "Me llamo Juan y molo un monton");
                System.Console.WriteLine ("Bibliografia del usuario 1 despues: " + _IUsuarioCAD.ReadOIDDefault (usu1).Bibliografia);

                /* Metodo Ver usuario */

                var usuarioDevuelto = usuarioCEN.VerUsuario (admin1);
                System.Console.WriteLine ("Pruebo verUsuario: " + usuarioDevuelto.Nombre);

                /* Pruebas denunciar usuario y comentario */
                comentarioCEN.DenunciarComentario (comentario1);
                comentarioCEN.DenunciarComentario (comentario1);
                comentarioCEN.DenunciarComentario (comentario1);
                System.Console.WriteLine ("Denucio el comentario 1 tres veces: " + _IComentarioCAD.ReadOIDDefault (comentario1).NumdenunciasComentario);

                usuarioCEN.DenunciarUser (usu1);
                usuarioCEN.DenunciarUser (usu1);
                System.Console.WriteLine ("Denucio al usuario 1 dos veces: " + _IUsuarioCAD.ReadOIDDefault (usu1).NumDenunciasUser);


                /* Prueba para ver libros de un usuario */

                IList<LibroEN> librosUsu1 = libroCEN.VerLibrosUsuario (usu1);

                // Para visualizar las categorias de los libros
                if (librosUsu1 != null) {
                        foreach (LibroEN libros in librosUsu1) {
                                System.Console.WriteLine ("Libros de el usuario 1 son: " + libros.Titulo.ToString ());
                        }
                }


                IList<LibroEN> librosUsu3 = libroCEN.VerLibrosUsuario (usu3);
                // Para visualizar libros de un usuario
                if (librosUsu3 != null) {
                        foreach (LibroEN libros in librosUsu3) {
                                System.Console.WriteLine ("Libros de el usuario 3 son: " + libros.Titulo.ToString ());
                        }
                }


                /* Pruebas INVITAR usuario*/


                capituloCP.InvitarUsuario (cap1, _IUsuarioCAD.ReadOIDDefault (usu3).Email);
                capituloCP.InvitarUsuario (cap1, _IUsuarioCAD.ReadOIDDefault (usu3).Email);

                /* COMO mostrar q capitulos estan disponibles para un usuario */



                /* Pruebas redactar. Añado un asterisco para indentificar
                 * el nuevo texto añadido */
                System.Console.WriteLine ("Contenido del cap1 antes: " + capituloCEN.VerCapitulo (cap1).Contenido);
                capituloCEN.Redactar ("Erase una vez...", cap1);
                System.Console.WriteLine ("Contenido del cap1 despues: " + capituloCEN.VerCapitulo (cap1).Contenido);






                /* Pruebas Escritura colaborativa */

                capituloCEN.RedactarColaborativo (cap1);
                capituloCEN.RedactarColaborativo (cap1);
                capituloCEN.GuardarContenido (cap1, "Erase una vez...");
                capituloCEN.RedactarColaborativo (cap1);











                #endregion

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
