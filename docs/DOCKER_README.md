# Docker Setup for MenuDemo

This guide shows you how to run your MenuDemo application using Docker in the simplest way possible.

## What you get
- Your ASP.NET Core app running in a container
- PostgreSQL database running in a container  
- Both containers talking to each other
- Data persistence (your database won't disappear when you stop containers)

## Prerequisites
- Docker Desktop installed on your Mac

## Quick Start

### 1. Start everything
```bash
docker-compose up --build
```

### 2. Access your app
- Open your browser to: http://localhost:5001
- Your app is now running!

### 3. Stop everything
Press `Ctrl+C` in the terminal, then run:
```bash
docker-compose down
```

## Useful Commands

### Start in background (detached mode)
```bash
docker-compose up -d --build
```

### View logs
```bash
docker-compose logs web      # App logs
docker-compose logs postgres # Database logs
```

### Stop and remove everything (including database data)
```bash
docker-compose down -v
```

### Rebuild just the app (after code changes)
```bash
docker-compose build web
docker-compose up -d
```

## Database Connection
- The app connects to PostgreSQL automatically
- Database: `MenuDemo`
- Username: `postgres`
- Password: 
- Port: `5432` (accessible from host machine too)

## Troubleshooting

### App won't start?
1. Make sure Docker Desktop is running
2. Check if ports 5001 or 5432 are already in use
3. Try: `docker-compose down` then `docker-compose up --build`

### Database connection issues?
- Wait a few seconds - PostgreSQL takes time to start up
- The app waits for the database to be healthy before starting

That's it! You now have a fully containerized development environment. 🐳
