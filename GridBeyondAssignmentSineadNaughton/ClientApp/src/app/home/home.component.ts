import { Component, OnInit } from '@angular/core';
import { Time } from '@angular/common';
import { PriceItem } from '../models/PriceItem';
import { PriceItemsService } from '../services/PriceItemsService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{

  constructor(private service: PriceItemsService) { }

  priceItems: PriceItem[];
  price: number = 0;
  date: any = new Date();
  time: string = "00:00";

  async ngOnInit() {
    this.priceItems = await this.service.getAllPriceItems();
  }

  async addPrice()
  {
   
    let hoursAndMinutes: string[] = this.time.split(':');
    let hours: number = parseInt(hoursAndMinutes[0]);
    let minutes: number = parseInt(hoursAndMinutes[1]);
    let timestamp: Date = new Date(this.date.year, this.date.month-1, this.date.day, hours, minutes);
    let priceItem: PriceItem = new PriceItem(this.price, timestamp);
    this.service.addPriceItem(priceItem);
    this.priceItems = await this.service.getAllPriceItems();
  }
}
