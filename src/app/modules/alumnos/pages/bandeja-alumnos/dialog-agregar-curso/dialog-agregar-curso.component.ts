import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AlumnoModel } from '@modules/alumnos/models/AlumnoModel';
import { CursoModel } from '@modules/alumnos/models/CursoModel';
import { NotasAlumnoModel } from '@modules/alumnos/models/NotasAlumnoModel';
import { AlumnoService } from '@modules/alumnos/services/alumno.service';

@Component({
  selector: 'app-dialog-agregar-curso',
  templateUrl: './dialog-agregar-curso.component.html',
  styleUrls: ['./dialog-agregar-curso.component.scss'],
})
export class DialogAgregarCursoComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: MatTableDataSource<NotasAlumnoModel> =
    new MatTableDataSource<NotasAlumnoModel>([]);
  displayedColumns: string[] = [];
  titulo: string = '';
  cancelButtonText: string = 'No';
  guardarButtonText: string = 'Si';
  p_alumno: AlumnoModel;
  nombre: string = '';
  listCurso: CursoModel[] = [];
  constructor(
    @Inject(MAT_DIALOG_DATA) private data: any,
    public dialogRef: MatDialogRef<DialogAgregarCursoComponent>,
    private _alumServ: AlumnoService
  ) {
    if (this.data) {
      this.titulo = this.data.titulo || this.titulo;
      if (this.data.buttonText) {
        this.cancelButtonText =
          this.data.buttonText.cancel || this.cancelButtonText;
        this.guardarButtonText =
          this.data.buttonText.aceptar || this.guardarButtonText;
      }
      this.p_alumno = this.data.alumno;
      this.nombre = `${this.p_alumno.nombres} ${this.p_alumno.apellidos}`;
    }
  }

  ngOnInit(): void {
    this.getListCurso();
    this.displayedColumns = [
      'cantidad',
      'select',
      'parcial',
      'practica',
      'final',
      'p_parcial',
      'p_practica',
      'p_final',
    ];
  }

  getListCurso() {
    this._alumServ.getCursos().subscribe((res: CursoModel[]) => {
      this.listCurso = res;
      this.getNotasAlumnos();
    });
  }

  getNotasAlumnos() {
    this._alumServ.getNotasAlumnos().subscribe((res: NotasAlumnoModel[]) => {
      if (res.length > 0) {
        let data = res.filter((x) => x.alumnoId == this.p_alumno.id);
        this.dataSource.data = data;
      }
    });
  }

  addRow() {
    let row: any = {
      alumnoId: this.p_alumno.id,
      cursoId: 0,
      practicas: 0,
      parcial: 0,
      final: 0,
      promedioPracticas: 0,
      promedioParcial: 0,
      promedioFinal: 0,
    };
    this.dataSource.data.push(row);
    this.dataSource.filter = '';
  }
}
