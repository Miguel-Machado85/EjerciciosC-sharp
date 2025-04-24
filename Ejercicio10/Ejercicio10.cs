using System;
using System.Collections.Generic;

// Se crea la clase Nodo, que contiene su valor, y sus hijos
public class NodoB<E> where E : IComparable<E>{
    public E Llave { get; set; }
    public NodoB<E> HijoIzq { get; private set; }
    public NodoB<E> HijoDer { get; private set; }
    public NodoB<E> Padre { get; private set; }

    public NodoB(E llave)
    {
        Llave = llave;
    }

    public void SetHijoIzq(NodoB<E> hijo)
    {
        HijoIzq = hijo;
        if (hijo != null)
            hijo.Padre = this;
    }

    public void SetHijoDer(NodoB<E> hijo)
    {
        HijoDer = hijo;
        if (hijo != null)
            hijo.Padre = this;
    }
}

// Se crea la clase arbol, que contiene la raiz que es un nodo, y ese nodo tiene la informacion del
// resto de nodos en el arbol
public class ArbolB<E> where E : IComparable<E>{
    public NodoB<E> Raiz { get; set; }

    public ArbolB(NodoB<E> raiz)
    {
        Raiz = raiz;
    }

    // Metodo para ver los niveles
    public List<List<E>> NivelesPorNivel(){
        // Lista de listas que contendra cada nivel del arbol
        var resultado = new List<List<E>>();
        if (Raiz == null) return resultado;

        // cola auxiliar
        Queue<NodoB<E>> cola = new Queue<NodoB<E>>();
        // Metemos primero la raiz a la cola
        cola.Enqueue(Raiz);

        // El while andara hasta que lleguemos a las hojas del arbol
        while (cola.Count > 0){
            // Se crea el limite de cada nivel y la lista que tendra sus nodos
            int nivelSize = cola.Count;
            List<E> nivel = new List<E>();

            // Este for llena el nivel con sus nodos
            for (int i = 0; i < nivelSize; i++){
                NodoB<E> actual = cola.Dequeue();
                nivel.Add(actual.Llave);

                // Si el nodo tiene hijos, se agregan a la cola para la siguiente iteracion del while
                if (actual.HijoIzq != null) cola.Enqueue(actual.HijoIzq);
                if (actual.HijoDer != null) cola.Enqueue(actual.HijoDer);
            }
            // Se agrega el nivel y se continua al siguiente, hasta que lleguemos a las hojas
            // sin hijos y el while acabe
            resultado.Add(nivel);
        }

        return resultado;
    }
}

public class Program{
    public static void Main()
    {
        //Se crean los nodos del arbol del ejemplo
        var n1 = new NodoB<int>(1);
        var n2 = new NodoB<int>(2);
        var n3 = new NodoB<int>(3);
        var n4 = new NodoB<int>(4);
        var n5 = new NodoB<int>(5);

        n2.SetHijoIzq(n4);
        n2.SetHijoDer(n5);
        n1.SetHijoIzq(n2);
        n1.SetHijoDer(n3);
        //Se pueden agregar mas nodos para el arbol, e imprimira los niveles

        // Se crea el arbol con la raiz nodo1
        var arbol = new ArbolB<int>(n1);
        var niveles = arbol.NivelesPorNivel();

        // Se imprimen los niveles
        Console.Write("[");
        foreach (var nivel in niveles){
            Console.Write($"[{string.Join(", ", nivel)}]");
        }
        Console.Write("]");
    }
}
