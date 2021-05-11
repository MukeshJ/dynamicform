import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AppService } from 'src/app/app.service';
import { PropertiesObject } from 'src/app/core/models/properties-object';
import { PropertyObject } from 'src/app/core/models/property-object';
import { PropertyBase } from 'src/app/core/property-base';
import { PropertyControlService } from 'src/app/core/property-control.service';
import { ClonerService } from 'src/app/core/services/clone.service';

@Component({
  selector: 'app-detail-form',
  templateUrl: './detail-form.component.html',
  styleUrls: ['./detail-form.component.scss']
})
export class DetailFormComponent implements OnInit, OnChanges {

  @Input() properties: PropertyBase<string>[] = [];
  form: FormGroup;

  @Input() selectProperty: PropertiesObject;
  payLoad = '';

  constructor(
    private qcs: PropertyControlService,
    private cloneService: ClonerService,
    private appService: AppService) { }

  ngOnInit() {

  }
  ngOnChanges(changes: SimpleChanges) {
    if (changes['properties']) {
      if (this.form) {
        for (var control in this.form.controls) {
          this.form.removeControl(control)
        }
      }
      this.form = this.cloneService.deepClone<FormGroup>(this.qcs.toFormGroup(this.properties));
    }
  }

  onSubmit() {
    this.payLoad = JSON.stringify(this.form.getRawValue());
    this.buildUpdateObject();
  }

  buildUpdateObject() {
    for (let item in this.form.controls) {
      this.selectProperty.properties.map(c => {
        if (c.id.toString() === item) {
          if (typeof (c.value) === "object") {
            c.value['Value'] = this.form.get(item).value;
          }
          else {
            c.value = this.form.get(item).value;
          }
        }
      })
    }
    const unsubscribe$ = this.appService.addProperties(this.selectProperty)
      .subscribe(c => {
        alert("Property Updated");
        this.appService.getProperties()
          .subscribe(c=> {
            this.appService.setParentObject(this.cloneService.deepClone(c));
          });
      });
  }

}
