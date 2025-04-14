using System;
using System.Collections.Generic;
using System.Linq;

//listas a intercalar
List<char> lista1 = new List<char>{'1','2','3'};
List<char> lista2 = new List<char>{'a','b'};
List<char> output = new List<char>();
int i = 0;
int j = 0;
//mismo funcionamiento que un merge comun y corriente
//va intercalando elemento a elemento, hasta que una de las dos listas se acabe
while(i<lista1.Count && j<lista2.Count){
    output.Add(lista1[i]);
    i++;
    output.Add(lista2[j]);
    j++;
}
//en el caso de que una de los dos listas se acabe, lo que se hace es que simplemente anade lo sobrante.
if(i<lista1.Count){
    for (int k = i; k < lista1.Count; k++){
        output.Add(lista1[k]);
    }
}

if(j<lista2.Count){
    for(int k = j; k < lista2.Count; k++){
        output.Add(lista2[k]);
    }
}
 
Console.Write("[");
foreach (var caracter in output){
    Console.Write($"'{caracter}'" + ",");
}
Console.WriteLine("]");