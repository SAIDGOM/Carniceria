using Carniceria.Interfaces;
using Carniceria.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Carniceria.Services
{
    public static class ProductoService
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
        private static readonly string rutaArchivo = Path.Combine(carpetaData, "productos.dat");

        private static readonly object _candadoArchivo = new object();

        static ProductoService()
        {
            VerificarYCrearArchivos();
        }

        private static void VerificarYCrearArchivos()
        {
            // EXCEPCIONES
            try
            {
                if (!Directory.Exists(carpetaData))
                {
                    Directory.CreateDirectory(carpetaData);
                }

                string rutaPlantilla = Path.Combine(carpetaPlantilla, "productos.dat");
                bool archivoNoExiste = !File.Exists(rutaArchivo);
                bool archivoEstaVacio = File.Exists(rutaArchivo) && new FileInfo(rutaArchivo).Length == 0;
                bool plantillaTieneDatos = File.Exists(rutaPlantilla) && new FileInfo(rutaPlantilla).Length > 0;

                if ((archivoNoExiste || archivoEstaVacio) && plantillaTieneDatos)
                {
                    // ARCHIVOS
                    File.Copy(rutaPlantilla, rutaArchivo, true);
                }

                if (!File.Exists(rutaArchivo))
                {
                    // ARCHIVOS
                    File.Create(rutaArchivo).Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[CRÍTICO] Error al crear la base de datos de productos: {ex.Message}");
            }
        }

        // HERENCIA DE INTERFACES
        public static List<IProducto> ObtenerTodos()
        {
            // HERENCIA DE INTERFACES
            var lista = new List<IProducto>();

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

                    if (datos.Length >= 6)
                    {
                        // EXCEPCIONES
                        try
                        {
                            string id = datos[0].Trim();
                            string nombre = datos[1].Trim();
                            decimal precio = decimal.Parse(datos[2].Trim(), CultureInfo.InvariantCulture);
                            decimal stock = decimal.Parse(datos[3].Trim(), CultureInfo.InvariantCulture);
                            string categoria = NormalizarCategoria(datos[4]);
                            string unidad = NormalizarUnidad(datos[5]);

                            lista.Add(CrearProducto(id, nombre, precio, stock, categoria, unidad));
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"[ADVERTENCIA] Línea de producto corrupta omitida: '{linea}'. Error: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] No se pudo leer la base de productos: {ex.Message}");
            }

            return lista;
        }

        // HERENCIA DE INTERFACES
        public static IProducto BuscarPorId(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;

            var productos = ObtenerTodos();

            foreach (var p in productos)
            {
                if (p.Id.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return p;
                }
            }

            return null;
        }

        public static bool Agregar(string id, string nombre, decimal precio, decimal stock, string categoria, string unidad)
        {
            if (!DatosValidos(id, nombre, categoria, unidad)) return false;
            if (precio < 0 || stock < 0) return false;
            if (BuscarPorId(id) != null) return false;

            string categoriaFinal = NormalizarCategoria(categoria);
            string unidadFinal = NormalizarUnidad(unidad);

            string precioStr = precio.ToString("F2", CultureInfo.InvariantCulture);
            string stockStr = stock.ToString("F3", CultureInfo.InvariantCulture);
            string linea = $"{id.Trim()},{nombre.Trim()},{precioStr},{stockStr},{categoriaFinal},{unidadFinal}";

            // EXCEPCIONES
            try
            {
                lock (_candadoArchivo)
                {
                    // ARCHIVOS
                    File.AppendAllLines(rutaArchivo, new[] { linea });
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] No se pudo agregar el producto {id}: {ex.Message}");
                return false;
            }
        }

        public static bool Modificar(string idOriginal, string idNuevo, string nombre, decimal precio, decimal stock, string categoria, string unidad)
        {
            if (!DatosValidos(idOriginal, nombre, categoria, unidad)) return false;
            if (string.IsNullOrWhiteSpace(idNuevo)) return false;
            if (precio < 0 || stock < 0) return false;

            var productos = ObtenerTodos();

            // HERENCIA DE INTERFACES
            IProducto productoAEditar = null;

            foreach (var p in productos)
            {
                if (p.Id.Equals(idOriginal.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    productoAEditar = p;
                    break;
                }
            }

            if (productoAEditar == null) return false;

            if (!idOriginal.Equals(idNuevo, StringComparison.OrdinalIgnoreCase) && BuscarPorId(idNuevo) != null)
            {
                return false;
            }

            string categoriaFinal = NormalizarCategoria(categoria);
            string unidadFinal = NormalizarUnidad(unidad);

            // EXCEPCIONES
            try
            {
                lock (_candadoArchivo)
                {
                    var lineas = new List<string>();

                    foreach (var p in productos)
                    {
                        if (p.Id.Equals(idOriginal.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            string pStr = precio.ToString("F2", CultureInfo.InvariantCulture);
                            string sStr = stock.ToString("F3", CultureInfo.InvariantCulture);

                            lineas.Add($"{idNuevo.Trim()},{nombre.Trim()},{pStr},{sStr},{categoriaFinal},{unidadFinal}");
                        }
                        else
                        {
                            string pStr = p.Precio.ToString("F2", CultureInfo.InvariantCulture);
                            string sStr = p.Stock.ToString("F3", CultureInfo.InvariantCulture);
                            string cat = NormalizarCategoria(p.Categoria);
                            string uni = NormalizarUnidad(p.UnidadMedida);

                            lineas.Add($"{p.Id},{p.Nombre},{pStr},{sStr},{cat},{uni}");
                        }
                    }

                    // ARCHIVOS
                    File.WriteAllLines(rutaArchivo, lineas);
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Fallo al modificar el producto {idOriginal}: {ex.Message}");
                return false;
            }
        }

        public static bool Eliminar(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            if (!File.Exists(rutaArchivo)) return false;

            // EXCEPCIONES
            try
            {
                lock (_candadoArchivo)
                {
                    var lineasRestantes = new List<string>();

                    // ARCHIVOS
                    string[] lineas = File.ReadAllLines(rutaArchivo);

                    foreach (string linea in lineas)
                    {
                        var datos = linea.Split(',');

                        if (datos.Length == 0 ||
                            !datos[0].Trim().Equals(id.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            lineasRestantes.Add(linea);
                        }
                    }

                    // ARCHIVOS
                    File.WriteAllLines(rutaArchivo, lineasRestantes);
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] No se pudo eliminar el producto {id}: {ex.Message}");
                return false;
            }
        }

        public static bool RestarStock(string id, decimal cantidadRestar)
        {
            var p = BuscarPorId(id);

            if (p == null || cantidadRestar < 0 || p.Stock < cantidadRestar)
            {
                return false;
            }

            return Modificar(
                p.Id,
                p.Id,
                p.Nombre,
                p.Precio,
                p.Stock - cantidadRestar,
                p.Categoria,
                p.UnidadMedida);
        }

        private static bool DatosValidos(string id, string nombre, string categoria, string unidad)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            if (string.IsNullOrWhiteSpace(nombre)) return false;
            if (string.IsNullOrWhiteSpace(categoria)) return false;
            if (string.IsNullOrWhiteSpace(unidad)) return false;

            if (id.Contains(",")) return false;
            if (nombre.Contains(",")) return false;
            if (categoria.Contains(",")) return false;
            if (unidad.Contains(",")) return false;

            return true;
        }

        private static string NormalizarCategoria(string categoria)
        {
            string cat = (categoria ?? string.Empty).Trim();

            if (cat.Equals("Res", StringComparison.OrdinalIgnoreCase))
            {
                return "Res";
            }

            if (cat.Equals("Cerdo", StringComparison.OrdinalIgnoreCase))
            {
                return "Cerdo";
            }

            if (string.IsNullOrWhiteSpace(cat))
            {
                return "Otros";
            }

            return cat;
        }

        private static string NormalizarUnidad(string unidad)
        {
            string uni = (unidad ?? string.Empty).Trim().ToUpper();

            if (uni == "PZA")
            {
                return "PZA";
            }

            return "KG";
        }

        // HERENCIA DE INTERFACES
        private static IProducto CrearProducto(string id, string nombre, decimal precio, decimal stock, string cat, string unidad)
        {
            // HERENCIA DE INTERFACES
            IProducto p;

            string categoriaClean = NormalizarCategoria(cat);

            switch (categoriaClean)
            {
                case "Res":
                    // INSTANCIACIÓN DE CLASES PROPIAS
                    p = new ProductoRes
                    {
                        Id = id,
                        Nombre = nombre,
                        Precio = precio,
                        Stock = stock
                    };
                    break;

                case "Cerdo":
                    // INSTANCIACIÓN DE CLASES PROPIAS
                    p = new ProductoCerdo
                    {
                        Id = id,
                        Nombre = nombre,
                        Precio = precio,
                        Stock = stock
                    };
                    break;

                default:
                    // INSTANCIACIÓN DE CLASES PROPIAS
                    p = new ProductoOtros
                    {
                        Id = id,
                        Nombre = nombre,
                        Precio = precio,
                        Stock = stock,
                        Categoria = categoriaClean
                    };
                    break;
            }

            p.UnidadMedida = NormalizarUnidad(unidad);
            return p;
        }
    }
}
