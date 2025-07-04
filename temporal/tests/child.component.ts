




import { Component, EventEmitter, Output, output} from '@angular/core';

@Component({
  selector: 'app-child',
  standalone: true,
  imports: [],
  templateUrl: './child.component.html',
  styleUrl: './child.component.css',
})
export class ChildComponent {

  // Vamos a crear un evento, el cual se hace con un decorador @Output.
   @Output()
   login: EventEmitter<any> = new EventEmitter<any>();

  //login = output<any>();

  userName: string = "GERARDO TORDOYA";

  handleLogin() {
    this.login.emit(this.userName);
  }
}
