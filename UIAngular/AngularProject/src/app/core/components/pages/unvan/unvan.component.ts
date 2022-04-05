import { Component, AfterViewInit, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Unvan } from './models/unvan';
import { UnvanService } from './services/unvan.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';



declare var jQuery: any;
@Component({
    selector: 'app-unvan',
    templateUrl: './unvan.component.html',
    styleUrls: ['./unvan.component.scss']
})


export class UnvanComponent implements AfterViewInit, OnInit {

	dataSource: MatTableDataSource<any>;
	@ViewChild(MatPaginator) paginator: MatPaginator;
	@ViewChild(MatSort) sort: MatSort;

	displayedColumns: string[] = [  'id', 'kod', 'ad','update', 'delete'];

    unvanList: Unvan[];
    unvan: Unvan = new Unvan();

    unvanAddForm: FormGroup;

    unvanId: number;

    constructor(private service: UnvanService, private formBuilder: FormBuilder) { }
    ngOnInit(): void {
      
    }
    ngAfterViewInit(): void {
       
    }

    getList() {
        this.service.getList().subscribe(data => {
            this.unvanList= data;
        });
    }
    save() {
        if (this.unvanAddForm.valid) {
            this.unvan = Object.assign({}, this.unvanAddForm.value)

            if (this.unvan.id == 0)
                this.add();
            else
                this.update();
        } else {
            console.log("InValidForm")
        }
    }
    add() {
        this.service.add(this.unvan).subscribe(data => {
            console.log(data)
            this.getList();

        })
    }

    update() {

        this.service.update(this.unvan).subscribe(data => {

            var index = this.unvanList.findIndex(x => x.id == this.unvan.id);
            this.unvanList[index] = this.unvan;
            console.log(data);
            this.configDataTable();


        })
    }
    createAddForm() {
        this.unvanAddForm = this.formBuilder.group({
            id: [0],
            isDeleted: [false],
            kod: ["", Validators.required],
            ad: ["", Validators.required],  
        })
    }
    delete(id: number) {
        this.service.delete(id).subscribe(data => {
            this.unvanList = this.unvanList.filter(x => x.id != id);
            console.log(this.unvanList)
            this.configDataTable();
        })
    }
    configDataTable(): void {
		this.sort.active = "id";
		this.sort.direction = "desc";
		this.dataSource.paginator = this.paginator;
		this.dataSource.sort = this.sort;
	}

}