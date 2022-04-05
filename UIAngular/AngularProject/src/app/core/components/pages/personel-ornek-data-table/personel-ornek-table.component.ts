import { Component, AfterViewInit, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonelOrnekDataTable } from './models/personel-ornek-data-table';
import { PersonelOrnekDataTableDto } from './models/personel-ornek-data-table-dto';
import { PersonelOrnekDataTableService } from './services/personel-ornek-data-table.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';


declare var jQuery: any;
@Component({
    selector: 'app-personel-ornek-data-table',
    templateUrl: './personel-ornek-data-table.component.html' 
})

export class PersonelOrnekTableComponent implements AfterViewInit, OnInit {


    dataSource: MatTableDataSource<any>;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    displayedColumns: string[] = ['id', 'sicilnumrasi', 'ad', 'soyad', 'cinsiyet', 'ceptelefonu', 'evtelefonu', 'mailadresi', 'departmankod', 'departmanad', 'isegiristarihi', 'istencikistarihi'];

    personelOrnekTableList: PersonelOrnekDataTableDto[];
    personelOrnekTable: PersonelOrnekDataTableDto = new PersonelOrnekDataTableDto();

    personelOrnekTableAddForm: FormGroup;

    personelOrnekTableId: number;
    constructor(private service: PersonelOrnekDataTableService, private formBuilder: FormBuilder) { }


    ngOnInit(): void {

    }
    ngAfterViewInit(): void {
        throw new Error('Method not implemented.');
    }

    getList() {
        this.service.getList().subscribe(data => {
            this.personelOrnekTableList = data;
        });
    }
    save() {
        if (this.personelOrnekTableAddForm.valid) {
            this.personelOrnekTable = Object.assign({}, this.personelOrnekTableAddForm.value)

            if (this.personelOrnekTable.id == 0)
                this.add();
            else
                this.update();
        } else {
            console.log("InValidForm")
        }
    }
    add() {
        this.service.add(this.personelOrnekTable).subscribe(data => {
            console.log(data)
            this.getList();

        })
    }

    update() {

        this.service.update(this.personelOrnekTable).subscribe(data => {

            var index = this.personelOrnekTableList.findIndex(x => x.id == this.personelOrnekTable.id);
            this.personelOrnekTableList[index] = this.personelOrnekTable;
            console.log(data);
            this.configDataTable();

        })
    }
    createAddForm() {
        this.personelOrnekTableAddForm = this.formBuilder.group({
            id: [0],
            isDeleted: [false],
            kod: ["", Validators.required],
            ad: ["", Validators.required],
            soyad: ["", Validators.required],

        })
    }
    delete(id: number) {
        this.service.delete(id).subscribe(data => {
            this.personelOrnekTableList = this.personelOrnekTableList.filter(x => x.id != id);
            console.log(this.personelOrnekTableList)
            this.configDataTable();
        })
    }
    configDataTable(): void {
        this.sort.active = "id";
        this.sort.direction = "desc";
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }
    applyFilter(event: Event) {
		const filterValue = (event.target as HTMLInputElement).value;
		this.dataSource.filter = filterValue.trim().toLowerCase();

		if (this.dataSource.paginator) {
			this.dataSource.paginator.firstPage();
		}
	}

}
