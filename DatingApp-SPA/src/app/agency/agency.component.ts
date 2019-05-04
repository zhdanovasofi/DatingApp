import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-agency',
  templateUrl: './agency.component.html',
  styleUrls: ['./agency.component.css']
})
export class AgencyComponent implements OnInit {

  prices: boolean;
  constructor() {
    this.prices  = false;
   }

  ngOnInit() {
  }

  pricesToggle(){
    this.prices = !this.prices;
  }

}
