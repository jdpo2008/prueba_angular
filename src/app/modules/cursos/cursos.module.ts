import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '@shared/shared.module';

import { CursoService } from './services/curso.service';

import { BandejaCursosComponent } from './pages/bandeja-cursos/bandeja-cursos.component';
import { RegistrarCursoComponent } from './pages/registrar-curso/registrar-curso.component';

const routes: Routes = [
  {
    path: 'bandeja-cursos',
    component: BandejaCursosComponent,
  },
];

@NgModule({
  declarations: [BandejaCursosComponent, RegistrarCursoComponent],
  imports: [SharedModule, RouterModule.forChild(routes)],
  providers: [CursoService],
})
export class CursosModule {}
