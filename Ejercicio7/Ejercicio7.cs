using System;
using System.Collections.Generic;
using System.Linq;

//Lista de donde va a sacar las palabras sin repetidos
string[] input = {"hola", "casa", "perro", "luz", "pez", "queso", "batman", "john", "garfield"};
List<string> output = new List<string>();


foreach (var palabra in input){
    //guarda la palabra en un arreglo con sus respectivos caracteres
    char[] caracteres = palabra.ToCharArray();
    //un hashset no admite repetidos, entonces por ejemplo la palabra "casa" se guarda es "c,a,s"
    HashSet<char> caracteresSinRep = new HashSet<char>(palabra.ToCharArray());

    //si el hashSet no elimina ningun caracter, es porque no se repite
    if(caracteres.Length == caracteresSinRep.Count){
        output.Add(palabra);
    }
}

Console.Write("[");
foreach (var palabra in output){
    Console.Write($"'{output[i]}'");
}
Console.Write("]");