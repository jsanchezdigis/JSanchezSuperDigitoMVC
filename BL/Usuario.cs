using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JsanchezSuperDigitoMvcContext context = new DL.JsanchezSuperDigitoMvcContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"UsuarioAdd " +
                        $"'{usuario.UserName}'," +
                        $"'{usuario.Password}'");
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
        public static ML.Result GetByName(string UserName)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JsanchezSuperDigitoMvcContext context = new DL.JsanchezSuperDigitoMvcContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetByUserName '{UserName}'").AsEnumerable().FirstOrDefault();

                    if (query != null)
                    {
                        result.Object = new List<object>();
                        var obj = query;
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Password = obj.Password;

                            result.Object = usuario;
                        }
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
        public static ML.Result HistorialGetByIdUsuario(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JsanchezSuperDigitoMvcContext context = new DL.JsanchezSuperDigitoMvcContext())
                {
                    var query = context.Historials.FromSqlRaw($"HistorialGetByIdUsuario '{IdUsuario}'").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach(var obj in query)
                        {
                            ML.Historial historial = new ML.Historial();

                            historial.IdHistorial = obj.IdHistorial;
                            historial.Digito = obj.Digito.Value;
                            historial.SuperDigito = obj.SuperDigito.Value;
                            historial.Fecha = obj.Fecha.Value.ToString("dd-MM-yyyy:hh:mm");
                            historial.Usuario = new ML.Usuario();
                            historial.Usuario.IdUsuario = obj.IdUsuario.Value;

                            result.Objects.Add(historial);
                        }
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