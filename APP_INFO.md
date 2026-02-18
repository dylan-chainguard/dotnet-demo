# BlogApp - ASP.NET Core Demo

A simple single-page blog application built with ASP.NET Core MVC that allows you to create, read, update, and delete blog posts. All posts are stored in-memory for demonstration purposes.

## Features

- Create new blog posts
- View all blog posts
- Edit existing posts
- Delete posts
- Responsive, clean UI
- In-memory storage (no database required)

## Running with Docker

### Build the Docker image

```bash
docker build -t blogapp .
```

### Run the container

```bash
docker run -p 8080:8080 blogapp
```

The application will be available at `http://localhost:8080`

## Project Structure

- `Program.cs` - Application entry point and configuration
- `Models/BlogPost.cs` - Blog post data model
- `Services/BlogPostService.cs` - In-memory storage service
- `Controllers/BlogController.cs` - Handles HTTP requests
- `Views/Blog/Index.cshtml` - Main UI page
- `wwwroot/css/site.css` - Styling
- `Dockerfile` - Multistage Docker build configuration

## Development

If you have .NET 8.0 SDK installed locally:

```bash
dotnet run
```

Then navigate to `https://localhost:5001` or `http://localhost:5000`
