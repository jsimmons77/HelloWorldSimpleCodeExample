import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-quote-of-the-day',
  templateUrl: './quote-of-the-day.component.html',
  styleUrls: ['./quote-of-the-day.component.css']
})
export class QuoteOfTheDayComponent {
  public quoteOfTheDay: QuoteOfTheDay;
  public quoteOfTheDayList: QuoteOfTheDay[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<QuoteOfTheDay>(baseUrl + 'api/quoteoftheday').subscribe(result => {
      this.quoteOfTheDay = result;
    }, error => console.error(error));

    http.get<QuoteOfTheDay[]>(baseUrl + 'api/quoteofthedaylist').subscribe(result => {
      this.quoteOfTheDayList = result;
    }, error => console.error(error));
  }
}

interface QuoteOfTheDay {
  quoteText: string,
  author: string,
  dayOfTheWeek: string
}
