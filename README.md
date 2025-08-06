📚 Gestión de Libros – Proyecto Fullstack
Este proyecto es una aplicación simple de gestión de libros desarrollada como parte de un trabajo práctico académico. Está dividido en dos partes: un backend en ASP.NET Core con Entity Framework y PostgreSQL, y un frontend en HTML con Bootstrap y JavaScript puro.

🛠 Tecnologías utilizadas
Backend: ASP.NET Core 8, Entity Framework Core (Code First), PostgreSQL (Docker)

Frontend: HTML, CSS (Bootstrap 5), JavaScript (vanilla)

Herramientas: Rider / Visual Studio, Postman, Docker Desktop

🔄 Funcionalidades principales
Obtener el primer libro registrado en la base de datos (GET /api/libro/primero)

Editar datos de un libro (PUT /api/libro/{id})

Validación de campos requeridos desde el frontend

Alerta visual según éxito o error al guardar

Interfaz responsive y clara con Bootstrap

🧪 Validaciones
Campos obligatorios en el formulario

Feedback visual con Bootstrap Alerts (alert-success / alert-danger)

Botón deshabilitado mientras se espera la respuesta del servidor

🗃 Base de datos
Se modelaron correctamente las relaciones 1:N entre libros, autores y categorías.

Migraciones aplicadas con Entity Framework Core.

PostgreSQL corriendo en Docker.

🎯 Objetivo académico
El objetivo del proyecto fue integrar conocimientos de:

Desarrollo de Web APIs en .NET

Consumo de endpoints desde el frontend sin frameworks

Validaciones, manejo de estados y comunicación entre capas
