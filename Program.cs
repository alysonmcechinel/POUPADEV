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
}

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

var notasTurma = new List<int> { 10, 2, 5, 7, 8, 9, 7, 6, 6, 5, 3, 10, 9, 8 };

var existeNota1 = notasTurma.Any(a => a == 1);
var primeiraNota10 = notasTurma.First( a =>  a == 10);
var singleNota1 = notasTurma.Single(a => a == 2);
var max = notasTurma.Max();
var min = notasTurma.Min();
var sum = notasTurma.Sum();
var media = notasTurma.Average();
var ordered = notasTurma.OrderBy(a => a);

foreach (var nota in ordered) {
    Console.WriteLine(nota);
}*/

// base da programação C#
// Abstração,
// Encapsulamento => public protected, internal, protected internal, private
// Herança
// Polimorfismo

var objetivos = new List<ObjetivoFinanceiro> {
    new ObjetivoFinanceiro("Viagem a Orlando", 25000),
    new ObjetivoFinanceiroComPrazo(new DateTime(2023, 10, 1), "Viagem a Orlando com Prazo", 25000)
};

foreach (var objetivo in objetivos) {
    objetivo.ImprimirResumo();
}

ExibirMenu();

var opcao = Console.ReadLine();

while (opcao != "0") {
    switch (opcao) {
        case "1":
            // Cadastrar
            CadastrarObjetivo();
            break;
        case "2":
            // Depósito
            RealizarOperacao(TipoOperacao.Deposito);
            break;
        case "3":
            // Saque
            RealizarOperacao(TipoOperacao.Saque);
            break;
        case "4":
            // Detalhes
            ObterDetalhes();
            break;
        default:
            // Opção inválida.
            Console.WriteLine("Opção inválida.");
            break;
    }

    ExibirMenu();

    opcao = Console.ReadLine();
}

void CadastrarObjetivo() {
    Console.WriteLine("Digite um título.");
    var titulo = Console.ReadLine();
    
    Console.WriteLine("Digite um valor de objetivo.");
    var valorLido = Console.ReadLine();
    var valor = decimal.Parse(valorLido);

    var objetivo = new ObjetivoFinanceiro(titulo, valor);

    objetivos.Add(objetivo);
    Console.WriteLine($"Objetivo ID: {objetivo.Id} foi criado com sucesso.");
}

void RealizarOperacao(TipoOperacao tipo) {
    Console.WriteLine("Digite o ID do Objetivo.");
    var idLido = Console.ReadLine();
    var id = int.Parse(idLido);

    Console.WriteLine("Digite o valor da operação:");
    var valorLido = Console.ReadLine();
    var valor = decimal.Parse(valorLido);

    var operacao = new Operacao(valor, tipo, id);

    var objetivo = objetivos.SingleOrDefault(o => o.Id == id);

    objetivo.Operacoes.Add(operacao);
}

void ObterDetalhes() {
    Console.WriteLine("Digite o ID do Objetivo.");
    var idLido = Console.ReadLine();
    var id = int.Parse(idLido);

    var objetivo = objetivos.SingleOrDefault(o => o.Id == id);

    objetivo.ImprimirResumo();
}

void ExibirMenu() {
    Console.WriteLine("Digite 1 para Cadastro de Objetivo");
    Console.WriteLine("Digite 2 para Realizar um Depósito.");
    Console.WriteLine("Digite 3 para Realizar um Saque.");
    Console.WriteLine("Digite 4 para Exibir Detalhes de um Objetivo.");
    Console.WriteLine("Digite 0 para encerrar.");
}


public enum TipoOperacao {
    Saque = 0,
    Deposito = 1
}

public class Operacao {

    public Operacao(decimal valor, TipoOperacao tipo, int idObjetivo)
    {
        Id = new Random().Next(0, 1000);
        Valor = valor;
        Tipo = tipo;
        IdObjetivo = idObjetivo;
    }

    public int Id { get; private set; }
    public decimal Valor { get; private set; }
    public TipoOperacao Tipo { get; private set; }
    public int IdObjetivo { get; private set; }
}

public class ObjetivoFinanceiro {

    public ObjetivoFinanceiro(string? titulo, decimal? valorObjetivo)
    {
        Id = new Random().Next(0, 1000);
        Titulo = titulo;
        ValorObjetivo = valorObjetivo;

        Operacoes = new List<Operacao>();
    }

    public int Id { get; private set; }
    public string? Titulo { get; private set; }
    public decimal? ValorObjetivo { get; private set; }
    public List<Operacao> Operacoes { get; private set; }
    public decimal Saldo => ObterSaldo();

    public decimal ObterSaldo() {
        var totalDeposito = Operacoes
            .Where(a => a.Tipo == TipoOperacao.Deposito)
            .Sum(a => a.Valor);

        var totalSaque = Operacoes
            .Where(a => a.Tipo == TipoOperacao.Saque)
            .Sum(a => a.Valor);

        return totalDeposito - totalSaque;
    }

    public virtual void ImprimirResumo() {
        Console.WriteLine($"Objetivo {Titulo}, Valor: {ValorObjetivo}, com Saldo Atual: R${Saldo}");
    }
}

public class ObjetivoFinanceiroComPrazo : ObjetivoFinanceiro
{
    public ObjetivoFinanceiroComPrazo(DateTime prazo, string? titulo, decimal? valorObjetivo) : base(titulo, valorObjetivo)
    {
        Prazo = prazo;
    }

    public DateTime Prazo { get; private set; }

    public override void ImprimirResumo()
    {
        base.ImprimirResumo();

        var diasRestantes = (Prazo - DateTime.Now).TotalDays;
        var valorRestante = ValorObjetivo - Saldo;

        Console.WriteLine($"Faltam {diasRestantes} para o prazo de seu objetivo, e faltam R${valorRestante} para completar.");
    }
}