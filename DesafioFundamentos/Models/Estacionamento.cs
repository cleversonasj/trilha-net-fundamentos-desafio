using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa;
            var regexPlaca = new Regex(@"^[A-Z]{3}-\d{4}$");

            do
            {
                Console.Clear();
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placa = Console.ReadLine()?.Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(placa) || !regexPlaca.IsMatch(placa))
                {
                    Console.WriteLine("Placa inválida. Use o formato XXX-NNNN (ex: ABC-1234).");
                    Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                }

                if (veiculos.Contains(placa))
                {
                    Console.WriteLine($"O veículo com a placa {placa} já está estacionado.");
                    Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    return;
                }

            } while (string.IsNullOrWhiteSpace(placa) || !regexPlaca.IsMatch(placa));

            veiculos.Add(placa);
            Console.WriteLine($"Veículo {placa} estacionado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            string placa;
            var regexPlaca = new Regex(@"^[A-Z]{3}-\d{4}$");

            do
            {
                Console.Clear();
                Console.Write("Digite a placa do veículo para remover (formato XXX-NNNN): ");
                placa = Console.ReadLine()?.Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(placa) || !regexPlaca.IsMatch(placa))
                {
                    Console.WriteLine("Placa inválida. Use o formato XXX-NNNN (ex: ABC-1234).");
                    Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    continue;
                }

                if (!veiculos.Contains(placa))
                {
                    Console.WriteLine("Veículo não encontrado. Verifique a placa digitada.");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    return;
                }

            } while (string.IsNullOrWhiteSpace(placa) || !veiculos.Contains(placa));

            int horas;
            do
            {
                Console.Clear();
                Console.Write($"Digite a quantidade de horas que o veículo {placa} permaneceu estacionado: ");
                string entradaHoras = Console.ReadLine();

                if (!int.TryParse(entradaHoras, out horas) || horas < 0)
                {
                    Console.WriteLine("Número de horas inválido. Digite apenas números inteiros positivos.");
                    Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                }

            } while (horas < 0);

            decimal valorTotal = this.precoInicial + (this.precoPorHora * horas);
            veiculos.Remove(placa);

            Console.WriteLine($"O veículo {placa} foi removido. Valor total a pagar: R$ {valorTotal:F2}");
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            if (!veiculos.Any())
            {
                Console.WriteLine("Nenhum veículo está estacionado no momento.");
                return;
            }
            
            Console.WriteLine("Veículos estacionados:\n");
            foreach (string placa in veiculos)
            {
                Console.WriteLine($"Placa: {placa}");
            }
        }
    }
}
