import { Component, AfterViewInit, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Personel } from './models/personel';
import { PersonelService } from './services/personel.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
declare var jQuery: any;
@Component({
    selector: 'app-personel',
    templateUrl: './personel.component.html',
    styleUrls: ['./personel.component.scss']
})

export class PersonelComponent implements AfterViewInit, OnInit {

    dataSource: MatTableDataSource<any>;
	@ViewChild(MatPaginator) paginator: MatPaginator;
	@ViewChild(MatSort) sort: MatSort;

    displayedColumns: string[] = [  'id', 'sicilNumarasi', 'ad',  'soyad', 'sicilnumarasi', 'ceptelefonu',   'evtelefonu',  'mail',  'update', 'delete'];

    personelList: Personel[];
    personel: Personel = new Personel();

    personelAddForm: FormGroup;

    personelId: number;

    constructor(private personelService: PersonelService, private formBuilder: FormBuilder) { }

    ngOnInit(): void {
        this.getPersonelList(); 
    }


    ngAfterViewInit(): void {
        throw new Error("Method not implemented.");
    }


    getPersonelList() {
        this.personelService.getList().subscribe(data => {
            this.personelList = data;
        });
    }
    save() {
        if (this.personelAddForm.valid) {
            this.personel = Object.assign({}, this.personelAddForm.value)

            if (this.personel.id == 0)
                this.addPersonel();
            else
                this.updatePersonel();
        } else {
            console.log("InValidForm")
        }
    }
    addPersonel() {
        this.personelService.add(this.personel).subscribe(data => {
            console.log(data)
            this.getPersonelList(); 

        })
    }

    updatePersonel() {

        this.personelService.update(this.personel).subscribe(data => {

            var index = this.personelList.findIndex(x => x.id == this.personel.id);
            this.personelList[index] = this.personel; 
            this.configDataTable();

 

        })
    }
    createPersonelAddForm() {
        this.personelAddForm = this.formBuilder.group({
            id: [0],
            isDeleted: [false],
            sicilNumarasi: ["", Validators.required],
            ad: ["", Validators.required],
            soyad: ["", Validators.required],
            cinsiyet: ["", Validators.required],
            cepTelefonu: ["", [Validators.required]],
            evTelefonu: [""],
            mailAdresi: ["", [Validators.required]]
        })
    }
    deletePersonel(personelId: number) {
            this.personelService.delete(personelId).subscribe(data => { 
            this.personelList = this.personelList.filter(x => x.id != personelId);
            console.log(this.personelList)
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