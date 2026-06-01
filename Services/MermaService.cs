using Carniceria.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace Carniceria.Services
{
    public static class MermaService
    {
        private const string VersionActual = "MERMA";
        private const string NombreApp = "CARNICERIA";

        // ARCHIVOS
        private static readonly string _carpetaPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        // ARCHIVOS
        private static readonly string _carpetaData = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            NombreApp,
            "Datos");

        // ARCHIVOS
        private static readonly string _rutaArchivo = Path.Combine(_carpetaData, "Merma.dat");

        private static readonly object _candadoArchivo = new object();

        // ARCHIVOS
        private static readonly Encoding Codificacion = new UTF8Encoding(false);

        static MermaService()
        {
            // EXCEPCIONES
            try
            {
                if (!Directory.Exists(_carpetaData))
                {
                    Directory.CreateDirectory(_carpetaData);
                }

                if (!File.Exists(_rutaArchivo))
                {
                    string rutaPlantilla = Path.Combine(_carpetaPlantilla, "Merma.dat");

                    if (File.Exists(rutaPlantilla) && new FileInfo(rutaPlantilla).Length > 0)
                    {
                        // ARCHIVOS
                        File.Copy(rutaPlantilla, _rutaArchivo, true);
                    }
                    else
                    {
                        // ARCHIVOS
                        File.WriteAllText(_rutaArchivo, string.Empty, Codificacion);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[CRÍTICO] Error al inicializar carpeta Data en MermaService: {ex.Message}");
            }
        }

        public static void Guardar(Merma merma)
        {
            // EXCEPCIONES
            if (merma == null) throw new ArgumentNullException(nameof(merma));

            ValidarMerma(merma);

            var producto = ProductoService.BuscarPorId(merma.IdProducto);

            // EXCEPCIONES
            if (producto == null)
            {
                throw new InvalidOperationException("El producto seleccionado ya no existe en inventario.");
            }

            // EXCEPCIONES
            if (producto.Stock < merma.CantidadMerma)
            {
                throw new InvalidOperationException($"No hay stock suficiente. Disponible: {producto.Stock:N3} {producto.UnidadMedida}.");
            }

            merma.NombreProducto = producto.Nombre;
            merma.PrecioUnitario = producto.Precio;
            merma.UnidadMedida = producto.UnidadMedida;

            // EXCEPCIONES
            if (producto.UnidadMedida == "PZA" && merma.CantidadMerma % 1 != 0)
            {
                throw new InvalidOperationException("Este producto se maneja por piezas enteras.");
            }

            // EXCEPCIONES
            try
            {
                string linea = FormatearLinea(merma);

                lock (_candadoArchivo)
                {
                    // ARCHIVOS
                    File.AppendAllLines(_rutaArchivo, new[] { linea }, Codificacion);
                }

                bool stockActualizado = ProductoService.RestarStock(merma.IdProducto, merma.CantidadMerma);

                // EXCEPCIONES
                if (!stockActualizado)
                {
                    throw new InvalidOperationException("La merma se guardó, pero no se pudo actualizar el stock.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR FATAL] No se pudo guardar la merma: {ex.Message}");

                // EXCEPCIONES
                throw new Exception("Error al guardar la merma en el disco duro.", ex);
            }
        }

        public static List<Merma> ObtenerTodas()
        {
            var mermas = new List<Merma>();

            if (!File.Exists(_rutaArchivo)) return mermas;

            // EXCEPCIONES
            try
            {
                string[] lineas;

                lock (_candadoArchivo)
                {
                    // ARCHIVOS
                    lineas = File.ReadAllLines(_rutaArchivo, Codificacion);
                }

                foreach (var lineaOriginal in lineas)
                {
                    string linea = LimpiarBom(lineaOriginal);

                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    // EXCEPCIONES
                    try
                    {
                        var merma = IntentarLeerLinea(linea);

                        if (merma != null)
                        {
                            mermas.Add(merma);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[ADVERTENCIA] Error al parsear línea de merma '{linea}': {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Fallo crítico al leer el archivo de mermas: {ex.Message}");
            }

            return mermas;
        }

        private static void ValidarMerma(Merma merma)
        {
            // EXCEPCIONES
            if (string.IsNullOrWhiteSpace(merma.IdProducto))
            {
                throw new ArgumentException("El ID del producto es obligatorio.");
            }

            // EXCEPCIONES
            if (merma.PesoBruto <= 0)
            {
                throw new ArgumentException("El peso bruto debe ser mayor a cero.");
            }

            // EXCEPCIONES
            if (merma.PesoNeto < 0)
            {
                throw new ArgumentException("El peso neto no puede ser negativo.");
            }

            // EXCEPCIONES
            if (merma.PesoNeto > merma.PesoBruto)
            {
                throw new ArgumentException("El peso neto no puede ser mayor al peso bruto.");
            }
        }

        private static string FormatearLinea(Merma merma)
        {
            return string.Join("\t", new[]
            {
                VersionActual,
                merma.Fecha.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                merma.IdProducto,
                Codificar(merma.NombreProducto),
                merma.PesoBruto.ToString("F3", CultureInfo.InvariantCulture),
                merma.PesoNeto.ToString("F3", CultureInfo.InvariantCulture),
                merma.PrecioUnitario.ToString("F2", CultureInfo.InvariantCulture),
                Codificar(merma.UnidadMedida),
                Codificar(merma.Notas)
            });
        }

        private static Merma IntentarLeerLinea(string linea)
        {
            linea = LimpiarBom(linea);

            var partes = linea.Split('\t');

            if (partes.Length >= 9 && LimpiarBom(partes[0]) == VersionActual)
            {
                return LeerFormatoNuevo(partes, true);
            }

            if (partes.Length >= 8 && LimpiarBom(partes[0]) == VersionActual)
            {
                return LeerFormatoNuevo(partes, false);
            }

            return LeerFormatoAnterior(linea);
        }

        private static Merma LeerFormatoNuevo(string[] partes, bool traeUnidad)
        {
            // INSTANCIACIÓN DE CLASES PROPIAS
            return new Merma
            {
                Fecha = DateTime.ParseExact(partes[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                IdProducto = partes[2],
                NombreProducto = Decodificar(partes[3]),
                PesoBruto = decimal.Parse(partes[4], CultureInfo.InvariantCulture),
                PesoNeto = decimal.Parse(partes[5], CultureInfo.InvariantCulture),
                PrecioUnitario = decimal.Parse(partes[6], CultureInfo.InvariantCulture),
                UnidadMedida = traeUnidad ? Decodificar(partes[7]) : "KG",
                Notas = Decodificar(traeUnidad ? partes[8] : partes[7])
            };
        }

        private static Merma LeerFormatoAnterior(string linea)
        {
            linea = LimpiarBom(linea);

            var partes = linea.Split(new[] { ',' }, 6);

            if (partes.Length < 6) return null;

            // INSTANCIACIÓN DE CLASES PROPIAS
            var merma = new Merma
            {
                Fecha = DateTime.Parse(partes[0], CultureInfo.InvariantCulture),
                IdProducto = partes[1].Trim(),
                NombreProducto = partes[2].Trim(),
                PesoBruto = decimal.Parse(partes[3], CultureInfo.InvariantCulture),
                PesoNeto = decimal.Parse(partes[4], CultureInfo.InvariantCulture),
                Notas = partes[5].Trim()
            };

            var producto = ProductoService.BuscarPorId(merma.IdProducto);
            merma.PrecioUnitario = producto?.Precio ?? 0;
            merma.UnidadMedida = producto?.UnidadMedida ?? "KG";

            return merma;
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
                return Encoding.UTF8.GetString(Convert.FromBase64String(valor ?? string.Empty));
            }
            catch
            {
                return string.Empty;
            }
        }

        private static string LimpiarBom(string valor)
        {
            return (valor ?? string.Empty).Replace("\uFEFF", string.Empty).Trim();
        }
    }
}
