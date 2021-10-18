import { DatePipe } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { BandejaAlumnosComponent } from './pages/bandeja-alumnos/bandeja-alumnos.component';
import { RegistrarAlumnoComponent } from './pages/registrar-alumno/registrar-alumno.component';
import { AlumnoService } from './services/alumno.service';
import { DialogEliminarComponent } from './pages/bandeja-alumnos/dialog-eliminar/dialog-eliminar.component';
import { DialogAgregarCursoComponent } from './pages/bandeja-alumnos/dialog-agregar-curso/dialog-agregar-curso.component';

const routes: Routes = [
  {
    path: 'bandeja-alumnos',
    component: BandejaAlumnosComponent,
  },
];

@NgModule({
  declarations: [BandejaAlumnosComponent, RegistrarAlumnoComponent, DialogEliminarComponent, DialogAgregarCursoComponent],
  imports: [SharedModule, RouterModule.forChild(routes)],
  providers: [DatePipe, AlumnoService],
})
export class AlumnosModule {}
