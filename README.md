# 📚 Gestión de Libros – Proyecto Fullstack

Aplicación simple de gestión de libros desarrollada como trabajo práctico académico. El sistema está dividido en dos partes: un backend en ASP.NET Core con Entity Framework y PostgreSQL, y un frontend en HTML con Bootstrap y JavaScript puro.

---

## 🛠 Tecnologías utilizadas

### 🔙 Backend
- ASP.NET Core 8  
- Entity Framework Core (Code First)  
- PostgreSQL (contenedor Docker)

### 🌐 Frontend
- HTML  
- CSS (Bootstrap 5)  
- JavaScript (vanilla)

### 🧰 Herramientas
- Rider / Visual Studio  
- Postman  
- Docker Desktop  

---

## 🔄 Funcionalidades principales

- 📖 Obtener el primer libro registrado en la base de datos  
  `GET /api/libro/primero`

- ✏️ Editar datos de un libro  
  `PUT /api/libro/{id}`

- ✅ Validación de campos requeridos desde el frontend

- ⚠️ Alerta visual según éxito o error al guardar

- 📱 Interfaz responsive y clara utilizando Bootstrap

---

## 🧪 Validaciones implementadas

- Campos obligatorios en el formulario  
- Feedback visual usando `alert-success` y `alert-danger` de Bootstrap  
- Botón de envío deshabilitado mientras se espera la respuesta del servidor  

---

## 🗃 Base de datos

- Relaciones 1:N correctamente modeladas entre libros, autores y categorías  
- Migraciones generadas y aplicadas con Entity Framework Core  
- Base de datos PostgreSQL ejecutándose dentro de Docker  

---

**Brunelli Jazmin**  

