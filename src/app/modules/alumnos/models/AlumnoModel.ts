import { CursoModel } from './CursoModel';
import { NotasAlumnoModel } from './NotasAlumnoModel';

export class AlumnoModel {
  constructor(
    public apellidos?: string,
    public cursos?: CursoModel[],
    public dni?: string,
    public edad?: number,
    public email?: string,
    public fechaCreacion?: Date,
    public fechaEdicion?: Date,
    public fechaNacimiento?: Date,
    public id?: string,
    public idUsuarioCreacion?: string,
    public idUsuarioEdicion?: string,
    public nombres?: string,
    public notasAlumno?: NotasAlumnoModel[],
    public sexo?: number
  ) {}
}
