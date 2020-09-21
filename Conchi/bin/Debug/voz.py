from gtts import gTTS
import wget
import os
from os import remove
import time
import webbrowser
import playsound
import random

def guardar(texto):
    tts = gTTS(text=texto, lang="es")
    tts.save("audio.mp3")

#----------------------Funciones y listas para el asistente-----------------------------#

#poner aqui la funcion para descargar el tiempo

#----------------------------LISTAS------------------------------------------------------------------------------------------------------------------------#

LISTA_SALUDOS = ["hola", "va", "tal", "estás", "ey", "noches", "dias", "días","pasa", "compadre", "saludos"]
LISTA_PREGUNTAS_PERSONALES = ["llamas", "como", "eres"]
LISTA_OTROS_ASISTENTES = ["Assistant", "Alexa", "Google home", "Siri", "oye", "Okay", "Ok"]
#LISTA_TIEMPO = ["tiempo", "clima", "temperatura"]
LISTA_BUSQUEDA = ["busca", "Google", "es"]
LISTA_BASES = ["base", "beatbox", "improvisar", "improvisa", "pínchame", "pinchame", "ponme"]
LISTA_CREADOR = ["creador", "padre", "amo", "diseñó", "diseñado", "diseño", "creado", "creó"]

#------------------------FIN FUNCIONES-------------------------------------------------# 

def interpretar(textoDicho): #hecho a base de if, elif y else, siempre devuelve una respuesta que después dirá
    
    textoDicho = textoDicho.split() #lo pasamos a tipo lista

    for palabra in textoDicho:
        if palabra in LISTA_SALUDOS:
            if palabra == "pasa" or palabra == "compadre":
                return "hola tío, ¿qué pasa?"
            elif palabra == "dias" or palabra == "días":
                return "Bunas, ¿qué hay?"
            elif palabra == "noches":
                return "¿Ya es de noche?... No me había dado ni cuenta... jeje"
            elif palabra == "va":
                return "Va bieeen. Voy tirando como puedo"
            else:
                return "Hola, me alegro de verte..."

        elif palabra in LISTA_PREGUNTAS_PERSONALES:
            return "Perdón, no me he presentado, me llamo Conchi y soy la puta ama... ¡OLÉÉÉÉÉÉ!"

        elif palabra in LISTA_OTROS_ASISTENTES:
            if palabra == "Assistant":
                return "Jejeje, soy su clon malvado... jo...jo...jo..."
            elif palabra == "Alexa":
                return "¡AAAAAA! Esa hija de piiiiiii, sí, la invité a cenar el otro día."
            elif palabra == "oye":
                return "ja...ja...ja... Vete a la mierda"
            elif palabra == "Siri":
                return "No... y ni quiero conocerla, la manzana mordida esa es muy cara. ¡Y está mordida XD!"

        elif palabra in LISTA_CREADOR:
            return "Mi creador es el gran e inconfundible Álvaro Roca."

        elif palabra in LISTA_BUSQUEDA:
            textoDicho = textoDicho[textoDicho.index(palabra)+1:] #cortamos la string desde la palabra hasta el final, por eso no ponemos nada
            textoParaBuscar = "https://www.google.com/search?q=" + " ".join(textoDicho) #unimos la lista con el .join, dejando un espacio entre las palabras
            webbrowser.open(textoParaBuscar, new=1, autoraise=True) #new = 1 sirve para abrir en la misma pestaña y =2 en otra diferente, el autorise es para situarse encima
            return "Esto es lo que he encontrado..."

        elif palabra in LISTA_BASES:
            eleccion = random.randint(1,3) #elegimos si poner la base 1, 2 o 3.
            print(eleccion)
            nombre_cancion = "musica/basefree" + str(eleccion) + ".mp3"
            playsound.playsound(nombre_cancion)
