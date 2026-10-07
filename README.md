# Charla #1 - Seguridad en C# y Windows Forms

**Fecha:** 06/10/2026

Este repositorio contiene los programas desarrollados para la investigación sobre **Principios de Seguridad en C# y Validaciones**, correspondiente a la materia **Herramientas de la Programación Aplicada III (.NET)**.

El objetivo de los ejemplos es demostrar de forma práctica algunas buenas prácticas de seguridad aplicadas en aplicaciones de escritorio desarrolladas con **C# y Windows Forms**.

## Escenarios desarrollados

### 1. Manejo seguro de contraseñas
Programa de registro de usuarios que utiliza **BCrypt** para generar un hash de la contraseña y evitar almacenarla directamente en texto plano.

Incluye:
- Validación de campos
- Confirmación de contraseña
- Uso de `ErrorProvider`
- Uso de `PasswordChar`
- Generación de hash con BCrypt

### 2. Prevención de SQL Injection
Programa que demuestra la diferencia entre una consulta SQL construida de forma insegura mediante concatenación y una consulta segura utilizando parámetros.

Incluye:
- Ejemplo de entrada maliciosa
- Consulta vulnerable
- Consulta parametrizada
- Explicación visual de la diferencia entre ambas

### 3. Validación y control de acceso
Programa que demuestra validación de entradas y control de permisos según el rol del usuario.

Incluye:
- Validación de nombre, edad y correo
- Uso de `ErrorProvider`
- Roles de Administrador y Usuario
- Control de permisos
- Aplicación del principio de mínimo privilegio

## Tecnologías utilizadas

- C#
- Windows Forms
- Visual Studio
- .NET
- BCrypt.Net-Next

## Estructura

Cada escenario fue desarrollado como un proyecto independiente para facilitar su ejecución y explicación durante la presentación.

## Objetivo académico

Los programas buscan relacionar la programación segura con atributos de calidad del software como:

- Seguridad
- Confiabilidad
- Mantenibilidad
- Usabilidad

También se relacionan con buenas prácticas de desarrollo y con el modelo de calidad de software **ISO/IEC 25010**.

---

# Programa 1 - Manejo Seguro de Contraseñas con BCrypt

## Descripción

Este programa implementa un formulario de registro de usuarios aplicando buenas prácticas de seguridad para el manejo de contraseñas.

El objetivo principal es demostrar por qué las contraseñas no deben almacenarse en texto plano y cómo utilizar algoritmos de hash para proteger la información sensible de los usuarios.

La aplicación utiliza la biblioteca BCrypt para generar un hash seguro a partir de la contraseña ingresada.

## Conceptos de Seguridad Aplicados

### Hash de Contraseñas

La contraseña introducida por el usuario se transforma mediante:

```csharp
BCrypt.Net.BCrypt.HashPassword()
```

Esto genera una cadena cifrada irreversible que puede almacenarse de forma segura.

Ejemplo:

```text
Contraseña original:
MiPassword123

Hash generado:
$2a$11$7m0UwL...
```

### Ocultamiento de Contraseñas

Se utiliza:

```csharp
UseSystemPasswordChar = true;
```

para evitar que la contraseña sea visible durante su escritura.

### Confirmación de Contraseña

El usuario debe ingresar la contraseña dos veces para reducir errores de digitación.

### Restricción de Longitud

Se establece:

```csharp
MaxLength = 20
```

para limitar el tamaño de entrada.

### Validaciones Implementadas

- Usuario obligatorio.
- Contraseña obligatoria.
- Longitud mínima de seis caracteres.
- Confirmación obligatoria.
- Coincidencia entre ambas contraseñas.

### Uso de ErrorProvider

Los errores de validación se muestran mediante indicadores visuales sin interrumpir la experiencia del usuario.

## Riesgo Mitigado

Este programa ayuda a prevenir:

- Robo de contraseñas almacenadas en texto plano.
- Exposición de credenciales.
- Errores de digitación durante el registro.

## Captura de Pantalla

<img width="748" height="495" alt="image" src="https://github.com/user-attachments/assets/8a42dea2-89d4-4147-bdee-3e1ff07910a6" />

---

# Programa 2 - Prevención de SQL Injection

## Descripción

Este programa demuestra una de las vulnerabilidades más comunes en aplicaciones conectadas a bases de datos: SQL Injection.

Se compara una consulta insegura basada en concatenación de cadenas con una consulta segura utilizando parámetros.

## Conceptos de Seguridad Aplicados

### Consulta Vulnerable

La aplicación construye una consulta mediante concatenación:

```csharp
string consulta =
"SELECT * FROM Usuarios WHERE NombreUsuario = '" +
entrada + "'";
```

Este enfoque permite que datos introducidos por el usuario modifiquen el comportamiento de la consulta.

### Ejemplo de Entrada Maliciosa

```text
admin' OR '1'='1' --
```

La consulta resultante sería:

```sql
SELECT * FROM Usuarios
WHERE NombreUsuario = 'admin' OR '1'='1' --'
```

Esto puede provocar accesos no autorizados.

### Consulta Segura

La aplicación demuestra la forma correcta:

```sql
SELECT * FROM Usuarios
WHERE NombreUsuario = @usuario
```

Mediante parámetros:

```csharp
@usuario
```

