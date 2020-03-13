import { Component, OnInit } from '@angular/core';
import { Time } from '@angular/common';
import { PriceItem } from '../models/PriceItem';
import { PriceItemsService } from '../services/PriceItemsService';
import * as CanvasJS from '../../assets/canvasjs.min';
import { PriceCalculation } from '../models/PriceCalculation';
import { Data } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(private service: PriceItemsService) { }

  priceItems: PriceItem[];
  price: number = 0;
  date: any = new Date();
  time: string = "00:00";

  priceCalculation: PriceCalculation;

  async ngOnInit() {
    //get avg, min, max etc.
    this.priceCalculation = await this.service.getPriceCalculation();

    //get all items
    this.priceItems = await this.service.getAllPriceItems();

    //set graph
    this.renderGraph();
  }

  //Sets teh graph and plots the PriceItems on it
  private renderGraph() {
    //empty array for datapoints
    let dataPoints = [];
    let y = 0;

    //PriceItems stores in teh datapoints array with price as Y, and Timestamp as X
    for (var i = 0; i < this.priceItems.length; i++) {
      dataPoints.push({ y: this.priceItems[i].price, label: this.getFormattedDate(this.priceItems[i].timestamp) });
    }
    let chart = new CanvasJS.Chart("chartContainer", {
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: "Price Chart"
      },
      data: [
        {
          type: "line",
          dataPoints: dataPoints
        }
      ],
      axisY: {
        title: "Price"
      },
      axisX: {
        title: "Timestamp"
      }
    });
    chart.render();
  }

  async addPrice() {
    //check if date has been set by datepicker
    if (this.date.year) {
      //Combine the date, hours, and minutes to make the timestamp
      let hoursAndMinutes: string[] = this.time.split(':');
      let hours: number = parseInt(hoursAndMinutes[0]);
      let minutes: number = parseInt(hoursAndMinutes[1]);
      let timestamp: Date = new Date(this.date.year, this.date.month - 1, this.date.day, hours, minutes);

      //create PriceItem object to pass to API
      let priceItem: PriceItem = new PriceItem(this.price, timestamp);

      //Call service to add price item and load items again
      await this.service.addPriceItem(priceItem);
      this.priceItems = await this.service.getAllPriceItems();

      //render graph again
      this.renderGraph();
    }
  }

  //Format date for graph
  getFormattedDate(date: Date) {
    date = new Date(date);
    return date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " + date.getHours() + ":" + date.getMinutes();
  }
}
