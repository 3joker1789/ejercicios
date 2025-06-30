import string

# Crear la lista del abecedario
alphabet = list(string.ascii_lowercase)

# Filtrar letras que no ocupan posiciones múltiplos de 3 (considerando posición 1-based)
filtered = [char for i, char in enumerate(alphabet) if (i + 1) % 3 != 0]

# Mostrar la lista resultante
print(filtered)