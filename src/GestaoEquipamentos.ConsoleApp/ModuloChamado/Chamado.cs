using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    internal class Chamado
    {
        private string titulo, descricao;
        private Equipamento equipamento;
        private DateTime dataAbertura;

        public Chamado(string titulo, string descricao, Equipamento equipamento)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.equipamento = equipamento;
        }
        public Chamado(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.equipamento = equipamento;
            this.dataAbertura = dataAbertura;
        }

        public void MostrarChamado()
        {
            Console.WriteLine($"Nome: {this.titulo}\nDescrição: {this.descricao}");
            Console.WriteLine($"Equipamento:");
            equipamento.MostrarEquipamento();
            Console.WriteLine($"\nData de abertura: {this.dataAbertura.Date.ToString("dd/MM/yyyy")}");
            Console.WriteLine("------------------------");
        }

        public string RetornaTitulo()
        {
            return this.titulo;
        }
        public DateTime RetornaData()
        {
            return this.dataAbertura;
        }
    }
}
