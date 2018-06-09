import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from './patient';

@Injectable()
export class DataService {

    private url = "/api/patients";

    constructor(private http: HttpClient) {
    }

    getPatients() {
        return this.http.get(this.url);
    }

    createPatient(patient: Patient) {
        return this.http.post(this.url, patient);
    }
    updatePatient(patient: Patient) {

        return this.http.put(this.url + '/' + patient.PatientId, patient);
    }
    deletePatient(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}