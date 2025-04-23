using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Se ingresa el input
string input = "Hola mundo. Hola clase, hola estudiantes!";

// Se separa el mensaje en espacios, ignorando los caracteres solicitados y elimina splits vacios para evitar palabras vacias
string[] palabras = input.Split(new char[] { ' ', ',', '.', '!', '¡', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

// Se crea el diccionario donde se guardaran las palabras con la frecuencia con la que aparecen
Dictionary<string, int> palabraFrecuencia = new Dictionary<string, int>();

for (int i = 0; i < palabras.Length; i++)
{
    // Conseguimos la palabra individual
    string currentP = palabras[i];
    // La pone en minusculas para evitar dos entradas de una misma palabra en mayuscula o minuscula
    string lowerP = currentP.ToLower();
    // Si la palabra no esta contenida en el diccionario, se le crea una entrada, comenzando con frecuencia 1
    if(!palabraFrecuencia.ContainsKey(lowerP)){
        palabraFrecuencia.Add(lowerP, 1);
    } else {
        // Si la palabra si esta, simplemente aumentamos su frecuencia por 1
        palabraFrecuencia[lowerP] += 1;
    }
}

// Ordenamos el diccionario para que muestre las palabras mas frecuentes primero
var sortedFrecuencias = palabraFrecuencia.OrderByDescending(par => par.Value);

// Se imprime cada palabra con su frecuencia
foreach (var palabra in sortedFrecuencias)
{
    Console.WriteLine(palabra);
}