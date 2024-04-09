<h1>Online Bookstore API</h1>

<p>RESTful API for managing books in an online bookstore.</p>

<h2>Features</h2>

* Create, edit, and delete books.
* List all books and query by ID.

<h2>Requirements</h2>

* .NET 8

<h2>Endpoints</h2>

| Route | Method | Description |
|---|---|---|
| `/api/books` | POST | Create new book |
| `/api/books` | GET | Get all books |
| `/api/books/{id}` | GET | Get book by ID |
| `/api/books/{id}` | PUT | Edit book by ID |
| `/api/books/{id}` | DELETE | Delete book by ID |

<h2>Status Codes</h2>

* 201: Created
* 200: OK
* 404: Not found
* 400: Validation error
* 500: Internal error
<h2>Usage Example</h2>

```html
curl -X POST \
  -H "Content-Type: application/json" \
  -d '{
    "title": "My Book",
    "author": "Book Author",
    "genre": "Fiction",
    "price": 10.99,
    "quantity": 10
  }' \
  http://localhost:5000/api/books

curl -X GET \
  http://localhost:5000/api/books
