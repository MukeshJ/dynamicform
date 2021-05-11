import { EntityPropertyDataType } from './entity-property-data-type';

export interface PropertyObject{
  id: number;
  label: string;
  propertyType: EntityPropertyDataType;
  value: any
}
