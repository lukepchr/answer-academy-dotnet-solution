import { IColour } from '../people/interfaces/icolour';

export class ColourNamesValueConverter {

  toView(colours: IColour[]) {
    
      let list = [];

      for (let i = 0; i < colours.length; i++){
         
          list.push(colours[i].name);
          }

      return list.sort().join(", ");
  }
}

