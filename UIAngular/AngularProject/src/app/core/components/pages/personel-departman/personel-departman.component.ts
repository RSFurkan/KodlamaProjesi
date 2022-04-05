import { Component, AfterViewInit, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonelDepartman } from './models/personel-departman';
import { PersonelDepartmentService } from './services/personel-departman.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PersonelDepartmanDto } from './models/personel-departman-dto';
import { LookUp } from 'src/app/core/models/lookUp';
import { LookUpService } from 'src/app/core/services/lookUp.service';

declare var jQuery: any;
@Component({
    selector: 'app-personel-department',
    templateUrl: './personel-department.component.html' 
})

export class PersonelDepartmentComponent implements AfterViewInit, OnInit {
    dataSource: MatTableDataSource<any>;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    displayedColumns: string[] = ['id', 'personelad', 'personelsoyad', 'departmanad', 'departmankod', 'update', 'delete'];
    personelDepartmentList: PersonelDepartmanDto[];
    personelDepartment: PersonelDepartman = new PersonelDepartman();

    departmentDropdownList: LookUp[];
    personelDropdownList: LookUp[];
    personelDepartmentAddForm: FormGroup;

    personelDepartmentId: number;

    constructor(private lookUpService: LookUpService, private personelDepartmentService: PersonelDepartmentService, private formBuilder: FormBuilder) { }

    ngOnInit(): void {

        this.lookUpService.getdepartmentlookup().subscribe(data => {
            this.departmentDropdownList = data;
        })
        this.lookUpService.getpersonellookup().subscribe(data => {
            this.personelDropdownList = data;
        })
        this.createDepartmentAddForm();

    }
    ngAfterViewInit(): void {
    }

    getPersonelDepartmentList() {
        this.personelDepartmentService.getList().subscribe(data => {
            this.personelDepartmentList = data;
        });
    }
    save() {
        if (this.personelDepartmentAddForm.valid) {
            this.personelDepartment = Object.assign({}, this.personelDepartmentAddForm.value)

            if (this.personelDepartment.id == 0)
                this.addDepartment();
            else
                this.updateDepartment();
        } else {
            console.log("InValidForm")
        }
    }
    addDepartment() {
        this.personelDepartmentService.add(this.personelDepartment).subscribe(data => {
            console.log(data)
            this.getPersonelDepartmentList();

        })
    }

    updateDepartment() {

        this.personelDepartmentService.update(this.personelDepartment).subscribe(data => {

            var index = this.personelDepartmentList.findIndex(x => x.id == this.personelDepartment.id);
            this.personelDepartmentList[index] = this.personelDepartment;
            console.log(data);
            this.configDataTable();


        })
    }
    createDepartmentAddForm() {
        this.personelDepartmentAddForm = this.formBuilder.group({
            id: [0],
            isDeleted: [false],
            personelId: [0, Validators.required],
            departmentId: [0, Validators.required]

        })
    }
    deletePersonelDepartment(id: number) {
        this.personelDepartmentService.delete(id).subscribe(data => {
            this.personelDepartmentList = this.personelDepartmentList.filter(x => x.id != id);
            this.configDataTable();
        })
    }
    applyFilter(event: Event) {
        const filterValue = (event.target as HTMLInputElement).value;
        this.dataSource.filter = filterValue.trim().toLowerCase();

        if (this.dataSource.paginator) {
            this.dataSource.paginator.firstPage();
        }
    }

    configDataTable(): void {
        this.sort.active = "id";
        this.sort.direction = "desc";
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }
    getPersonelDepartmentById(id: number) {

    }
}
