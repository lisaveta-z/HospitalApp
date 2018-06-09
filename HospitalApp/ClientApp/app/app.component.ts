//import { Component } from '@angular/core';

//@Component({
//    selector: 'app',
//    template: `<label>Введите имя:</label>
//                 <input [(ngModel)]="name" placeholder="name">
//                 <h2>Добро пожаловать {{name}}!</h2>`
//})
//export class AppComponent {
//    name = '';
//}

import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Patient } from './patient';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    patient: Patient = new Patient();   // изменяемый пациент
    patients: Patient[];                // массив пациентов
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadPatients();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadPatients() {
        this.dataService.getPatients()
            .subscribe((data: Patient[]) => this.patients = data);
    }
    // сохранение данных
    save() {
        if (this.patient.PatientId == null) {
            this.dataService.createPatient(this.patient)
                .subscribe((data: Patient) => this.patients.push(data));
        } else {
            this.dataService.updatePatient(this.patient)
                .subscribe(data => this.loadPatients());
        }
        this.cancel();
    }
    editPatient(p: Patient) {
        this.patient = p;
    }
    cancel() {
        this.patient = new Patient();
        this.tableMode = true;
    }
    delete(p: Patient) {
        this.dataService.deletePatient(p.PatientId)
            .subscribe(data => this.loadPatients());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}