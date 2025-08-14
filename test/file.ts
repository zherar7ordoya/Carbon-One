










// ------------------- Componente Angular (TypeScript) -------------------
/* archivo: ejemplo.component.ts */
import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';

@Component({
    selector: 'app-ejemplo',
    template: `
    <div class="container">
      <h1>{{ titulo }}</h1>
      <ul>
        <li *ngFor="let item of items$ | async">{{ item.nombre }}</li>
      </ul>
      <button (click)="agregarItem()">Agregar item</button>
    </div>
  `,
    styles: [`
    .container {
      padding: 1rem;
      background-color: #f3f3f3;
      h1 { color: #222; }
      button { background-color: #007ACC; color: white; border: none; }
    }
  `]
})
export class EjemploComponent implements OnInit {
    titulo: string = 'Componente de prueba';
    items$: Observable<{ nombre: string }[]> = of([{ nombre: 'Item 1' }, { nombre: 'Item 2' }]);

    constructor() { }

    async ngOnInit(): Promise<void> {
        await this.cargarDatos();
    }

    async cargarDatos(): Promise<void> {
        const nuevosItems = await this.simularAsync();
        this.items$ = of(nuevosItems);
    }

    private async simularAsync(): Promise<{ nombre: string }[]> {
        return new Promise(resolve => setTimeout(() => resolve([{ nombre: 'Item 3' }]), 200));
    }

    agregarItem(): void {
        this.items$.subscribe(items => {
            this.items$ = of([...items, { nombre: `Item ${items.length + 1}` }]);
        });
    }
}