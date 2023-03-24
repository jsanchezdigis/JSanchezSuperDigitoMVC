
Console.WriteLine("Ingresa el numero: ");
int x = int.Parse(Console.ReadLine());

int SuperDigito = BL.Historial.CalcularSuperDigito(x);

Console.WriteLine("Super digito de {0} es:{1}",x,SuperDigito);

Console.ReadKey();