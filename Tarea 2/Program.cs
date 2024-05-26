using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace Tarea_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Listas para almacenar la información de los empleados
            List<int> cedulas = new List<int>();
            List<string> nombres = new List<string>();
            List<string> tiposEmpleado = new List<string>();
            List<int> cantidadHoras = new List<int>();
            List<int> preciosPorHora = new List<int>();
            List<int> Salario_ordinario = new List<int>();
            List<double> Aumento = new List<double>();
            List<int> Salario_bruto = new List<int>();
            List<int> Salario_neto = new List<int>();
            List<int> Deduccion_CCSS = new List<int>();
            string continuar;
            string tipo = "";

            // Bucle para añadir empleados
            do
            {
                // Solicitar y almacenar la cédula
                Console.Write("Digite el número de cédula del empleado: ");
                cedulas.Add(int.Parse(Console.ReadLine()));

                // Solicitar y almacenar el nombre
                Console.Write("Digite el nombre del empleado: ");
                nombres.Add(Console.ReadLine());

                // Solicitar y almacenar el tipo de empleado
                Console.Write("Digite el tipo de empleado (1 para Operario, 2 para Técnico y 3 para Profesional):");
                int tipoNumero = int.Parse(Console.ReadLine());

                if (tipoNumero == 1)
                {
                    tipo = "Operario";
                }
                else if (tipoNumero == 2)
                {
                    tipo = "Tecnico";
                }
                else if (tipoNumero == 3)
                {
                    tipo = "Profesional";
                }

                tiposEmpleado.Add(tipo);

                // Solicitar y almacenar la cantidad de horas laboradas
                Console.Write("Digite la cantidad de horas laboradas: ");
                cantidadHoras.Add(int.Parse(Console.ReadLine()));

                // Solicitar y almacenar el precio por hora laborada
                Console.Write("Digite el precio por hora laborada: ");
                preciosPorHora.Add(int.Parse(Console.ReadLine()));

                // Calcular el salario ordinario y agregarlo a la lista
                int salarioOrdinario = cantidadHoras[cantidadHoras.Count - 1] * preciosPorHora[preciosPorHora.Count - 1];
                Salario_ordinario.Add(salarioOrdinario);

                // Calcular el aumento
                double aumento = 0;
                if (tipoNumero == 1)
                {
                    aumento = 0.15; // Para Operario
                }
                else if (tipoNumero == 2)
                {
                    aumento = 0.2; // Para Técnico
                }
                else if (tipoNumero == 3)
                {
                    aumento = 0.3; // Para Profesional
                }

                // Agregar el aumento a la lista
                Aumento.Add(aumento);

                // Calcular el salario bruto (con aumento)
                int salarioBruto = (int)(salarioOrdinario + (salarioOrdinario * aumento));
                Salario_bruto.Add(salarioBruto);

                // Calcular la deducción de CCSS y agregarla a la lista
                double deduccionCCSS = salarioBruto * 0.0917;
                Deduccion_CCSS.Add((int)deduccionCCSS);

                // Calcular el salario neto
                double salneto = salarioBruto - deduccionCCSS;
                Salario_neto.Add((int)salneto);


                Console.WriteLine("\nInformación del empleado:");
                Console.WriteLine($"Cédula: {cedulas[cedulas.Count - 1]}");
                Console.WriteLine($"Nombre: {nombres[nombres.Count - 1]}");
                Console.WriteLine($"Tipo de Empleado: {tiposEmpleado[tiposEmpleado.Count - 1]}");
                Console.WriteLine($"Cantidad de Horas Laboradas: {cantidadHoras[cantidadHoras.Count - 1]}");
                Console.WriteLine($"Precio por Hora Laborada: {preciosPorHora[preciosPorHora.Count - 1]}");
                Console.WriteLine($"Salario Ordinario: {Salario_ordinario[Salario_ordinario.Count - 1]}");
                Console.WriteLine($"Aumento: {Salario_ordinario[Salario_ordinario.Count - 1] * Aumento[Aumento.Count - 1]}");
                Console.WriteLine($"Salario Bruto: {salarioBruto}");
                Console.WriteLine($"Salario Neto: {salneto}");
                Console.WriteLine($"Deducciones: {deduccionCCSS}");


                // Preguntar si se quiere añadir otro empleado
                Console.Write("¿Quieres registrar otro empleado? (s/n): ");
                continuar = Console.ReadLine().ToLower();
            } while (continuar == "s");

            // Mostrar la información de los empleados
            Console.WriteLine("\nInformación de los empleados registrados:");

            // Calcular Cantidad de Empleados Tipo Operario

            int cantidadOperarios = 0;
            for (int i = 0; i < tiposEmpleado.Count; i++)
            {
                if (tiposEmpleado[i] == "Operario")
                {
                    cantidadOperarios++;
                }
            }
            Console.WriteLine($"Cantidad de Empleados Tipo Operario: {cantidadOperarios}");

            // Calcular el acumulado del salario neto para los operarios
            int acumuladoNetoOperarios = Salario_neto.Where((salarioNeto, index) => tiposEmpleado[index] == "Operario").Sum();
            Console.WriteLine($"Acumulado Salario Neto para Operarios: {acumuladoNetoOperarios}");

            // Calcular el promedio del salario neto para los operarios
            double promedioOperarios = cantidadOperarios > 0 ? Salario_neto.Where((salarioNeto, index) => tiposEmpleado[index] == "Operario").Average() : 0;
            Console.WriteLine($"Promedio Salario Neto para Operarios: {promedioOperarios}");

            // Calcular Cantidad de Empleados Tipo Técnicos
            int cantidadTecnicos = 0;
            for (int i = 0; i < tiposEmpleado.Count; i++)
            {
                if (tiposEmpleado[i] == "Tecnico")
                {
                    cantidadTecnicos++;
                }
            }
            Console.WriteLine($"Cantidad de Empleados Tipo Tecnicos: {cantidadTecnicos}");

            // Calcular el acumulado del salario neto para los Técnicos
            int acumuladoNetoTecnicos = Salario_neto.Where((salarioNeto, index) => tiposEmpleado[index] == "Tecnico").Sum();
            Console.WriteLine($"Acumulado Salario Neto para Técnicos: {acumuladoNetoTecnicos}");

            // Calcular el promedio del salario neto para los Técnicos
            double promedioTecnicos = cantidadTecnicos > 0 ? Salario_neto.Where((salarioNeto, index) => tiposEmpleado[index] == "Tecnico").Average() : 0;
            Console.WriteLine($"Promedio Salario Neto para Operarios: {promedioTecnicos}");

            // Calcular Cantidad de Empleados Tipo Profesional
            int cantidadProfesionales = 0;
            for (int i = 0; i < tiposEmpleado.Count; i++)
            {
                if (tiposEmpleado[i] == "Profesional")
                {
                    cantidadProfesionales++;
                }
            }
            Console.WriteLine($"Cantidad de Empleados Tipo Profesional: {cantidadProfesionales}");

            // Calcular el acumulado del salario neto para los profesionales
            int acumuladoNetoProfesionales = Salario_neto.Where((salarioNeto, index) => tiposEmpleado[index] == "Profesional").Sum();
            Console.WriteLine($"Acumulado Salario Neto para Profesionales: {acumuladoNetoProfesionales}");

            // Calcular el promedio del salario neto para los profesionales
            double promedioProfesionales = cantidadProfesionales > 0 ? Salario_neto.Where((salarioNeto, index) => tiposEmpleado[index] == "Profesional").Average() : 0;
            Console.WriteLine($"Promedio Salario Neto para Profesionales: {promedioProfesionales}");
            Console.ReadLine();
        }
    }
}

