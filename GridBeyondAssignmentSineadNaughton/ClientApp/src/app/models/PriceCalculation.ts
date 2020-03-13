export class PriceCalculation {

  constructor(priceAverage: number, priceMax: number, priceMin: number, mostExpensiveSixtyMinutesPeriod: string) {
    this.priceAverage = priceAverage;
    this.priceMax = priceMax;
    this.priceMin = priceMin;
    this.mostExpensiveSixtyMinutesPeriod = mostExpensiveSixtyMinutesPeriod;
  }

  priceAverage: number;
  priceMax: number;
  priceMin: number;
  mostExpensiveSixtyMinutesPeriod: string;

}
