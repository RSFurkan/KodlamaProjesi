import { Component, AfterViewInit, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonelUnvan } from './models/personel-unvan';
import { PersonelUnvanDto } from './models/personel-unvan-dto';
import { PersonelUnvanService } from './services/personel-unvan.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

declare var jQuery: any;
@Component({
    selector: 'app-personel-unvan',
    templateUrl: './personel-unvan.component.html',
    styleUrls: ['./personel-unvan.component.scss']
})


export class PersonelUnvanComponent implements AfterViewInit, OnInit {

	dataSource: MatTableDataSource<any>;
	@ViewChild(MatPaginator) paginator: MatPaginator;
	@ViewChild(MatSort) sort: MatSort;

	displayedColumns: string[] = [  'id', 'personel', 'unvan','update', 'delete'];

    personelUnvanList: PersonelUnvanDto[];
    personelUnvan: PersonelUnvan = new PersonelUnvan();

    personelUnvanAddForm: FormGroup;

    personelUnvanId: number;
    constructor(private service: PersonelUnvanService, private formBuilder: FormBuilder) { }

    ngOnInit(): void {
      this.getList();
    }
    ngAfterViewInit(): void {
        throw new Error('Method not implemented.');
    }
    getList() {
        this.service.getList().subscribe(data => {
            this.personelUnvanList= data;
        });
    }
    save() {
        if (this.personelUnvanAddForm.valid) {
            this.personelUnvan = Object.assign({}, this.personelUnvanAddForm.value)

            if (this.personelUnvan.id == 0)
                this.add();
            else
                this.update();
        } else {
            console.log("InValidForm")
        }
    }
    add() {
        this.service.add(this.personelUnvan).subscribe(data => {
            console.log(data)
            this.getList();

        })
    }

    update() {

        this.service.update(this.personelUnvan).subscribe(data => {

            var index = this.personelUnvanList.findIndex(x => x.personelId == this.personelUnvan.personelId);
            this.personelUnvanList[index] = this.personelUnvan;
            console.log(data);
            this.configDataTable();


        })
    }
    createAddForm() {
        this.personelUnvanAddForm = this.formBuilder.group({
            id: [0],
            isDeleted: [false],
            personelId: [0, Validators.required],
            unvanId: [0, Validators.required],  
        })
    }
    delete(id: number) {
        this.service.delete(id).subscribe(data => {
            this.personelUnvanList = this.personelUnvanList.filter(x => x.personelId != id);
            console.log(this.personelUnvanList)
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