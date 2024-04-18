namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    internal class Equipamento
    {
        private string nome, numeroSerie, fabricante;
        private double preco;
        private DateTime dataFabricacao;
        public Equipamento(string nome, string numeroSerie, string fabricante, double preco, DateTime data)
        {
            this.nome = nome;
            this.numeroSerie = numeroSerie;
            this.fabricante = fabricante;
            this.preco = preco;
            this.dataFabricacao = data;
        }
        public void MostrarEquipamento()
        {
            Console.WriteLine($"Nome: {this.nome}\nNumero de série: {this.numeroSerie}");
            Console.WriteLine($"Fabricante: {this.fabricante}\nData de fabricação: {this.dataFabricacao.Date.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Preço: R${this.preco}");
            Console.WriteLine("------------------------");
        }

        public string RetornaNome()
        {
            return this.nome;
        }
    }
}
