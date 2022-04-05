import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BrowserModule } from '@angular/platform-browser';
import { Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DepartmentComponent } from './core/components/pages/departman/departman.component';
import { PersonelDepartmentComponent } from './core/components/pages/personel-departman/personel-departman.component';
import { PersonelOrnekTableComponent } from './core/components/pages/personel-ornek-data-table/personel-ornek-table.component';
import { PersonelUnvanComponent } from './core/components/pages/personel-unvan/personel-unvan.component';
import { PersonelComponent } from './core/components/pages/personel/personel.component';
import { UnvanComponent } from './core/components/pages/unvan/unvan.component';

export interface DropdownLink {
  title: string;
  iconClass?: string;
  routerLink?: string;
}
export enum NavItemType {
  Sidebar = 1,  
  NavbarLeft = 2, 
  NavbarRight = 3  
}
export interface NavItem {
  type: NavItemType;
  title: string;
  routerLink?: string;
  iconClass?: string;
  numNotifications?: number;
  dropdownItems?: (DropdownLink | 'separator')[];
}

const UserLayoutRoutes: Routes = [
  { path: '', component: PersonelOrnekTableComponent  },
  { path: 'department', component: DepartmentComponent},
  { path: 'personel', component: PersonelComponent },
  { path: 'personel-department', component: PersonelDepartmentComponent },
  { path: 'ornek-data', component: PersonelOrnekTableComponent},
  { path: 'personel-unvan', component: PersonelUnvanComponent},
  { path: 'unvan', component: UnvanComponent },

];
 
 
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DepartmentComponent,
    PersonelComponent,
    PersonelDepartmentComponent,
    PersonelUnvanComponent,
    UnvanComponent,
    PersonelOrnekTableComponent 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
