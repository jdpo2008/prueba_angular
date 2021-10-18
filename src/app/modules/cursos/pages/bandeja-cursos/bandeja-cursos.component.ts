import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CursoService } from '@modules/cursos/services/curso.service';
import { ColumnsDefInterface } from '@shared/models/ColumnsDefInterface';
import { CursoModel } from '../../../alumnos/models/CursoModel';

@Component({
  selector: 'app-bandeja-cursos',
  templateUrl: './bandeja-cursos.component.html',
  styleUrls: ['./bandeja-cursos.component.scss'],
})
export class BandejaCursosComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: MatTableDataSource<CursoModel>;
  columnsDef: ColumnsDefInterface[] = [];
  displayedColumns: string[] = [];
  listCurso: CursoModel[] = [];
  constructor(private _serv: CursoService) {
    this.columnsDef = [
      {
        name: 'qt',
        displayedName: '#',
        id: 1,
        type: 'index',
      },
      {
        name: 'nombre',
        displayedName: 'Nombre',
        id: 2,
        type: 'string',
      },
      {
        name: 'descripcion',
        displayedName: 'Descripcion',
        id: 3,
        type: 'string',
      },
      {
        name: 'acciones',
        displayedName: 'Acciones',
        id: 4,
        type: 'acciones',
      },
    ];
    this.columnsDef
      .sort((a, b) => (a.id < b.id ? -1 : 1))
      .forEach((column: ColumnsDefInterface) => {
        this.displayedColumns.push(column.name);
      });
  }

  ngOnInit(): void {
    this.getListCurso();
  }

  getListCurso() {
    this._serv.getCursos().subscribe((res: CursoModel[]) => {
      this.dataSource = new MatTableDataSource<CursoModel>(res);
    });
  }

  eliminarCurso(curso: CursoModel) {
    this._serv.deleteCurso(curso.id).subscribe((response) => {
      console.log(response);
      if (response == true) {
        this.getListCurso();
      }
    });
  }
}
