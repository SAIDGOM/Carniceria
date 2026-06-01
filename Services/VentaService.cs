using Carniceria.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Carniceria.Services
{
    public static class VentaService
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
        private static readonly string rutaArchivo = Path.Combine(carpetaData, "ventas_historial.dat");

        private static readonly object _candadoArchivo = new object();

        static VentaService()
        {
            // EXCEPCIONES
            try
            {
                if (!Directory.Exists(carpetaData))
                {
                    Directory.CreateDirectory(carpetaData);
                }

                if (!File.Exists(rutaArchivo))
                {
                    string rutaPlantilla = Path.Combine(carpetaPlantilla, "ventas_historial.dat");

                    if (File.Exists(rutaPlantilla) && new FileInfo(rutaPlantilla).Length > 0)
                    {
                        // ARCHIVOS
                        File.Copy(rutaPlantilla, rutaArchivo, true);
                    }
                    else
                    {
                        // ARCHIVOS
                        using (File.Create(rutaArchivo)) { }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[CRÍTICO] Error al inicializar carpeta Data en VentaService: {ex.Message}");
            }
        }

        public static void RegistrarVenta(Venta nuevaVenta)
        {
            // EXCEPCIONES
            if (nuevaVenta == null)
            {
                throw new ArgumentNullException(nameof(nuevaVenta));
            }

            string fechaStr = nuevaVenta.FechaHora.ToString("yyyy-MM-dd HH:mm:ss");
            string kilosStr = nuevaVenta.KilosVendidos.ToString("F3", CultureInfo.InvariantCulture);
            string totalStr = nuevaVenta.TotalPagado.ToString("F2", CultureInfo.InvariantCulture);

            string linea = string.Join(",", new[]
            {
                Limpiar(nuevaVenta.IdProducto),
                fechaStr,
                Limpiar(nuevaVenta.NombreProducto),
                Limpiar(nuevaVenta.Categoria),
                kilosStr,
                totalStr,
                Limpiar(nuevaVenta.Vendedor),
                Limpiar(nuevaVenta.MetodoPago)
            });

            // EXCEPCIONES
            try
            {
                lock (_candadoArchivo)
                {
                    // ARCHIVOS
                    File.AppendAllLines(rutaArchivo, new[] { linea });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR FATAL] Falló el registro de venta: {ex.Message}");
                throw;
            }
        }

        public static List<Venta> ObtenerTodas()
        {
            var lista = new List<Venta>();

            if (!File.Exists(rutaArchivo)) return lista;

            string[] lineas;

            // EXCEPCIONES
            try
            {
                lock (_candadoArchivo)
                {
                    // ARCHIVOS
                    lineas = File.ReadAllLines(rutaArchivo);
                }

                foreach (var linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    var datos = linea.Split(',');

                    if (datos.Length >= 7)
                    {
                        // EXCEPCIONES
                        try
                        {
                            // INSTANCIACIÓN DE CLASES PROPIAS
                            var venta = new Venta
                            {
                                IdProducto = datos[0],
                                FechaHora = DateTime.ParseExact(datos[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                                NombreProducto = datos[2],
                                Categoria = datos[3],
                                KilosVendidos = decimal.Parse(datos[4], CultureInfo.InvariantCulture),
                                TotalPagado = decimal.Parse(datos[5], CultureInfo.InvariantCulture),
                                Vendedor = datos[6],
                                MetodoPago = datos.Length >= 8 ? datos[7] : "Efectivo"
                            };

                            lista.Add(venta);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"[ADVERTENCIA] Error de parseo en historial de ventas. Línea: '{linea}'. Error: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] No se pudo leer el historial de ventas: {ex.Message}");
            }

            return lista;
        }

        public static string LimpiarHistorialConRespaldo()
        {
            // EXCEPCIONES
            try
            {
                string carpetaRespaldos = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "VENTAS CARNICERIA",
                    "HISTORIAL_RESPALDOS");

                if (!Directory.Exists(carpetaRespaldos))
                {
                    // ARCHIVOS
                    Directory.CreateDirectory(carpetaRespaldos);
                }

                string respaldo = Path.Combine(
                    carpetaRespaldos,
                    $"ventas_backup_{DateTime.Now:yyyyMMdd_HHmmss}.dat");

                lock (_candadoArchivo)
                {
                    if (File.Exists(rutaArchivo) && new FileInfo(rutaArchivo).Length > 0)
                    {
                        // ARCHIVOS
                        File.Copy(rutaArchivo, respaldo, true);
                    }

                    // ARCHIVOS
                    File.WriteAllText(rutaArchivo, string.Empty);
                }

                return respaldo;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] No se pudo limpiar el historial de ventas: {ex.Message}");
                throw;
            }
        }

        private static string Limpiar(string valor)
        {
            return (valor ?? string.Empty).Replace(",", " ").Trim();
        }
    }
}
