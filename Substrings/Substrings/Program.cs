using System;
using System.IO;

class Program
{
	static void Main()
	{
		string rutaArchivo = "tarea.txt";

		try // utiliza un bloque try-catch para manejar posibles excepciones, como cuando el archivo no se encuentra (FileNotFoundException)
			// o cuando ocurre un error de E/S (IOException).
			// Si se puede abrir el archivo correctamente, se lee todo el contenido utilizando sr.ReadToEnd() y se imprime en la consola.
		{
			// StreamReader es una clase que permite leer el contenido de un archivo de texto.
			// StreamReader se utiliza dentro de un bloque using para asegurarse de que se liberen los recursos correctamente después de su uso.Esto se debe a que StreamReader implementa la interfaz IDisposable.
			using (StreamReader sr = new StreamReader(rutaArchivo))
			{
				// !sr.EndOfStream es una condición que verifica si no se ha alcanzado el final del archivo. Esto se utiliza en un bucle while para leer cada línea del archivo hasta que se llegue al final.
				while (!sr.EndOfStream) // el código que extrae las partes deseadas van dentro de un bucle while que lee cada línea del archivo de texto.
										// Cada vez que se lee una línea, se aplican las operaciones de Substring para obtener las partes específicas según el formato indicado.
				{
					string linea = sr.ReadLine(); // sr.ReadLine() es un método de StreamReader que lee la siguiente línea del archivo y la almacena en la variable linea.
												  // Cada iteración del bucle while lee una línea nueva hasta que se alcance el final del archivo.

					if (linea.Length != 64)
					{
						Console.WriteLine("Error: Debería tener 64 caracteres.");
						continue; // se utiliza continue para pasar a la siguiente línea sin realizar más operaciones.
					}

					string nombre = linea.Substring(0, 16);

					string fecha = linea.Substring(16, 8);
					DateTime fechaParsed = DateTime.ParseExact(fecha, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

					string peso = linea.Substring(24, 3);
					int pesoParsed = int.Parse(peso);

					string calle = linea.Substring(27, 8);

					string altura = linea.Substring(35, 4);
					int alturaParsed = int.Parse(altura);

					string ciudad = linea.Substring(39, 16);

					string pais = linea.Substring(55, 9);

					// Realiza las operaciones necesarias con los valores extraídos
					Console.WriteLine("Nombre: " + nombre);
					Console.WriteLine("Fecha: " + fechaParsed.ToString("yyyy-MM-dd"));
					Console.WriteLine("Peso: " + pesoParsed);
					Console.WriteLine("Calle: " + calle);
					Console.WriteLine("Altura: " + alturaParsed);
					Console.WriteLine("Ciudad: " + ciudad);
					Console.WriteLine("Pais: " + pais);
					Console.WriteLine();
				}
			}
		}
		catch (FileNotFoundException)
		{
			Console.WriteLine("No se pudo encontrar el archivo.");
		}
		catch (IOException ex)
		{
			Console.WriteLine("Error al abrir el archivo: " + ex.Message);
		}
		catch (FormatException ex)
		{
			Console.WriteLine("Error al convertir los datos: " + ex.Message);
		}

		Console.ReadLine();
	}
}
