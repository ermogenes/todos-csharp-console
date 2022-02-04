# todos-csharp-console
Uma aplicação TODO em C# (console) com EFCore 6, MySQL e Pomelo

## Banco

https://github.com/ermogenes/todos-mysql

### EF Tools

Instalar
```
dotnet tool install --global dotnet-ef
```

Atualizar
```
dotnet tool update --global dotnet-ef
```

### Pacotes

```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql

```

### `Scaffolding`

```
dotnet ef dbcontext scaffold "server=localhost;port=3333;uid=root;pwd=1234;database=todos" Pomelo.EntityFrameworkCore.MySql -o db -f --no-pluralize
```
