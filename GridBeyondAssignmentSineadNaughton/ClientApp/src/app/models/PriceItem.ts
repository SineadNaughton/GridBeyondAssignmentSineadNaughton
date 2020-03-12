export class PriceItem {

  constructor(price: number, timestamp: Date) {
    this.price = price;
    this.timestamp = timestamp;
  }

  price: number;
  timestamp: Date;
  id: number;

}
