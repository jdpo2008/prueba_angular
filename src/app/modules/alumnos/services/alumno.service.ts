import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AlumnoModel } from '../models/AlumnoModel';
import { NotasAlumnoModel } from '../models/NotasAlumnoModel';
import { CursoModel } from '../models/CursoModel';

@Injectable()
export class AlumnoService {
  constructor(private _hhtp: HttpClient) {}

  getAlumnos(): Observable<AlumnoModel[]> {
    return this._hhtp.get<AlumnoModel[]>(`${environment.apiUrl}/alumno`);
  }

  getAlumnoById(id: string): Observable<AlumnoModel[]> {
    return this._hhtp.get<AlumnoModel[]>(`${environment.apiUrl}/alumno/${id}`);
  }

  postAlumno(body: AlumnoModel): Observable<AlumnoModel> {
    return this._hhtp.post<AlumnoModel>(`${environment.apiUrl}/alumno`, body);
  }

  putAlumno(body: AlumnoModel, id: string): Observable<boolean> {
    return this._hhtp.put<boolean>(`${environment.apiUrl}/alumno/${id}`, body);
  }

  deleteAlumno(id: string): Observable<boolean> {
    return this._hhtp.delete<boolean>(`${environment.apiUrl}/alumno/${id}`);
  }

  getCursos(): Observable<CursoModel[]> {
    return this._hhtp.get<CursoModel[]>(`${environment.apiUrl}/curso`);
  }

  getNotasAlumnos(): Observable<NotasAlumnoModel[]> {
    return this._hhtp.get<NotasAlumnoModel[]>(
      `${environment.apiUrl}/NotasAlumno`
    );
  }
}
