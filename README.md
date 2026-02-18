# Dotnet Demo

A simple single-page blog application built with ASP.NET Core MVC that allows you to create, read, update, and delete blog posts. All posts are stored in-memory for demonstration purposes.
## Running with Docker

Build and run using the standard Microsoft .NET images:

```bash
docker build -t blogapp .
docker run -p 8080:8080 blogapp
```

Build and run using the Chainguard images:

If you are running this yourself, first update the registry url on lines [2](./Dockerfile.cg#L2) and [23](./Dockerfile.cg#L23) in Dockerfile.cg to match your organization's url.

```bash
docker build -t blogapp:cg -f Dockerfile.cg .
docker run -p 8080:8080 blogapp:cg
```

## Migrating to Chainguard

Switching to Chainguard images is simple and provides enhanced security with minimal, distroless containers.

For reference, see this guide for details on [migrating to chainguard containers](https://edu.chainguard.dev/downloads/migrating-to-chainguard-images.pdf).

This dotnet example covers a few of the key differences:

### Base Image

Simply swap the base image to the Chainguard alternative in the `FROM` statement.

[Example in Dockerfile](./Dockerfile.cg#L2):

```diff
- FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
+ FROM cgr.dev/your-registry.com/dotnet-sdk:8-dev AS build
```

It is recommended to start with the `-dev` variants which include a shell and package manager. When you are ready to go full distroless, you can use a multi-stage build with the non-dev variant.

### Root User

Chainguard images default to a nonroot user, so it is often necessary to explicitly set the user to root if it's needed.

[Example in Dockerfile](./Dockerfile.cg#L6):

```diff
+ USER root
```

After performing the necessary actions as root, switch back to a nonroot user so that the image does not run as root by default.

[Example in Dockerfile](./Dockerfile.cg#L20):
```diff
+ USER nonroot
```

### Package Manager

Chainguard images use `apk` as a package manager instead of `apt`, `yum`, `dnf` or others you may be using today. If your Dockerfile uses these then you will need to convert them to use `apk` instead.

[Example adding `curl`](./Dockerfile.cg#L6):

```diff
- RUN apt-get update && apt-get install -y curl
+ RUN apk add curl
```
