using System;
using System.Collections.Generic;
using System.Linq;

int iteraciones= 4;
string input = "uno dos tres cuatro";

//Usamos split para convertir el string inicial en un arreglo de strings, separados por el espacio
string[] palabras = input.Split(' ');

//Tomamos ese arreglo y lo convertimos en una linkedList
LinkedList<string> palabrasL = new LinkedList<string>(palabras);

for(int i = 0; i< iteraciones; i++){
    //La linkedList nos permite revisar el ultimo valor, quitarlo y ponerlo por delante
    // Hacemos eso tantas veces como nos pida las iteraciones
    string ultimo = palabrasL.Last.Value;
    palabrasL.RemoveLast();
    palabrasL.AddFirst(ultimo);
}

//Se imprime la linkedList
foreach (var palabra in palabrasL){
    Console.Write(palabra + " ");
}
