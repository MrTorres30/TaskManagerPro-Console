# 📌 TaskManagerPro — Core Engine

[![.NET](https://img.shields.io/badge/.NET-8.0%2B-512BD4?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat&logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![Architecture](https://img.shields.io/badge/Architecture-Separation%20of%20Concerns-blue?style=flat)]()
[![Git](https://img.shields.io/badge/Commits-Conventional%20Commits-FE5196?style=flat&logo=git&logoColor=white)](https://www.conventionalcommits.org/)

> **TaskManagerPro — Core Engine** es una aplicación de consola en **C# (.NET)** orientada al Backend, diseñada bajo principios de **Clean Code**, **Programación Orientada a Objetos (POO)** y **Separación de Responsabilidades (SoC)**. Cuenta con un sistema completo de gestión de tareas (CRUD) y un motor de **auditoría inmutable en memoria**.

---

## 🚀 Funcionalidades Principales

- 📝 **Creación de Tareas:** Asignación automática de `Id` incremental, timestamp de creación (`CreatedAt`) y estado inicial pendiente.
- 📋 **Listado y Visualización:** Vista detallada con estado formateado (`✅ Completada` / `⏳ Pendiente`) y fecha legible.
- ✅ **Completado de Tareas:** Actualización de estado garantizando integridad referencial.
- ✏️ **Edición de Tareas:** Modificación segura de título y descripción por ID.
- 🗑️ **Eliminación Segura:** Confirmación interactiva previa al borrado (`s/n`) para evitar pérdidas accidentales.
- 📜 **Historial de Auditoría Inmutable:** Registro cronológico de cada operación realizada en el sistema.
- 🛡️ **Validación Defensiva (Crash-Proof):** Manejo de entradas con `int.TryParse`, validación de nulos con `string.IsNullOrWhiteSpace` y operadores *null-coalescing* (`??`).

---

## 🏛️ Arquitectura y Principios de Diseño

El proyecto está estructurado en 3 capas desacopladas más un punto de composición:

```
TaskManagerProC/
│
├── Models/              # Entidades de Dominio
│   ├── TaskItem.cs      # Modelo de Tarea (Id, Title, Description, IsCompleted, CreatedAt)
│   └── AuditLog.cs      # Modelo de Log (Id, Message, Timestamp)
│
├── Services/            # Lógica de Negocio y Estado en Memoria
│   ├── TaskManager.cs   # Gestión de tareas y orquestación con auditoría
│   └── AuditService.cs  # Registro e inmutabilidad del historial
│
├── UI/                  # Capa de Presentación e Interacción
│   └── ConsoleInterface.cs # Menú interactivo, validaciones y UX
│
├── Program.cs           # Composition Root (Inyección de Dependencias)
└── TaskManagerProC.csproj
```

### 🔑 Decisiones Técnicas Clave

| Concepto | Implementación | Justificación |
|---|---|---|
| **Separation of Concerns (SoC)** | `Models` / `Services` / `UI` | Desacoplamiento total entre la lógica de negocio, datos y presentación. |
| **Dependency Injection (DI)** | Constructor Injection en `TaskManager` y `ConsoleInterface` | Facilita el testeo unitario y evita dependencias rígidas (*tight coupling*). |
| **Encapsulamiento & Inmutabilidad** | `private readonly List<T>` expuestas como `IReadOnlyList<T>` | Protege las colecciones internas de ser modificadas o vaciadas desde el exterior. |
| **Composition Root** | Centralizado en `Program.cs` | Un único punto donde se inicializa el grafo de dependencias de la aplicación. |
| **Guard Clauses** | Early Return (`if (task is null) return false;`) | Reduce la complejidad ciclomática y elimina anidamientos innecesarios. |
| **Null Safety** | Inicialización con `string.Empty` y operador `??` | Eliminación preventiva de excepciones `NullReferenceException`. |

---

## 💻 Requisitos y Ejecución

### Prerrequisitos
- [.NET SDK 8.0](https://dotnet.microsoft.com/download) o superior.

### Instalación y Ejecución

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/TU_USUARIO/TaskManagerProC.git
   cd TaskManagerProC
   ```

2. **Compilar y ejecutar:**
   ```bash
   dotnet run
   ```

---

## 🛠️ Tecnologías

- **Lenguaje:** C# 12
- **Plataforma:** .NET 8.0 SDK
- **Colecciones & Consultas:** Generic Collections (`List<T>`, `IReadOnlyList<T>`), LINQ (`FirstOrDefault`)
- **Control de Versiones:** Git con estándar [Conventional Commits](https://www.conventionalcommits.org/)

---

## 👤 Autor

Desarrollado por **[Tu Nombre]**  
- GitHub: [@TU_USUARIO](https://github.com/TU_USUARIO)
- LinkedIn: [Tu Perfil](https://linkedin.com/in/tu-perfil)
