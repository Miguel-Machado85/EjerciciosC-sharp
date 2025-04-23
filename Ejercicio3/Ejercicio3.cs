using System;
using System.Collections.Generic;
using System.Linq;

List<int> input = new List<int>{0,1,2,4,5,7};
int inicial = input[0];
List<string> output = new List<string>();

for (int i = 1; i < input.Count; i++){
    if(!(input[i] - input[i-1] == 1)){
        if(inicial == input[i-1]){
            string solo = inicial.ToString();
            output.Add(solo);
            inicial = input[i];
        } else{
            string rango = inicial + "->" + input[i-1];
            output.Add(rango);
            inicial = input[i];
        }
    }
}

if (inicial == input[input.Count - 1]){
    output.Add(inicial.ToString());
} else {
    output.Add(inicial + "->" + input[input.Count - 1]);
}

Console.Write("[");
foreach (var rango in output){
    Console.Write($"\"{rango}\" ");
}
Console.Write("]");

