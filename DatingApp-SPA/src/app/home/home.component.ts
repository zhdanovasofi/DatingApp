import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  registerMode = false;
  infoMode = false;
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }


  registerToggle() {
    this.registerMode = true;
    console.log('registerMode' + this.registerMode);
  }
  infoToggle(){
    this.infoMode = !this.infoMode;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }
}
