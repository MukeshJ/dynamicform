import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { ParentObject } from './core/models/parent-object';
import { environment } from 'src/environments/environment';
import { PropertiesObject } from './core/models/properties-object';

@Injectable({ providedIn: 'root' })
export class AppService {

  private _parentobj = new BehaviorSubject<ParentObject>(null);

  public get parentObject$(): Observable<ParentObject> {
    return this._parentobj.asObservable();
  }

  public setParentObject(objParent: ParentObject) {
    this._parentobj.next(objParent);
  }

  constructor(private httpClient: HttpClient) {
  }

  getProperties(): Observable<ParentObject> {
    return this.httpClient.get<ParentObject>(environment.apiUrl + 'DynamicalForm')
  }
  addProperties(objProperty: any): Observable<PropertiesObject> {
    return this.httpClient.post<PropertiesObject>(environment.apiUrl + 'DynamicalForm', objProperty)
  }

}
