namespace GestaoEquipamentos.ConsoleApp {
    internal class Equipamento {
        private string nome, numeroSerie, fabricante, data;
        private double preco;

        public Equipamento(string nome, string numeroSerie, string fabricante, double preco, string data) {
            this.nome = nome;
            this.numeroSerie = numeroSerie;
            this.fabricante = fabricante;
            this.preco = preco;
            this.data = data;
        }
        public void MostrarEquipamento() {
            Console.WriteLine($"Nome: {this.nome}\nNumero de série: {this.numeroSerie}");
            Console.WriteLine($"Fabricante: {this.fabricante}\nData de fabricação: {this.data}");
            Console.WriteLine($"Preço: R${this.preco}");
            Console.WriteLine("------------------------");
        }

        public string RetornaNome() {
            return this.nome;
        }
    }
}
