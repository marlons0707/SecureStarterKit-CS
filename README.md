
# SecureStarterKit

SecureStarterKit es una plantilla de inicio para aplicaciones web en ASP.NET Core, diseñada para implementar un CRUD básico de usuarios y enfocada en seguir las recomendaciones de seguridad del [OWASP Top 10 2021](https://owasp.org/www-project-top-ten/).

Este proyecto está orientado a desarrolladores que deseen comenzar rápidamente con un proyecto seguro, aplicando buenas prácticas desde el principio.

Desarrollado como parte del proyecto de grado de la maestría en Seguridad Informática de la Universidad Mariano Gálvez de Guatemala.
Por: 
- Marlon Saravia Gregorio
- Manuel Sánchez Paz
- Sergio López Reyes
- Edgar Antonio Aju
- Sandi Yamilet Bamac

---

## 🚀 **Características**
- Operaciones CRUD para la gestión de usuarios.
- Hashing seguro de contraseñas utilizando `PasswordHasher`.
- Protección contra las vulnerabilidades más comunes del OWASP Top 10:
  - A01:2021 (Broken Access Control): Validación de permisos en endpoints.
  - A02:2021 (Cryptographic Failures): Contraseñas con hashing seguro.
  - A03:2021 (Injection): Uso de Entity Framework Core para evitar SQL Injection.
  - A05:2021 (Security Misconfiguration): Configuración segura de la aplicación.

---

## 📂 **Estructura del Proyecto**

```plaintext
SecureStarterKit/
├── Controllers/
│   └── UserController.cs       # Controlador CRUD de usuarios
├── Data/
│   └── ApplicationDbContext.cs # Contexto de base de datos
├── Models/
│   └── User.cs                 # Modelo de usuario
├── wwwroot/                    # Archivos estáticos (CSS, JS, etc.)
├── appsettings.json            # Configuración del proyecto
├── Program.cs                  # Configuración principal de la app
└── SecureStarterKit.csproj     # Archivo de configuración del proyecto .NET
```

---

## 🛠️ **Requisitos**
- **SDK .NET Core**: Version 6.0 o superior.
- **Base de Datos**: SQLite (puedes cambiarla en `ApplicationDbContext`).
- **Herramienta para gestionar dependencias**: `dotnet`.

---

## 📖 **Cómo Usar**

### 1. Clonar el Repositorio
Clona este repositorio en tu máquina local:
```bash
git clone https://github.com/tuusuario/SecureStarterKit.git
cd SecureStarterKit
```

### 2. Restaurar Dependencias
Restaura las dependencias del proyecto:
```bash
dotnet restore
```

### 3. Configurar la Base de Datos
Actualiza y aplica las migraciones para configurar la base de datos:
```bash
dotnet ef database update
```

### 4. Ejecutar el Proyecto
Inicia la aplicación:
```bash
dotnet run
```

### 5. Probar Endpoints
Accede a la API en [http://localhost:5000/api/user](http://localhost:5000/api/user).

---

## 🛡️ **Seguridad**
Este proyecto aplica las siguientes medidas de seguridad:
1. **Contraseñas Hasheadas**: Implementación de `PasswordHasher` para gestionar contraseñas de manera segura.
2. **Validación de Entradas**: Uso de Entity Framework Core para prevenir SQL Injection.
3. **Protección de Rutas**: Solo usuarios autorizados pueden acceder a ciertas rutas (extensible según tus necesidades).

---

## 📄 **Licencia**
Este proyecto se distribuye bajo la licencia MIT. Puedes usarlo y modificarlo libremente.

---

**¡Gracias por usar SecureStarterKit! 🎉**
