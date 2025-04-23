using System;
using System.Collections.Generic;
using System.Linq;

// Clase individual para cada nodo, tiene su valor y sus hijos
class Nodo {
    public int valor;
    public Nodo izquierdo;
    public Nodo derecho;

    public Nodo(int valor) {
        this.valor = valor;
        izquierdo = null;
        derecho = null;
    }

    public void setHijoIzq(Nodo nodo){
        this.izquierdo = nodo;
    }

    public void setHijoDer(Nodo nodo){
        this.derecho = nodo;
    }
}

class Solucion {
    static int SumarHojas(Nodo raiz) {
        // Por seguridad, si entrega un abrol nulo retorna 0
        if (raiz == null) return 0;

        // Revisa si el nodo en el que estamos parados es una hoja
        if (raiz.izquierdo == null && raiz.derecho == null) {
            return raiz.valor;
        }

        // Si no es una hoja, hace la llamada recursiva para la suma de sus hijos
        return SumarHojas(raiz.izquierdo) + SumarHojas(raiz.derecho);
    }

    static void Main() {
        // Construimos el árbol del ejemplo
        Nodo raiz = new Nodo(5);
        Nodo nodo3 = new Nodo(3);
        Nodo nodo8 = new Nodo(8);
        Nodo nodo1 = new Nodo(1);
        Nodo nodoQue = new Nodo(4);
        Nodo nodo10 = new Nodo(10);
        Nodo nodo11 = new Nodo(11);

        raiz.setHijoIzq(nodo3);
        raiz.setHijoDer(nodo8);
        nodo3.setHijoIzq(nodo1);
        nodo3.setHijoDer(nodoQue);
        nodo8.setHijoDer(nodo10);
        nodo10.setHijoIzq(nodo11);

        int sumaHojas = SumarHojas(raiz);
        Console.WriteLine("Suma de hojas: " + sumaHojas);
    }
}
