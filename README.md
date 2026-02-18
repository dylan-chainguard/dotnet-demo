# Dotnet Demo

A simple single-page blog application built with ASP.NET Core MVC that allows you to create, read, update, and delete blog posts. All posts are stored in-memory for demonstration purposes.
## Running with Docker

Build and run using the standard Microsoft .NET images:

```bash
docker build -t blogapp .
docker run -p 8080:8080 blogapp
```

Build and run using the Chainguard images:

If you are running this yourself, first update the registry url on lines 2 and 23 in Dockerfile.cg to match your organization's url.

```bash
docker build -t blogapp:cg -f Dockerfile.cg .
docker run -p 8080:8080 blogapp:cg
```

### Migrating to Chainguard

Switching to Chainguard images is simple and provides enhanced security with minimal, distroless containers.

<pre> ```diff - const greeting = "Hello world"; + const greeting = "Hello, world!"; ``` </pre>
