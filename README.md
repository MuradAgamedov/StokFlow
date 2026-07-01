# StokFlow (ModernWMC)

StokFlow is an ASP.NET Core (.NET 10) warehouse and inventory management system (Warehouse Management Console). It combines an admin panel for managing products, warehouses, inventory, purchase orders, and transfers with a public-facing corporate site (about, contact, FAQ, etc.).

## Features

- **Inventory management**: stock records, stock adjustment, and a visual warehouse map
- **Warehouse & location management**: warehouses, locations, and categories
- **Purchase orders**: creation and tracking of purchase orders
- **Transfers**: stock transfers between warehouses
- **Company & measure unit management**: companies, measure units
- **Content management**: hero, about, FAQ, CTA, privacy policy, and terms of use content
- **Contact**: contact form messages, phone/email/address/map information
- **Authentication**: admin login and authorization via ASP.NET Core Identity
- **Statistics**: summary statistics on the dashboard

## Tech Stack

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core 10 (SQL Server)
- ASP.NET Core Identity
- Razor Views + ViewComponents
- Docker Compose (optional PostgreSQL service)

## Project Structure

```
Areas/Admin/       Admin panel (Controllers, ViewModels, Views)
Controllers/        Public site controllers (Home, About, Contact, Faq, etc.)
Data/                Abstract/Concrete data access layer and EF DbContext
Services/            Abstract/Concrete service layer (business logic)
Models/              Domain models
ViewModels/          Public site view models
ViewComponents/      Components such as Header, Footer, AddBranchModal
Migrations/          EF Core migrations
Views/               Public site Razor views
wwwroot/             Static files (css, js, uploads)
```

## Requirements

- .NET 10 SDK
- SQL Server (local or remote) — connection string is defined in `appsettings.json`
- (Optional) Docker, to run the PostgreSQL service via `docker-compose`

## Setup

1. Clone the repository and navigate to the project directory.
2. Update the `ConnectionStrings:DefaultConnection` value in `appsettings.json` (or `appsettings.Development.json`) to match your environment.
3. Apply the database migrations:

   ```bash
   dotnet ef database update
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

On first run, the application automatically seeds initial data and the admin user/roles via `DbSeeder` and `IdentitySeeder`.

## Accessing the Admin Panel

The admin panel is accessed via `/Admin/Login`. Access to admin pages without logging in is blocked using `AccessDeniedPath`.

## Docker with PostgreSQL (Optional)

The `docker-compose.yml` file in the repository defines an optional PostgreSQL service:

```bash
docker compose up -d
```
