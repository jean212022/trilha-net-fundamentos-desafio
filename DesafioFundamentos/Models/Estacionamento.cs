using static System.Console;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        public decimal ValorInicial { get; set; }
        public decimal PrecoHora { get; set; }
        public List<string> Carros { get; set; }

        public Estacionamento(){
            WriteLine("Seja bem vindo ao sistema de estacionamento!");
            ValorInicial = LendoValoresIniciais("Digite o preço inicial:");
            PrecoHora = LendoValoresIniciais("Agora digite o preco por hora:");
            Carros = new List<string>();
        }

        public decimal LendoValoresIniciais(string mensagem)
        {
            decimal valor;
            do
            {
                WriteLine(mensagem); 
            } while(!decimal.TryParse(ReadLine(), out valor));
            return valor;
        }
        public void CadastrarVeiculo(){
            string? carro;
            while(true)
            {
                WriteLine("Digite a placa do veículo para estacionar:");
                carro = ReadLine();
                if(!String.IsNullOrEmpty(carro))
                {
                    break;
                }             
                WriteLine("A placa não pode ser vazia");   
            }
            Carros.Add(carro);
        }
        public void ListarVeiculos(){
            WriteLine("Os veículos estacionados são:");
            foreach(var carro in Carros){
                WriteLine(carro);
            }
        }
        public void RemoverVeiculo(){
            WriteLine("Digite a placa do veículo para remover:");
            string? veiculo = ReadLine();
            if(String.IsNullOrEmpty(veiculo) || !Carros.Remove(veiculo))
            {
                WriteLine("Veículo inexistênte!");
                return;
            }
            uint horas;
            while(true)
            {
                WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if(!uint.TryParse(ReadLine(), out horas)){
                    WriteLine("Erro: Quantidade de horas inexistente!");
                } else {
                    break;
                }
            }
            decimal preco = ValorInicial + PrecoHora * horas;
            WriteLine($"O veículo {veiculo} foi removido e o preco total foi de: R${preco}");
        }
        public void Menu(){
            while(true){
                Clear();
                WriteLine("Digite a sua opção:");
                WriteLine("1 - Cadastrar veículo");
                WriteLine("2 - Remover veículo");
                WriteLine("3 - Listar veículos");
                WriteLine("4 - Encerrar");
                string? resp = ReadLine();
                if(string.Equals(resp, "1"))
                {
                    CadastrarVeiculo();
                } else if(string.Equals(resp, "2"))
                {
                    RemoverVeiculo();
                } else if(string.Equals(resp, "3"))
                {
                    ListarVeiculos();
                } else if(string.Equals(resp, "4"))
                {
                    WriteLine("Pressione uma tecla para continuar"); ReadLine();
                    break;
                } else 
                {
                    WriteLine("Opção Invalida!");
                }
                WriteLine("Pressione uma tecla para continuar"); ReadLine();
            }
        }
    }
}