export interface ColumnsDefInterface {
  id: number;
  name: string;
  displayedName: string;
  type?:
    | 'string'
    | 'number'
    | 'date'
    | 'datetime'
    | 'boolean'
    | 'time'
    | 'index'
    | 'acciones';
  decimals?: number;
  backgroundColorTitle?: string;
  alignTitle?: 'left' | 'center' | 'right';
  alignContent?: 'left' | 'center' | 'right';
}
