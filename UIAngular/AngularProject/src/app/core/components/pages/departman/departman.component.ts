import { Component, AfterViewInit, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Departman } from './models/departman';
import { DepartmnetService } from './services/department.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';



declare var jQuery: any;
@Component({
    selector: 'app-department',
    templateUrl: './departman.component.html' 
})

export class DepartmentComponent implements AfterViewInit, OnInit {


	dataSource: MatTableDataSource<any>;
	@ViewChild(MatPaginator) paginator: MatPaginator;
	@ViewChild(MatSort) sort: MatSort;

	displayedColumns: string[] = [  'id', 'kod', 'ad','update', 'delete'];

    departmentList: Departman[];
    department: Departman = new Departman();

    departmentAddForm: FormGroup;

    departmentId: number;

    constructor(private departmentService: DepartmnetService, private formBuilder: FormBuilder) { }


    ngOnInit(): void {
        this.getDepartmentList();
    }
    ngAfterViewInit(): void {
        throw new Error('Method not implemented.');
    }
    getDepartmentList() {
        this.departmentService.getDepartmentList().subscribe(data => {
            this.departmentList = data;
        });
    }
    save() {
        if (this.departmentAddForm.valid) {
            this.department = Object.assign({}, this.departmentAddForm.value)

            if (this.department.id == 0)
                this.addDepartment();
            else
                this.updateDepartment();
        } else {
            console.log("InValidForm")
        }
    }
    addDepartment() {
        this.departmentService.addDepartment(this.department).subscribe(data => {
            console.log(data)
            this.getDepartmentList();

        })
    }

    updateDepartment() {

        this.departmentService.updateDepartment(this.department).subscribe(data => {

            var index = this.departmentList.findIndex(x => x.id == this.department.id);
            this.departmentList[index] = this.department;
            console.log(data);
            this.configDataTable();


        })
    }
    createDepartmentAddForm() {
        this.departmentAddForm = this.formBuilder.group({
            id: [0],
            isDeleted: [false],
            kod: ["", Validators.required],
            ad: ["", Validators.required],
            soyad: ["", Validators.required],

        })
    }
    deleteDepartment(id: number) {
        this.departmentService.deleteDepartment(id).subscribe(data => {
            this.departmentList = this.departmentList.filter(x => x.id != id);
            console.log(this.departmentList)
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
    getdepartmanById(id:number)
    {

    }





}