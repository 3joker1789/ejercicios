# Solicitar una palabra al usuario
word = input("Ingrese una palabra: ").lower()

# Inicializar un diccionario para contar las vocales
vowels = {'a': 0, 'e': 0, 'i': 0, 'o': 0, 'u': 0}

# Contar las vocales en la palabra
for letter in word:
    if letter in vowels:
        vowels[letter] += 1

# Mostrar el número de veces que aparece cada vocal
print(vowels)