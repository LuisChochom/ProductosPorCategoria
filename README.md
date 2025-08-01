Explicación del análisis técnico, sobre la base de datos y sus relaciones.

Relaciones:
  Producto pertenece a una Categoria
  Venta se relaciona con un Producto

Clave lógica:
  Se usa ORDER BY Fecha DESC para traer la última venta.

JOIN:
  Se usan JOINs para conectar Venta → Producto → Categoria.

Restricción:
  Solo queremos 1 resultado (TOP 1) y el campo deseado es Categoria.Nombre.
