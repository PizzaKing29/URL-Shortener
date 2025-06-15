# URL Shortener API

This is a simple URL shortener API built with ASP.NET Core. It allows you to submit a long URL and get a short code, which redirects to the original URL.

---

## Features

- Generate a unique short code for any valid URL starting with `http://` or `https://`.
- Redirect users from the short URL to the original URL.
- Thread-safe URL storage using an in-memory concurrent dictionary.

---

## How to Run

1. Clone or download the project.
2. Open the project in Visual Studio or your preferred IDE.
3. Run the project. By default, it will listen on `http://localhost:5000`.

---

## API Endpoints

### POST `/`

Create a shortened URL.

- **Request Body**: JSON object with the `OriginalUrl` property.

Example:

```json
{
  "OriginalUrl": "https://google.com"
}

## Testing with curl

Create a short URL:

```bash
curl -X POST http://localhost:5000/ \
-H "Content-Type: application/json" \
-d "{\"OriginalUrl\":\"https://google.com\"}"
```

This will output something like:

```bash
http://localhost:5000/abc123
```

Then, open your browser and this will redirect you to https://google.com.