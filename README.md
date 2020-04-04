
# THIS program was made with .net 5 version 5.0.100-preview.1.20155.7

## Busqueda de palabras entre otras palabras

El codigo de este programa tiene como objetivo solucionar el problema de encontrar palabras entre otras palabras, lo que hace en especifico es mirar si tiene dos palabras adelante y atras de el, le saca la similitud a partir de shingles y usando como metodo de distancia el index de Jaccard.

Una descripcion de las clases que hay son:

# WordSim

Simplemente la informacion de las palabras, si estan en el medio de dos palabras mas, entre otras cosas.

# JacardIndex

Esta clase se encarga de sacar los shingles y ver las similiradades entre ambos strings, y la similiradidad se evalua con el indice de jacard

# Filter

Se encarga de encontrar las palabras que se parecen en toda la cadena a la palabra de busqueda

# Program

Aqui esta el main del programa, se encarga de conseguir la informacion de la consola y mostrar los datos que cumplen las condiciones que se piden (que se encuentre en medio de dos palabras) adicionalmente se le ha agregado un modo impreciso para poder encontrar palabras similares a la pedida.
