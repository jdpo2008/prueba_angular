import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class DashboardService {
  constructor(private _hhtp: HttpClient) {}

  getCantidadCursos(): Observable<number> {
    return this._hhtp
      .get<number>(`${environment.apiUrl}/curso`)
      .pipe(map((res: any) => res.length));
  }

  getCantidadAlumnos(): Observable<number> {
    return this._hhtp
      .get<number>(`${environment.apiUrl}/alumno`)
      .pipe(map((res: any) => res.length));
  }
}
