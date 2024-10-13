# API de Lista de Compras

La **API de Lista de Compras** es un servicio web RESTful desarrollado en **ASP.NET Core** y **C#**. Permite a los usuarios gestionar sus listas de compras y los artículos asociados a ellas a través de operaciones CRUD (Crear, Leer, Actualizar, Eliminar). La API está documentada y puede ser probada fácilmente utilizando **Swagger**.

## Tecnologías

- **ASP.NET Core**: Framework utilizado para construir aplicaciones web.
- **C#**: Lenguaje de programación utilizado en el desarrollo de la API.
- **Entity Framework Core**: ORM utilizado para interactuar con la base de datos.
- **SQL Server**: Sistema de gestión de bases de datos utilizado para almacenar los datos de las listas y artículos.
- **Swagger**: Herramienta para la documentación y prueba de APIs.

## Características

- **Gestión de Listas de Compras**: Crear, leer, actualizar y eliminar listas de compras.
- **Gestión de Artículos**: Crear, leer, actualizar y eliminar artículos dentro de las listas de compras.
- **Validación de Datos**: Asegura que los datos ingresados cumplen con los criterios establecidos.
- **Documentación Interactiva**: Uso de Swagger para probar la API de manera sencilla e intuitiva.

## Endpoints

**Shopping Lists - Listas de Compras**
GET /api/shoppinglists: Obtiene todas las listas de compras.
GET /api/shoppinglists/{id}: Obtiene una lista de compras específica por ID.
POST /api/shoppinglists: Crea una nueva lista de compras.
PUT /api/shoppinglists/{id}: Actualiza una lista de compras existente.
DELETE /api/shoppinglists/{id}: Elimina una lista de compras.

**Shopping Items - Artículos**
GET /api/shoppinglists/{shoppingListId}/items: Obtiene todos los artículos de una lista de compras específica.
GET /api/shoppinglists/{shoppingListId}/items/{id}: Obtiene un artículo específico por ID.
POST /api/shoppinglists/{shoppingListId}/items: Crea un nuevo artículo en una lista de compras.
PUT /api/shoppinglists/{shoppingListId}/items/{id}: Actualiza un artículo existente.
DELETE /api/shoppinglists/{shoppingListId}/items/{id}: Elimina un artículo de una lista de compras.

## Instalación

**Restaurar las dependencias**:

```bash
git clone https://github.com/mangelesc/ShoppingList-API.git
```

**Restaurar las dependencias**:

```bash
dotnet restore
```

**Migraciones**:
Si necesitas crear la base de datos y las tablas iniciales, ejecuta:

```bash
dotnet ef database update
```

**Restaurar las dependencias**:

```bash
dotnet watch run
```
