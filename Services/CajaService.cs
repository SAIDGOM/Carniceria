using Carniceria.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Carniceria.Services
{
    public static class CajaService
    {
        private const string VersionActual = "CAJA";
        private const string NombreApp = "CARNICERIA";

        // ARCHIVOS
        private static readonly string CarpetaPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        // ARCHIVOS
        private static readonly string CarpetaData = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            NombreApp,
            "Datos");

        // ARCHIVOS
        private static readonly string RutaArchivo = Path.Combine(CarpetaData, "caja_fondos.dat");

        private static readonly object CandadoArchivo = new object();

        static CajaService()
        {
            // EXCEPCIONES
            try
            {
                if (!Directory.Exists(CarpetaData))
                {
                    Directory.CreateDirectory(CarpetaData);
                }

                if (!File.Exists(RutaArchivo))
                {
                    string rutaPlantilla = Path.Combine(CarpetaPlantilla, "caja_fondos.dat");

                    if (File.Exists(rutaPlantilla) && new FileInfo(rutaPlantilla).Length > 0)
                    {
                        // ARCHIVOS
                        File.Copy(rutaPlantilla, RutaArchivo, true);
                    }
                    else
                    {
                        // ARCHIVOS
                        File.Create(RutaArchivo).Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[CRÍTICO] Error al inicializar carpeta Data en CajaService: {ex.Message}");
            }
        }

        // SOBRECARGA
        public static FondoCaja ObtenerFondo()
        {
            return ObtenerFondo(DateTime.Now);
        }

        // SOBRECARGA
        public static FondoCaja ObtenerFondo(DateTime fecha)
        {
            return LeerFondos()
                .FirstOrDefault(f => f.Fecha.Date == fecha.Date)
                // INSTANCIACIÓN DE CLASES PROPIAS
                ?? new FondoCaja
                {
                    Fecha = fecha.Date,
                    MontoInicial = 0,
                    Responsable = string.Empty,
                    Actualizado = fecha
                };
        }

        public static void GuardarFondo(FondoCaja fondo)
        {
            // EXCEPCIONES
            if (fondo == null) throw new ArgumentNullException(nameof(fondo));

            // EXCEPCIONES
            if (fondo.MontoInicial < 0) throw new InvalidOperationException("El fondo inicial no puede ser negativo.");

            // EXCEPCIONES
            try
            {
                if (!Directory.Exists(CarpetaData))
                {
                    Directory.CreateDirectory(CarpetaData);
                }

                lock (CandadoArchivo)
                {
                    var fondos = LeerFondosSinCandado()
                        .Where(f => f.Fecha.Date != fondo.Fecha.Date)
                        .ToList();

                    fondos.Add(fondo);
                    EscribirFondosSinCandado(fondos);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR FATAL] No se pudo guardar el fondo de caja: {ex.Message}");
                throw;
            }
        }

        private static List<FondoCaja> LeerFondos()
        {
            lock (CandadoArchivo)
            {
                return LeerFondosSinCandado();
            }
        }

        private static List<FondoCaja> LeerFondosSinCandado()
        {
            var fondos = new List<FondoCaja>();

            if (!File.Exists(RutaArchivo)) return fondos;

            // EXCEPCIONES
            try
            {
                // ARCHIVOS
                var lineas = File.ReadAllLines(RutaArchivo);

                foreach (var linea in lineas)
                {
                    var fondo = IntentarLeer(linea);

                    if (fondo != null)
                    {
                        fondos.Add(fondo);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Fallo al leer el archivo de fondos de caja: {ex.Message}");
            }

            return fondos;
        }

        private static void EscribirFondosSinCandado(IEnumerable<FondoCaja> fondos)
        {
            var lineas = fondos.OrderBy(f => f.Fecha).Select(FormatearLinea);

            // ARCHIVOS
            File.WriteAllLines(RutaArchivo, lineas);
        }

        private static string FormatearLinea(FondoCaja fondo)
        {
            return string.Join("\t", new[]
            {
                VersionActual,
                fondo.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                fondo.MontoInicial.ToString("F2", CultureInfo.InvariantCulture),
                Codificar(fondo.Responsable),
                fondo.Actualizado.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            });
        }

        private static FondoCaja IntentarLeer(string linea)
        {
            if (string.IsNullOrWhiteSpace(linea)) return null;

            // EXCEPCIONES
            try
            {
                var partes = linea.Split('\t');

                if (partes.Length < 5 || partes[0] != VersionActual) return null;

                // INSTANCIACIÓN DE CLASES PROPIAS
                return new FondoCaja
                {
                    Fecha = DateTime.ParseExact(partes[1], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    MontoInicial = decimal.Parse(partes[2], CultureInfo.InvariantCulture),
                    Responsable = Decodificar(partes[3]),
                    Actualizado = DateTime.ParseExact(partes[4], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ADVERTENCIA] Error de parseo en fondo de caja. Línea omitida. Detalle: {ex.Message}");
                return null;
            }
        }

        private static string Codificar(string valor)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(valor ?? string.Empty));
        }

        private static string Decodificar(string valor)
        {
            // EXCEPCIONES
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(valor));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ADVERTENCIA] Error al decodificar texto base64 '{valor}': {ex.Message}");
                return string.Empty;
            }
        }
    }
}
