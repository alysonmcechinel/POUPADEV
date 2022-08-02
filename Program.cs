// See https://aka.ms/new-console-template for more information
/*Console.WriteLine("Digite seu nome");

var nome = Console.ReadLine();

Console.WriteLine("Hello, " + nome);
Console.WriteLine($"Hello, {nome}");

string secondoNome = "Matias";
int numeroInt = 5;
float numeroFloat = 5.4f;
double numeroDouble = 5.4;
decimal numeroDecimal = 5.3m;
int[] matrix = new int[3] { 1, 2, 3 };
char caractere = 'a';
DateTime hoje = DateTime.Now;
DateTime myNiver = new DateTime(1999, 4, 1);

// if - else

Console.WriteLine("Digite uma opção entre 1 e 3");
var opcao = Console.ReadLine();

if (opcao == "1") {
    Console.WriteLine("if - else: Opção 1 selecionada");
} else if (opcao == "2") {
    Console.WriteLine("if - else: Opção 2 selecionada");
} else if (opcao == "2") {
    Console.WriteLine("if - else: Opção 3 selecionada");
} else {
    Console.WriteLine("if - else: Opção inválida");
}

// switch - case

switch (opcao) {
    case "1":
        Console.WriteLine("switch: Opção 1 selecionada");
        break;
    case "2":
        Console.WriteLine("switch: Opção 2 selecionada");
        break;
    case "3":
        Console.WriteLine("switch: Opção 3 selecionada");
        break;
    default:
        Console.WriteLine("switch: Opção inválida");
        break;
}*/

// for 
var valores = Console.ReadLine();
var matrizValores = valores.Split(" ");

for (int i = 0; i < matrizValores.Length; i++) {
    Console.WriteLine(matrizValores[i] + " ");
}

// while
Console.WriteLine("----------------");
var contador = 0;

while (contador < matrizValores.Length) {

    Console.WriteLine(matrizValores[contador]);
    contador++;

}