import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AppService } from '../app.service';
import { CheckboxProperty } from '../core/checkbox-property';
import { DropdownProperty } from '../core/dropdown-property';
import { EntityPropertyDataType } from '../core/models/entity-property-data-type';
import { ParentObject } from '../core/models/parent-object';
import { PropertiesObject } from '../core/models/properties-object';
import { PropertyObject } from '../core/models/property-object';
import { Unit } from '../core/models/unit';
import { NumberTextBoxProperty } from '../core/number-property';
import { PropertyBase } from '../core/property-base';
import { ClonerService } from '../core/services/clone.service';
import { TextboxProperty } from '../core/textbox-property';

@Component({
  selector: 'app-detail-view',
  templateUrl: './detail-view.component.html',
  styleUrls: ['./detail-view.component.scss']
})
export class DetailViewComponent implements OnInit {
  parentObject: ParentObject;
  selectProperty: PropertiesObject;
  properties: PropertyBase<string>[] = [];
  constructor(private appService: AppService,
    private cloneService: ClonerService) { }

  ngOnInit(): void {
    const unsub$ = this.appService.parentObject$.subscribe(c => {
      if (c) {
        this.parentObject = c;
        this.selectProperty = this.parentObject.datas[0];
        this.buldPropertyBaseArray();
      }
    });
  }

  onSelectItem(property: PropertiesObject) {
    this.selectProperty = this.cloneService.deepClone(property);
    this.buldPropertyBaseArray();
  }

  // Build Properties Object
  buldPropertyBaseArray() {
    const demoPropertiesBase: PropertyBase<string>[] = [];
    this.selectProperty.properties.forEach(property => {
      if (property.propertyType === EntityPropertyDataType.booleanProperty) {
        demoPropertiesBase.push(new CheckboxProperty({
          id: property.id,
          label: property.label,
          order: property.id,
          value: property.value,
          checked: property.value ? true : false
        }),
        )
      }
      else if (property.propertyType == EntityPropertyDataType.stringProperty) {
        demoPropertiesBase.push(new TextboxProperty({
          id: property.id,
          label: property.label,
          order: property.id,
          value: property.value
        }),
        )
      }
      else if (property.propertyType == EntityPropertyDataType.numericProperty) {
        demoPropertiesBase.push(new NumberTextBoxProperty({
          id: property.id,
          label: property.label,
          order: property.id,
          value: property.value
        }),
        )
      }
      else if (property.propertyType == EntityPropertyDataType.quantityProperty) {

        const options = [];
        const latestProperty = this.cloneService.deepClone(property);
        let id;
        let value = '';
        let unitValue = '';

        for (const propData in latestProperty["value"]) {
          if (propData === "Value") {
            unitValue = latestProperty["value"][propData];
          }
          if (propData === "Unit") {
            let valueData = this.cloneService.deepClone<Unit>(latestProperty["value"][propData]);
            for (const innerProperty in valueData) {
              if (innerProperty === "Id") {
                id = valueData[innerProperty]
              }
              else if (innerProperty === "Symbol") {
                value = valueData[innerProperty]
              }
            }
          }
        }
        demoPropertiesBase.push(new DropdownProperty({
          id: property.id,
          label: property.label,
          order: property.id,
          value: unitValue,
          unitvalue: value,
          unitId: property.id + 'unit',
          options: [{
            key: id.toString(),
            value: value
          }]
        }),
        )
      }
      if (property.propertyType == EntityPropertyDataType.geometryProperty) {
        demoPropertiesBase.push(new NumberTextBoxProperty({
          id: property.id,
          label: property.label,
          order: property.id,
          value: property.value
        }),
        )
      }
    });

    this.properties = this.cloneService.deepClone<PropertyBase<string>[]>(demoPropertiesBase);
  }


}
