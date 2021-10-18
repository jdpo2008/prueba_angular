import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AlumnoModel } from '@modules/alumnos/models/AlumnoModel';

@Component({
  selector: 'app-dialog-eliminar',
  templateUrl: './dialog-eliminar.component.html',
  styleUrls: ['./dialog-eliminar.component.scss'],
})
export class DialogEliminarComponent implements OnInit {
  titulo: string = '';
  cancelButtonText: string = 'No';
  guardarButtonText: string = 'Si';
  p_alumno: AlumnoModel;
  nombre: string = '';
  constructor(
    @Inject(MAT_DIALOG_DATA) private data: any,
    public dialogRef: MatDialogRef<DialogEliminarComponent>
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

  ngOnInit(): void {}
}
