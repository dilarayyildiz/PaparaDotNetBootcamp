# Merchant Web API Project - Week 1 Assignment

## 📌 Description

This .NET Web API provides CRUD operations for managing merchants while adhering to RESTful standards. It ensures structured error handling, proper HTTP status codes, and supports model validation.

---

## 📜 Table of Contents
- Features
- Prerequisites
- API Endpoints
- Technologies Used
- Error Handling
- Example Requests
- Contact

---

## ✅ Features

✔️ **RESTful API Standards** – Follows best practices for resource management  
✔️ **HTTP Methods** – Implements GET, POST, PUT, and DELETE operations  
✔️ **Proper HTTP Status Codes** – Uses 200, 201, 400, 404, 500 with a standardized error response format  
✔️ **Model Validation** – Ensures required fields are validated before processing  
✔️ **Routing** – Well-defined endpoints with meaningful URLs  
✔️ **Model Binding** – Supports data binding from both body and query parameters  
✔️ **Advanced Listing & Sorting** – Allows filtering and sorting merchants by specific criteria  

---

## 📌 Prerequisites

- .NET SDK
- Optional: Postman for testing API endpoints

---

## 🌐 API Endpoints

| HTTP Method | Endpoint | Description |
|------------|---------|-------------|
| **GET** | `/api/MerchantInformation/GetAll` | Get all merchants |
| **GET** | `/api/MerchantInformation/GetbyId/{id}` | Get a specific merchant by ID |
| **POST** | `/api/MerchantInformation/Post` | Create a new merchant |
| **PUT** | `/api/MerchantInformation/{id}` | Update a merchant completely by ID |
| **DELETE** | `/api/MerchantInformation/{id}` | Delete a merchant by ID |

---

## 🛠️ Technologies Used

- **.NET 8**
- **ASP.NET Core Web API**
- **Swagger UI** (for API documentation)

---

## ⚙️ Error Handling

If an unexpected error occurs during any API request, the error handling middleware catches the exception and returns a structured JSON response with an appropriate HTTP status code.

Example error response:
```json
{
  "statusCode": 500,
  "message": "An unexpected error occurred. Please try again later."
}
```

---

## 📄 Example Requests

### Create Merchant
**Endpoint:** `POST /api/MerchantInformation/Post`

**Request Body:**
```json
{
  "Name": "New Merchant",
  "Address": "123 Main Street",
  "Email": "merchant@example.com",
  "Phone": "1234567890",
  "OpenDate": "2024-03-16T00:00:00Z"
}
```

**Respons:**
```json
{
  "Id": 4,
  "Name": "New Merchant",
  "Address": "123 Main Street",
  "Email": "merchant@example.com",
  "Phone": "1234567890",
  "OpenDate": "2024-03-16T00:00:00Z"
}
```
---

