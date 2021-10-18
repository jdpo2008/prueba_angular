import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AlumnoModel } from '@modules/alumnos/models/AlumnoModel';
import { CursoModel } from '@modules/alumnos/models/CursoModel';
import { NotasAlumnoModel } from '@modules/alumnos/models/NotasAlumnoModel';
import { AlumnoService } from '@modules/alumnos/services/alumno.service';
import { ColumnsDefInterface } from '@shared/models/ColumnsDefInterface';
import { RegistrarAlumnoComponent } from '../registrar-alumno/registrar-alumno.component';
import { DialogAgregarCursoComponent } from './dialog-agregar-curso/dialog-agregar-curso.component';
import { DialogEliminarComponent } from './dialog-eliminar/dialog-eliminar.component';

@Component({
  selector: 'app-bandeja-alumnos',
  templateUrl: './bandeja-alumnos.component.html',
  styleUrls: ['./bandeja-alumnos.component.scss'],
})
export class BandejaAlumnosComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource: MatTableDataSource<AlumnoModel>;
  columnsDef: ColumnsDefInterface[] = [];
  displayedColumns: string[] = [];
  defaultAlumno: AlumnoModel = new AlumnoModel();
  constructor(private _serv: AlumnoService, public dialog: MatDialog) {
    this.columnsDef = [
      {
        name: 'qt',
        displayedName: '#',
        id: 1,
        type: 'index',
      },
      {
        name: 'nombres',
        displayedName: 'Nombres',
        id: 2,
        type: 'string',
      },
      {
        name: 'apellidos',
        displayedName: 'Apellidos',
        id: 3,
        type: 'string',
      },
      {
        name: 'email',
        displayedName: 'Email',
        id: 4,
        type: 'string',
      },
      {
        name: 'dni',
        displayedName: 'DNI',
        id: 5,
        type: 'string',
      },
      {
        name: 'sexo',
        displayedName: 'Sexo',
        id: 6,
        type: 'time',
      },
      {
        name: 'fechaNacimiento',
        displayedName: 'Nacimiento',
        id: 7,
        type: 'date',
      },
      {
        name: 'edad',
        displayedName: 'Edad',
        id: 8,
        type: 'string',
      },
      {
        name: 'fechaCreacion',
        displayedName: 'Creación',
        id: 9,
        type: 'date',
      },
      {
        name: 'acciones',
        displayedName: 'Acciones',
        id: 10,
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
    this.getAlumnos();
  }

  getAlumnos() {
    this._serv.getAlumnos().subscribe((response: AlumnoModel[]) => {
      this.dataSource = new MatTableDataSource(response);
      this.dataSource.paginator = this.paginator;
    });
  }

  public openDialogRegistrar(alumno: AlumnoModel) {
    const dialogRef = this.dialog.open(RegistrarAlumnoComponent, {
      width: '45%',
      data: {
        titulo: alumno.id ? 'ACTUALIZAR ALUMNO' : 'REGISTRAR ALUMNO',
        buttonText: {
          guardar: alumno.id ? 'Actualizar' : 'Registrar',
          cancel: 'No',
        },
        alumno,
      },
    });

    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed == true) {
        this.getAlumnos();
      }
    });
  }

  public openDialogEliminar(alumno: AlumnoModel) {
    const dialogRef = this.dialog.open(DialogEliminarComponent, {
      width: '35%',
      data: {
        titulo: 'ELIMINAR ESTUDIANTE',
        buttonText: {
          aceptar: 'Si',
          cancel: 'No',
        },
        alumno,
      },
    });

    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed == true) {
        this._serv.deleteAlumno(alumno.id).subscribe((response) => {
          console.log(response);
          if (response == true) {
            this.getAlumnos();
          }
        });
      }
    });
  }

  public openDialogCurso(alumno: AlumnoModel) {
    const dialogRef = this.dialog.open(DialogAgregarCursoComponent, {
      width: '70%',
      data: {
        titulo: 'AGREGAR CURSOS Y NOTAS ALUMNO',
        buttonText: {
          aceptar: 'Guardar',
          cancel: 'Salir',
        },
        alumno,
      },
    });

    dialogRef.afterClosed().subscribe((response: any) => {
      if (response.confirmed == true) {
        let data: NotasAlumnoModel[] = response.data;

        data.forEach((element: NotasAlumnoModel) => {
          let curso: CursoModel = {
            id: element.cursoId,
          };
          alumno.cursos.push(curso);
        });

        data.forEach((element: NotasAlumnoModel) => {
          alumno.notasAlumno.push(element);
        });

        console.log(response);

        // this._serv.putAlumno(alumno, alumno.id).subscribe((response) => {
        //   console.log(response);
        //   if (response == true) {
        //     this.getAlumnos();
        //   }
        // });
      }
    });
  }
}
