import { DatePipe } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AlumnoModel } from '@modules/alumnos/models/AlumnoModel';
import { AlumnoService } from '@modules/alumnos/services/alumno.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-registrar-alumno',
  templateUrl: './registrar-alumno.component.html',
  styles: [],
})
export class RegistrarAlumnoComponent implements OnInit {
  alumnoForm: FormGroup = new FormGroup({});
  titulo: string = '';
  cancelButtonText: string = 'Cancel';
  guardarButtonText: string = 'Guardar';
  p_alumno: AlumnoModel;
  formAction$: Observable<AlumnoModel | boolean>;
  constructor(
    @Inject(MAT_DIALOG_DATA) private data: any,
    public dialogRef: MatDialogRef<RegistrarAlumnoComponent>,
    private _fb: FormBuilder,
    private datePipe: DatePipe,
    private _serv: AlumnoService
  ) {
    if (this.data) {
      this.titulo = this.data.titulo || this.titulo;
      if (this.data.buttonText) {
        this.cancelButtonText =
          this.data.buttonText.cancel || this.cancelButtonText;
        this.guardarButtonText =
          this.data.buttonText.guardar || this.guardarButtonText;
      }
      this.p_alumno = this.data.alumno;
    }
  }

  ngOnInit(): void {
    this._buildAlumnoForm(this.p_alumno);
  }

  get f() {
    return this.alumnoForm.controls;
  }

  registrarAlumno() {
    //this.p_alumno = this.p_alumno.id ? this.p_alumno : this.f.values;

    let body: AlumnoModel = {
      id: this.p_alumno.id,
      nombres: this.f.nombres.value,
      apellidos: this.f.apellidos.value,
      email: this.f.email.value,
      dni: this.f.dni.value,
      fechaNacimiento: new Date(this.f.fechaNacimiento.value),
      edad: this.f.edad.value,
      sexo: this.f.sexo.value,
      cursos: [],
      notasAlumno: [],
    };

    this.formAction$ =
      this.p_alumno.id == undefined
        ? this._serv.postAlumno(body)
        : this._serv.putAlumno(body, this.p_alumno.id);

    this.formAction$.subscribe((response) => {
      this.dialogRef.close(true);
    });
  }

  private _buildAlumnoForm(data: any) {
    this.alumnoForm = this._fb.group({
      nombres: [data?.nombres || '', [Validators.required]],
      apellidos: [data?.apellidos || '', [Validators.required]],
      email: [data?.email || '', [Validators.required, Validators.email]],
      dni: [data?.dni || '', [Validators.required]],
      edad: [data?.edad || '', [Validators.required]],
      fechaNacimiento: [
        this.datePipe.transform(data?.fechaNacimiento, 'yyyy-MM-dd') ||
          this.datePipe.transform(new Date(), 'yyyy-MM-dd'),

        [Validators.required],
      ],
      sexo: [data?.sexo || 0, [Validators.required]],
    });
  }
}
