import { PropertyBase } from './property-base';

export class DropdownProperty extends PropertyBase<string>{
  controlType = 'dropdown';
  type = "select"
  unitType = "numbertextbox";
}
