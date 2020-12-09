import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'newLine',
})
export class NewLinePipe implements PipeTransform {
  transform(value: string, args?: any): string {
    if (!value) {
      return null;
    }
    value.replace('/[↵]/g', '<br>');
    return value;
  }
}
