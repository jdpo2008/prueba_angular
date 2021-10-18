export class NotasAlumnoModel {
  //   public Guid AlumnoId { get; set; }
  //     public Guid CursoId { get; set; }

  //     public decimal Practicas { get; set; }
  //     public decimal Parcial { get; set; }
  //     public decimal Final { get; set; }

  //     public decimal PromedioPracticas { get; set; }
  //     public decimal PromedioParcial { get; set; }
  //     public decimal PromedioFinal { get; set; }
  constructor(
    public id?: string,
    public alumnoId?: string,
    public cursoId?: string,
    public practicas?: number,
    public parcial?: number,
    public final?: number,
    public promedioPracticas?: number,
    public promedioParcial?: number,
    public promedioFinal?: number
  ) {}
}
