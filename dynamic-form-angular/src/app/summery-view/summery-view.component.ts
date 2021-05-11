import { Component, Input, OnInit } from '@angular/core';
import { AppService } from '../app.service';
import { MatTableDataSource } from '@angular/material/table';
import { PropertiesObject } from '../core/models/properties-object';
import { ParentObject } from '../core/models/parent-object';

@Component({
  selector: 'app-summery-view',
  templateUrl: './summery-view.component.html',
  styleUrls: ['./summery-view.component.scss']
})
export class SummeryViewComponent implements OnInit {
  dataSource: MatTableDataSource<PropertiesObject>;
  columnsToDisplay: string[] = []

  constructor(private appService: AppService) { }

  ngOnInit(): void {
    this.getProperties();
  }

  getProperties() {
    const unsub$ = this.appService.parentObject$.subscribe(parentObject => {
      if (parentObject) {
        let dataSourceArray = [];
        let columns = [];
        parentObject.datas.forEach(data => {
          let obj = {};
          obj['samplingTime'] = data.samplingTime;
          columns.push('samplingTime');
          data.properties.forEach(property => {
            columns.push(property.label);
            if (typeof (property.value) == "object") {
              obj[property.label] = property.value.Value
            } else {
              obj[property.label] = property.value;
            }
          });
          dataSourceArray.push(obj);
        });
        this.columnsToDisplay = [...new Set(columns)];
        this.dataSource = new MatTableDataSource(dataSourceArray);
      }
    });
  }
}
