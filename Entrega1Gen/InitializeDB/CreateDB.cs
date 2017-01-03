
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
/* Realizado por Julian Sanchez Garcia y Mariano Lopez Escudero
 *  Para la asignatura de Diseño de Sistemas Multimedia. UA 2016 */

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
                // Inicializamos valores de los objetos que vamos a crear


                #region Roles

                IRolCAD _IRolCAD = new RolCAD ();
                RolEN rolUser = new RolEN ();
                RolEN rolAdmin = new RolEN ();
                RolCEN rolCEN = new RolCEN (_IRolCAD);

                rolUser.TipoRoll = "Usuario";

                var rol1 = rolCEN.New_ (rolUser.TipoRoll);

                rolAdmin.TipoRoll = "Administrador";

                var rol2 = rolCEN.New_ (rolAdmin.TipoRoll);



                #endregion

                #region Usuario

                IUsuarioCAD _IUsuarioCAD = new UsuarioCAD ();
                UsuarioEN usuario1EN, usuario2adminEN, usuario3EN = new UsuarioEN ();
                UsuarioCEN usuarioCEN = new UsuarioCEN (_IUsuarioCAD);

                // Usuario ADMINISTRADOR
                // IAdministradorCAD _IAdministradorCAD = new AdministradorCAD ();
                // AdministradorEN administradorEN = new AdministradorEN ();
                // AdministradorCEN administradorCEN = new AdministradorCEN (_IAdministradorCAD);

                // Inicializamos los atributos de las clases
                //Usuario1
                usuario1EN = new UsuarioEN ();
                usuario1EN.Email = "emailUsu1";
                usuario1EN.Nombre = "usu1";
                usuario1EN.Edad = 18;
                usuario1EN.Fecha_alta = DateTime.Now;
                usuario1EN.Foto = @"http://fotouser.miarroba.st/68731257/300/mr-anonimo.jpg";
                usuario1EN.Bibliografia = "Soy usuario1 de esta web";
                usuario1EN.Baneado = false;
                usuario1EN.Contrasenya = "12345";

                //Usuario2
                usuario2adminEN = new UsuarioEN ();
                usuario2adminEN.Email = "emailAdmin";
                usuario2adminEN.Nombre = "admin";
                usuario2adminEN.Edad = 18;
                usuario2adminEN.Fecha_alta = DateTime.Now;
                usuario2adminEN.Foto = @"http://photos1.blogger.com/blogger/1942/3777/1600/Anonimo.jpg";
                usuario2adminEN.Bibliografia = "Soy el usuario 2 y Admin de esta web";
                usuario2adminEN.Baneado = false;
                usuario2adminEN.Contrasenya = "1234";

                //Usuario3
                usuario3EN = new UsuarioEN ();
                usuario3EN.Email = "emailUsu3";
                usuario3EN.Nombre = "usu3";
                usuario3EN.Edad = 24;
                usuario3EN.Fecha_alta = DateTime.Now;
                usuario3EN.Foto = @"http://sr.photos3.fotosearch.com/bthumb/CSP/CSP442/k21530077.jpg";
                usuario3EN.Bibliografia = "Soy un usuario 3 de esta web";
                usuario3EN.Baneado = false;
                usuario3EN.Contrasenya = "12345ABCD";

                // registro de usuarios
                var usu1 = usuarioCEN.Registrarse (usuario1EN.Nombre, usuario1EN.Contrasenya, usuario1EN.Email, usuario1EN.Edad, usuario1EN.Fecha_alta, usuario1EN.Foto, usuario1EN.Bibliografia, usuario1EN.Baneado, 0, false, "alias1", rol1);
                // administrador
                var admin1 = usuarioCEN.Registrarse (usuario2adminEN.Nombre, usuario2adminEN.Contrasenya, usuario2adminEN.Email, usuario2adminEN.Edad, usuario2adminEN.Fecha_alta, usuario2adminEN.Foto, usuario2adminEN.Bibliografia, usuario2adminEN.Baneado, 0, false, "alias2", rol2);
                // Tercer usuario
                var usu3 = usuarioCEN.Registrarse (usuario3EN.Nombre, usuario3EN.Contrasenya, usuario3EN.Email, usuario3EN.Edad, usuario3EN.Fecha_alta, usuario3EN.Foto, usuario3EN.Bibliografia, usuario3EN.Baneado, 0, false, "alias3", rol1);

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

                // Libro 1 ----PUBLICADO
                libro1EN.Titulo = "Don Quijote de la Mancha";
                libro1EN.Portada = @"http://covers.feedbooks.net/book/3236.jpg?size=large&t=1439166627";
                libro1EN.Descripcion = "Novela de Cervantes que cuenta las aventuras y desventuras del ingenioso hidalgo y su compañero Sancho";
                libro1EN.Fecha = DateTime.Now;
                libro1EN.Publicado = true;
                libro1EN.Baneado = false;
                libro1EN.Num_denuncias = 0;
                libro1EN.EnRevision = false;

                // Libro 2
                libro2EN.Titulo = "El Castigo Divinno";
                libro2EN.Portada = @"http://3.bp.blogspot.com/-sTfJtm6oT6g/UXHJg8st8kI/AAAAAAAABEQ/DUBdoSQ9Urw/s1600/castigo_divino_med.jpg";
                libro2EN.Descripcion = "Novela romántica ambientada en la post guerra española.";
                libro2EN.Fecha = DateTime.Now;
                libro2EN.Publicado = true;
                libro2EN.Baneado = false;
                libro2EN.Num_denuncias = 0;
                libro2EN.EnRevision = false;

                //Libro 3 ---- De Pago
                libro3EN.Titulo = "El Principito";
                libro3EN.Portada = @"http://estaticos.elperiodico.com/resources/jpg/2/3/portada-principito-obra-mas-famosa-saint-exupery-1467190147132.jpg";
                libro3EN.Descripcion = "El principito es un cuento poético que viene acompañado de ilustraciones hechas con acuarelas por el mismo Saint-Exupéry.";
                libro3EN.Fecha = DateTime.Today;
                libro3EN.Publicado = true;
                libro3EN.Baneado = false;
                libro3EN.Num_denuncias = 0;
                libro3EN.Precio = 12;
                libro3EN.Pagado = false;
                libro3EN.EnRevision = false;


                //Libro 4 ----PUBLICADO
                libro4EN.Titulo = "El Don apacible";
                libro4EN.Portada = @"https://clubdecatadores.files.wordpress.com/2012/10/el-don-apacible-libro-3-mijac3adl-shc3b3lojov.jpg";
                libro4EN.Descripcion = "La novela trata sobre la vida de los cosacos del Don a inicios del siglo XX, probablemente hacia 1912, poco antes de la Primera Guerra Mundial.";
                libro4EN.Fecha = DateTime.Now;
                libro4EN.Publicado = true;
                libro4EN.Baneado = false;
                libro4EN.Num_denuncias = 0;
                libro3EN.Precio = 15;
                libro3EN.Pagado = false;
                libro4EN.EnRevision = false;

                // lista de usuarios
                // creamos listas de usuarios y categorias para crear los libros
                System.Collections.Generic.List<String> listaUsuarios = new List<string>();
                listaUsuarios.Add (usuario1EN.Email);
                CapituloCAD _ICapituloCAD = new CapituloCAD ();
                /* Se crean dos libros gratuitos y uno de pago
                 * Se guardan sus OIDS para inicializar la bbdd */
                int idLibro1 = gratuitoCEN.New_ (libro1EN.Titulo, libro1EN.Portada, libro1EN.Descripcion, libro1EN.Fecha, libro1EN.Publicado, usu1, listaCategorias, libro1EN.Baneado, libro1EN.Num_denuncias, 0, 0, libro1EN.EnRevision);
                int idLibro2 = gratuitoCEN.New_ (libro2EN.Titulo, libro2EN.Portada, libro2EN.Descripcion, libro2EN.Fecha, libro2EN.Publicado, admin1, listaCategorias, libro2EN.Baneado, libro2EN.Num_denuncias, 0, 0, libro2EN.EnRevision);
                int idLibro3 = PagoCEN.New_ (libro3EN.Titulo, libro3EN.Portada, libro3EN.Descripcion, libro3EN.Fecha, libro3EN.Publicado, usu1, listaCategorias, libro3EN.Baneado, libro3EN.Num_denuncias, 0, 0, libro3EN.EnRevision, libro3EN.Precio, false);
                int idLibro4 = PagoCEN.New_ (libro4EN.Titulo, libro4EN.Portada, libro4EN.Descripcion, libro4EN.Fecha, libro4EN.Publicado, usu3, listaCategorias2, libro4EN.Baneado, libro4EN.Num_denuncias, 0, 0, libro4EN.EnRevision, libro4EN.Precio, false);

                #endregion
                /* Se añaden los mismos 4 capitulos a cada uno de los 4 libros */
                // CAPITULOS
                #region Capitulo
                // Composicion
                CapituloEN capituloEN = new CapituloEN ();
                CapituloCEN capituloCEN = new CapituloCEN ();

                //Capitulo  1
                capituloEN.Id_capitulo = 1;
                capituloEN.Nombre = "Capitulo 1";
                capituloEN.Numero = 1;
                capituloEN.Contenido = "<h1>Lorem ipsum</h1> <p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p><p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                </p>              <p>                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>";
                capituloEN.Editando = false;
                var cap1Lib1 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro1, capituloEN.Editando);
                var cap1Lib2 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro2, capituloEN.Editando);
                var cap1Lib3 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro3, capituloEN.Editando);
                var cap1Lib4 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro4, capituloEN.Editando);

                //capitulo 2
                capituloEN.Id_capitulo = 2;
                capituloEN.Nombre = "Capitulo 2";
                capituloEN.Numero = 2;
                capituloEN.Contenido = "<h1>Lorem ipsum</h1> <p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p><p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                </p>              <p>                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>";
                capituloEN.Editando = false;
                var cap2Lib1 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro1, capituloEN.Editando);
                var cap2Lib2 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro2, capituloEN.Editando);
                var cap2Lib3 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro3, capituloEN.Editando);
                var cap2Lib4 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro4, capituloEN.Editando);

                //capitulo 3
                capituloEN.Id_capitulo = 3;
                capituloEN.Nombre = "Capitulo3";
                capituloEN.Numero = 3;
                capituloEN.Contenido = "<h1>Lorem ipsum</h1> <p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p><p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                </p>              <p>                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>";
                capituloEN.Editando = true;
                var cap3Lib1 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro1, capituloEN.Editando);
                var cap3Lib2 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro2, capituloEN.Editando);
                var cap3Lib3 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro3, capituloEN.Editando);
                var cap3Lib4 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro4, capituloEN.Editando);

                //capitulo 4
                capituloEN = new CapituloEN ();
                capituloEN.Id_capitulo = 4;
                capituloEN.Nombre = "Capitulo 4";
                capituloEN.Numero = 3;
                capituloEN.Contenido = "<h1>Lorem ipsum</h1> <p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p><p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.                </p>              <p>                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod                    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>";
                capituloEN.Editando = true;
                var cap4Lib1 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro1, capituloEN.Editando);
                var cap4Lib2 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro2, capituloEN.Editando);
                var cap4Lib3 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro3, capituloEN.Editando);
                var cap4Lib4 = capituloCEN.New_ (capituloEN.Nombre, capituloEN.Numero, capituloEN.Contenido, idLibro4, capituloEN.Editando);

                #endregion

                #region Comentario
                IComentarioCAD _IComentarioCAD = new ComentarioCAD ();
                // ComentarioEN comentario1EN, comentario2EN, comentario3EN, comentario4EN = new ComentarioEN();
                ComentarioEN comentario1EN = new ComentarioEN ();
                ComentarioEN comentario2EN = new ComentarioEN ();
                ComentarioEN comentario3EN = new ComentarioEN ();
                ComentarioEN comentario4EN = new ComentarioEN ();

                ComentarioCEN comentarioCEN = new ComentarioCEN (_IComentarioCAD);

                // Inicializamos datos de comentarios
                // Comentario 1
                comentario1EN.Texto_comentario = "Mola mucho este libro!!!";
                comentario1EN.Baneado = false;
                comentario1EN.EnRevisionC = false;
                var comentario1 = comentarioCEN.New_ (comentario1EN.Texto_comentario, idLibro1, comentario1EN.Baneado, 0, DateTime.Today, usu1, comentario1EN.EnRevisionC);

                // Comentario 2
                comentario2EN.Texto_comentario = "Mola mucho este libro otra vez!!!";
                comentario2EN.Baneado = false;
                comentario2EN.EnRevisionC = false;
                var comentario2 = comentarioCEN.New_ (comentario2EN.Texto_comentario, idLibro1, comentario2EN.Baneado, 0, DateTime.Today, usu3, comentario2EN.EnRevisionC);

                // Comentario 3
                comentario3EN.Texto_comentario = "Este libro me ha emocionado como ninguno";
                comentario3EN.Baneado = false;
                comentario3EN.EnRevisionC = false;
                var comentario3 = comentarioCEN.New_ (comentario3EN.Texto_comentario, idLibro2, comentario3EN.Baneado, 0, DateTime.Today, usu1, comentario3EN.EnRevisionC);

                // Comentario 4
                comentario4EN.Texto_comentario = "Soy lo peor, no me he enterado de la mitad. Muy bueno";
                comentario4EN.Baneado = false;
                comentario4EN.EnRevisionC = false;
                var comentario4 = comentarioCEN.New_ (comentario4EN.Texto_comentario, idLibro1, comentario4EN.Baneado, 0, DateTime.Today, usu1, comentario4EN.EnRevisionC);

                #endregion


                #region Valoracion

                ValoracionCAD _IValoracionCAD = new ValoracionCAD ();
                ValoracionCEN valoracionCEN = new ValoracionCEN (_IValoracionCAD);

                LibroCP libroCP = new LibroCP ();

                libroCP.Valorar (idLibro1, 5, usu1);
                libroCP.Valorar (idLibro1, 10, usu3);
                libroCP.Valorar (idLibro1, 7, usu1);

                var notaMEdia1 = _ILibroCAD.ReadOIDDefault (idLibro1).NotaMediaValoracion;
                // System.Console.WriteLine ("La media de valoracion del libro es: " + notaMEdia1);

                var numVal = _ILibroCAD.ReadOIDDefault (idLibro1).ContValoraciones;
                // System.Console.WriteLine ("Han valorado un numero de usuarios de: " + numVal);


                #endregion


                #region Pruebas
                // INICIO SESION
                // System.Console.WriteLine ("Inicia sesion?: " + usuarioCEN.IniciarSesion (usuario2adminEN.Email, usuario2adminEN.Contrasenya));

                /*
                 *  // llamadas paa comprobar de lectura READ ALL
                 *  var r = usuarioCEN.ReadAll (0, 10);
                 *  var l = gratuitoCEN.VerLibrosGratuitos (0, 10);
                 *  var p = PagoCEN.VerLibrosPago (0, 10);
                 *  var mostrarLibros = libroCEN.VerLibreria (0, 10);
                 *  var mostrarLibro = libroCEN.VerLibro (idLibro1);
                 *  var c = capituloCEN.ReadAll (0, 10);
                 *  // BUSCAR libro
                 *  var prueba_filtrolibro = libroCEN.BuscarLibro ("El Quijote");
                 *  // comprobar VER LIBRO PAGO
                 *  var librosPago = PagoCEN.VerLibrosPago (0, -1);
                 */

                #region visualizaciones
                CapituloCP capituloCP = new CapituloCP ();
                /*
                 *  // Para visualizar el contenido de cada comentario publicados y no baneados
                 *  IList<ComentarioEN> listaComentarios = comentarioCEN.VerComentarios(0, 10);
                 *  if (listaComentarios != null) {
                 *          foreach (ComentarioEN comentarios in listaComentarios) {
                 *                  // System.Console.WriteLine (comentarios.Texto_comentario.ToString ());
                 *          }
                 *  }
                 *
                 *  // comprobar capitulos de libro
                 *
                 *  IList<CapituloEN> listCapitulos = capituloCP.LeerCapitulo (idLibro1);
                 *
                 *  // Para visualizar el contenido de cada capitulo
                 *  if (listCapitulos != null) {
                 *          foreach (CapituloEN capitulo in listCapitulos) {
                 *                  // System.Console.WriteLine(capitulo.Contenido.ToString());
                 *          }
                 *  }
                 *
                 *  // Creamos una lista de categorias del libro del id pasado por parametro
                 *  IList<CategoriaEN> listCategorias = categoriaCEN.VerCategorias (0, 10);
                 *  // Para visualizar el contenido de categorias. Se muestran todas
                 *  if (listCategorias != null) {
                 *          foreach (CategoriaEN categorias in listCategorias) {
                 *                  // System.Console.WriteLine (categorias.Nombre_categoria.ToString ());
                 *          }
                 *  }
                 */
                #endregion

                #region readfilters

                /*
                 *  // Creamos una lista de Libros paar ver su categoria pasada por parametro
                 *  // La categoria cat1 tiene tres libros t cat2 solo uno
                 *  IList<LibroEN> listLibros = libroCEN.BuscarLibroPorCategoria (cat1);
                 *  IList<LibroEN> listLibros2 = libroCEN.BuscarLibroPorCategoria (cat2);
                 *
                 *  // Para visualizar las CATEGORIAS
                 *  if (listLibros != null) {
                 *          foreach (LibroEN libros in listLibros) {
                 *                  System.Console.WriteLine ("Libros de la categoria aventuras: " + libros.Titulo.ToString ());
                 *          }
                 *  }
                 *
                 *
                 *  // Creamos una lista de USUARIOS para ver todos los que se llaman igual
                 *  IList<UsuarioEN> listUsuarios = usuarioCEN.BuscarUsuario ("Cliente1Nombre");
                 *
                 *  // Para visualizar las CATEGORIAS de los LIBROS
                 *  if (listUsuarios != null) {
                 *          foreach (UsuarioEN usuarios in listUsuarios) {
                 *                  System.Console.WriteLine ("Los usuarios son: " + usuarios.Nombre.ToString ());
                 *          }
                 *  }
                 *
                 *
                 *  // Creamos una lista de comentarios para ver todos los coemntarios ordenados por fecha del libro
                 *  IList<ComentarioEN> listComentarios = comentarioCEN.ComentariosLibro (idLibro1);
                 *  if (listComentarios != null) {
                 *          foreach (ComentarioEN comentarios in listComentarios) {
                 *                  System.Console.WriteLine ("Los comentarios son: " + comentarios.Texto_comentario.ToString ());
                 *                  //System.Console.WriteLine("Los comentarios son: " + comentarios.Usuario.ToString());
                 *                  System.Console.WriteLine ("Persona que realiza el comentario:" + _IComentarioCAD.ReadOIDDefault (comentarios.Id).Usuario.Email);
                 *          }
                 *  }
                 *
                 *  // Creamos una lista de valoraciones para ver todas las valoraciones de un libro
                 *  IList<ValoracionEN> listValoracion = valoracionCEN.ValoracionesLibro (idLibro1);
                 *  if (listValoracion != null) {
                 *          foreach (ValoracionEN valoraciones in listValoracion) {
                 *                  System.Console.WriteLine ("Valoraciones de libro1:" + _IValoracionCAD.ReadOIDDefault (valoraciones.Id).Puntuacion);
                 *          }
                 *  }
                 *
                 *  // Creamos una lista de LIBROS para ver LOS 6 MEJORES
                 *
                 *  IList<LibroEN> listmejoreslibros = libroCEN.MejoresLibros ();
                 *  if (listmejoreslibros != null) {
                 *          foreach (LibroEN libros in listmejoreslibros) {
                 *                  System.Console.WriteLine ("mejores libros:" + _ILibroCAD.ReadOIDDefault (libros.Id_libro).Titulo);
                 *          }
                 *  }
                 */
                #endregion

                /* Prueba para bannear usuario. Se le paa el OID del usuario1EN y lo bannea*/
                /*
                 * _IUsuarioCAD.ReadOIDDefault (usu1);
                 * usuarioCEN.BanearUsuario (usuario1EN.Email);
                 * var usuBaneado = _IUsuarioCAD.ReadOIDDefault (usu1).Baneado;
                 * System.Console.WriteLine ("El usuario " + _IUsuarioCAD.ReadOIDDefault (usu1).Nombre.ToString () + " debe estar baneado: " + usuBaneado);
                 */


                /*
                 *
                 *  // DENUNCIAR LIBRO Leemos el OID del libro y lo denunciamos 4 veces
                 *  System.Console.WriteLine ("Este libro no debe estar en revision: " + _ILibroCAD.ReadOIDDefault (idLibro1).EnRevision);
                 *  libroCEN.Denunciar (idLibro1);
                 *  libroCEN.Denunciar (idLibro1);
                 *  libroCEN.Denunciar (idLibro1);
                 *  libroCEN.Denunciar (idLibro1);
                 *
                 *  var er = _ILibroCAD.ReadOIDDefault (idLibro1).Num_denuncias;
                 *  //  var v = _ILibroCAD.ReadOIDDefault (idLibro1).Baneado;
                 *  System.Console.WriteLine ("Este libro debe tener 4 denuncia: " + er);
                 *  // en cuanto se denuncia un libro cambia atributo eeRevision a true
                 *  var rev = _ILibroCAD.ReadOIDDefault (idLibro1).EnRevision;
                 *  System.Console.WriteLine ("Este libro debe en revision para admin: " + rev);
                 *
                 *  // pruebas DENUNCIAR COMENTARIO comentario pasa a estar enRevision
                 *  comentarioCEN.DenunciarComentario (comentario1);
                 *  comentarioCEN.DenunciarComentario (comentario1);
                 *  comentarioCEN.DenunciarComentario (comentario1);
                 *  System.Console.WriteLine ("Denucio el comentario 1 tres veces: " + _IComentarioCAD.ReadOIDDefault (comentario1).NumdenunciasComentario);
                 *
                 *  System.Console.WriteLine ("Esta en revision antes de denunciar el comentario 2???: " + _IComentarioCAD.ReadOIDDefault (comentario2).EnRevisionC);
                 *  comentarioCEN.DenunciarComentario (comentario2);
                 *  System.Console.WriteLine ("Denunciamos el comentario 2, esta en revision???:" + _IComentarioCAD.ReadOIDDefault (comentario2).EnRevisionC);
                 *
                 *  // DENUNCIAR USUARIO
                 *  System.Console.WriteLine ("Esta en revision el usuario 1 ANTES de denunciarlo??: " + _IUsuarioCAD.ReadOIDDefault (usu1).EnRevisionU);
                 *  usuarioCEN.DenunciarUser (usu1);
                 *  usuarioCEN.DenunciarUser (usu1);
                 *  System.Console.WriteLine ("Denucio al usuario 1 dos veces: " + _IUsuarioCAD.ReadOIDDefault (usu1).EnRevisionU);
                 *  System.Console.WriteLine ("Esta en revision el usuario 1 DESPUES de denunciarlo??: " + _IUsuarioCAD.ReadOIDDefault (usu1).EnRevisionU);
                 *  System.Console.WriteLine ("NUM denuncias usuario 1 (2): " + _IUsuarioCAD.ReadOIDDefault (usu1).NumDenunciasUser);
                 *
                 */


                /*
                 *  // VER un capitulo de un libro
                 *  libroCEN.VerLibro (idLibro1);
                 *
                 *  CapituloCEN cen = new CapituloCEN ();
                 *  CapituloEN capituloDevuelto = new CapituloEN ();
                 *  cen.VerCapitulo(cap1Lib1);
                 *  CapituloEN capituloPrueba = new CapituloEN ();
                 *
                 *  capituloPrueba = cen.VerCapitulo(cap1Lib1);
                 *  System.Console.WriteLine ("Le paso el capitulo 1: " + capituloPrueba.Nombre);
                 */

                /*
                 *  // Probar MODIFICAR atributos de LIBRO y USUARIO
                 *
                 *  LibroEN libroEN = _ILibroCAD.ReadOIDDefault (idLibro1);
                 *  string cadena = "Nueva descripcion del Quijote";
                 *  libroCEN.CambiarDescripcion (idLibro1, cadena);
                 *  var dede = _ILibroCAD.ReadOIDDefault (idLibro1).Descripcion;
                 *  System.Console.WriteLine ("Se modifica la descripcion del libro?: " + dede);
                 *
                 *  libroCEN.CambiarTitulo (idLibro1, "El quijote version 2");
                 *  var modifTitulo = _ILibroCAD.ReadOIDDefault (idLibro1).Titulo;
                 *  System.Console.WriteLine ("Se modifica la descripcion del libro?: " + modifTitulo);
                 *
                 *  libroCEN.Publicar (idLibro2, false);
                 *  System.Console.WriteLine ("Ponemos el libro 2 no publicado: " + _ILibroCAD.ReadOIDDefault (idLibro2).Titulo + "esta  publicado?: " + _ILibroCAD.ReadOIDDefault (idLibro2).Publicado);
                 *
                 *  libroCEN.CambiarPortada (idLibro3, "https://2.bp.blogspot.com/-O-97fthl61U/V49_--zr3pI/AAAAAAAAAPQ/dSvemDk4fmEey8HsyjPSmg-4by7kF7ZvgCLcB/s1600/Elprincipito.jpg");
                 *  System.Console.WriteLine ("Nueva portada del libro " + _ILibroCAD.ReadOIDDefault (idLibro3).Titulo + " Es la nueva: " + _ILibroCAD.ReadOIDDefault (idLibro3).Portada);
                 *
                 *  // Modifier de comentarios
                 *  comentarioCEN.EditarComentario (comentario1, "Modifico el comentario 1 ");
                 *  System.Console.WriteLine ("Edito comentario 1 " + _IComentarioCAD.ReadOIDDefault (comentario1).Texto_comentario);
                 *
                 *  // Modifier de usuario
                 *  System.Console.WriteLine ("Nombre del usuario 1 antes: " + _IUsuarioCAD.ReadOIDDefault (usu1).Nombre);
                 *  usuarioCEN.CambiarNombre (usu1, "Juan Usuario 1");
                 *  System.Console.WriteLine ("Nombre del usuario 1 despues: " + _IUsuarioCAD.ReadOIDDefault (usu1).Nombre);
                 *
                 *  System.Console.WriteLine ("Contraseña del usuario 1 antes: " + _IUsuarioCAD.ReadOIDDefault (usu1).Contrasenya);
                 *  usuarioCEN.CambiarContrasenya (usu1, "123456789");
                 *  System.Console.WriteLine ("Contra del usuario 1 despues: " + _IUsuarioCAD.ReadOIDDefault (usu1).Contrasenya.ToString ());
                 *
                 *  System.Console.WriteLine ("Foto del usuario 1 antes: " + _IUsuarioCAD.ReadOIDDefault (usu1).Foto);
                 *  usuarioCEN.CambiarFoto (usu1, "http://geroabai.com/upload/entradas/650_img_222_nafarroa-bai-irunea-propone-ampliar-el-perfil-de-los-destinatarios-de-las-viviendas-municipales.jpg");
                 *  System.Console.WriteLine ("Foto del usuario 1 despues: " + _IUsuarioCAD.ReadOIDDefault (usu1).Foto);
                 *
                 *
                 *  System.Console.WriteLine ("Bilbiografia del usuario 1 antes: " + _IUsuarioCAD.ReadOIDDefault (usu1).Bibliografia);
                 *  usuarioCEN.CambiarBibliografia (usu1, "Me llamo Juan y molo un monton");
                 *  System.Console.WriteLine ("Bibliografia del usuario 1 despues: " + _IUsuarioCAD.ReadOIDDefault (usu1).Bibliografia);
                 *
                 * // Pagar libro
                 *  PagoCEN.Pagar (idLibro4, true);
                 *  System.Console.WriteLine ("Pagado ¿si o no? " + _IPagoCAD.ReadOIDDefault (idLibro4).Pagado);
                 *
                 */

                /*
                 *  // Metodo Ver usuario
                 *  var usuarioDevuelto = usuarioCEN.VerUsuario (admin1);
                 *  System.Console.WriteLine ("Pruebo verUsuario: " + usuarioDevuelto.Nombre);
                 *
                 *  // Prueba para VER LIBROS de un USUARIO
                 *  IList<LibroEN> librosUsu1 = libroCEN.VerLibrosUsuario (usu1);
                 *  if (librosUsu1 != null) {
                 *          foreach (LibroEN libros in librosUsu1) {
                 *                  System.Console.WriteLine ("Libros de el usuario 1 son: " + libros.Titulo.ToString ());
                 *          }
                 *  }
                 *
                 *
                 *  IList<LibroEN> librosUsu3 = libroCEN.VerLibrosUsuario (usu3);
                 *  if (librosUsu3 != null) {
                 *          foreach (LibroEN libros in librosUsu3) {
                 *                  System.Console.WriteLine ("Libros de el usuario 3 son: " + libros.Titulo.ToString ());
                 *          }
                 *  }
                 */

                /*
                 *  // Pruebas INVITAR usuario
                 *  capituloCP.InvitarUsuario(cap1Lib1, _IUsuarioCAD.ReadOIDDefault(usu3).Email);
                 *  capituloCP.InvitarUsuario(cap1Lib1, _IUsuarioCAD.ReadOIDDefault(usu3).Email);
                 *
                 *  // COMO mostrar q capitulos estan disponibles para un usuario ¿?¿?¿?¿
                 *
                 */

                /*
                 * // Pruebas REDACTAR. Añado un asterisco para indentificar el nuevo texto añadido
                 *     System.Console.WriteLine("Contenido del cap1 antes: " + capituloCEN.VerCapitulo(cap1Lib1).Contenido);
                 *     capituloCEN.Redactar("Erase una vez...", cap1Lib1);
                 *     System.Console.WriteLine("Contenido del cap1 despues: " + capituloCEN.VerCapitulo(cap1Lib1).Contenido);
                 *
                 *     // Prueba redactar con 4096 caracteres- se cambia valor en atributo contenido de la tabla Capitulo a varchar(max)
                 *     System.Console.WriteLine ("Contenido del capitulo 2 antes: " + capituloCEN.VerCapitulo (cap2Lib1).Contenido);
                 *     // pra probar 4096 caracteres
                 *     // Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi feugiat nibh sit amet erat scelerisque, at faucibus nibh sodales. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam ut blandit lorem. Suspendisse ut ante vel lacus tincidunt iaculis. Donec dolor nunc, malesuada ut diam quis, lacinia fermentum tellus. Aenean ut varius nibh. Cras et vehicula metus.Donec ullamcorper tincidunt nulla id suscipit. Nullam augue diam, lacinia sit amet dolor in, pellentesque viverra dui. Ut congue blandit ante, eget ornare dolor eleifend et. Cras eget leo pulvinar, elementum mauris eu, facilisis velit. Aenean vestibulum dui non aliquam pretium. Aliquam ac nisl ut lorem laoreet bibendum. Nunc tellus sapien, fringilla a iaculis sit amet, laoreet vel velit. Morbi pretium erat sit amet nisl varius, eget ullamcorper nisl malesuada. Ut et massa ex. Etiam rutrum ligula odio. Donec eros mauris, iaculis non vestibulum rutrum, tincidunt at justo. Proin semper nisi et turpis vulputate molestie. Nunc varius enim vel risus volutpat, eget consectetur augue pulvinar. Nulla euismod luctus nibh vitae convallis.Aenean eget suscipit lacus. Quisque lobortis lorem orci, a sagittis leo euismod a. Curabitur at neque tincidunt tellus suscipit sodales. Nullam justo leo, rutrum et vehicula ut, imperdiet et elit. Maecenas tempus purus et lacus dapibus sollicitudin. Integer ut orci pretium, tempor nibh et, tristique nisi. Vivamus non urna suscipit, iaculis purus at, pharetra purus. Nulla facilisi. Etiam euismod mattis porta. Nulla in pretium justo. Ut condimentum magna et vehicula egestas. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Quisque accumsan lorem quis justo pulvinar ullamcorper. Duis placerat ultricies varius. In non sem erat. Suspendisse faucibus auctor est id interdum. Maecenas malesuada ipsum in elit ullamcorper euismod. In venenatis lectus at ex fermentum, eget molestie enim ultrices. Suspendisse faucibus urna aliquam est commodo finibus. Cras sit amet tellus consequat, interdum lacus non, malesuada tellus. In semper risus vitae ligula placerat tincidunt. Suspendisse et dapibus elit. Aenean in elit hendrerit, facilisis lorem quis, faucibus augue. Suspendisse porta convallis posuere. Sed ac odio at quam imperdiet commodo. Nulla vel sapien ac massa varius pulvinar. Praesent rhoncus nisl dapibus, imperdiet tortor vitae, posuere augue. Aliquam ex ipsum, sodales sit amet aliquam varius, ornare eget metus.Curabitur ipsum tellus, euismod eu nunc ac, convallis finibus risus. Nunc in ligula at risus fermentum tempus. Nullam congue felis porttitor rutrum volutpat. Sed nec mi convallis, pulvinar nunc vel, cursus tellus. In nec consectetur massa, quis lacinia velit. Nullam velit orci, maximus non venenatis quis, aliquam sit amet purus. Praesent pretium posuere purus eu convallis. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Fusce rutrum nisi nec massa tempus dictum. Suspendisse egestas dui tortor, ut finibus orci accumsan sed. In a dignissim diam. Fusce vel rutrum nisi. Suspendisse congue cursus tortor, ac accumsan augue mattis ut. Curabitur et turpis in neque fermentum semper. Proin dapibus eget nibh et venenatis. Vivamus sit amet ultrices mi. Nulla sed sodales nunc. Praesent vestibulum, diam et dapibus molestie, augue risus auctor lectus, non porttitor est metus quis metus. Ut pharetra dui et dui aliquam, eu dictum eros euismod. Phasellus in magna at enim eleifend porttitor. Aliquam cursus est nec leo rutrum volutpat.Suspendisse pharetra sollicitudin ante, at ultricies dui blandit et. Cras eget orci justo. Mauris pellentesque enim vel lorem euismod egestas. Cras ante libero, hendrerit sed mauris non, semper semper dui. Etiam vehicula nibh et massa semper tristique. Curabitur id lobortis diam. Phasellus placerat semper ante sed dictum. Praesent accumsan volutpat nulla, id rhoncus orci volutpat vel. Quisque arcu ligula, fringilla eget velit eu, volutpat congue diam. Donec non pharetra metus. Duis lacinia nunc vestibulum bibendum tristique.Integer finibus urna metus, in pulvinar elit condimentum ac. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Suspendisse blandit urna ex, sed placerat sapien congue eget. Aliquam ornare lacus velit, vitae iaculis tortor dapibus sit amet. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam interdum, neque vitae fringilla aliquam, elit arcu vehicula nibh, sit amet vestibulum arcu eros in tellus. Praesent tellus diam, venenatis vitae dolor et, vestibulum dignissim eros.Aliquam porta lectus sed augue rutrum, ut tincidunt nisi lobortis. Vestibulum tempor turpis et nunc auctor, at cursus erat euismod. Pellentesque at faucibus velit. Quisque arcu ex, ullamcorper consectetur congue quis, rutrum ac libero. Maecenas condimentum bibendum ante, commodo pellentesque eros. Sed accumsan leo et tortor faucibus pellentesque. Maecenas eu odio elit. Nam elementum feugiat nibh. Nam rutrum nulla ut ante tincidunt, mollis sollicitudin mauris laoreet. Mauris commodo malesuada nunc eu porttitor. Morbi elementum ligula ut risus suscipit, at malesuada eros varius. Donec auctor sit amet velit quis imperdiet. Pellentesque posuere erat eget cursus rhoncus. Suspendisse sagittis tortor efficitur nisl volutpat, sollicitudin lacinia arcu viverra. Vestibulum pulvinar vulputate ligula sed tempor.Etiam a diam efficitur, pulvinar dui quis, fermentum nunc. Aliquam blandit felis id diam tristique consectetur. Vestibulum nec diam consequat, condimentum ex eget, maximus libero. Praesent commodo egestas nisl. Cras elementum eu mi at convallis. Pellentesque libero arcu, facilisis eu commodo in, luctus non lacus. In sit amet ultrices nisi. Proin sit amet ex purus. Sed pellentesque vehicula lectus sit amet interdum. Maecenas at efficitur dui, sit amet dignissim lacus. Donec cursus lacinia est nec auctor. Ut tempus, urna fermentum fermentum dapibus, ipsum arcu commodo est, sit amet dapibus tortor turpis et tellus. Aenean rutrum enim sit amet leo ullamcorper congue. Sed hendrerit mattis cursus. Etiam ut sapien sed tellus sollicitudin dictum at at dui. Donec in pharetra sapien.Vestibulum in mauris bibendum elit facilisis auctor eu in nulla. Donec finibus eget neque in ornare. Aliquam pharetra enim ut quam blandit faucibus. Donec iaculis eros efficitur risus varius, ut mattis augue accumsan. Quisque non posuere nibh. Morbi ac blandit eros. Proin eros nibh, molestie at porttitor sit amet, mattis ut massa. Quisque pellentesque purus ac est placerat auctor. Nunc sit amet pretium tortor, id porta elit. Suspendisse sed sapien ac tortor fringilla viverra posuere quis orci.Integer eu ligula hendrerit, aliquam leo a, pellentesque ante. Donec ut feugiat sem. Proin iaculis, nibh quis sollicitudin sagittis, nisl metus mollis arcu, sed elementum risus sapien nec elit. Maecenas eu odio varius dolor pellentesque posuere non nec nunc. Cras lacinia gravida massa. Donec et pharetra enim. Nunc mi massa, dictum non pellentesque nec, iaculis dapibus lacus. Sed laoreet sodales gravida. In hac habitasse platea dictumst. In malesuada vestibulum nulla eu porttitor. Curabitur sodales rhoncus mollis. Maecenas congue semper odio in lacinia. Ut dapibus congue nisi, sit amet tristique tortor posuere eget. Nulla dolor risus, faucibus ac tortor quis, hendrerit tempor turpis. Vestibulum vulputate facilisis lectus, vitae maximus nulla condimentum sit amet.Nunc rutrum eu dolor non varius. Nullam quis ligula iaculis lorem lobortis tincidunt. Duis in nibh tellus. Proin at dolor diam. Donec tincidunt nibh at commodo gravida. Vestibulum nec fringilla nisl. Aliquam laoreet, elit sed vulputate feugiat, metus risus tristique erat, vel venenatis dolor quam non ex. Morbi fermentum ultricies enim et aliquam. Cras dapibus, nisl nec gravida scelerisque, est purus porttitor metus, sit amet dignissim mauris ex rutrum justo. Duis convallis non neque et convallis. Aenean tempor mattis ullamcorper. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris ac faucibus tellus. Proin accumsan vel justo in vulputate.Etiam in risus varius, ultricies diam sed, placerat justo. Suspendisse ultrices odio ut bibendum congue. Suspendisse at tristique magna. Nam scelerisque fringilla molestie. Morbi fringilla, turpis vitae finibus lobortis, leo est suscipit ex, ac egestas eros nisi eget nunc. Praesent id sagittis enim, ut congue velit. Sed vulputate, turpis sed sodales convallis, nisi eros ultricies ante, eu dapibus ligula erat non diam. Pellentesque eu ex et ante elementum elementum. Suspendisse sollicitudin, sem ut iaculis elementum, ante metus semper ligula, at molestie tellus erat vel ligula. Curabitur in pulvinar est. Pellentesque at dolor et dolor ornare consectetur ut sed nulla. Duis nulla ex, tempor dignissim quam a, condimentum porta libero. Sed elit nisi, consectetur a sem sit amet, feugiat condimentum purus.Curabitur pulvinar suscipit enim, quis auctor nunc suscipit non. Proin lobortis tellus mauris, sit amet congue nunc dictum vel. Sed velit est, gravida et felis a, blandit hendrerit nisl. Suspendisse eu dapibus lectus. Pellentesque nulla ex, egestas ut magna vitae, condimentum vehicula turpis. Sed mauris ipsum, consectetur eu consectetur et, interdum auctor lacus. Nullam venenatis tempus felis non mattis. Nunc malesuada, sapien ut fermentum gravida, tellus sem gravida turpis, in scelerisque enim mi quis nulla. Vestibulum mattis ullamcorper commodo. Nunc dictum enim eu augue dictum pretium. Nulla facilisi. Nulla et luctus mauris. Sed non massa orci.Aliquam eu interdum arcu. Fusce id tellus id metus ornare iaculis at vel ante. Phasellus eget tellus gravida, ultrices orci id, imperdiet felis. Mauris accumsan gravida lacus quis ullamcorper. Donec euismod tempus ultricies. Proin ornare volutpat dui, at faucibus odio feugiat at. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Maecenas sem nulla, convallis eu fringilla sed, semper at risus. Donec ut dapibus ipsum. Aliquam et suscipit eros.Integer vel nunc sit amet turpis sollicitudin varius et sed sapien. Mauris pretium quam ut urna lobortis suscipit. Morbi sed nibh ut mauris fringilla sagittis ut eget tortor. Praesent sed sem blandit, mattis ex at, pharetra turpis. Nulla rhoncus, justo in facilisis malesuada, neque diam fermentum diam, eu malesuada neque risus in lectus. Maecenas sagittis convallis tincidunt. In dapibus arcu in leo consectetur fermentum. Nam nec lorem vel dolor condimentum tempus eget vitae lectus. Integer quis ullamcorper purus. Aenean nec sapien molestie, faucibus mi et, gravida mauris. Nulla pharetra ipsum vel lacus fringilla congue. Praesent suscipit dui metus, vitae imperdiet arcu feugiat at.Proin molestie tincidunt nisl, sit amet venenatis diam. Nam consectetur lorem eget imperdiet venenatis. Proin non nisi luctus, accumsan lacus in, sodales neque. Nullam commodo at arcu nec lacinia. Nam commodo congue orci, vel finibus ante tristique at. Phasellus ex lacus, venenatis vitae magna id, iaculis porttitor elit. Pellentesque eget velit faucibus velit tincidunt tristique a ac dolor. Praesent efficitur cursus ligula, id consectetur orci luctus et. Integer rutrum consectetur nisl, non gravida sem blandit et. Cras ex justo, pulvinar at iaculis ut, tristique a nulla. Morbi sollicitudin, turpis sed dignissim fermentum, sem ex ullamcorper massa, ut faucibus lectus ipsum quis ex. Proin malesuada tempus lectus eget egestas. Pellentesque venenatis urna massa, eget lacinia orci fermentum quis. Pellentesque nibh eros, blandit id consectetur at, vulputate vel mi. Nullam viverra fermentum dignissim. Curabitur sit amet iaculis libero.Mauris ut posuere urna. Aenean id tristique tellus, ac venenatis leo. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Cras posuere tellus varius, bibendum velit eu, aliquam lorem. Mauris neque mauris, convallis a lacinia sed, fringilla vitae ex. In finibus scelerisque sapien ac faucibus. Morbi commodo, urna non pulvinar varius, tortor erat varius massa, vel semper turpis lorem ut urna. Donec pretium, orci quis pulvinar ornare, ligula lacus ultrices augue, ut iaculis libero nulla eu sapien.Donec et lectus non nisi aliquet fringilla eu in tellus. Mauris nec nisi ut felis aliquet pretium eu sit amet arcu. Nullam posuere gravida lectus, eu facilisis lacus dignissim sed. Nam fermentum rutrum consequat. Cras auctor, leo quis pulvinar blandit, eros metus gravida orci, non venenatis justo eros consectetur mauris. Sed commodo, tellus hendrerit aliquam feugiat, purus ligula bibendum elit, ac malesuada odio nibh ut sapien. Nunc faucibus lorem ut eros egestas venenatis. Suspendisse malesuada, nulla eu lacinia ultricies, arcu eros malesuada felis, et commodo leo dui sit amet lectus.Sed mattis nibh felis, vel tempor nibh convallis id. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur et ligula id sapien mollis facilisis vitae in mi. Etiam imperdiet quam nec felis elementum, non finibus orci consectetur. Quisque velit lectus, lacinia quis orci et, egestas tristique libero. Nullam dapibus posuere augue at pretium. Curabitur non nisi non lectus porttitor accumsan vitae a enim. Quisque et finibus augue. Cras eget massa sit amet purus blandit maximus vel vel urna. Praesent leo sem, fermentum sit amet vehicula vitae, pellentesque quis diam. Aenean nec risus metus. Aliquam at molestie velit. Nam tincidunt at est eget condimentum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Integer odio elit, facilisis sit amet faucibus quis, sollicitudin congue justo.Phasellus fermentum dui eget sapien convallis consectetur. Nam tincidunt sagittis dolor ut luctus. Fusce non sodales tortor, ut eleifend urna. Integer fringilla sapien ligula, id auctor risus pellentesque eget. Aenean et bibendum lectus. Praesent euismod at odio dictum facilisis. Vivamus sit amet convallis massa, nec fringilla libero. Aenean bibendum nisi a maximus aliquet. Aenean venenatis tincidunt feugiat. In laoreet ex at felis ullamcorper ornare.Mauris mollis fermentum aliquam. Sed non posuere arcu. Morbi placerat lectus in condimentum sollicitudin. Praesent vel cursus erat. Donec suscipit orci quis condimentum porttitor. Sed sem augue, finibus vel faucibus quis, aliquet et est. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.Proin imperdiet non diam sit amet accumsan. Phasellus ut massa ultricies, consequat velit quis, volutpat turpis. Aliquam ut ligula nibh. Quisque egestas purus felis. Sed faucibus ultrices augue non pulvinar. Vestibulum congue sem quis posuere pulvinar. Vivamus felis tortor, lobortis vehicula pretium vulputate, tincidunt ac urna. Sed id dignissim sem. Proin facilisis urna id est hendrerit, eu lacinia ex feugiat. Mauris vitae nunc velit. Nullam hendrerit convallis metus sed convallis.Maecenas gravida rutrum purus vel consequat. Fusce malesuada venenatis orci, et egestas ex condimentum in. Morbi ornare et neque sed finibus. Nullam nec nibh ornare, pellentesque lectus nec, vestibulum leo. Mauris ac metus vel turpis lobortis tincidunt. Pellentesque eget dignissim leo, id fringilla metus. Maecenas consectetur urna purus, at elementum sem tristique non. Sed sagittis posuere fringilla. Suspendisse ut ex vulputate nisi sodales scelerisque quis non dui. Quisque interdum elementum elit, et auctor orci bibendum ac. Sed vestibulum aliquet augue, in sollicitudin dui fringilla quis. Sed dignissim nisl magna, vehicula fringilla nunc lacinia id.Cras a condimentum nibh. Curabitur venenatis a nibh tempor facilisis. Nam lobortis sapien eu mi tincidunt scelerisque. Suspendisse vel rutrum ante, at tristique urna. Nunc dapibus sapien sit amet massa tincidunt cursus. Fusce condimentum pulvinar odio, vel fringilla augue consequat ut. Curabitur vel porta enim. Nulla fringilla diam at felis vehicula, eget blandit tellus tempor. Donec in sollicitudin sapien. Vivamus at varius arcu. Quisque luctus fringilla est, a dapibus lectus dignissim et. Pellentesque ligula purus, lacinia ac pretium at, placerat ac ante. Nunc vitae condimentum diam. Vestibulum vel magna eros. Fusce lectus justo, sagittis sed efficitur vel, mollis non dolor.Etiam tempor risus sit amet velit dictum, vitae aliquet lectus tempus. Praesent imperdiet, sapien ut varius tincidunt, ex libero euismod ipsum, ut ultricies lacus ex sit amet leo. Ut nec magna in lacus aliquet rhoncus sed eget orci. Ut nisl nunc, feugiat laoreet dolor at, accumsan convallis arcu. Integer ut volutpat ex. In hac habitasse platea dictumst. Donec eget mauris ex. Vivamus malesuada est id lorem rutrum posuere.Nunc viverra massa a porta ullamcorper. Integer fringilla fringilla elit, et tincidunt ex hendrerit non. Sed vestibulum vehicula ipsum vitae vulputate. Pellentesque vel urna ac elit ornare malesuada. Morbi egestas, augue eget venenatis molestie, ex eros euismod risus, at dictum mi sapien et velit. Morbi est arcu, malesuada quis nisl eget, tincidunt consectetur lorem. Sed scelerisque odio vitae nibh varius, elementum aliquet nulla tempus. Ut gravida varius nisi quis porta. Donec felis erat, aliquet non bibendum sit amet, ullamcorper non sapien. Duis lectus enim, commodo vitae commodo at, facilisis non felis. Etiam dolor tellus, euismod eu sodales sit amet, finibus eu arcu. Integer elementum, risus id commodo pretium, purus metus egestas velit, tincidunt ultricies lorem elit et nulla.Maecenas accumsan quis nibh sit amet euismod. Donec porttitor urna ac efficitur sollicitudin. Donec varius justo in quam lobortis, a dignissim sem sodales. Suspendisse maximus, nisi vitae accumsan dictum, elit justo eleifend odio, id pretium turpis sapien non lorem. Fusce tristique nibh nec interdum hendrerit. Nunc convallis, arcu sit amet eleifend congue, ante arcu interdum nibh, non dapibus arcu eros nec enim. Donec consequat finibus odio, pharetra aliquam tellus aliquam ac. Aliquam et porttitor nulla. Nunc vitae aliquet sem. Sed rhoncus dignissim ligula at euismod. Integer id diam vehicula, tempor felis sit amet, aliquet sem. Morbi non cursus neque, nec pulvinar lectus. Aliquam pellentesque quis lectus egestas vulputate.Sed mattis nulla eget odio posuere consequat. Aliquam rutrum augue tellus. Ut dapibus lectus imperdiet, tempus neque vitae, tristique lorem. Donec tincidunt eros vel diam tincidunt consectetur. Quisque eu mollis nibh. Phasellus iaculis eu urna quis pellentesque. Mauris posuere convallis libero eget placerat. Maecenas pharetra condimentum sem vel accumsan. Nunc dapibus, lorem et venenatis iaculis, arcu odio sagittis magna, vitae placerat purus lacus et ligula. Nunc non aliquet felis, ac luctus velit. Duis volutpat dolor ex, vitae volutpat felis lacinia ut. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae;Donec vitae leo risus. Duis ac consequat enim. Nam ac massa sed sapien tristique fermentum. Nunc imperdiet risus et tortor vulputate, ut rhoncus ipsum ultrices. Vestibulum pulvinar malesuada tellus. Phasellus a lacinia mauris, ut cursus lorem. Quisque sem purus, dapibus eu nunc ac, commodo tincidunt mauris. Proin vel porttitor tellus. Curabitur eget pretium sem. Ut ullamcorper sodales mi, varius iaculis augue maximus at. Sed aliquam bibendum ipsum vitae hendrerit. Fusce euismod velit orci, sed dignissim justo interdum quis. Vestibulum vehicula nisl ex. Aliquam id quam sit amet nisi mollis condimentum sit amet sed lectus. In leo justo, finibus eget maximus vel, sagittis quis augue. Quisque porta vestibulum leo at condimentum.Donec sit amet congue massa. Quisque sapien est, tincidunt nec metus ac, semper varius ante. Nunc feugiat ornare diam, sed ullamcorper ex ornare eget. Etiam sit amet ipsum pellentesque, finibus magna ac, dignissim risus. Sed ac dolor ipsum. Nulla ullamcorper egestas erat, eu vestibulum enim. Suspendisse iaculis sed nisi vitae auctor. Phasellus placerat elit eget bibendum ultricies.Donec accumsan arcu consectetur tortor ultricies, non accumsan diam pretium. Vivamus vel imperdiet ligula, a lacinia quam. Suspendisse volutpat rutrum imperdiet. Nam malesuada neque ut scelerisque porttitor. Quisque nulla metus, fringilla id venenatis sit amet, congue sed ligula. Maecenas tempus erat nec lectus mattis, vitae congue enim pellentesque. Morbi pharetra mauris augue, sed bibendum sapien pharetra fringilla. Aenean hendrerit est leo, sed tincidunt arcu semper vitae. Suspendisse vestibulum tempus tellus, ac ullamcorper massa sollicitudin vitae. Ut vel nulla congue, dictum lectus vel, ullamcorper dolor.Vestibulum vel convallis risus, nec porttitor sem. Suspendisse iaculis vestibulum tempus. Vestibulum mattis purus vel odio consectetur elementum. In sollicitudin pulvinar quam eget efficitur. Proin ut congue nisi. Morbi aliquet porta molestie. Nulla pharetra justo in elit vestibulum, quis interdum magna pretium. Sed vitae libero iaculis, tempor urna eu, maximus ex. In hac habitasse platea dictumst.Nam ut diam a magna tempus aliquet ut eget neque. Aliquam faucibus lectus sed orci rutrum ullamcorper. Quisque dictum tempus tincidunt. Quisque nec dolor orci. Cras vestibulum consequat tellus id dictum. Mauris aliquam pharetra dictum. Donec porta eleifend ipsum et pharetra. Fusce laoreet libero eget sollicitudin volutpat. Mauris eu urna sed risus ultricies accumsan. Cras nec eros sit amet dui posuere scelerisque. Duis feugiat ante eget quam cursus fringilla. Quisque tempus fermentum tempor.Quisque eu leo luctus quam venenatis dignissim. Ut molestie elit vitae elit blandit, at pretium magna accumsan. Nunc fringilla, ante nec pharetra dapibus, velit sem malesuada tellus, a tempus risus sapien at orci. In hac habitasse platea dictumst. Sed eu turpis placerat purus dignissim sodales. Nullam sit amet erat sit amet tortor placerat facilisis. Integer in nibh non tellus imperdiet placerat ut porta ante. Nulla iaculis, purus et rhoncus euismod, est enim sagittis ipsum, id ultrices orci velit in metus. Sed mattis neque sed purus gravida mollis. Quisque gravida scelerisque lacus, vel semper dui pretium vitae.Donec dignissim scelerisque diam, a convallis est aliquet sit amet. Phasellus viverra hendrerit facilisis. Aenean ornare, nibh non sollicitudin malesuada, lorem purus lacinia risus, ac faucibus dui turpis et augue. Curabitur ac nisl nibh. Interdum et malesuada fames ac ante ipsum primis in faucibus. Etiam facilisis urna eros, vitae cursus arcu cursus id. Phasellus tortor magna, blandit eget elementum sit amet, molestie at nisl. Praesent ac libero massa. Donec id sapien non orci malesuada condimentum. Nam egestas euismod sapien, a vestibulum nunc viverra at. Suspendisse quis neque erat. Sed placerat bibendum justo nec dignissim.Cras bibendum lectus in sapien ullamcorper, eu sodales ligula euismod. Nullam faucibus orci quis eros pellentesque, in pretium sem congue. Pellentesque velit diam, vehicula in nisi vel, ornare porta ex. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque ultricies neque purus, eget maximus justo tincidunt sed. Morbi tincidunt magna ac feugiat blandit. Morbi lectus erat, placerat at purus quis, iaculis iaculis ex. Nunc bibendum, dui in tempus ultrices, sapien eros euismod diam, euismod semper leo dui id magna. Vestibulum eu malesuada nisi. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Proin egestas euismod molestie. Cras a est eget tellus finibus molestie ut eu justo. Ut vitae diam id turpis condimentum finibus non quis neque. Praesent nec consequat orci. Donec mi purus, semper vitae aliquet sit amet, ullamcorper a libero.Nulla purus mauris, commodo sed placerat quis, vulputate non nunc. Proin lectus sem, ultrices id ipsum nec, aliquam dignissim arcu. Donec tempor purus sed metus sagittis, sed semper orci hendrerit. Nam elit turpis, posuere pellentesque facilisis in, aliquet nec libero. Fusce finibus lectus quis lacinia venenatis. Duis interdum dolor urna, sed rutrum mauris eleifend sit amet. Nullam a sodales nisl, nec placerat ligula. Pellentesque aliquam, quam vel sollicitudin blandit, orci nisl pharetra urna, a aliquam lectus mi ut magna. Fusce hendrerit, sem non venenatis dictum, felis velit euismod urna, ut maximus odio dolor luctus augue.Duis at massa quam. Nulla in purus vulputate, aliquet mi in, euismod est. Phasellus accumsan congue luctus. Phasellus fermentum eros dui, id accumsan leo condimentum et. Morbi vehicula urna et eros aliquam pulvinar. Curabitur in dapibus lectus, nec feugiat ligula. In sed ante ac nisi elementum pharetra. Nulla facilisis placerat varius.Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Maecenas id commodo nisi. Nam vitae nibh ut tortor feugiat rutrum at a nisl. Proin blandit est at commodo iaculis. Etiam aliquet arcu eget felis placerat, ac interdum est aliquet. Nunc feugiat dolor erat, non luctus arcu efficitur id. Cras dictum sem eget massa commodo, in rutrum ipsum vehicula.Morbi semper euismod metus sed finibus. Mauris euismod, nulla a faucibus tempus, sem velit pulvinar massa, sit amet dignissim urna sapien vitae lorem. Donec ornare mi feugiat felis condimentum, vitae convallis ante finibus. Fusce mattis, augue quis rutrum sodales, elit massa mattis justo, a tincidunt turpis dui vel ipsum. Aliquam quis nisl at dolor venenatis pretium vel a mauris. Mauris id turpis sed libero scelerisque varius et eget tellus. Praesent sodales tellus ac dui aliquam rhoncus. Vivamus ut gravida lorem. Aenean feugiat ex non erat pulvinar aliquam. Cras purus metus, consectetur a libero eu, lobortis posuere enim. Pellentesque sapien sem, ultricies vel vestibulum sed, iaculis a urna. Nullam non bibendum diam. Proin feugiat metus mi, id ultricies ipsum varius id. Nam vehicula nisl nec fringilla ullamcorper. Integer vehicula mattis lacus, rutrum aliquet mauris convallis eget.Donec euismod purus non mauris luctus luctus eget vitae turpis. Nam ultricies pulvinar iaculis. Donec eget tempor dolor. Mauris et nisl at lacus lacinia varius. In a leo sit amet justo euismod tincidunt. Vestibulum ut nunc consequat, fringilla velit non, posuere mauris. Etiam nec quam vitae diam dapibus pharetra vel at nibh. Nulla sollicitudin enim ut ornare tempus. Aliquam erat volutpat. Integer dapibus maximus nibh eu malesuada.Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc quis arcu hendrerit, eleifend tellus malesuada, dignissim urna. Cras scelerisque, erat sit amet eleifend pretium, tellus leo sollicitudin erat, vel pellentesque elit felis a enim. Vivamus nec tortor purus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Vivamus ultricies pretium elit vel maximus. Quisque varius, nisl placerat mollis pulvinar, magna justo eleifend sem, nec molestie ligula ante ac justo.Aliquam neque tortor, suscipit nec suscipit aliquam, blandit vel felis. Proin et rhoncus mauris. Praesent non tincidunt arcu. Pellentesque id mollis est. Phasellus euismod tortor ac nulla tristique sollicitudin. Nunc nec nunc vel urna faucibus mollis vel feugiat tellus. Sed vel odio lacus. Quisque finibus lacus eros, id ultrices enim aliquam vel. Vivamus aliquet luctus commodo. Nullam porttitor enim lorem. Donec eros odio, lobortis non varius a, pellentesque quis justo. Praesent aliquam tempus mi, in pretium felis convallis volutpat.Sed viverra purus elit, vitae aliquam nibh rhoncus nec. Duis nisl turpis, commodo id nisl eu, mattis fringilla nulla. Vestibulum luctus sem eget libero lacinia lobortis. Praesent ac felis nulla. Suspendisse quis elementum dolor, et suscipit risus. Nulla facilisi. Duis.
                 *     capituloCEN.Redactar("Lorem ipsum dolor sit amet", cap2Lib1);
                 *
                 *     System.Console.WriteLine("Contenido del capitulo 2 despues con lorem ipsum: " + capituloCEN.VerCapitulo(cap2Lib1).Contenido);
                 *     System.Console.WriteLine("LONGITUD: " + capituloCEN.VerCapitulo(cap2Lib1).Contenido.Length);
                 */

                /*
                 * // Pruebas Escritura colaborativa
                 *
                 *  capituloCEN.RedactarColaborativo(cap1Lib1);
                 *  capituloCEN.RedactarColaborativo(cap1Lib1);
                 *  capituloCEN.GuardarContenido(cap1Lib1, "Erase una vez...");
                 *  capituloCEN.RedactarColaborativo(cap1Lib1);
                 *
                 */

                /*
                 *  // PRUEBAS VerCategoriasLibro
                 *  // devuelve una lista de categorias a partir del id del Libro
                 *  IList<CategoriaEN> categoriasLibro1 = categoriaCEN.VerCatLibro (idLibro1);
                 *  // Para visualizar el contenido de categorias. Se muestran todas
                 *  var y = 0;
                 *  if (categoriasLibro1 != null) {
                 *          foreach (CategoriaEN categorias in categoriasLibro1) {
                 *                  System.Console.WriteLine ("Categoria " + y + " del Libro 1: " + categorias.Nombre_categoria.ToString ());
                 *                  y++;
                 *          }
                 *  }
                 *
                 *  // para el libr02
                 *  IList<CategoriaEN> categoriasLibro2 = categoriaCEN.VerCatLibro (idLibro4);
                 *  // Para visualizar el contenido de categorias. Se muestran todas
                 *  var contador = 0;
                 *  if (categoriasLibro2 != null) {
                 *          foreach (CategoriaEN categorias2 in categoriasLibro2) {
                 *                  System.Console.WriteLine ("Categoria " + contador + " del Libro 2: " + categorias2.Nombre_categoria.ToString ());
                 *                  contador++;
                 *          }
                 *  }
                 *
                 */


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
