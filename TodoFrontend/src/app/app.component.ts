import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Todo, TodoService } from './todo.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; 


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Todos';

  todos: Todo[] = [];
  newTodo: string = '';

  constructor(private todoService: TodoService) {}

  ngOnInit() {
    this.todoService.getTodos().subscribe(
      (data) => {
        this.todos = data;
      },
      (error) => {
        console.error('Error fetching todos:', error);
      }
    );
  }

  addTodo(): void {
    if (this.newTodo.trim()) {
      const todo: Todo = {
        id: 0,
        title: this.newTodo,
        isCompleted: false
      };
      // Add the new todo to the list
      this.todoService.addTodo(todo).subscribe(newTodo => {
        this.todos.push(newTodo); 
        this.newTodo = '';
      });
    }    
  }

  deleteTodo(id: number): void {
    this.todoService.deleteTodo(id).subscribe(() => {
      this.todos = this.todos.filter(todo => todo.id !== id);
    });
  }

  toggleComplete(todo: Todo): void {
    // todo.isCompleted = !todo.isCompleted; // change it by binding already
    this.todoService.updateTodo(todo.id, todo).subscribe();
  }
}
