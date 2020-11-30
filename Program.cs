// NOTACIÓN INFIJO A POSFIJO CON RECURSIVIDAD
// INTEGRANTES: JACK NARVÁEZ, ALAN GUIJARRO, MARTÍN GUERRA, ISAAC HARO
// SEMESTRE: TERCERO
// MATERIA: ESTRUCTURA DE DATOS
using System;

namespace INFIJO_A_POSFIJO
{
    // CREACIÓN DE LA CLASE Nodo
    class Nodo
    {
        //INSTANCIAMOS SUS ATRIBUTOS
        public string dato;
        public Nodo siguiente;
        //CONSTRUCTOR Nodo PARA INICIALIZAR LOS ATRIBUTOS DE LA CLASE EN null
        public Nodo()
        {
            dato = null;
            siguiente = null;
        }
        //CONSTRUCTOR Nodo PARA INICIALIZAR LOS ATRIBUTOS DE LA CLASE EN CON LOS DATOS INGRESADOS POR EL USUARIO
        public Nodo(string a)
        {
            dato = a;
            siguiente = null;
        }
    }
    //CREACIÓN DE LA CLASE PILA
    class Pila
    {
        //Nodo comienzo QUE NOS SERVIRÁ DE RAÍZ EN NUESTRA PILA
        Nodo comienzo = new Nodo();
        //FUNCIÓN PUSH QUE INGRESA DATOS POR EL FINAL A NUESTRA PILA
        public void PUSH(string n)
        {
            if (comienzo == null)
            {
                comienzo.dato = n;
                comienzo.siguiente = null;
            }
            else
            {
                Nodo nuevo = comienzo;
                Nodo nuevo2 = new Nodo(n);
                while (nuevo.siguiente != null)
                {
                    nuevo = nuevo.siguiente;
                }
                nuevo.siguiente = nuevo2;
                nuevo2.siguiente = null;
            }
        }
        //FUNCIÓN POP QUE ELIMINA DATOS POR EL FINAL A NUESTRA PILA Y NOS VUELVE UN string
        public string POP()
        {
            Nodo actual = comienzo;
            Nodo anterior = null;
            string e;
            while (actual.siguiente != null)
            {
                anterior = actual;
                actual = actual.siguiente;

            }
            e = anterior.siguiente.dato;
            Console.WriteLine("Su elemento a eliminar es: " + anterior.siguiente.dato);
            anterior.siguiente = null;
            return e;
        }
        //FUNCIÓN ContarPila QUE LLEVA LA CUENTA DE LA CANTIDAD DE ELEMENTOS QUE TENEMOS EN NUESTRA PILA
        public int ContarPila()
        {
            int cont = 0;
            Nodo eliminar = comienzo;
            while (eliminar.siguiente != null)
            {
                eliminar = eliminar.siguiente;
                cont++;
            }
            Console.WriteLine("Su Pila contiene " + cont + " elementos");
            return cont;
        }
        //FUNCIÓN PrintPila QUE IMPRIME CADA ELEMENTO DE NUESTRA PILA
        public void PrintPila()
        {
            Nodo print = comienzo;
            Console.WriteLine("Ahora su Pila es: ");
            while (print != null)
            {
                Console.Write(print.dato);
                print = print.siguiente;
            }
        }

    }
    //CLASE Program
    class Program
    {
        //FUNCIÓN POSFIJO QUE REALIZA TODO EL PROCEDIMIENTO DE CAMBIO DE NOTACIÓN INFIJA A POSFIJA
        static void POSFIJO(int i, string operacion, Pila p1, Pila p2)
        {
            string n;
                n = operacion.Substring(i, 1);
                if (n == "+" || n == "-" || n == "*" || n == "/")
                {
                  //LLAMAMOS A NUESTRA FUNCIÓN PUSH
                p2.PUSH(n);
                }
                else
                {
                    if (n != "(")
                    {
                        if (n == ")")
                        {
                           //LLAMAMOS A NUESTRA FUNCIÓN PUSH Y LE INGRESAMOS EL POP DE MI OTRA PILA
                            p1.PUSH(p2.POP());
                        }
                        else
                        {
                           //LLAMAMOS A NUESTRA FUNCIÓN PUSH
                           p1.PUSH(n);
                        }
                    }

                }
                if (i != operacion.Length - 1)
                {
                   i++;
                   POSFIJO(i, operacion, p1, p2); //RECURSIVIDAD
                }
                else
                {
                   //LLAMAMOS A NUESTRA FUNCIÓN Final
                   Final(p1, p2);
                }       
        }
        //FUNCIÓN Final QUE COLOCA LOS ÚLTIMOS ELEMENTOS DE MI PILA DE OPERADORES EN MI PILA PRINCIPAL
        static void Final(Pila p1, Pila p2)
        {
            int cont;
            cont = p2.ContarPila();
            for (int j = 0; j < cont; j++)
            {
                p1.PUSH(p2.POP());
            }
            Console.WriteLine(" ");
            Console.WriteLine("Su pila en notación POSFIJA es:");
            p1.PrintPila();
            Console.WriteLine(" ");
            p1.ContarPila();
        }
        //PROGRAMA PRINCIPAL
        static void Main(string[] args)
        {
            //CREAMOS DOS OBJETOS TIPO Pila
            Pila p1 = new Pila();
            Pila p2 = new Pila();
            string operacion;
            Console.WriteLine("             Conversiones");
            Console.WriteLine("==============================\n\n");
            //PEDIMOS AL USUARIO INGRESAR LOS DATOS REQUERIDOS
            Console.WriteLine("Ingrese una ecuación en notación INFIJA");
            operacion = Console.ReadLine();
            //LLAMAMOS A NUESTRA FUNCIÓN POSFIJO QUE REALIZARÁ LA CONVERSIÓN DE NOTACIÓN
            POSFIJO(0,operacion, p1, p2);
            
        }
    }
}
