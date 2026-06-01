# Sistema de Carnicería

Proyecto final de **Programación Orientada a Objetos** desarrollado en **C# con Windows Forms**.

## Datos académicos

**Institución:** Instituto Tecnológico de Minatitlan

**Carrera:** Ingeniería en Sistemas Computacionales y Tecnológicos

**Semestre:** Segundo semestre

**Materia:** Programación Orientada a Objetos

**Docente encargada:** Ana Estela Ruiz Linares

**Proyecto:** Sistema de Carnicería

## Descripción

Este proyecto es un sistema de punto de venta e inventario para una carnicería local.

Está pensado para apoyar el control diario del negocio mediante el registro de ventas, productos, inventario, mermas, usuarios, corte de caja, reportes, gráficas y manual de usuario.

El sistema fue desarrollado con el objetivo de reducir errores en las ventas, organizar la información de productos y facilitar la administración de una carnicería pequeña o mediana.

El proyecto aplica conceptos de Programación Orientada a Objetos como clases, interfaces, herencia, sobrecarga de métodos, manejo de excepciones, uso de archivos y organización modular del código.

## Tipo de sistema

Sistema de escritorio para Windows desarrollado con **Windows Forms**.

El programa utiliza formularios y controles de usuario para separar las pantallas principales del sistema y mejorar la organización visual.

Se recomienda utilizarlo en una pantalla de **16 pulgadas o superior** para una mejor experiencia visual.

En pantallas de 14 pulgadas el sistema funciona, pero algunos elementos de la interfaz pueden moverse o verse más ajustados debido al tamaño de pantalla.

## Accesos del sistema

El sistema cuenta con dos tipos de acceso:

* Administrador
* Empleado

Cada usuario entra con sus credenciales y el sistema muestra funciones de acuerdo con su rol.

## Rol Administrador

El administrador tiene acceso completo al sistema.

Funciones principales del administrador:

* Iniciar sesión en el sistema.
* Realizar ventas.
* Consultar inventario.
* Agregar productos.
* Modificar productos.
* Registrar mermas.
* Consultar corte de caja.
* Revisar reportes.
* Exportar información en PDF.
* Exportar información en Excel.
* Consultar gráficas.
* Administrar usuarios.
* Revisar información importante del sistema.
* Abrir el manual de usuario desde el botón de ayuda.
* Cerrar sesión de forma segura.

## Rol Empleado

El empleado tiene acceso a las funciones necesarias para operar durante el turno.

Funciones principales del empleado:

* Iniciar sesión en el sistema.
* Realizar ventas.
* Buscar productos por ID o nombre.
* Agregar productos al carrito.
* Cobrar ventas.
* Consultar información básica del inventario.
* Registrar mermas si el sistema lo permite.
* Abrir el manual de usuario desde el botón de ayuda.
* Cerrar sesión al finalizar su turno.

El empleado no tiene acceso completo a la administración del sistema.

## Módulos principales

### Inicio de sesión

Permite el acceso al sistema mediante usuario y contraseña.

El sistema identifica el rol del usuario y habilita las funciones correspondientes.

### Ventas

Permite buscar productos por ID o nombre, agregar productos al carrito, calcular subtotales, calcular el total de la venta y realizar el cobro.

El sistema valida el stock disponible antes de cobrar y descuenta automáticamente el inventario cuando la venta se registra correctamente.

### Inventario

Permite consultar productos registrados, precios, categorías, unidades de medida y stock disponible.

También permite visualizar información del inventario mediante tablas y gráficas.

### Productos

Permite administrar los productos de la carnicería.

Desde este módulo se pueden agregar o modificar productos, así como actualizar datos importantes como nombre, categoría, precio, unidad de medida y stock.

### Mermas

Permite registrar productos perdidos, dañados o retirados de la venta.

El registro de mermas ayuda a controlar pérdidas y mantener actualizado el inventario.

### Corte de caja

Permite revisar ventas, métodos de pago, totales y movimientos registrados.

Este módulo ayuda a verificar los ingresos del día y controlar el cierre de caja.

### Usuarios

Permite administrar las cuentas del sistema.

