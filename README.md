# 📌 Prueba Técnica – Módulo de Trabajadores (.NET 8)

## 📖 Descripción

Aplicación web desarrollada como solución al requerimiento de mantenimiento de trabajadores.

El sistema permite:

✅ Registrar trabajadores  
✅ Editar trabajadores  
✅ Eliminar trabajadores  
✅ Listar trabajadores  
✅ Filtrar por sexo  

---

## 🚀 Tecnologías Utilizadas

### 🔹 Backend
- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Procedimientos almacenados

### 🔹 Frontend
- Razor Views
- Bootstrap 5

### 🔹 Infraestructura
- Docker
- Docker Compose

---

## 🏗 Arquitectura

El proyecto sigue una estructura MVC:

- **Models** → Entidades / ViewModels  
- **Controllers** → Lógica de negocio  
- **Views** → Interfaz de usuario  

---

## ⚙️ Requisitos Previos

Antes de ejecutar el proyecto asegúrate de tener instalado:

✅ Docker  
✅ Docker Compose  

Verificar instalación:

```bash
docker --version
docker compose version
🐳 Ejecución con Docker
Clonar el repositorio:

git clone https://github.com/Lenin-LG/Myper-SAC-Prueba.git
Ingresar al proyecto:

cd Myper-SAC-Prueba
Construir y levantar contenedores:

docker compose up -d --build
🌐 Acceso a la Aplicación
Una vez iniciado:
http://localhost:5000
👉 Aplicación Web:

http://localhost:5050
👉 SQL Server (si lo necesitas):

localhost,1433
Usuario y contraseña definidos en docker-compose.yml.

🗄 Base de Datos
Nombre:

TrabajadoresPrueba
La base se crea automáticamente al iniciar los contenedores.

