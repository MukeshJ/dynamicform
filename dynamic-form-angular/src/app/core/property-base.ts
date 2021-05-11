import { EntityPropertyDataType } from './models/entity-property-data-type';

export class PropertyBase<T>{
  value: T;
  id: number;
  label: string;
  required: boolean;
  order: number;
  controlType: string;
  checked?: boolean;
  type: string;
  unitvalue?: string;
  unitId?: string;
  unitType?: string;
  options: { key: string, value: string }[];
  constructor(options: {
    value?: T;
    id?: number;
    label?: string;
    required?: boolean;
    order?: number;
    controlType?: string;
    checked?: boolean;
    type?: string;
    unitvalue?: string;
    unitType?: string;
    unitId?: string;
    options?: { key: string, value: string }[];
  } = {}) {
    this.value = options.value;
    this.id = options.id || 0;
    this.label = options.label || '';
    this.required = !!options.required;
    this.order = options.order === undefined ? 1 : options.order;
    this.controlType = options.controlType || '';
    this.type = options.type || '';
    this.options = options.options || [];
    this.checked = options.checked || false;
    this.unitvalue = options.unitvalue || '';
    this.unitId = options.unitId || '';
    this.unitType = options.unitType || '';
  }
}
