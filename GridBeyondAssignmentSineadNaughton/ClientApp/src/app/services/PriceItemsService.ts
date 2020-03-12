import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PriceItem } from '../models/PriceItem';
import { Observable } from 'rxjs';

@Injectable()
export class PriceItemsService {

  constructor(private http: HttpClient) { }

  async getAllPriceItems() {
    let priceItems: PriceItem[] = await this.http.get<PriceItem[]>("/api/priceitems").toPromise();
    return priceItems;
  }

  async addPriceItem(priceItem: PriceItem) {
    await this.http.post("/api/priceitems", priceItem).toPromise();
  }
}
