import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { PropertyBase } from './property-base';

@Injectable({
  providedIn: 'root'
})
export class PropertyControlService {
  constructor() { }

  toFormGroup(properties: PropertyBase<string>[]) {

    const group: any = {};

    properties.forEach(propery => {
      if (propery.controlType === "dropdown") {
        group[propery.id] = propery.required ? new FormControl(propery.value || '', Validators.required)
          : new FormControl(propery.value || '');

        // group[propery.id] = propery.required ? new FormControl(propery.unitvalue || false, Validators.required)
        //   : new FormControl(propery.unitvalue  || '');
      }
      if (propery.controlType === "checkbox") {
        group[propery.id] = propery.required ? new FormControl(propery.value === 'true' ? true : false || false, Validators.required)
          : new FormControl(propery.value === 'true' ? true : false || false);
      } else {
        group[propery.id] = propery.required ? new FormControl(propery.value || '', Validators.required)
          : new FormControl(propery.value || '');
      }
    });
    return new FormGroup(group);
  }
}

