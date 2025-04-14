using System;
using System.Collections.Generic;
using System.Linq;

//Se crea el input de prueba del cual va a coger los anagramas
string[] input = {"eat","tea","tan","ate","nat","bat","tab","toy","boo","obo","pepe","epep"};
List<List<string>> output = new List<List<string>>();
//se crea donde se van a guardar los anagramas ya organizados
Dictionary<string, List<string>> claves = new Dictionary<string, List<string>>();

foreach(string palabra in input) {
    //creamos el array de caracteres para poder organizarlo despues en orden alfabatico
    char [] caracteres= palabra.ToCharArray();
    //organizamos alfabeticamente el arreglo anterior
    Array.Sort(caracteres);

    //ese sort organizado, va a ser la clave. Lo anterior funciona, debido a que si dos palabras son
    //anagramas, sus caracteres ordenados alfabeticamente van a ser iguales.
    string clave= new string(caracteres);

    //revisa si la clave creada ya existe
    if(!claves.ContainsKey(clave)){
        //si no encuentra la clave, crea un nuevo apartado en el diccionario, con esa clave y crea una nueva lista
        claves[clave]= new List<string>();

    }

    //ya con la seguridad de que existe un apartado con esa clave, ahi si puede meter la palabra al elemento
    claves[clave].Add(palabra);
}

//se especifica el value porque sin esto sale como PairKeyValue, y no sabria con que comparar.
foreach (var anagramas in claves){
    Console.Write("[");

    foreach (var palabra in anagramas.Value){
        Console.Write($"\"{palabra}\" ");
    }
    Console.WriteLine("]");
}