import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { CursoModel } from '@modules/alumnos/models/CursoModel';

@Injectable()
export class CursoService {
  constructor(private _hhtp: HttpClient) {}

  getCursos(): Observable<CursoModel[]> {
    return this._hhtp.get<CursoModel[]>(`${environment.apiUrl}/curso`);
  }

  deleteCurso(id: string): Observable<boolean> {
    return this._hhtp.delete<boolean>(`${environment.apiUrl}/curso/${id}`);
  }
}