El administrador puede crear, modificar o eliminar usuarios, así como asignar roles de Administrador o Empleado.

### Reportes

Permite generar reportes en PDF y exportar información a Excel.

Los reportes sirven como evidencia y apoyo para revisar ventas, inventario y cortes de caja.

### Gráficas

El sistema incluye gráficas para visualizar información importante del negocio.

Las gráficas ayudan a interpretar datos de inventario, ventas o caja de forma más clara.

### Manual de usuario

El sistema cuenta con un botón de ayuda que genera un manual de usuario en PDF.

El manual se genera de forma temporal y muestra información según el tipo de usuario que inició sesión.

## Manejo de Forms y UserControls

El sistema está organizado mediante formularios y controles de usuario.

Los **Forms** se utilizan para ventanas principales, pantallas de acceso, cobro y formularios independientes.

Los **UserControls** se utilizan para dividir las secciones internas del sistema, como ventas, inventario, usuarios, corte de caja y otros módulos.

Esta organización permite que el proyecto sea más ordenado, más fácil de mantener y visualmente más claro para el usuario.

## Optimización y experiencia de usuario

El sistema fue diseñado buscando una interfaz visualmente atractiva, intuitiva y fácil de usar.

Se aplicaron estilos visuales en tablas, botones, formularios y paneles para que el usuario pueda identificar rápidamente cada módulo.

También se incluyeron validaciones para evitar errores comunes, como ventas sin productos, cantidades inválidas, productos inexistentes o inventario insuficiente.

El sistema incluye mensajes de advertencia, confirmación y error para guiar al usuario durante el uso del programa.

## Requisitos de Programación Orientada a Objetos

El proyecto incluye los siguientes puntos:

* Instanciación de clases propias.
* Sobrecarga de métodos.
* Herencia de clases.
* Herencia de interfaces.
* Uso de interfaces.
* Manejo de excepciones.
* Uso de archivos.
* Uso de gráficos.
* Interfaz gráfica en Windows Forms.

## Estructura del proyecto

```text
Data/
Interfaces/
Models/
Properties/
Resources/
Services/
Views/
```

Descripción general de carpetas:

* `Data`: archivos de datos utilizados por el sistema.
* `Interfaces`: interfaces utilizadas para organizar el código.
* `Models`: clases principales del sistema.
* `Properties`: configuración y propiedades del proyecto.
* `Resources`: imágenes, iconos y recursos visuales.
* `Services`: lógica de manejo de datos, archivos, ventas, usuarios, caja, reportes y manual.
* `Views`: formularios y controles visuales del sistema.

## Librerías utilizadas

El proyecto utiliza las siguientes librerías:

* `iTextSharp`: generación de documentos PDF, reportes y manual de usuario.
* `EPPlus`: exportación de información a archivos Excel.
* `WinForms.DataVisualization`: creación y visualización de gráficas dentro del sistema.

## Tecnologías utilizadas

* C#
* Windows Forms
* .NET
* GitHub

## Recomendación de uso

Para una mejor experiencia se recomienda:

* Usar una pantalla de 16 pulgadas o superior.
* Ejecutar el sistema en Windows.
* No modificar manualmente los archivos de datos.
* Cerrar sesión al terminar de usar el sistema.
* Realizar cortes de caja diariamente.
* Mantener actualizado el inventario.
* Usar cada cuenta de usuario según su rol.
* Guardar reportes importantes cuando sea necesario.

## Objetivo académico

Este sistema fue desarrollado como proyecto final de la materia de Programación Orientada a Objetos.

El objetivo principal fue aplicar los conocimientos adquiridos durante el curso en un caso práctico, utilizando conceptos como clases, objetos, interfaces, herencia, sobrecarga, excepciones, archivos, gráficos e interfaz gráfica.

## Autor

**Said De Jesus Gomez Librado**

## Nota final

Espero que el programa desarrollado sea de su agrado.

Este sistema fue realizado con el propósito de aplicar los conocimientos adquiridos durante el segundo semestre de Ingeniería en Sistemas Computacionales y Tecnológicos, enfocándolo en un caso práctico de punto de venta e inventario para una carnicería local.

