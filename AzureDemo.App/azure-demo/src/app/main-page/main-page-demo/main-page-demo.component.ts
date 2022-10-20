import { Component } from '@angular/core';
import { DemoServiceService } from '../demo-service.service';

@Component({
  selector: 'app-main-page-demo',
  templateUrl: './main-page-demo.component.html',
  styleUrls: ['./main-page-demo.component.scss']
})
export class MainPageDemoComponent{
  public item: any;
  public itemId: any;
  public items: any;
  constructor(private demoServiceService: DemoServiceService) { }

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
    this.demoServiceService.getAllItems()
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
