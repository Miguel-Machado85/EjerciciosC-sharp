using System;
using System.Collections.Generic;
using System.Linq;

//input en el que se dan cualquier numero de palabras repetidas cualquier numero de veces
List<string> input = new List<string>{"apple","banana","apple","orange","banana"};
List<string> output = new List<string>();

//Hacemos for inverso para conseguir solo la ultima aparicion del elemento
for (int i = input.Count-1; i >= 0; i--){
    //Si la palabra no esta contenida en nuestro output, es porque es la ultima vez que aparece y lo agregamos
    if(!output.Contains(input[i])){
        output.Add(input[i]);
    }
}

// Se imprime el output, con solo la ultima aparicion de cada palabra diferente
Console.Write("[");
foreach (var palabra in output){
    Console.Write($"\"{palabra}\" ");
}
Console.Write("]");