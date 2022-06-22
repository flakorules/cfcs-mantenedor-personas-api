# Mantenedor de Personas - API

**Lorem Ipsum** is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.

## Instrucciones para levantar el ambiente de desarrollo

### Pre requisitos

* Visual Studio 2019 o superior
* Acceso a una insstancia de PostgreSQL

### Paso a paso

1. Descargar los fuentes

   ```
   git clone repo
   ```
2. Modificar connection string en appsetings

   ```
     "ConnectionString": {
       "Mantenedor": "User ID=<USUARIO>;Password=<PASSWORD>;Host=<SERVIDOR>;Port=<PUERTO>;Database=<BASE DE DATOS>;Pooling=true;SSL Mode=Require;Trust Server Certificate=True;"
     }
   ```
3. Update Database

   ```
   dotnet ef database update --project Cfcs.Mantenedor.API --connection "User ID=<USUARIO>;Password=<PASSWORD>;Host=<SERVIDOR>;Port=<PUERTO>;Database=<BASE DE DATOS>;Pooling=true;SSL Mode=Require;Trust Server Certificate=True;"
   ```
4. Ejecutar Script "src/INSERT DATA.sql", para ello se sugiere utilizar la aplicación de escritorio PgAdmin, conectandose a la instancia
