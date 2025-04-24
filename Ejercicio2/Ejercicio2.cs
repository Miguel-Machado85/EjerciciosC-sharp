using System;
using System.Collections.Generic;

class Program{
    static void Main(){
        // Se crea el string en el que vamos a buscar los substrings
        string s = "barfoothefoobarman";
        // Se crea el arreglo con las palabras que los substrings deben contener
        string[] words = { "foo", "bar"};
        List<int> resultado = EncontrarConcatenaciones(s, words);

        // Se imprime el resultado con el inicio de cada substring valido
        Console.Write("[");
        Console.Write(string.Join(", ", resultado));
        Console.WriteLine("]");
    }

    static List<int> EncontrarConcatenaciones(string s, string[] words){
        List<int> indices = new List<int>();
        if (words.Length == 0 || string.IsNullOrEmpty(s)) return indices;

        // Vamos a usar una ventana deslizante, para saber que tan grande debe ser el mensaje que
        // contenga todas nuestras palabras
        int palabraLen = words[0].Length;
        int totalLen = palabraLen * words.Length;

        // Creamos un diccionario para tener las palabras individuales y sus frecuencias,
        // en caso de que queramos que alguna palabra salga varias veces
        Dictionary<string, int> objetivo = new Dictionary<string, int>();
        foreach (string palabra in words){
            if (!objetivo.ContainsKey(palabra))
                objetivo[palabra] = 0;
            objetivo[palabra]++;
        }

        // el for va desde i hasta el limite que le da la ventana, asi revisa cada subcadena
        for (int i = 0; i <= s.Length - totalLen; i++){
            // diccionario auxiliar para encontrar las palabras de cada substring
            Dictionary<string, int> visto = new Dictionary<string, int>();
            int j = 0;

            while (j < words.Length){
                // Crea la palabra con palabraInicio, y diciendole que tenga un tamaño de las palabras de
                // words
                int palabraInicio = i + j * palabraLen;
                string palabra = s.Substring(palabraInicio, palabraLen);

                // Si la palabra no esta en words, terminamos esa iteracion
                if (!objetivo.ContainsKey(palabra))
                    break;

                // Si ha visto la palabra antes, sube la frecuencia
                if (!visto.ContainsKey(palabra))
                    visto[palabra] = 0;
                visto[palabra]++;

                // Si la frecuencia de la palabra es mayor a la que deberia aparecer, terminamos la iteracin
                if (visto[palabra] > objetivo[palabra])
                    break;

                // Seguimos haciendo palabras hasta que acabe la ventana
                j++;
            }

            // si j logra avanzar hasta words.length, fue porque todas las palabras
            // del substring son validas
            if (j == words.Length)
                // Agrega la posicion valida a la respuestra
                indices.Add(i);
        }

        return indices;
    }
}
