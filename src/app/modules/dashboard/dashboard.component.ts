import { Component, OnInit } from '@angular/core';
import { forkJoin, Observable } from 'rxjs';
import { DashboardService } from './dashboard.service';

interface DashboardData {
  alumnosData: number;
  cursosData: number;
  alumnoPag?: number;
  cursosPag?: number;
}
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  loadData$: Observable<DashboardData> = new Observable();
  data: DashboardData;
  constructor(private _serv: DashboardService) {}

  ngOnInit(): void {
    this.getDashboardData();
  }

  getDashboardData() {
    this.loadData$ = forkJoin({
      alumnosData: this._serv.getCantidadAlumnos(),
      cursosData: this._serv.getCantidadCursos(),
    });

    this.loadData$.subscribe((response: DashboardData) => {
      this.data = response;
      this.data.alumnoPag = Math.ceil(response.alumnosData / 5);
      this.data.cursosPag = Math.ceil(response.cursosData / 5);
    });
  }
}
