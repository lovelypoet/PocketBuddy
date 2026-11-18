# PocketBuddy

PocketBuddy is a personal finance application with a clear backend flow:

```text
Controller -> Service -> Repository -> Database
```

## Repository layout

```text
backend/
  PocketBuddy.Api/               Web host, middleware, filters, Swagger, and controllers
    Controllers/                 HTTP endpoints and request/response handling
    Extensions/                  Dependency injection, Swagger, and HTTP setup extensions
  PocketBuddy.Domain/            Entities, enums, and shared business models
  PocketBuddy.Services/          Business rules and use cases
  PocketBuddy.Repository/        EF Core context and repositories
  PocketBuddy.Api.Tests/         API and service tests
frontend/
  pocketbuddy-web/
    src/
      app/                       App entry, routing, and global providers
      components/
        ui/                      Internal design-system primitives
        layout/                  Shared layout components
      features/                  Feature-owned UI, hooks, services, and types
      pages/                     Route-level page composition
      services/                  Shared HTTP client and interceptors
      types/                     Global shared types
      utils/                     Shared helper functions
docker/
docker-compose.yml
```

## Adding a backend feature

1. Add entities to `PocketBuddy.Domain/Entities`.
2. Add database access to `PocketBuddy.Repository`.
3. Add use-case logic to `PocketBuddy.Services`.
4. Register concrete services and repositories in their `DependencyInjection.cs` files.
5. Add an HTTP endpoint in `PocketBuddy.Api/Controllers`.

Controllers handle HTTP, services own business rules, and repositories are the only layer that accesses the database.

## Adding a frontend feature

For a feature such as Accounts, use `frontend/pocketbuddy-web/src/features/accounts`:

1. Put feature-only UI in `components/`.
2. Put state and React Query hooks in `hooks/`.
3. Put feature API calls in `services/`.
4. Define feature interfaces and DTOs in `types.ts`.
5. Compose the feature into a route-level page in `pages/`.

Use `components/ui` only for reusable, business-neutral primitives such as `Button`, `Input`, `Card`, and `Modal`. Use `components/layout` for layout shared across pages. The shared Axios instance lives in `services/apiClient.ts`.

## Local development

Prerequisites: .NET 10 SDK, Node.js 20.19+ (or 22.12+), npm, and Docker Desktop / Docker Engine with Docker Compose.

Start the local database:

```powershell
Copy-Item .env.example .env
docker compose up -d sqlserver
```

Run the API:

```powershell
$env:ConnectionStrings__DefaultConnection = "Server=localhost,1433;Database=PocketBuddy;User Id=sa;Password=<your-local-password>;TrustServerCertificate=True"
dotnet run --project backend\PocketBuddy.Api
```

Run the frontend in another terminal:

```powershell
Copy-Item frontend\pocketbuddy-web\.env.example frontend\pocketbuddy-web\.env.local
Set-Location frontend\pocketbuddy-web
npm ci
npm run dev
```

## Build and test

```powershell
dotnet build PocketBuddy.sln
dotnet test PocketBuddy.sln

Set-Location frontend\pocketbuddy-web
npm run build
npm test
```

## Database migrations

```powershell
dotnet ef migrations add InitialIdentitySchema `
  --project backend\PocketBuddy.Repository `
  --startup-project backend\PocketBuddy.Api `
  --output-dir Persistence\Migrations

dotnet ef database update `
  --project backend\PocketBuddy.Repository `
  --startup-project backend\PocketBuddy.Api
```

Never commit `.env` or `.env.local`; use their example files as templates.
