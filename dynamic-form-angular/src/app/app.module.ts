import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTabsModule } from '@angular/material/tabs';
import { SummeryViewComponent } from './summery-view/summery-view.component';
import { DetailViewComponent } from './detail-view/detail-view.component';
import { HttpClientModule } from '@angular/common/http';
import { DetailFormComponent } from './detail-view/detail-form/detail-form.component';
import { FormPropertyComponent } from './detail-view/form-property/form-property.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [
    AppComponent,
    SummeryViewComponent,
    DetailViewComponent,
    DetailFormComponent,
    FormPropertyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTabsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatSelectModule,
    MatTableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
