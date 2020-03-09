using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Autobuses_ITLA
{
    class Program
    {
        public struct autobus
        {
            public string marca { get; set; }
            public string modelo { get; set; }
            public int capacidad { get; set; }
            public string placa { get; set; }

            public chofer chofer_asignado { get; set; }
        }

        public static List<autobus> autobuses = new List<autobus>(); //Listado de autobuses

        public struct chofer 
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public long telefono { get; set; }
        }

        public static List<chofer> choferes = new List<chofer>(); //Listado de choferes

        public struct ruta 
        {
            public string ciudad_origen { get; set; }
            public string ciudad_destino { get; set; }
            public double costo { get; set; }

            public int cantidad_disponible { get; set; }
            public autobus autobus_asignado { get; set; }
        }

        public static List<ruta> rutas = new List<ruta>(); //Listado de rutas

        public static int cantidad;
        public static string ciudadOrigen;
        public static string ciudadDestino;
        public struct reservacion
        {
            public string nombre_cliente { get; set; }
            public ruta ruta_sel  { get; set; }

            public int cantidad_tickets { get; set; }

            public double total { get; set; }

        }

        public static List<reservacion> reservaciones = new List<reservacion>(); //Listado de reservaciones
        public enum opciones 
        {
            MANTENIMIENTO_AUTOBUSES = 1,
            MANTENIMIENTO_CHOFERES,
            MANTENIMIENTO_RUTAS,
            VENDER_TICKETS,
            VER_RESERVACIONES,
            SALIR_PROGRAMA,
        }

        public enum opciones_autobus 
        {
            CREAR_AUTOBUS = 1,
            EDITAR_AUTOBUS,
            LISTAR_AUTOBUS,
            BORRAR_AUTOBUS,
            VOLVER_MENU_PRINCIPAL,
        }

        public enum opciones_choferes
        {
            CREAR_CHOFER = 1,
            EDITAR_CHOFER,
            LISTAR_CHOFER,
            ASIGNAR_CHOFER,
            BORRAR_CHOFER,
            VOLVER_MENU_PRINCIPAL,
        }

        public enum opciones_rutas
        {
            CREAR_RUTA = 1,
            EDITAR_RUTA,
            LISTAR_RUTAS,
            BORRAR_RUTA,
            VOLVER_MENU_PRINCIPAL,
        }

        static void Main(string[] args)
        {
            menu();
        }
        public static void menu() 
        {
            Console.WriteLine("Bienvenido a Autobuses ITLA. Seleccione la opcion deseada:\n");
            Console.WriteLine(" 1- Para mantenimiento de autobuses\n 2- Para mantenimiento de choferes\n " +
                "3- Para manteminimiento de rutas\n 4- Vender tickets\n 5- Ver reservaciones\n 6- Salir del programa");

            try
            {
                int sel = Convert.ToInt32(Console.ReadLine());

                switch (sel)
                {
                    case (int)opciones.MANTENIMIENTO_AUTOBUSES:
                        Console.Clear();
                        mantenimiento_autobuses();
                        break;

                    case (int)opciones.MANTENIMIENTO_CHOFERES:
                        Console.Clear();
                        mantenimiento_choferes();
                        break;

                    case (int)opciones.MANTENIMIENTO_RUTAS:
                        mantenimientoRutas();
                        Console.Clear();
                        break;

                    case (int)opciones.VENDER_TICKETS:
                        comprarTicket();
                        Console.Clear();
                        break;

                    case (int)opciones.VER_RESERVACIONES:
                        verReservaciones();
                        Console.Clear();
                        break;

                    case (int)opciones.SALIR_PROGRAMA:
                        Console.WriteLine("\nGracias por usar Autobuses ITLA. Vuelve pronto!");
                        Environment.Exit(100);
                        break;

                    default:
                        Console.WriteLine("Seleccione dentro de las opciones dadas. Presione cualquier tecla para volver al menu.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo se aceptan valores de numeros enteros como opcion. Presione cualquier tecla para volver al menu.");
                Console.ReadKey();
                Console.Clear();
                menu();
            }
            catch (Exception E) 
            {
                Console.WriteLine("Ha habido un error de tipo: {0}. Presione cualquier tecla para al menu.", E);
                Console.ReadKey();
                Console.Clear();
                menu();
            }   
        }

        //-----------------------------Para mantenimiento de autobus---------------------------------------------
        public static void mantenimiento_autobuses() 
        {
            Console.WriteLine("Que operacion desea realizar:\n\n 1- Crear autobus\n 2- Editar autobus\n 3- Listar autobuses\n 4- Borrar autobus\n 5- Volver al menu principal");

            try
            {
                int sel = Convert.ToInt32(Console.ReadLine());

                switch (sel) 
                {
                    case (int)opciones_autobus.CREAR_AUTOBUS:
                        crear_autobus();
                        Console.WriteLine("\nAutobus creado. Presione cualquier tecla para volver al menu principal.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                    case (int)opciones_autobus.EDITAR_AUTOBUS:
                        editar_autobuses();
                        Console.WriteLine("\nAutobus editado. Presione cualquier tecla para volver al menu principal.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                    case (int)opciones_autobus.LISTAR_AUTOBUS:
                        listar_autobuses();
                        Console.WriteLine("\nPresione cualquier tecla para volver al menu principal.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                    case (int)opciones_autobus.BORRAR_AUTOBUS:
                        borrar_autobus();
                        Console.WriteLine("Autobus borrado. Presione cualquier tecla para volver al menu principal.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                    case (int)opciones_autobus.VOLVER_MENU_PRINCIPAL:
                        Console.Clear();
                        menu();
                        break;

                    default:
                        Console.WriteLine("Elija solo de entre las opciones dadas. Presione cualquier tecla para volver al mantenimiento de autobuses.");
                        Console.ReadKey();
                        Console.Clear();
                        mantenimiento_autobuses();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo se aceptan valores de numeros enteros como opcion. Presione cualquier tecla para volver al manteminiento de autobuses.");
                Console.ReadKey();
                Console.Clear();
                mantenimiento_autobuses();
            }
            catch (Exception E)
            {
                Console.WriteLine("Ha habido un error de tipo: {0}. Presione cualquier tecla para al mantenimiento de autobuses.", E);
                Console.ReadKey();
                Console.Clear();
                mantenimiento_autobuses();
            }
        }

        public static string strExepcion() //Metodo para capturar errores de marca, modelo y placa
        {
            string str = "";
            try
            {
                str = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo se aceptan valores de tipo cadena o string. Presione una tecla para volver a intentar.");
                Console.ReadKey();
                Console.Clear();
                crear_autobus();
            }
            return str;
        }
        public static void crear_autobus() 
        {
            autobus n_autobus = new autobus();

            //Ingreso de placa de autobus
            Console.WriteLine("Inserte la placa del autobus que desea crear");
            try
            {
                //Validacion de si placa existe
                string placa = Console.ReadLine();
                foreach (autobus item in autobuses)
                {
                    if (item.placa.Equals(placa))
                    {
                        Console.WriteLine("La placa ingresada ya esta en uso. Presione cualquier tecla para volver al menu de creacion de autobus.");
                        Console.ReadKey();
                        Console.Clear();
                        crear_autobus();
                    }
                }
                n_autobus.placa = placa;
            }

            catch (Exception exp)
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para volver al menu de creacion de autobus.", exp.Message);
                Console.ReadKey();
                Console.Clear();
                crear_autobus();
            }

            //Ingreso de marca de autobus
            Console.WriteLine("Inserte la marca del autobus que desea crear");
            n_autobus.marca = strExepcion();

            //Ingreso de modelo de autobus
            Console.WriteLine("Inserte el modelo del autobus que desea crear");
            n_autobus.modelo = strExepcion();

            //Ingreso de capacidad de autobus
            Console.WriteLine("Inserte la capacidad del autobus que desea crear");
            try
            {
                n_autobus.capacidad = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo se aceptan valores de tipo entero o integer. Presione una tecla para volver a menu principal.");
                Console.ReadKey();
                Console.Clear();
                menu();
            }

            
            autobuses.Add(n_autobus);
        }

        public static void listar_autobuses() 
        {
            foreach (autobus item in autobuses) 
            {
                Console.WriteLine("Autobus en posicion: {0}", autobuses.IndexOf(item) + 1);
                Console.WriteLine("Marca: {0}", item.marca);
                Console.WriteLine("Modelo: {0}", item.modelo);
                Console.WriteLine("Capacidad: {0}", item.capacidad);
                Console.WriteLine("Placa: {0}", item.placa);

                Console.WriteLine("Chofer: {0}", item.chofer_asignado.nombre);
                Console.WriteLine("");
            }
        }

        public static void editar_autobuses() 
        {
            Console.WriteLine("\nListado de autobuses\n");
            listar_autobuses();
            Console.Write("Inserte la placa del autobus que desea editar: ");
            string placa = Console.ReadLine();

            int contador = 0;
            foreach (autobus item in autobuses) 
            {
                if (item.placa == placa) 
                {
                    contador++;
                }
            }

            if (contador > 0)
            {
                Console.WriteLine("Placa validada!");
            }
            else 
            {
                Console.WriteLine("La placa ingresada no existe. Presione cualquier tecla para volver al menu principal.");
                Console.ReadKey();
                Console.Clear();
                menu();
            }
            Console.Clear();

            Console.WriteLine("\nQue desea cambiar\n 1- Marca\n 2- Modelo\n 3- Placa\n 4- Capacidad\n 5- Chofer");

            try
            {
                int sel2 = Convert.ToInt32(Console.ReadLine());

                switch (sel2)
                {
                    case 1:
                        editarMarca(placa);
                        break;

                    case 2:
                        editarModelo(placa);
                        break;

                    case 3:
                        editarPlaca(placa);
                        break;

                    case 4:
                        editarCapacidad(placa);
                        break;

                    case 5:
                        editarChofer(placa);
                        break;

                    default:
                        Console.WriteLine("Seleccione solo dentro de las opciones dadas. Presione cualquier tecla para volver al menu editar autobus");
                        Console.ReadKey();
                        Console.Clear();
                        editar_autobuses();
                        break;
                }
            }
            catch (FormatException) 
            {
                Console.WriteLine("Solo se aceptan valores de tipo numerico entero. Presione cualquier tecla para volver al menu de edicion de autobuses");
                Console.ReadKey();
                Console.Clear();
                editar_autobuses();
            }

        }

        public static void borrar_autobus() 
        {
            listar_autobuses();
            Console.WriteLine("Seleccione la posicion que desea borrar");
            try
            {
                int sel = Convert.ToInt32(Console.ReadLine());
                autobuses.RemoveAt(sel - 1);
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo valores de tipo entero son aceptados. Presione cualquier tecla para volver al menu de borrado.");
                Console.ReadKey();
                Console.Clear();
                borrar_autobus();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para volver al menu de borrado.", exp.Message);
                Console.ReadKey();
                Console.Clear();
                borrar_autobus();
            }
        }
        public static void editarMarca(string placa) 
        {
            int pos;
            autobus auto_actualizar = new autobus();
            mantenerCampos(ref auto_actualizar, placa);

            try
            {
                Console.WriteLine("Inserte el nuevo nombre de la marca");
                string marcaNueva = Console.ReadLine();

                auto_actualizar.marca = marcaNueva;

                foreach (autobus item in autobuses)
                {
                    if (item.placa.Equals(placa))
                    {
                        pos = autobuses.IndexOf(item);
                        autobuses[pos] = auto_actualizar;
                        break;
                    }
                }
                Console.WriteLine("Autobus editado de manera exitosa! Presione cualquier tecla par continuar.");
                Console.ReadLine();
            }
            catch (Exception exp) 
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para intentar de nuevo.", exp);
                Console.ReadKey();
                editarMarca(placa);
            }
        }

        public static void editarModelo(string placa)
        {
            int pos;
            autobus auto_actualizar = new autobus();
            mantenerCampos(ref auto_actualizar, placa);

            try
            {
                Console.WriteLine("Inserte el nuevo nombre de la marca");
                string modeloNuevo = Console.ReadLine();

                auto_actualizar.modelo = modeloNuevo;

                foreach (autobus item in autobuses)
                {
                    if (item.placa.Equals(placa))
                    {
                        pos = autobuses.IndexOf(item);
                        autobuses[pos] = auto_actualizar;
                        break;
                    }
                }
                Console.WriteLine("Autobus editado de manera exitosa! Presione cualquier tecla par continuar.");
                Console.ReadLine();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para intentar de nuevo.", exp);
                Console.ReadKey();
                editarMarca(placa);
            }
        }

        public static void editarPlaca(string placa)
        {
            int pos;
            autobus auto_actualizar = new autobus();
            mantenerCampos(ref auto_actualizar, placa);

            try
            {
                Console.WriteLine("Inserte el nuevo nombre de la marca");
                string placaNueva = Console.ReadLine();

                auto_actualizar.placa = placaNueva;

                foreach (autobus item in autobuses)
                {
                    if (item.placa.Equals(placa))
                    {
                        pos = autobuses.IndexOf(item);
                        autobuses[pos] = auto_actualizar;
                        break;
                    }
                }
                Console.WriteLine("Autobus editado de manera exitosa! Presione cualquier tecla par continuar.");
                Console.ReadLine();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para intentar de nuevo.", exp);
                Console.ReadKey();
                editarMarca(placa);
            }
        }

        public static void editarCapacidad(string placa)
        {
            int pos;
            autobus auto_actualizar = new autobus();
            mantenerCampos(ref auto_actualizar, placa);

            try
            {
                Console.WriteLine("Inserte el nuevo nombre de la marca");
                int capacidadNueva = Convert.ToInt32(Console.ReadLine());

                auto_actualizar.capacidad = capacidadNueva;

                foreach (autobus item in autobuses)
                {
                    if (item.placa.Equals(placa))
                    {
                        pos = autobuses.IndexOf(item);
                        autobuses[pos] = auto_actualizar;
                        break;
                    }
                }
                Console.WriteLine("Autobus editado de manera exitosa! Presione cualquier tecla par continuar.");
                Console.ReadLine();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para intentar de nuevo.", exp);
                Console.ReadKey();
                editarMarca(placa);
            }
        }

       
        public static void editarChofer(string placa)
        {
            int pos;
            autobus auto_actualizar = new autobus();
            mantenerCampos(ref auto_actualizar, placa);

            try
            {
                Console.WriteLine("Listado de choferes");
                foreach (chofer item in choferes) 
                {
                    Console.WriteLine("Posicion: {0}", choferes.IndexOf(item) + 1);
                    Console.WriteLine("Nombre: {0}", item.nombre);
                    Console.WriteLine("Apellido: {0}", item.apellido);
                    Console.WriteLine("Telefono: {0}", item.telefono);
                    Console.WriteLine("");
                }

                Console.WriteLine("Ingrese el nombre del chofer que desea agregar");
                string nombre = Console.ReadLine();

                foreach (chofer item in choferes) 
                {
                    if (item.nombre.Equals(nombre)) 
                    {
                        auto_actualizar.chofer_asignado = item;
                    }
                }

                foreach (autobus item in autobuses)
                {
                    if (item.placa.Equals(placa))
                    {
                        pos = autobuses.IndexOf(item);
                        autobuses[pos] = auto_actualizar;
                        break;
                    }
                }
                Console.WriteLine("Autobus editado de manera exitosa! Presione cualquier tecla par continuar.");
                Console.ReadLine();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para intentar de nuevo.", exp);
                Console.ReadKey();
                editarMarca(placa);
            }
        }

        //---------------------------Para mantenimiento de choferes------------------------------------------
        public static void mantenimiento_choferes()
        {
            Console.WriteLine("Que operacion desea realizar:\n\n 1- Crear chofer\n 2- Editar chofer\n 3- Listar chofer\n 4- Asignar chofer\n 5- Borrar chofer\n 6- Volver al menu principal");

            try
            {
                int sel = Convert.ToInt32(Console.ReadLine());

                switch (sel)
                {
                    case (int)opciones_choferes.CREAR_CHOFER:
                        crear_chofer();
                        Console.WriteLine("\nChofer creado. Presione cualquier tecla para volver al menu principal.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                    case (int)opciones_choferes.EDITAR_CHOFER:
                        _editarChofer();
                        Console.WriteLine("\nChofer editado. Presione cualquier tecla para volver al menu principal.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                    case (int)opciones_choferes.LISTAR_CHOFER:
                        listar_chofer();
                        Console.WriteLine("\nPresione cualquier tecla para volver al menu principal.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                     case(int)opciones_choferes.ASIGNAR_CHOFER:
                        asignarChofer();
                        Console.WriteLine("\nPresione cualquier tecla para volver al menu principal.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                    case (int)opciones_choferes.BORRAR_CHOFER:
                        borrar_chofer();
                        Console.WriteLine("Chofer borrado. Presione cualquier tecla para volver al menu principal.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                    case (int)opciones_choferes.VOLVER_MENU_PRINCIPAL:
                        Console.Clear();
                        menu();
                        break;

                    default:
                        Console.WriteLine("Elija solo de entre las opciones dadas. Presione cualquier tecla para volver al mantenimiento de autobuses.");
                        Console.ReadKey();
                        Console.Clear();
                        mantenimiento_choferes();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo se aceptan valores de numeros enteros como opcion. Presione cualquier tecla para volver al manteminiento de autobuses.");
                Console.ReadKey();
                Console.Clear();
                mantenimiento_choferes();
            }
            catch (Exception E)
            {
                Console.WriteLine("Ha habido un error de tipo: {0}. Presione cualquier tecla para al mantenimiento de autobuses.", E);
                Console.ReadKey();
                Console.Clear();
                mantenimiento_choferes();
            }
        }
        public static void mantenerCamposChoferes(ref chofer ch, int sel) 
        {
            ch.nombre = choferes[(sel - 1)].nombre;
            ch.apellido = choferes[(sel - 1)].apellido;
            ch.telefono = choferes[(sel - 1)].telefono;
        }
        public static void crear_chofer()
        {
            chofer n_chofer = new chofer();

            //Ingreso de nombre de chofer
            Console.WriteLine("Inserte el nombre del chofer que desea crear");
            try
            {
                n_chofer.nombre = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo se aceptan valores de tipo cadena o string. Presione una tecla para volver a menu principal.");
                Console.ReadKey();
                Console.Clear();
                menu();
            }

            //Ingreso de nombre de chofer
            Console.WriteLine("Inserte el apellido del chofer que desea crear");
            try
            {
                n_chofer.apellido = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo se aceptan valores de tipo cadena o string. Presione una tecla para volver a menu principal.");
                Console.ReadKey();
                Console.Clear();
                menu();
            }

            //Ingreso de telefono de chofer
            Console.WriteLine("Inserte el numero de telefono del chofer que desea crear");
            try
            {
                n_chofer.telefono = Convert.ToInt64(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo se aceptan valores de tipo entero o integer. Presione una tecla para volver a menu principal.");
                Console.ReadKey();
                Console.Clear();
                menu();
            }

            choferes.Add(n_chofer);
        }

        public static void _editarChofer() 
        {
            Console.WriteLine("Listado de choferes\n");
            listar_chofer();
            Console.WriteLine("Ingrese la posicion del chofer que desea editar: ");
            int sel = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n 1- Editar a nombre\n 2- Editar apellido\n 3- Editar numero de telefono\n 4- Volver al menu principal");
            int sel2 = Convert.ToInt32(Console.ReadLine());

            chofer choferActualizado = new chofer();
            mantenerCamposChoferes(ref choferActualizado, sel);

            switch (sel2) 
            {
                case 1:
                    Console.WriteLine("Inserte el nuevo nombre del chofer:");
                    choferActualizado.nombre = Console.ReadLine();
                    choferes[(sel - 1)] = choferActualizado;
                    break;

                case 2:
                    Console.WriteLine("Inserte el nuevo apellido del chofer:");
                    choferActualizado.apellido = Console.ReadLine();
                    choferes[sel - 1] = choferActualizado;
                    break;

                case 3:
                    Console.WriteLine("Inserte el nuevo numero de telefono del chofer:");
                    choferActualizado.telefono = Convert.ToInt64(Console.ReadLine());
                    choferes[sel - 1] = choferActualizado;
                    break;

                case 4:
                    menu();
                    break;
            }

            
        }

        public static void borrar_chofer() 
        {
            listar_chofer();
            Console.WriteLine("Seleccione la posicion que desea borrar");
            try
            {
                int sel = Convert.ToInt32(Console.ReadLine());
                choferes.RemoveAt(sel - 1);
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo valores de tipo entero son aceptados. Presione cualquier tecla para volver al menu de borrado.");
                Console.ReadKey();
                Console.Clear();
                borrar_chofer();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para volver al menu de borrado.", exp.Message);
                Console.ReadKey();
                Console.Clear();
                borrar_chofer();
            }
        }

        //asigna los campos que ya tenia el objeto en la lista al objeto nuevo
        public static void mantenerCampos(ref autobus _autobus, string campo) 
        {
            foreach (autobus item in autobuses)
            {
                if (item.placa.Equals(campo))
                {
                    _autobus.marca = item.marca;
                    _autobus.modelo = item.modelo;
                    _autobus.placa = item.placa;
                    _autobus.capacidad = item.capacidad;
                    _autobus.chofer_asignado = item.chofer_asignado;
                }
            }
        }
        
        public static void asignarChofer() 
        {
            Console.WriteLine("\nListado de autobuses sin chofer:\n");

            foreach (autobus item in autobuses)
            {
                if (string.IsNullOrEmpty(item.chofer_asignado.nombre))
                {
                    Console.WriteLine("Autobus en posicion: {0}", autobuses.IndexOf(item) + 1);
                    Console.WriteLine("Marca: {0}", item.marca);
                    Console.WriteLine("Modelo: {0}", item.modelo);
                    Console.WriteLine("Capacidad: {0}", item.capacidad);
                    Console.WriteLine("Placa: {0}", item.placa);
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("Inserte la placa de a que autobus desea asignar chofer");

            try
            {

                string entradaPlaca = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Listado de choferes: ");
                listar_chofer();

                Console.WriteLine("\nInserte el nombre del chofer que desea asignar al autobus ya seleccionado");
                string choferAsignar = Console.ReadLine();

                autobus autoActualizado = new autobus();
                mantenerCampos(ref autoActualizado, entradaPlaca);

                foreach (chofer item in choferes) //Comparando nombre entrado con choferes en listado
                {
                    if (item.nombre.Equals(choferAsignar)) 
                    {
                        autoActualizado.chofer_asignado = item;
                    }
                }

                int pos;

                foreach (autobus item in autobuses) //Comparando placa entrada con las listadas para sustituir el autobus por el actualizado
                {
                    if (item.placa.Equals(entradaPlaca)) 
                    {
                        pos = autobuses.IndexOf(item);
                        autobuses[pos] = autoActualizado;
                        break;
                    }
                }

                
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo valores de tipo entero aceptados.");
                asignarChofer();
            }
        }

        public static void listar_chofer()
        {
            foreach (chofer item in choferes)
            {
                Console.WriteLine("Chofer en posicion: {0}", choferes.IndexOf(item) + 1);
                Console.WriteLine("Nombre: {0}", item.nombre);
                Console.WriteLine("Apellido: {0}", item.apellido);
                Console.WriteLine("Telefono: {0}", item.telefono);
                Console.WriteLine("");
            }
        }

        //-----------------------METODOS DE RUTAS----------------------------------

        public static void mantenimientoRutas()
        {
            Console.WriteLine("Seleccione la opcion deseada: \n");

            Console.WriteLine(" 1- Crear ruta\n 2- Editar ruta\n 3- Listar ruta\n 4- Borrar ruta\n 5- Volver al menu principal");
            try
            {
                int sel = Convert.ToInt32(Console.ReadLine());
                switch (sel) 
                {
                    case (int)opciones_rutas.CREAR_RUTA:
                        crearRuta();
                        break;

                    case (int)opciones_rutas.EDITAR_RUTA:
                        _editarRutas();
                        break;

                    case (int)opciones_rutas.LISTAR_RUTAS:
                        listar_rutas();
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                        break;

                    case (int)opciones_rutas.BORRAR_RUTA:
                        borrarRuta();
                        break;

                    case (int)opciones_rutas.VOLVER_MENU_PRINCIPAL:
                        menu();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo valores de tipo entero son aceptados. Presione cualquier tecla para volver al menu de borrado.");
                Console.ReadKey();
                Console.Clear();
                borrarRuta();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para volver al menu de borrado.", exp.Message);
                Console.ReadKey();
                Console.Clear();
                borrarRuta();
            }
        }
        public static void crearRuta()
        {
            validacionAutobuses();

            Console.Clear();
            ruta rutaNueva = new ruta();

            Console.WriteLine("Ingrese la ciudad de origen de la ruta");
            rutaNueva.ciudad_origen = Console.ReadLine();

            Console.WriteLine("Ingrese la ciudad de destino de la ruta");
            rutaNueva.ciudad_destino = Console.ReadLine();

            Console.WriteLine("Ingrese el costo de la ruta");
            rutaNueva.costo = Convert.ToDouble(Console.ReadLine());

            
            Console.WriteLine("Listando autobuses con choferes\n");
            ls_autobuses_Con_Choferes();

            Console.WriteLine("Ingrese la placa del autobus que desea agregar a la ruta: ");
            try
            {
                string sel = Console.ReadLine();

                foreach (autobus item in autobuses) 
                {
                    if (item.placa.Equals(sel))
                    {
                        rutaNueva.autobus_asignado = item;
                        rutaNueva.cantidad_disponible = item.capacidad;
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("La placa ingresa no existe. Asegurese de ingresar una del listado.\n" +
                            "Presione cualquier tecla para volver al menu principal.");
                        Console.ReadKey();
                        Console.Clear();
                        menu();
                    }
                }
                rutas.Add(rutaNueva);
            }
            catch (FormatException) 
            {
                Console.WriteLine("Solo se aceptan valores de tipo cadena o string. Presione cualquier tecla para volver al menu principal.");
                Console.ReadKey();
                Console.Clear();
                menu();
            }
            Console.Clear();
            menu();
        }

        public static void mantenerCamposRutas(ref ruta ruta1, int sel)
        {
            ruta1.ciudad_origen = rutas[sel].ciudad_origen;
            ruta1.ciudad_destino = rutas[sel].ciudad_destino;
            ruta1.costo = rutas[sel].costo;
            ruta1.autobus_asignado = rutas[sel].autobus_asignado;
            ruta1.cantidad_disponible = rutas[sel].autobus_asignado.capacidad;
        }

        public static void listar_rutas()
        {
            Console.Clear();
            Console.WriteLine("Listado de rutas: \n");
            foreach (ruta item in rutas)
            {
                Console.WriteLine("Ruta en posicion: {0}", rutas.IndexOf(item) + 1);
                Console.WriteLine("Ciudad de origen: {0}", item.ciudad_origen);
                Console.WriteLine("Ciudad de destino: {0}", item.ciudad_destino);
                Console.WriteLine("Capacidad {0}", item.autobus_asignado.capacidad);
                Console.WriteLine("Asientos disponibles: {0}", item.cantidad_disponible); 
                Console.WriteLine("Costo de la ruta: {0}", item.costo);
                Console.WriteLine("");
            }
            
        }

        public static void _editarRutas()
        {
            Console.WriteLine("Listado de rutas\n");
            listar_rutas();

            int sel = 0;
            int sel2 = 0;

            try
            {
                Console.WriteLine("Ingrese la posicion de la ruta que desea editar: ");
                sel = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n 1- Editar ciudad de origen\n 2- Editar ciudad destino\n 3- Editar costo de la ruta\n 4- Editar autobus asignado\n 5- Volver al menu principal");
                sel2 = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception exp) 
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para volver al menu de mantenimiento", exp.Message);
            }

            ruta rutaActualizada = new ruta();
            mantenerCamposRutas(ref rutaActualizada, sel);

            switch (sel2)
            {
                case 1:
                    Console.WriteLine("Inserte la nueva ciudad de origen:");
                    try 
                    {
                        rutaActualizada.ciudad_origen = Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Entrada de tipo de dato equivocada. Presione cualquier tecla para volver la menu de mantenimiento de rutas.");
                        Console.ReadKey();
                        Console.Clear();
                        mantenimientoRutas();
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Error: {0}", exp.Message);
                    }
                    rutas[(sel - 1)] = rutaActualizada;
                    break;

                case 2:
                    Console.WriteLine("Inserte la nueva ciudad de destino:");

                    try 
                    {
                        rutaActualizada.ciudad_destino = Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Entrada de tipo de dato equivocada. Presione cualquier tecla para volver la menu de mantenimiento de rutas.");
                        Console.ReadKey();
                        Console.Clear();
                        mantenimientoRutas();
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Error: {0}",exp.Message);
                    }
                    rutas[(sel - 1)] = rutaActualizada;
                    break;

                case 3:
                    Console.WriteLine("Inserte el nuevo costo de la ruta:");

                    try
                    {
                        rutaActualizada.costo = Convert.ToDouble(Console.ReadLine());
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("Entrada de tipo de dato equivocada. Presione cualquier tecla para volver la menu de mantenimiento de rutas.");
                        Console.ReadKey();
                        Console.Clear();
                        mantenimientoRutas();
                    }
                    catch (Exception exp) 
                    {
                        Console.WriteLine(exp.Message);
                    }
                    rutas[(sel - 1)] = rutaActualizada;
                    break;

                case 4:
                    Console.Clear();
                    ls_autobuses_Con_Choferes();
                    Console.WriteLine("Inserte la placa del nuevo autobus:");

                    try
                    {
                        string placaEntrada = Console.ReadLine();

                        foreach (autobus item in autobuses)
                        {
                            if (item.placa.Equals(placaEntrada))
                            {
                                rutaActualizada.autobus_asignado = item;
                            }
                        }

                    }
                    catch (FormatException) 
                    {
                        Console.WriteLine("Entrada de tipo de dato equivocada. Presione cualquier tecla para volver la menu de edicion.");
                        Console.ReadKey();
                        Console.Clear();
                        _editarRutas();
                    }

                    rutas[(sel - 1)] = rutaActualizada;
                    break;

                case 5:
                    menu();
                    break;

                default:
                    Console.WriteLine("Seleccione detro de las opciones dadas.Presione cualquier tecla para volver al menu principal");
                    Console.ReadKey();
                    Console.Clear();
                    menu();
                    break;
            }


        }

        public static void borrarRuta() 
        {
            Console.WriteLine("Ingrese la posicion de la ruta que desea borrar");
            try
            {
                int sel = Convert.ToInt32(Console.ReadLine());
                rutas.RemoveAt(sel - 1);
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo valores de tipo entero son aceptados. Presione cualquier tecla para volver al menu de mantenimiento.");
                Console.ReadKey();
                Console.Clear();
                mantenimientoRutas();
            }
            catch (Exception exp) 
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para volver al menu de mantenimiento.", exp.Message);
                Console.ReadKey();
                Console.Clear();
                mantenimientoRutas();
            }
        }

        public static void ls_autobuses_Con_Choferes() 
        {
            foreach (autobus item in autobuses) 
            {
                if (item.chofer_asignado.nombre != null)
                {
                    Console.WriteLine("Autobus en posicion: {0}", autobuses.IndexOf(item) + 1);
                    Console.WriteLine("Marca del autobus: {0}", item.marca);
                    Console.WriteLine("Modelo del autobus: {0}", item.modelo);
                    Console.WriteLine("Placa del autobus: {0}", item.placa);
                    Console.WriteLine("Chofer del autobus: {0}", item.chofer_asignado.nombre);
                    Console.WriteLine("");
                }
                else 
                {
                    Console.WriteLine("No hay autobuses con choferes asignados. Presione cualquier tecla para volver al menu principal.");
                    Console.ReadKey();
                    menu();
                }
            }
        }

        public static void validacionAutobuses()
        {
            if (autobuses.Count == 0) 
            {
                Console.WriteLine("Aun no hay autobuses disponibles. Presione cualquier tecla para volver al menu principal.");
                Console.ReadKey();
                Console.Clear();
                menu();
            }

            int contador = 0;

            try
            {
                foreach (autobus item in autobuses)
                {
                    if (item.chofer_asignado.nombre.Length > 2)
                    {
                        contador++;
                    }
                }
            }
            catch (Exception exp) 
            {
                Console.WriteLine("Error: {0}. Es probable que aun no hayan autobuses con chofer asignado.\n" +
                    " Vaya a mantenimiento de choferes y en la opcion 4 agregue uno." +
                    " Si aun no ha creado choferes vaya primero a la opcion 1 de mantenimiento de choferes.", exp.Message);
                Console.ReadKey();
                Console.Clear();
                menu();
            }

            if (contador == 0) 
            {
                Console.WriteLine("No hay autobuses con choferes asignados. Presione cualquier tecla para volver al menu principal.");
                Console.ReadKey();
                Console.Clear();
                menu();
            }
        }


        //---------------------------------Tickets y reservaciones-------------------------------------

        public static void validacionTickets()
        {
            if (rutas.Count == 0)
            {
                Console.WriteLine("Aun no hay rutas disponibles. Presione cualquier tecla para volver al menu principal.");
                Console.ReadKey();
                Console.Clear();
                menu();
            }
        }

        public static void comprarTicket() 
        {
            validacionTickets();

            Console.WriteLine("Inserte nombre del cliente: ");
            try
            {
                reservacion reserv_nueva = new reservacion();

                reserv_nueva.nombre_cliente = Console.ReadLine();

                Console.WriteLine("\nListado de rutas con asientos disponibles:\n ");
                foreach (ruta item in rutas) 
                {
                    if (item.cantidad_disponible > 0) 
                    {
                        Console.WriteLine("Ciudad origen: {0}", item.ciudad_origen);
                        Console.WriteLine("Ciudad destino: {0}", item.ciudad_destino);
                        Console.WriteLine("Costo de ticket : {0}", item.costo);
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("Inserte la ciudad de origen de la ruta que desea comprar el ticket");
                ciudadOrigen = Console.ReadLine();

                Console.WriteLine("Inserte la ciudad de destino de la ruta que desea comprar el ticket");
                ciudadDestino = Console.ReadLine();

                foreach (ruta item in rutas) 
                {
                    if (item.ciudad_origen.Equals(ciudadOrigen) && item.ciudad_destino.Equals(ciudadDestino))
                    {
                        reserv_nueva.ruta_sel = item;
                    }
                    else 
                    {
                        Console.WriteLine("Nombres de ciudades ingresados no estan en las rutas. Presione cualquier tecla para volver al menu de compra de tickets.");
                        Console.Clear();
                        comprarTicket();
                    }
                }

                Console.WriteLine("Seleccione la cantidad de tickets que desea comprar");
                cantidad = Convert.ToInt32(Console.ReadLine());

                foreach (ruta item in rutas)
                {
                    if (item.ciudad_origen.Equals(ciudadOrigen) && item.ciudad_destino.Equals(ciudadDestino))
                    {
                        if (item.autobus_asignado.capacidad < cantidad)
                        {
                            Console.WriteLine("No hay suficiente cantidad disponible. Presione cualquier tecla para volver al menu.");
                            Console.ReadKey();
                            comprarTicket();
                        }
                    }
                }
                //Restando cantidad comprada a la ruta
                //rutas.Where(p => p.ciudad_origen.Equals(ciudadOrigen) && p.ciudad_destino.Equals(ciudadDestino)).ToList().ForEach(p => p.cantidad_disponible -= cantidad);

                foreach (ruta item in rutas) 
                {
                    if (item.autobus_asignado.capacidad > cantidad) 
                    {
                        reserv_nueva.cantidad_tickets = cantidad;
                    }
                }


                foreach (ruta item in rutas)
                {
                    if (item.ciudad_origen.Equals(ciudadOrigen))
                    {
                        reserv_nueva.total = item.costo * cantidad;
                    }
                }

                reservaciones.Add(reserv_nueva);

                //Restando cantidad de tickets comprados a la ruta

                //adultos.Where(p => p.nombre2 == "Pedro").ToList().ForEach(p => { p.nombre2 = "Carlos"; p.apellido2 = "Mejia"; });
               // rutas.Where(p => p.ciudad_origen == ciudadOrigen && p.ciudad_destino == ciudadDestino).ToList().ForEach(p => p.autobus_asignado = autoActualizado);
            }
            catch (FormatException) 
            {
                Console.WriteLine("Error de entrada de tipo de datos. Presione cualquier tecla para volver a intentar.");
                Console.ReadKey();
                Console.Clear();
                comprarTicket();
            }
            Console.WriteLine("Venta exitosa! Presione cualquier tecla para volver al menu principal.");
            Console.ReadKey();
            restarVendidos();
            Console.Clear();
            menu();
        }

        public static void restarVendidos() 
        {
            ruta rutaActualizada = new ruta();
            int indice = 5;

            foreach (ruta item in rutas) 
            {
                if (item.ciudad_origen == ciudadOrigen && item.ciudad_destino == ciudadDestino) 
                {
                    indice = rutas.IndexOf(item);
                    rutaActualizada.autobus_asignado = item.autobus_asignado;
                    rutaActualizada.ciudad_destino = item.ciudad_destino;
                    rutaActualizada.ciudad_origen = item.ciudad_origen;
                    rutaActualizada.costo = item.costo;
                    rutaActualizada.cantidad_disponible = item.cantidad_disponible - cantidad;
                }
            }

            rutas[indice] = rutaActualizada;

            cantidad = 0;
            ciudadOrigen = "";
            ciudadDestino = "";
        }
        public static void verReservaciones() 
        {
            listar_rutas();


            try
            {
                Console.WriteLine("Escriba la ciudad de origen de la ruta: ");
                string c_Origen = Console.ReadLine();

                Console.WriteLine("Escriba la ciudad de destino de la ruta: ");
                string c_Destino = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Listado de reservaciones de la ruta seleccionada:\n ");

                foreach (reservacion item in reservaciones)
                {
                    if (item.ruta_sel.ciudad_origen.Equals(c_Origen) && item.ruta_sel.ciudad_destino.Equals(c_Destino))
                    {
                        Console.WriteLine("Nombre de cliente: {0}", item.nombre_cliente);
                        Console.WriteLine("Ruta: {0} - {1}", item.ruta_sel.ciudad_origen, item.ruta_sel.ciudad_destino);
                        Console.WriteLine("Cantidad de tickets comprados: {0}", item.cantidad_tickets);
                        Console.WriteLine("Total de la compra: {0}", item.total);
                        Console.WriteLine("");
                    }
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Tipo de dato insertado es inconrrecto. Presione cualquier tecla para volver al menu reservaciones");
                Console.ReadKey();
                Console.Clear();
                verReservaciones();
            }
            catch (Exception exp) 
            {
                Console.WriteLine("Error: {0}. Presione cualquier tecla para volver al menu de reservaciones.", exp.Message);
                Console.ReadKey();
                Console.Clear();
                verReservaciones();
            }
            Console.WriteLine("Presione alguna tecla para volver al menu principal.");
            Console.ReadKey();
            Console.Clear();
            menu();
        }
    }
}