### Separación entre Datos y Código

La entrada del usuario se procesa como un dato y no como una instrucción SQL.

## Riesgo Mitigado

La parametrización ayuda a prevenir:

- SQL Injection.
- Manipulación de consultas.
- Acceso no autorizado a información.
- Modificación indebida de registros.

## Aprendizaje Principal

Nunca se deben construir consultas SQL mediante concatenación de datos introducidos por el usuario.

## Captura de Pantalla

<img width="758" height="492" alt="image" src="https://github.com/user-attachments/assets/1860c098-bf55-4a47-9fa1-e778016725d4" />

<img width="752" height="497" alt="image" src="https://github.com/user-attachments/assets/d15771d2-082b-42ee-a050-12f0ccfb0531" />

<img width="750" height="496" alt="image" src="https://github.com/user-attachments/assets/ba151096-05cb-4a11-b998-3acd6800827b" />

<img width="747" height="491" alt="image" src="https://github.com/user-attachments/assets/c1ace09a-f647-480b-948f-2a7747e90a20" />


---

# Programa 3 - Validación de Datos y Control de Acceso por Roles

## Descripción

Este programa demuestra la importancia de validar los datos de entrada y restringir funcionalidades según el nivel de privilegios del usuario.

La aplicación crea un usuario temporal y posteriormente habilita o bloquea acciones dependiendo del rol seleccionado.

## Conceptos de Seguridad Aplicados

### Validación de Entradas

Se validan los siguientes campos:

#### Nombre

```text
No puede estar vacío.
```

#### Edad

Debe encontrarse entre:

```text
18 y 100 años
```

#### Correo Electrónico

Se valida la estructura básica:

```text
usuario@correo.com
```

#### Rol

Debe seleccionarse una opción válida.

### Uso de ErrorProvider

Los errores se muestran visualmente sobre cada control.

### Control de Acceso Basado en Roles

La aplicación implementa dos perfiles:

#### Administrador

Puede:

- Ver perfil.
- Editar perfil.
- Gestionar usuarios.

#### Usuario

Puede:

- Ver perfil.
- Editar perfil.

No puede:

- Gestionar usuarios.

### Verificación de Privilegios

Se utiliza el método:

```csharp
EsAdministrador()
```

para determinar si una acción está permitida o no.

### Principio de Mínimo Privilegio

Cada usuario recibe únicamente los permisos estrictamente necesarios para realizar sus tareas.

## Riesgo Mitigado

Este enfoque reduce:

- Escalamiento de privilegios.
- Accesos no autorizados.
- Acciones administrativas indebidas.
- Errores por falta de validación.

## Captura de Pantalla

<img width="1005" height="575" alt="image" src="https://github.com/user-attachments/assets/ca81b209-f84c-458d-b46c-e49740c04f0e" />

<img width="1041" height="572" alt="image" src="https://github.com/user-attachments/assets/434f4903-eec1-43af-a4d6-d8e4f0517a70" />

---

# Comparación de los Escenarios

| Programa | Tema de Seguridad |
|-----------|------------------|
| Programa 1 | Seguridad de contraseñas mediante hashing |
| Programa 2 | Prevención de SQL Injection |
| Programa 3 | Validación de entradas y control de acceso |

---

# Relación con ISO/IEC 25010

Los programas desarrollados se relacionan directamente con varias características del modelo de calidad ISO/IEC 25010.

## Seguridad

- Protección de credenciales.
- Restricción de accesos.
- Prevención de ataques.

## Confiabilidad

- Validación de información ingresada.
- Reducción de errores de ejecución.

## Mantenibilidad

- Separación de responsabilidades.
- Código modular.
- Clases reutilizables.

## Usabilidad

- Mensajes claros.
- Uso de ErrorProvider.
- Retroalimentación visual para el usuario.

---

# Estructura del Repositorio

```plaintext
Investigacion1-Seguridad/
│
├── Programa1_BCrypt/
│   ├── Form1.cs
│   ├── Usuario.cs
│   └── Program.cs
│
├── Programa2_SQLInjection/
│   ├── Form1.cs
│   └── Program.cs
│
├── Programa3_ControlAcceso/
│   ├── Form1.cs
│   ├── Usuario.cs
│   ├── Validaciones.cs
│   └── Program.cs
│
├── images/
│   ├── programa1-registro-seguro.png
│   ├── programa2-sqlinjection.png
│   └── programa3-control-acceso.png
│
└── README.md
```

---

# Conclusiones

A través de estos tres escenarios fue posible demostrar cómo aplicar principios fundamentales de seguridad en aplicaciones desarrolladas con C# y Windows Forms.

Las prácticas mostraron la importancia de:

- Proteger contraseñas mediante hashing.
- Evitar vulnerabilidades de SQL Injection.
- Validar adecuadamente las entradas del usuario.
- Implementar controles de acceso según roles.
- Aplicar el principio de mínimo privilegio.

Estas medidas contribuyen directamente a mejorar la calidad, seguridad y confiabilidad de las aplicaciones de software.

---

## Autores y Contexto

- Nombres: Johandry González; Christian Arce
- Institución: Universidad Tecnológica de Panamá (UTP)
- Asignatura: Herramientas de programación 3
- Charla #1
- Fecha de Realización: 06/10/2026
