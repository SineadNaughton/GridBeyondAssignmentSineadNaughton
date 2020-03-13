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
export class HomeComponent implements OnInit{

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
    this.renderChart();
  }

    private renderChart() {
        let dataPoints = [];
        let y = 0;
        for (var i = 0; i < this.priceItems.length; i++) {
            //y += Math.round(5 + Math.random() * (-5 - 5));
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

  async addPrice()
  {
    if (this.date.year) {
      let hoursAndMinutes: string[] = this.time.split(':');
      let hours: number = parseInt(hoursAndMinutes[0]);
      let minutes: number = parseInt(hoursAndMinutes[1]);
      let timestamp: Date = new Date(this.date.year, this.date.month - 1, this.date.day, hours, minutes);
      let priceItem: PriceItem = new PriceItem(this.price, timestamp);
      await this.service.addPriceItem(priceItem);
      this.priceItems = await this.service.getAllPriceItems();
      this.renderChart();
    }
  }

  getFormattedDate(date: Date) {
    date = new Date(date);
    return date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " + date.getHours() + ":" + date.getMinutes();
  }
}
