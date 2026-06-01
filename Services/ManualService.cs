using Carniceria.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using PdfFont = iTextSharp.text.Font;

namespace Carniceria.Services
{
    public static class ManualService
    {
        // ARCHIVOS
        private static readonly string CarpetaManuales = Path.GetTempPath();

        private static Process _procesoManual;

        // HERENCIA DE INTERFACES
        public static void AbrirManual(IUsuario usuario)
        {
            // EXCEPCIONES
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            if (_procesoManual != null && !_procesoManual.HasExited)
            {
                return;
            }

            // EXCEPCIONES
            try
            {
                bool esEmpleado = usuario.Rol.Equals("Empleado", StringComparison.OrdinalIgnoreCase);

                // ARCHIVOS
                string ruta = esEmpleado
                    ? CrearManualEmpleado(usuario)
                    : CrearManualAdministrador(usuario);

                // ARCHIVOS
                _procesoManual = Process.Start(new ProcessStartInfo
                {
                    FileName = ruta,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ERROR] No se pudo abrir el manual: " + ex.Message);
                throw;
            }
        }

        // HERENCIA DE INTERFACES
        private static string CrearManualEmpleado(IUsuario usuario)
        {
            // ARCHIVOS
            string ruta = Path.Combine(CarpetaManuales, "Manual_Temporal_Empleado_Carniceria.pdf");

            var secciones = new[]
            {
                ("1. ¿QUÉ ES EL SISTEMA?", new[]
                {
                    "El sistema de Carnicería es una aplicación de escritorio diseñada para apoyar el trabajo diario de una carnicería.",
                    "Permite realizar ventas, consultar productos, revisar existencias, registrar mermas y mantener un control básico del inventario.",
                    "El objetivo principal es reducir errores al vender, calcular totales correctamente y descontar el stock de forma automática.",
                    "Cada usuario entra con su propia cuenta, por lo que las acciones importantes quedan relacionadas con la persona que usó el sistema.",
                    "Este manual se genera de forma temporal al presionar el botón de Ayuda. Si se cierra, puede volver a abrirse desde el mismo botón."
                }),

                ("2. ACCESO COMO EMPLEADO", new[]
                {
                    "El empleado tiene acceso a las funciones necesarias para atender ventas y apoyar en el control diario del negocio.",
                    "Puede entrar al sistema usando su usuario y contraseña asignados.",
                    "Puede realizar ventas de productos disponibles.",
                    "Puede consultar información de inventario si el sistema lo permite.",
                    "Puede registrar mermas si tiene habilitada esa opción.",
                    "No puede administrar usuarios.",
                    "No puede modificar información delicada del sistema si no tiene permisos.",
                    "Debe cerrar sesión al terminar su turno para evitar que otra persona realice movimientos con su cuenta."
                }),

                ("3. INICIO DE SESIÓN", new[]
                {
                    "Paso 1: Abre el programa de Carnicería desde el acceso directo o desde el menú de inicio.",
                    "Paso 2: Escribe tu nombre de usuario.",
                    "Paso 3: Escribe tu contraseña.",
                    "Paso 4: Presiona el botón de ingresar o iniciar sesión.",
                    "Paso 5: Si los datos son correctos, el sistema abrirá el menú principal.",
                    "Si el usuario o contraseña son incorrectos, el sistema mostrará un mensaje de advertencia.",
                    "No compartas tu contraseña con otros usuarios."
                }),

                ("4. MENÚ PRINCIPAL", new[]
                {
                    "El menú principal muestra los módulos disponibles para el usuario.",
                    "Desde esta pantalla se puede entrar a ventas, inventario, mermas, ayuda y otras opciones permitidas.",
                    "Cada botón abre una sección diferente del sistema.",
                    "Si una opción no aparece o está bloqueada, significa que el usuario no tiene permiso para utilizarla.",
                    "El menú principal permite navegar por el sistema de forma rápida y ordenada."
                }),

                ("5. MÓDULO DE VENTAS", new[]
                {
                    "El módulo de ventas es la parte principal para atender clientes.",
                    "Aquí se buscan productos, se agregan al carrito, se calcula el total y se registra el cobro.",
                    "El sistema permite vender productos por kilogramo o por pieza, dependiendo de cómo esté registrado cada producto.",
                    "Antes de cobrar, el sistema valida que haya stock suficiente.",
                    "Cuando la venta se cobra correctamente, el inventario se descuenta automáticamente.",
                    "La venta queda registrada con la fecha, hora, producto, cantidad, total, vendedor y método de pago."
                }),

                ("6. CÓMO HACER UNA VENTA PASO A PASO", new[]
                {
                    "Paso 1: Entra al módulo de Ventas.",
                    "Paso 2: Escribe el ID o nombre del producto en el buscador.",
                    "Paso 3: Presiona Enter para buscar el producto.",
                    "Paso 4: Revisa que el nombre, precio, categoría y stock mostrados sean correctos.",
                    "Paso 5: Escribe la cantidad o peso que el cliente desea comprar.",
                    "Paso 6: Si el producto se vende por pieza, escribe una cantidad entera.",
                    "Paso 7: Presiona el botón Agregar para mandar el producto al carrito.",
                    "Paso 8: Revisa que el producto aparezca correctamente en la tabla de venta.",
                    "Paso 9: Agrega más productos si el cliente lo solicita.",
                    "Paso 10: Revisa el total de la venta.",
                    "Paso 11: Presiona Cobrar para abrir la ventana de cobro.",
                    "Paso 12: Selecciona el método de pago correspondiente.",
                    "Paso 13: Confirma la venta cuando el pago haya sido recibido.",
                    "Paso 14: El sistema registrará la venta y actualizará el inventario."
                }),

                ("7. VALIDACIONES EN VENTAS", new[]
                {
                    "El sistema no permite vender si no se ha seleccionado un producto válido.",
                    "El sistema no permite agregar cantidades vacías o menores a cero.",
                    "El sistema no permite vender más cantidad de la disponible en inventario.",
                    "Si el producto se vende por pieza, el sistema no permite capturar decimales.",
                    "Si el carrito está vacío, el sistema no permite cobrar.",
                    "Estas validaciones ayudan a evitar errores durante la venta."
                }),

                ("8. CONSULTA DE INVENTARIO", new[]
                {
                    "El inventario permite revisar los productos registrados en el sistema.",
                    "Se puede consultar el nombre del producto, categoría, precio, unidad de medida y stock disponible.",
                    "El empleado debe revisar el inventario cuando tenga dudas sobre la existencia de un producto.",
                    "Si el stock es insuficiente, se debe avisar al administrador.",
                    "El inventario ayuda a evitar ventas incorrectas y mejora el control de productos."
                }),

                ("9. REGISTRO DE MERMAS", new[]
                {
                    "Una merma es producto perdido, dañado, caducado, mal cortado o retirado de la venta.",
                    "Para registrar una merma, entra al módulo correspondiente.",
                    "Busca o selecciona el producto afectado.",
                    "Escribe la cantidad de producto que se perdió.",
                    "Registra el motivo de la merma.",
                    "Guarda el registro.",
                    "El sistema descontará esa cantidad del inventario si la función está habilitada.",
                    "Registrar mermas ayuda a conocer pérdidas reales del negocio."
                }),

                ("10. RECOMENDACIONES PARA EL EMPLEADO", new[]
                {
                    "Verifica el producto antes de agregarlo a la venta.",
                    "Revisa si el producto se vende por kilogramo o por pieza.",
                    "No cobres ventas si el cliente todavía no confirma el pedido.",
                    "No compartas tu usuario ni contraseña.",
                    "Cierra sesión al terminar tu turno.",
                    "Reporta al administrador cualquier error, producto faltante o diferencia de stock.",
                    "Usa el sistema con cuidado para mantener información confiable."
                }),

                ("11. CIERRE DE SESIÓN", new[]
                {
                    "Al terminar de usar el sistema, presiona la opción de cerrar sesión.",
                    "Cerrar sesión evita que otra persona use tu cuenta.",
                    "También ayuda a mantener el control de las acciones realizadas por cada usuario.",
                    "Si vas a dejar la computadora sola, cierra sesión antes de retirarte."
                })
            };

            EscribirManual(
                ruta,
                "MANUAL DE USUARIO - EMPLEADO",
                "Guía paso a paso para ventas, inventario, mermas, consulta de información y cierre de sesión.",
                usuario,
                secciones);

            return ruta;
        }

        // HERENCIA DE INTERFACES
        private static string CrearManualAdministrador(IUsuario usuario)
        {
            // ARCHIVOS
            string ruta = Path.Combine(CarpetaManuales, "Manual_Temporal_Administrador_Carniceria.pdf");

            var secciones = new[]
            {
                ("1. ¿QUÉ ES EL SISTEMA?", new[]
                {
                    "El sistema de Carnicería es una aplicación de escritorio desarrollada para administrar las operaciones principales de una carnicería.",
                    "Funciona como punto de venta e inventario, permitiendo registrar ventas, controlar productos, administrar usuarios, revisar caja y generar reportes.",
                    "El sistema ayuda a reducir errores de captura, controlar el stock disponible y mantener un historial de movimientos importantes.",
                    "También permite visualizar información mediante tablas, reportes y gráficas para facilitar la toma de decisiones.",
                    "Este manual se genera temporalmente cuando el usuario presiona el botón de Ayuda. No se guarda como reporte permanente, solo sirve para consulta."
                }),

                ("2. ROL DEL ADMINISTRADOR", new[]
                {
                    "El administrador tiene acceso completo al sistema.",
                    "Puede realizar ventas igual que un empleado.",
                    "Puede agregar, modificar y consultar productos.",
                    "Puede revisar inventario y controlar existencias.",
                    "Puede registrar mermas.",
                    "Puede consultar cortes de caja diarios y mensuales.",
                    "Puede exportar reportes en PDF y Excel.",
                    "Puede consultar estadísticas y gráficas.",
                    "Puede crear, modificar o eliminar usuarios.",
                    "Puede revisar bitácoras del sistema.",
                    "Este rol debe usarse con responsabilidad porque controla información importante del negocio."
                }),

                ("3. INICIO DE SESIÓN", new[]
                {
                    "Paso 1: Abre el programa de Carnicería desde el acceso directo del escritorio o desde el menú de inicio.",
                    "Paso 2: Escribe tu usuario de administrador.",
                    "Paso 3: Escribe tu contraseña.",
                    "Paso 4: Presiona el botón para ingresar.",
                    "Paso 5: Si los datos son correctos, el sistema abrirá el menú principal.",
                    "Si los datos son incorrectos, el sistema mostrará un mensaje de advertencia.",
                    "Se recomienda que solo el dueño o encargado del negocio tenga acceso al usuario administrador."
                }),

                ("4. MENÚ PRINCIPAL", new[]
                {
                    "El menú principal es la pantalla central del sistema.",
                    "Desde aquí se accede a los módulos de ventas, inventario, productos, mermas, corte de caja, usuarios, reportes, bitácora y ayuda.",
                    "Cada botón representa una función del sistema.",
                    "El diseño del menú permite que el usuario no se pierda y pueda entrar rápidamente al módulo que necesita.",
                    "Si se termina el uso del sistema, se debe cerrar sesión para proteger la información."
                }),

                ("5. MÓDULO DE VENTAS", new[]
                {
                    "El módulo de ventas permite registrar los productos que compra un cliente.",
                    "El administrador puede buscar productos por ID o por nombre.",
                    "El sistema muestra información del producto como nombre, categoría, precio, unidad de medida y stock disponible.",
                    "Los productos pueden venderse por kilogramo o por pieza, dependiendo de cómo estén registrados.",
                    "El sistema calcula automáticamente subtotales y total de la venta.",
                    "Antes de cobrar, valida que haya inventario suficiente.",
                    "Al finalizar la venta, el sistema descuenta el stock y guarda el registro de venta."
                }),

                ("6. CÓMO REALIZAR UNA VENTA PASO A PASO", new[]
                {
                    "Paso 1: Entra al módulo de Ventas.",
                    "Paso 2: Escribe el ID o nombre del producto.",
                    "Paso 3: Presiona Enter para buscar el producto.",
                    "Paso 4: Verifica que el producto encontrado sea el correcto.",
                    "Paso 5: Escribe la cantidad o peso solicitado por el cliente.",
                    "Paso 6: Si el producto se vende por pieza, escribe solo números enteros.",
                    "Paso 7: Presiona Agregar para añadir el producto al carrito.",
                    "Paso 8: Revisa el subtotal del producto.",
                    "Paso 9: Agrega más productos si el cliente lo requiere.",
                    "Paso 10: Revisa el total general.",
                    "Paso 11: Presiona Cobrar.",
                    "Paso 12: Selecciona el método de pago.",
                    "Paso 13: Confirma la venta cuando el pago esté realizado.",
                    "Paso 14: El sistema registrará la venta y actualizará el inventario."
                }),

                ("7. VALIDACIONES DEL MÓDULO DE VENTAS", new[]
                {
                    "El sistema no permite cobrar una venta vacía.",
                    "El sistema no permite agregar productos inexistentes.",
                    "El sistema no permite cantidades menores o iguales a cero.",
                    "El sistema no permite vender más producto del que existe en inventario.",
                    "El sistema no permite vender decimales cuando el producto se vende por pieza.",
                    "Estas validaciones evitan errores comunes al momento de atender clientes."
                }),

                ("8. MÓDULO DE INVENTARIO", new[]
                {
                    "El inventario permite consultar los productos disponibles dentro del sistema.",
                    "En esta sección se puede revisar el nombre del producto, categoría, precio, unidad de medida y stock actual.",
                    "El administrador puede utilizar esta información para saber qué productos están disponibles y cuáles necesitan reposición.",
                    "El inventario ayuda a detectar productos con bajo stock.",
                    "También permite visualizar información mediante tablas y gráficas, facilitando la administración del negocio.",
                    "Se recomienda revisar el inventario al inicio y al final del día."
                }),

                ("9. MÓDULO DE PRODUCTOS", new[]
                {
                    "El módulo de productos permite administrar la información de los productos vendidos en la carnicería.",
                    "El administrador puede agregar productos nuevos.",
                    "También puede modificar datos de productos existentes.",
                    "Los datos importantes son ID, nombre, categoría, precio, unidad de medida y stock.",
                    "La unidad de medida puede ser kilogramo o pieza, dependiendo del producto.",
                    "Es importante capturar correctamente los precios para evitar errores en las ventas.",
                    "También es importante mantener actualizado el stock para que el sistema funcione correctamente."
                }),

                ("10. CÓMO AGREGAR UN PRODUCTO", new[]
                {
                    "Paso 1: Entra al módulo de productos o inventario, según la organización del sistema.",
                    "Paso 2: Presiona la opción para agregar un producto nuevo.",
                    "Paso 3: Escribe el ID o código del producto.",
                    "Paso 4: Escribe el nombre del producto.",
                    "Paso 5: Selecciona o escribe la categoría.",
                    "Paso 6: Escribe el precio de venta.",
                    "Paso 7: Selecciona la unidad de medida: KG o PZA.",
                    "Paso 8: Escribe el stock inicial.",
                    "Paso 9: Guarda el producto.",
                    "Paso 10: Verifica que aparezca correctamente en la lista."
                }),

                ("11. CÓMO MODIFICAR UN PRODUCTO", new[]
                {
                    "Paso 1: Busca el producto que deseas modificar.",
                    "Paso 2: Selecciona el producto en la tabla.",
                    "Paso 3: Presiona la opción de editar o modificar.",
                    "Paso 4: Cambia los datos necesarios, como precio, categoría o stock.",
                    "Paso 5: Guarda los cambios.",
                    "Paso 6: Revisa que la información actualizada aparezca correctamente.",
                    "No se recomienda cambiar el ID de un producto si ya tiene ventas registradas."
                }),

                ("12. MÓDULO DE MERMAS", new[]
                {
                    "Las mermas representan producto perdido, dañado, caducado, mal cortado o retirado de la venta.",
                    "El registro de mermas ayuda a conocer pérdidas reales del negocio.",
                    "Al registrar una merma, el sistema puede descontar esa cantidad del inventario.",
                    "Es importante registrar el motivo para tener un mejor control administrativo.",
                    "Las mermas deben registrarse en cuanto ocurren para evitar diferencias de stock."
                }),

                ("13. CÓMO REGISTRAR UNA MERMA", new[]
                {
                    "Paso 1: Entra al módulo de Mermas.",
                    "Paso 2: Busca o selecciona el producto afectado.",
                    "Paso 3: Escribe la cantidad perdida.",
                    "Paso 4: Escribe el motivo de la merma.",
                    "Paso 5: Revisa que la cantidad sea correcta.",
                    "Paso 6: Guarda el registro.",
                    "Paso 7: Verifica que el stock se haya actualizado correctamente.",
                    "Ejemplos de motivos: producto dañado, merma por corte, producto caducado, error de manejo o devolución."
                }),

                ("14. CORTE DE CAJA", new[]
                {
                    "El corte de caja permite revisar el dinero generado por las ventas.",
                    "En esta sección se pueden consultar ventas del día, métodos de pago, totales y movimientos de caja.",
                    "El administrador puede revisar si el dinero recibido coincide con las ventas registradas.",
                    "El corte de caja ayuda a cerrar correctamente el turno o la jornada.",
                    "También permite detectar diferencias o errores en los cobros.",
                    "Se recomienda realizar corte de caja diariamente."
                }),

                ("15. CÓMO REALIZAR O CONSULTAR UN CORTE DE CAJA", new[]
                {
                    "Paso 1: Entra al módulo de Corte de Caja.",
                    "Paso 2: Selecciona la fecha o periodo que deseas revisar.",
                    "Paso 3: Revisa las ventas registradas.",
                    "Paso 4: Revisa los métodos de pago.",
                    "Paso 5: Verifica el total de ingresos.",
                    "Paso 6: Revisa movimientos adicionales si existen.",
                    "Paso 7: Exporta el reporte si necesitas guardarlo.",
                    "Paso 8: Compara la información del sistema con el dinero físico o digital recibido."
                }),

                ("16. REPORTES PDF Y EXCEL", new[]
                {
                    "El sistema permite exportar información en reportes PDF y Excel.",
                    "Los reportes PDF sirven para presentar información de forma ordenada y fácil de imprimir.",
                    "Los reportes Excel sirven para revisar, filtrar o analizar datos con más detalle.",
                    "Los reportes pueden incluir ventas, inventario, cortes de caja, movimientos o información administrativa.",
                    "Se recomienda guardar los reportes importantes en una carpeta segura.",
                    "Los reportes ayudan a tener evidencia del funcionamiento del negocio."
                }),

                ("17. GRÁFICAS Y ESTADÍSTICAS", new[]
                {
                    "El sistema puede mostrar gráficas para representar información importante.",
                    "Las gráficas ayudan a entender mejor los datos del negocio.",
                    "Pueden utilizarse para revisar ventas, stock, categorías, métodos de pago o movimientos.",
                    "Una gráfica permite identificar rápidamente productos con bajo inventario o ventas destacadas.",
                    "Este apartado facilita la toma de decisiones del administrador."
                }),

                ("18. MÓDULO DE USUARIOS", new[]
                {
                    "El módulo de usuarios permite administrar las cuentas que pueden entrar al sistema.",
                    "El administrador puede crear usuarios nuevos.",
                    "También puede modificar datos de usuarios existentes.",
                    "Puede eliminar usuarios que ya no deben tener acceso.",
                    "Cada usuario debe tener un rol asignado.",
                    "Los roles principales son Administrador y Empleado.",
                    "El rol Administrador tiene acceso completo.",
                    "El rol Empleado tiene acceso limitado a funciones operativas."
                }),

                ("19. CÓMO CREAR UN USUARIO", new[]
                {
                    "Paso 1: Entra al módulo de Usuarios.",
                    "Paso 2: Presiona la opción para agregar un usuario.",
                    "Paso 3: Escribe el nombre del usuario.",
                    "Paso 4: Escribe el usuario de acceso.",
                    "Paso 5: Escribe una contraseña.",
                    "Paso 6: Selecciona el rol correspondiente.",
                    "Paso 7: Guarda el usuario.",
                    "Paso 8: Verifica que aparezca en la lista.",
                    "Se recomienda usar contraseñas que no sean fáciles de adivinar."
                }),

                ("20. BITÁCORA DEL SISTEMA", new[]
                {
                    "La bitácora registra acciones importantes realizadas dentro del sistema.",
                    "Sirve para revisar movimientos, accesos, modificaciones o eventos relevantes.",
                    "Ayuda a mantener control y seguridad sobre el uso del programa.",
                    "El administrador puede consultar la bitácora para revisar actividad del sistema.",
                    "No se recomienda borrar bitácoras sin motivo, ya que pueden servir como evidencia de movimientos."
                }),

                ("21. SEGURIDAD Y BUEN USO", new[]
                {
                    "No compartas usuarios ni contraseñas.",
                    "Cada persona debe usar su propia cuenta.",
                    "Cierra sesión al terminar de usar el sistema.",
                    "No modifiques productos sin revisar que la información sea correcta.",
                    "No borres usuarios, productos o registros si no estás seguro.",
                    "Realiza cortes de caja diariamente.",
                    "Guarda reportes importantes.",
                    "Revisa el inventario con frecuencia.",
                    "Mantén actualizado el respaldo de información si el sistema utiliza archivos locales."
                }),

                ("22. ERRORES COMUNES Y SOLUCIONES", new[]
                {
                    "Si un producto no aparece, revisa que el ID o nombre esté escrito correctamente.",
                    "Si no se puede vender un producto, revisa que tenga stock disponible.",
                    "Si el sistema no permite decimales, probablemente el producto está registrado por pieza.",
                    "Si el carrito está vacío, primero agrega productos antes de cobrar.",
                    "Si un reporte no se genera, revisa que existan datos para el periodo seleccionado.",
                    "Si el sistema muestra un error, lee el mensaje y vuelve a intentar la operación.",
                    "Si el problema continúa, reinicia el sistema o avisa al encargado técnico."
                }),

                ("23. FLUJO RECOMENDADO DE TRABAJO DIARIO", new[]
                {
                    "Paso 1: Iniciar sesión con el usuario correspondiente.",
                    "Paso 2: Revisar inventario antes de comenzar ventas.",
                    "Paso 3: Realizar ventas durante el turno.",
                    "Paso 4: Registrar mermas cuando ocurran.",
                    "Paso 5: Revisar productos con bajo stock.",
                    "Paso 6: Consultar ventas del día.",
                    "Paso 7: Realizar corte de caja.",
                    "Paso 8: Exportar reportes si es necesario.",
                    "Paso 9: Cerrar sesión al terminar."
                }),

                ("24. CONCLUSIÓN", new[]
                {
                    "El sistema de Carnicería ayuda a controlar las operaciones principales del negocio.",
                    "Permite trabajar con ventas, inventario, productos, usuarios, mermas, caja, reportes y gráficas.",
                    "Su uso correcto mejora la organización y reduce errores administrativos.",
                    "El administrador debe revisar constantemente la información registrada para mantener el sistema actualizado."
                })
            };

            EscribirManual(
                ruta,
                "MANUAL DE USUARIO - ADMINISTRADOR",
                "Guía completa paso a paso para administración, ventas, inventario, productos, usuarios, caja, reportes, gráficas y seguridad.",
                usuario,
                secciones);

            return ruta;
        }

        // HERENCIA DE INTERFACES
        private static void EscribirManual(
            string ruta,
            string titulo,
            string descripcion,
            IUsuario usuario,
            IEnumerable<(string Titulo, string[] Lineas)> secciones)
        {
            // ARCHIVOS
            Directory.CreateDirectory(CarpetaManuales);

            // ARCHIVOS
            using (FileStream fs = new FileStream(ruta, FileMode.Create))
            using (Document doc = new Document(PageSize.A4, 45, 45, 45, 45))
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                PdfFont fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, new BaseColor(0, 150, 136));
                PdfFont fontDescripcion = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.DARK_GRAY);
                PdfFont fontInfo = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.GRAY);
                PdfFont fontSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
                PdfFont fontTexto = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.DARK_GRAY);
                PdfFont fontPie = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, BaseColor.GRAY);

                AgregarPortada(doc, titulo, descripcion, usuario, fontTitulo, fontDescripcion, fontInfo);

                foreach (var seccion in secciones)
                {
                    AgregarSeccion(doc, seccion.Titulo, seccion.Lineas, fontSubtitulo, fontTexto);
                }

                doc.Add(new Paragraph("\nFin del manual.", fontPie)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingBefore = 15
                });

                doc.Close();
            }
        }

        // HERENCIA DE INTERFACES
        private static void AgregarPortada(
            Document doc,
            string titulo,
            string descripcion,
            IUsuario usuario,
            PdfFont fontTitulo,
            PdfFont fontDescripcion,
            PdfFont fontInfo)
        {
            doc.Add(new Paragraph(titulo, fontTitulo)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            });

            doc.Add(new Paragraph(descripcion, fontDescripcion)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 18
            });

            // INSTANCIACIÓN DE CLASES PROPIAS
            PdfPTable tablaInfo = new PdfPTable(2)
            {
                WidthPercentage = 100,
                SpacingAfter = 20
            };

            tablaInfo.SetWidths(new float[] { 30f, 70f });

            AgregarCeldaInfo(tablaInfo, "Sistema:", "Carnicería - Punto de venta e inventario", fontInfo);
            AgregarCeldaInfo(tablaInfo, "Usuario:", usuario.Nombre, fontInfo);
            AgregarCeldaInfo(tablaInfo, "Rol:", usuario.Rol, fontInfo);
            AgregarCeldaInfo(tablaInfo, "Tipo:", "Manual temporal generado desde Ayuda", fontInfo);
            AgregarCeldaInfo(tablaInfo, "Generado:", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), fontInfo);

            doc.Add(tablaInfo);

            doc.Add(new Paragraph(
                "Este manual se genera temporalmente cuando el usuario presiona el botón de Ayuda. " +
                "No se guarda como reporte permanente del sistema. Si se cierra, puede volver a abrirse desde Ayuda.",
                fontInfo)
            {
                Alignment = Element.ALIGN_JUSTIFIED,
                SpacingAfter = 20
            });
        }

        private static void AgregarCeldaInfo(PdfPTable tabla, string etiqueta, string valor, PdfFont fuente)
        {
            tabla.AddCell(new PdfPCell(new Phrase(etiqueta, fuente))
            {
                BackgroundColor = new BaseColor(230, 245, 243),
                Padding = 6,
                BorderColor = new BaseColor(200, 200, 200)
            });

            tabla.AddCell(new PdfPCell(new Phrase(valor, fuente))
            {
                Padding = 6,
                BorderColor = new BaseColor(200, 200, 200)
            });
        }

        private static void AgregarSeccion(
            Document doc,
            string titulo,
            string[] lineas,
            PdfFont fontSubtitulo,
            PdfFont fontTexto)
        {
            doc.Add(new Paragraph(titulo, fontSubtitulo)
            {
                SpacingBefore = 12,
                SpacingAfter = 6
            });

            foreach (string linea in lineas)
            {
                doc.Add(new Paragraph("• " + linea, fontTexto)
                {
                    SpacingAfter = 4f,
                    IndentationLeft = 12f,
                    FirstLineIndent = -8f
                });
            }
        }
    }
}