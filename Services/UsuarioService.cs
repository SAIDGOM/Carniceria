using Carniceria.Interfaces;
using Carniceria.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Carniceria.Services
{
    public static class UsuarioService
    {
        private const string NombreApp = "CARNICERIA";

        // ARCHIVOS
        private static readonly string carpetaPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        // ARCHIVOS
        private static readonly string carpetaData = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            NombreApp,
            "Datos");

        // ARCHIVOS
        private static readonly string rutaUsuarios = Path.Combine(carpetaData, "usuarios.dat");

        // ARCHIVOS
        private static readonly string rutaBitacora = Path.Combine(carpetaData, "bitacora_accesos.dat");

        static UsuarioService()
        {
            // EXCEPCIONES
            try
            {
                if (!Directory.Exists(carpetaData))
                {
                    Directory.CreateDirectory(carpetaData);
                }

                string rutaUsuariosPlantilla = Path.Combine(carpetaPlantilla, "usuarios.dat");
                bool usuariosVacio = File.Exists(rutaUsuarios) && new FileInfo(rutaUsuarios).Length == 0;
                bool plantillaUsuariosTieneDatos = File.Exists(rutaUsuariosPlantilla) && new FileInfo(rutaUsuariosPlantilla).Length > 0;

                if ((!File.Exists(rutaUsuarios) || usuariosVacio) && plantillaUsuariosTieneDatos)
                {
                    // ARCHIVOS
                    File.Copy(rutaUsuariosPlantilla, rutaUsuarios, true);
                }

                if (!File.Exists(rutaUsuarios) || new FileInfo(rutaUsuarios).Length == 0)
                {
                    string usuarioMaestro = "ADMI,1234,Admi,Administrador";

                    // ARCHIVOS
                    File.WriteAllLines(rutaUsuarios, new[] { usuarioMaestro });
                }

                if (!File.Exists(rutaBitacora))
                {
                    string rutaBitacoraPlantilla = Path.Combine(carpetaPlantilla, "bitacora_accesos.dat");

                    if (File.Exists(rutaBitacoraPlantilla) && new FileInfo(rutaBitacoraPlantilla).Length > 0)
                    {
                        // ARCHIVOS
                        File.Copy(rutaBitacoraPlantilla, rutaBitacora, true);
                    }
                    else
                    {
                        // ARCHIVOS
                        File.Create(rutaBitacora).Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[CRÍTICO] Fallo al iniciar el servicio de usuarios: {ex.Message}");
            }
        }

        // HERENCIA DE INTERFACES
        public static IUsuario Autenticar(string username, string password)
        {
            if (!File.Exists(rutaUsuarios)) return null;

            // EXCEPCIONES
            try
            {
                // ARCHIVOS
                var lineas = File.ReadAllLines(rutaUsuarios);

                foreach (var linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    var datos = linea.Split(',');

                    if (datos.Length >= 3 &&
                        datos[0].Trim().Equals(username.Trim(), StringComparison.OrdinalIgnoreCase) &&
                        datos[1].Trim() == password.Trim())
                    {
                        string rol = datos[2].Trim();
                        string nombreReal = datos.Length >= 4 ? datos[3].Trim() : datos[0].Trim();

                        if (rol.Equals("Admi", StringComparison.OrdinalIgnoreCase))
                        {
                            // INSTANCIACIÓN DE CLASES PROPIAS
                            return new Admi
                            {
                                Username = datos[0].Trim(),
                                Nombre = nombreReal
                            };
                        }

                        // INSTANCIACIÓN DE CLASES PROPIAS
                        return new Empleado
                        {
                            Username = datos[0].Trim(),
                            Nombre = nombreReal
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Error al leer el archivo de autenticación: {ex.Message}");
            }

            return null;
        }

        // HERENCIA DE INTERFACES
        public static List<IUsuario> ObtenerTodos()
        {
            // HERENCIA DE INTERFACES
            var lista = new List<IUsuario>();

            if (!File.Exists(rutaUsuarios)) return lista;

            // EXCEPCIONES
            try
            {
                // ARCHIVOS
                var lineas = File.ReadAllLines(rutaUsuarios);

                foreach (var linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    var datos = linea.Split(',');

                    if (datos.Length >= 3)
                    {
                        string username = datos[0].Trim();
                        string rol = datos[2].Trim();
                        string nombreReal = datos.Length >= 4 ? datos[3].Trim() : username;

                        if (rol.Equals("Admi", StringComparison.OrdinalIgnoreCase))
                        {
                            // INSTANCIACIÓN DE CLASES PROPIAS
                            lista.Add(new Admi
                            {
                                Username = username,
                                Nombre = nombreReal
                            });
                        }
                        else
                        {
                            // INSTANCIACIÓN DE CLASES PROPIAS
                            lista.Add(new Empleado
                            {
                                Username = username,
                                Nombre = nombreReal
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Fallo al listar los usuarios: {ex.Message}");
            }

            return lista;
        }

        public static (string Pass, string Rol, string Nombre)? ObtenerPorNombre(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;
            if (!File.Exists(rutaUsuarios)) return null;

            // EXCEPCIONES
            try
            {
                // ARCHIVOS
                var lineas = File.ReadAllLines(rutaUsuarios);

                foreach (var linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    var datos = linea.Split(',');

                    if (datos.Length >= 3 &&
                        datos[0].Trim().Equals(username.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        string nombreReal = datos.Length >= 4 ? datos[3].Trim() : datos[0].Trim();
                        return (datos[1].Trim(), datos[2].Trim(), nombreReal);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Fallo al buscar el usuario '{username}': {ex.Message}");
            }

            return null;
        }

        public static bool ExisteUsuario(string username)
        {
            return ObtenerPorNombre(username) != null;
        }

        public static bool GuardarUsuario(string usernameOriginal, string usernameNuevo, string password, string rol, string nombre)
        {
            if (string.IsNullOrWhiteSpace(usernameNuevo) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(rol) ||
                string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            if (usernameNuevo.Contains(",") ||
                password.Contains(",") ||
                rol.Contains(",") ||
                nombre.Contains(","))
            {
                return false;
            }

            // EXCEPCIONES
            try
            {
                if (!Directory.Exists(carpetaData))
                {
                    Directory.CreateDirectory(carpetaData);
                }

                // ARCHIVOS
                var lineas = File.Exists(rutaUsuarios)
                    ? File.ReadAllLines(rutaUsuarios).ToList()
                    : new List<string>();

                string original = string.IsNullOrWhiteSpace(usernameOriginal)
                    ? usernameNuevo.Trim()
                    : usernameOriginal.Trim();

                string userNuevo = usernameNuevo.Trim().ToUpper();
                string passNuevo = password.Trim();
                string rolNuevo = rol.Trim();
                string nombreNuevo = nombre.Trim();

                string lineaNueva = $"{userNuevo},{passNuevo},{rolNuevo},{nombreNuevo}";
                bool actualizado = false;

                for (int i = 0; i < lineas.Count; i++)
                {
                    var datos = lineas[i].Split(',');

                    if (datos.Length >= 1 &&
                        datos[0].Trim().Equals(original, StringComparison.OrdinalIgnoreCase))
                    {
                        lineas[i] = lineaNueva;
                        actualizado = true;
                        break;
                    }
                }

                if (!actualizado)
                {
                    bool duplicado = lineas.Any(linea =>
                    {
                        var datos = linea.Split(',');
                        return datos.Length >= 1 &&
                               datos[0].Trim().Equals(userNuevo, StringComparison.OrdinalIgnoreCase);
                    });

                    if (duplicado)
                    {
                        return false;
                    }

                    lineas.Add(lineaNueva);
                }

                // ARCHIVOS
                File.WriteAllLines(rutaUsuarios, lineas);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] No se pudo guardar el usuario '{usernameNuevo}': {ex.Message}");
                return false;
            }
        }

        public static bool EliminarUsuario(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            if (!File.Exists(rutaUsuarios)) return false;

            // EXCEPCIONES
            try
            {
                // ARCHIVOS
                var lineasRestantes = File.ReadAllLines(rutaUsuarios)
                    .Where(linea =>
                    {
                        var datos = linea.Split(',');
                        return datos.Length == 0 ||
                               !datos[0].Trim().Equals(username.Trim(), StringComparison.OrdinalIgnoreCase);
                    })
                    .ToList();

                // ARCHIVOS
                File.WriteAllLines(rutaUsuarios, lineasRestantes);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] No se pudo eliminar el usuario '{username}': {ex.Message}");
                return false;
            }
        }

        public static void RegistrarAcceso(string usuario, string rol, string accion)
        {
            // EXCEPCIONES
            try
            {
                if (!Directory.Exists(carpetaData))
                {
                    Directory.CreateDirectory(carpetaData);
                }

                string fechaStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string linea = $"{usuario},{fechaStr},{accion},{rol}";

                // ARCHIVOS
                File.AppendAllLines(rutaBitacora, new[] { linea });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ADVERTENCIA] No se pudo registrar la bitácora para '{usuario}': {ex.Message}");
            }
        }

        public static List<SesionLog> ObtenerBitacora()
        {
            var lista = new List<SesionLog>();

            if (!File.Exists(rutaBitacora)) return lista;

            // EXCEPCIONES
            try
            {
                // ARCHIVOS
                var lineas = File.ReadAllLines(rutaBitacora);

                foreach (var linea in lineas)
                {
                    var datos = linea.Split(',');

                    if (datos.Length == 4)
                    {
                        // INSTANCIACIÓN DE CLASES PROPIAS
                        lista.Add(new SesionLog
                        {
                            Usuario = datos[0],
                            FechaHora = DateTime.ParseExact(datos[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                            Accion = datos[2],
                            Rol = datos[3]
                        });
                    }
                }

                lista.Reverse();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Fallo al leer la bitácora: {ex.Message}");
            }

            return lista;
        }

        public static void LimpiarBitacora()
        {
            // EXCEPCIONES
            try
            {
                if (File.Exists(rutaBitacora))
                {
                    // ARCHIVOS
                    File.Delete(rutaBitacora);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ADVERTENCIA] No se pudo borrar el archivo de bitácora: {ex.Message}");
            }
        }
    }
}
