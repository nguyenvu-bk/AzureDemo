import { Component, OnInit } from '@angular/core';
import { DemoServiceService } from '../demo-service.service';

@Component({
  selector: 'app-main-page-demo',
  templateUrl: './main-page-demo.component.html',
  styleUrls: ['./main-page-demo.component.scss']
})
export class MainPageDemoComponent implements OnInit {
  public item: any;
  public itemId: any;
  public items: any;
  private readonly QUERY = 'SELECT * from c';
  constructor(private demoServiceService: DemoServiceService) { }

  ngOnInit(): void {
    console.log("aaaaaaaa");
  }

  getById() {
    this.demoServiceService.getItem(this.itemId)
    .pipe()
    .subscribe({
      next: (result: any) => {
        this.item = result;
      }
    });
  }

  getAllItems() {
    this.demoServiceService.getAllItems(this.QUERY)
    .pipe()
    .subscribe({
      next: (result: any) => {
        this.items = result;
      }
    });
  }

  clear() {
    this.item = null;
    this.items = null;
    this.itemId = null;
  }
}
