# Vectores
a = [56, 2, 3]
b = [-1, 0, 2]

# Calcular el producto escalar
dot_product = sum(x * y for x, y in zip(a, b))

# Mostrar el resultado
print(f"Producto escalar: {dot_product}")