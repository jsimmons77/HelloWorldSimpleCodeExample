import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-hello-world',
  templateUrl: './hello-world.component.html',
  styleUrls: ['./hello-world.component.css']
})
export class HelloWorldComponent {
  public hello: HelloWorld;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<HelloWorld>(baseUrl + 'api/helloworld').subscribe(result => {
      this.hello = result;
    }, error => console.error(error));
  }
}

interface HelloWorld {
  message: string;
  subMessage: string;
}
