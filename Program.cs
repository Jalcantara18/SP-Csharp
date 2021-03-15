using System;
using System.Collections.Generic;
using System.Linq;

namespace SP_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int ID, ID2, Cant, Cantidad, Cantidad2, Devuelta, Edad, Total, Ctotal = 0, Op2;
            string Resultado, Resultado2, Nombre, Apellido;
            bool Conti = true, Respuesta = true;
            List<cliente> listaclientes = new List<cliente>();
            List<Factura> listaproducto = new List<Factura>();
            char Sexo, Sex, Res, Cont;
            do
            {
                ID = 0; Cant = 0; Cantidad = 0; Devuelta = 0; Cantidad2 = 0; Ctotal = 0; Total = 0;
                ListaProductos();
                SaltoDeLinea();

                try
                {
                    SImprimir(" Introduzca el ID del producto que desea: ");
                    while (!Int32.TryParse(Console.ReadLine(), out ID) || ID > 4 || ID < 1)
                    {
                        SImprimir(" El valor ingresado no es válido.\n Ingrese un número de ID correcto: ");
                    }
                    Resultado = IDseleccionado(ID.ToString());
                    Imprimir(" Usted ha seleccionado: " + Resultado);
                    SImprimir(" Introduzca la cantidad de productos que desea: ");
                    while (!Int32.TryParse(Console.ReadLine(), out Cantidad))
                    {
                        Imprimir(" El valor ingresado no es válido.\n Ingrese una cantidad correcta: ");
                    }
                    listaproducto.Add(new Factura(Resultado, Cantidad));
                    SImprimir(" Desea algo mas? (S/N): ");
                    Cont = Console.ReadLine().ToUpper()[0];
                    if (Cont == 'S')
                    {

                        do
                        {
                            ID2 = 0; Cantidad2 = 0;
                            SImprimir(" Introduzca el ID del producto que desea: ");
                            while (!Int32.TryParse(Console.ReadLine(), out ID2) || ID2 > 4 || ID2 < 1)
                            {
                                SImprimir(" El valor ingresado no es válido.\n Ingrese un número de ID correcto: ");
                            }
                            Resultado2 = IDseleccionado(ID2.ToString());
                            Imprimir(" Usted ha seleccionado: " + Resultado2);
                            SImprimir(" Introduzca la cantidad de productos que desea: ");
                            while (!Int32.TryParse(Console.ReadLine(), out Cantidad2))
                            {
                                Imprimir(" El valor ingresado no es válido.\n Ingrese una cantidad correcta: ");
                            }
                            Resultado = " " + Resultado + ", " + Resultado2;
                            Op2 = Operacion(ID2, Cantidad2);
                            Ctotal = Ctotal + Op2;
                            listaproducto.Add(new Factura(Resultado2, Cantidad2));

                            SImprimir(" Desea algo mas? (S/N): "); Cont = Console.ReadLine().ToUpper()[0]; Conti = (Cont == 'S') ? true : false;

                        } while (Conti);

                    }
                    else
                    {
                        SaltoDeLinea();
                    }
                    Limpiar();
                    Imprimir(" Ahora tomaremos algunos datos...");
                    SImprimir(" Inserte su nombre: ");
                    Nombre = (Console.ReadLine());
                    SImprimir(" Inserte su apellido: ");
                    Apellido = (Console.ReadLine());
                    SImprimir(" Inserte su edad: ");
                    Edad = int.Parse(Console.ReadLine());
                    SImprimir(" Introduzca Sexo (H) Hombre, (M) Mujer: ");
                    Sexo = Console.ReadLine().ToUpper()[0];
                    SImprimir(" Introduzca Cantidad pagada:");
                    while (!Int32.TryParse(Console.ReadLine(), out Cant))
                    {
                        Console.Write(" El valor ingresado no es válido.\nIngrese un número correcto: ");
                    }
                    Total = Ctotal + Operacion(ID, Cantidad);
                    Devuelta = fResta(Cant, Total);
                    if (Cant >= Total)
                    {
                        Console.Clear();
                        Imprimir(" Detalle de su compra: ");
                        Imprimir("| Producto |" + " Cantidad |");
                        Imprimir(" *****************************************");
                        foreach (Factura ListFact in listaproducto)
                        {
                            Imprimir(" |" + ListFact.Producto + " |" + ListFact.Cant + " |");
                        }
                        Imprimir(" Su orden fue procesada, su costo fue de RD$ " + Total + " y le resta un capital de RD$ " + Devuelta);


                    }
                    else if (Cant < Total)
                    {
                        Limpiar();
                        Imprimir(" Detalle de su compra: ");
                        Imprimir("| Producto |" + " Cantidad |");
                        Imprimir(" *****************************************");
                        foreach (Factura ListFact in listaproducto)
                        {
                            Imprimir(" |" + ListFact.Producto + " |" + ListFact.Cant + " |");
                        }
                        Imprimir(" El cliente no posee suficiente dinero para comprar la orden porque la misma da un total de RD$ "
                            + Total + "y el mismo cuenta con RD$ " + Cant);

                    }
                    listaclientes.Add(new cliente(Nombre, Apellido, Edad, Sexo, Resultado, Ctotal, Total, Devuelta));
                    listaproducto.Clear();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                finally
                {

                    SImprimir(" Desea Continuar? (S/N): "); Cont = Console.ReadLine().ToUpper()[0]; Respuesta = (Cont == 'S') ? true : false;
                    listaproducto.Clear();
                    Limpiar();
                }


            } while (Respuesta);
            SaltoDeLinea();
            SImprimir(" Desea imprimir un reporte del total de las compras por sexo (S/N): ");            
            Res = Console.ReadLine().ToUpper()[0];
            if (Res =='S')
            {
                SImprimir("Digite el sexo (H/M): ");
                Sex = Console.ReadLine().ToUpper()[0];
                var Filtro = listaclientes.Where(cliente => cliente.sexo == Sex);
                Imprimir(" |" + " Nombre |" + " Apellido |" + " Edad |" + " Sexo |" + " Producto | " + " Total |" + " Devuelta |");
                Imprimir(" **********************************************************************************************");
                foreach (cliente F in Filtro)
                {
                    Imprimir(" |" + F.nom + " |" + F.apell + "  |" + F.edad + "  |" + F.sexo + "  |" + F.Producto + "  |" + F.total + " |" + F.Devuelta+ " |");
                }
                SaltoDeLinea();
            }
            else
            {
                SaltoDeLinea();
            }
            
            SImprimir("Cualquier tecla para continuar: ");
            Console.ReadKey();
            Imprimir(" Todas las compras realizadas: ");
            Imprimir(" " + " Nombre " + " Apellido " + " Edad " + " Sexo " + " Producto " + " Total" + " Devuelta");
            Imprimir(" **********************************************************************************************");
            foreach (cliente ListCli in listaclientes)
            {
                Imprimir(" " + ListCli.nom + "  " + ListCli.apell + "  " + ListCli.edad + "  " + ListCli.sexo + " " + ListCli.Producto + " " + ListCli.total + "  " + ListCli.Devuelta);
            }

        }
       public enum Precio
        {
            Jabon = 10, PDental = 70, CDental = 25
        }
        static void SImprimir(string text) { Console.Write(text); }
        static void Imprimir(string text) { Console.WriteLine(text); }
        static void Limpiar() { Console.Clear(); }
        static void SaltoDeLinea() { Imprimir("\n"); }
        static void ListaProductos() {
            Imprimir(" **********************************************");
            Imprimir(" *  Bienvenido a Console.venta                *");
            Imprimir(" **********************************************");
            SaltoDeLinea();
            Imprimir(" ID          Producto          Precio   ");
            Imprimir(" ---------------------------------------");
            Imprimir(" 1)          Jabon             RD$ 10   ");
            Imprimir(" 2)          Pasta dental      RD$ 70   ");
            Imprimir(" 3)          Cepillo dental    RD$ 25   ");
        }
     
        public class cliente
        {
            public string nom { get; set; }
            public string apell { get; set; }
            public int edad { get; set; }
            public char sexo { get; set; }
            public string Producto { get; set; }
          
            public double pago { get; set; }
            public double total { get; set; }
            public double Devuelta { get; set; }
            public cliente(string cnom, string capell, int cedad, char csexo,string producto, double Pago, double Total, double Devuelta)
            {
                this.nom = cnom;
                this.apell = capell;
                this.edad = cedad;
                this.sexo = csexo;
                this.Producto = producto;
               
                this.pago = Pago;
                this.total = Total;
                this.Devuelta = Devuelta;
            }
        }

        public class Factura
        {
            public string Producto { get; set; }
            public double Cant { get; set; }
            public Factura(string producto, double Cantidad)
            {
               
                this.Producto = producto;
                this.Cant = Cantidad;
            }
        }
        static string IDseleccionado(string Op)
        {
            string Result = "";
            switch (Op)
            {
                case "1":

                   Result = "Jabon";

                    break;
                case "2":

                    Result = "Pasta Dental";

                    break;
                case "3":

                    Result = "Cepillo Dental";
                    break;
            }

            return Result;

        }
        static int fTotal(int a, int b)
        {
           int total = a * b;
            return total;
        }

        static int fResta(int a, int b)
        {
            int total = a - b;
            return total;
        }



        static int Operacion(int id, int cantidad)
        {
            int Result = 0;
            switch (id)
            {
                case 1:

                    Result = fTotal(cantidad, Convert.ToInt32(Precio.Jabon));
                    break;
                case 2:
                    Result = fTotal(cantidad, Convert.ToInt32(Precio.PDental));
                    break;
                case 3:

                    Result = fTotal(cantidad, Convert.ToInt32(Precio.CDental));

                    break;
                default:
                    Console.WriteLine(" Debe introducir un numero correcto");
                    break;
            }

            return Result;

        }

    }
}
