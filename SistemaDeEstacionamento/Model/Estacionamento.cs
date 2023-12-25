namespace SistemaDeEstacionamento.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial = 0;
        private decimal PrecoPorHora = 0;
        private List<string> Veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        private bool ValidarPlaca(string placa)
        {
            if (placa.Length != 7)
                return false;

            string letras = placa.Substring(0, 3);
            string numeros = placa.Substring(3);

            // Verificar se as primeiras 3 letras são alfabéticas
            if (!letras.All(char.IsLetter))
                return false;

            // Verificar se os últimos 4 caracteres são numéricos
            if (!numeros.All(char.IsDigit))
                return false;

            return true;
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("== ADICIONA VEÍCULO ==");
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine()!.ToUpper();

            if (ValidarPlaca(placa))
            {
                Veiculos.Add(placa);
                Console.WriteLine("Veículo adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida. A placa deve conter 3 letras seguidas de 4 números.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("== REMOVE VEÍCULO ==");
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine()!;

            // Verifica se o veículo existe
            if (Veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                decimal valorTotal = 0;

                if (int.TryParse(Console.ReadLine(), out horas))
                {
                     valorTotal = PrecoInicial + PrecoPorHora * horas;
                }
                else
                {
                    Console.WriteLine("Valor inválido para horas.");
                }

                Veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            Console.WriteLine("== LISTA DE VEÍCULOS ==");
            // Verifica se há veículos no estacionamento
            if (Veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                int contador = 0;
                foreach (string item in Veiculos)
                {
                    Console.WriteLine($" Véiculo Nº{contador+1} - {item}");
                    contador++;

                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}