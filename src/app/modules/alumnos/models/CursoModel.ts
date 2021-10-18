export class CursoModel {
  /**
      public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Obligatoriedad { get; set; }
     */
  constructor(
    public id?: string,
    public nombre?: string,
    public descripcion?: string,
    public obligatoriedad?: boolean
  ) {}
}
