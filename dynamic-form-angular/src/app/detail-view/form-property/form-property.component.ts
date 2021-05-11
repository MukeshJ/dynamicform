import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { PropertyBase } from 'src/app/core/property-base';

@Component({
  selector: 'app-form-property',
  templateUrl: './form-property.component.html',
  styleUrls: ['./form-property.component.scss']
})
export class FormPropertyComponent {

  @Input() property: PropertyBase<string>;
  @Input() form: FormGroup;
  get isValid() { return this.form.controls[this.property.id].valid; }

}
