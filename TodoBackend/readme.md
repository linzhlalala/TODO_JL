# Todo API Documentation
**Base URL:** `http://localhost:5000/api/todos`
### 1. Get All Todos
GET http://localhost:5000/api/todos

### 2. Get Task By ID
GET http://localhost:5000/api/todos/{id}

### 3. Add a Task
POST http://localhost:5000/api/todos
data = 
{
  "Id": 3,
  "Title": "Write API docs",
  "IsCompleted": false
}

### 4. Updata a Task
PUT http://localhost:5000/api/todos/{id}
data = 
{
  "Id": 3,
  "Title": "Write API docs",
  "IsCompleted": false
}

### 5. Delete a Task
DELETE http://localhost:5000/api/todos/{id}




