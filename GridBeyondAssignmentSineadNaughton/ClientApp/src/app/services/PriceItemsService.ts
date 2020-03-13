import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PriceItem } from '../models/PriceItem';
import { Observable } from 'rxjs';
import { PriceCalculation } from '../models/PriceCalculation';

@Injectable()
export class PriceItemsService {

  //Method below make http requests to the api 
  constructor(private http: HttpClient) { }

  async getAllPriceItems() {
    let priceItems: PriceItem[] = await this.http.get<PriceItem[]>("/api/priceitems").toPromise();
    return priceItems;
  }

  async addPriceItem(priceItem: PriceItem) {
    await this.http.post("/api/priceitems", priceItem).toPromise();
  }

  async getPriceCalculation() {
    let priceCalculations: PriceCalculation = await this.http.get<PriceCalculation>("/api/priceitems/calculations").toPromise();
    return priceCalculations;
  }
}
