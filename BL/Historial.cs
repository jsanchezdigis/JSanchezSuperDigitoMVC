using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Historial
    {
        public static int CalcularSuperDigito(int Digito)
        {
            if (Digito < 10)//Checamos si el numero es menor a 10
            {
                return Digito;
            }

            int suma = 0;
            while (Digito > 0)//Sumar cada uno de los digitos
            {
                suma += Digito % 10;//Obtenemos el residuo y lo sumamos
                Digito /= 10;//obtenemos la reduccion del numero
            }
            //Imprimir todas las sumas
            //int resultado = suma;
            //while(resultado != 0)
            //{
            //    Console.WriteLine("La suma de los super digitos es {0} ", resultado);
            //    break;
            //}

            return CalcularSuperDigito(suma);
        }
        public static ML.Result Add(ML.Historial historial)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JsanchezSuperDigitoMvcContext context = new DL.JsanchezSuperDigitoMvcContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"HistorialAdd1 " +
                        $"'{historial.Digito}'," +
                        $"'{historial.SuperDigito}'," +
                        $"'{historial.Usuario.IdUsuario}'");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(ML.Historial historial)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JsanchezSuperDigitoMvcContext context = new DL.JsanchezSuperDigitoMvcContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"HistorialDelete '{historial.IdHistorial}'");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino el registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
