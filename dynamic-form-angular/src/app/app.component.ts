import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';
import { ClonerService } from './core/services/clone.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'dynamic-form';
  /**
   *
   */
  constructor(private appService: AppService,
    private clonerService: ClonerService) {

  }

  ngOnInit() {
    const unSubscribe$ = this.appService.getProperties()
      .subscribe(c => {
        this.appService.setParentObject(this.clonerService.deepClone(c));
      })
  }
}
