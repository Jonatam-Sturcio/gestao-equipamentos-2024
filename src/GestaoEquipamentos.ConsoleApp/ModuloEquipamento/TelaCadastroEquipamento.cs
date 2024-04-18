namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    internal class TelaCadastroEquipamento
    {
        private RepositorioEquipamento repositorio = new();
        private void Cabecalho()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos\n");
        }
        private string ReceberInformacao(string textoApresentado)
        {
            string informacao = "";
            do
            {
                Cabecalho();
                Console.WriteLine(textoApresentado);

                informacao = Console.ReadLine();
                if (informacao.Length != 0)
                    break;

                Notificador.AvisoColorido("É necessário digitar o que foi solicitado!", ConsoleColor.Red);

            } while (true);
            return informacao;
        }
        private Equipamento ObterEquipamento()
        {
            string nomeEquipamento;
            while (true)
            {
                nomeEquipamento = ReceberInformacao("Informe o nome do equipamento: ");
                if (nomeEquipamento.Length < 6)
                {
                    Notificador.AvisoColorido("O nome deve conter no mínimo 6 caracteres!", ConsoleColor.Red);
                    continue;
                }
                break;
            }
            string numeroSerie = ReceberInformacao("Informe o numero de serie do equipamento: ");
            string fabricante = ReceberInformacao("Informe o nome do fabricante: ");
            double valorEquipamento = double.Parse(ReceberInformacao("Informe o preço do equipamento: "));
            string dataFabricacao = ReceberInformacao("Informe a data de fabricação do equipamento: ");
            return new Equipamento(nomeEquipamento, numeroSerie, fabricante, valorEquipamento, dataFabricacao);
        }
        public int MenuPrincipal()
        {
            char opcao;
            do
            {
                Cabecalho();
                Console.WriteLine(" 1 - Cadastrar Equipamentos");
                Console.WriteLine(" 2 - Controle de chamados");
                Console.WriteLine(" 0 - Sair\n");

                Console.WriteLine("Informe a opção desejada: ");
                opcao = Console.ReadLine()[0];

                if (char.IsNumber(opcao))
                    break;

                Notificador.AvisoColorido("Apenas números sao permitidos! Tente novamente!", ConsoleColor.Red);

            } while (true);

            return Convert.ToInt32(opcao + "");
        }
        public int MenuSecundario()
        {
            char opcao;
            do
            {
                Cabecalho();
                Console.WriteLine(" 1 - Inserir novo equipamento");
                Console.WriteLine(" 2 - Visualizar equipamentos");
                Console.WriteLine(" 3 - Editar equipamentos");
                Console.WriteLine(" 4 - Excluir equipamentos");
                Console.WriteLine(" 0 - Sair\n");

                Console.WriteLine("Informe a opção desejada: ");
                opcao = Console.ReadLine()[0];

                if (char.IsNumber(opcao))
                    break;

                Notificador.AvisoColorido("Apenas números sao permitidos! Tente novamente!", ConsoleColor.Red);

            } while (true);

            return Convert.ToInt32(opcao + "");
        }
        public void Inserir()
        {
            Cabecalho();

            Equipamento equipamento = ObterEquipamento();
            if (repositorio.EquipamentoExiste(equipamento.RetornaNome()))
            {
                Notificador.AvisoColorido("Já existe um equipamento com esse nome!", ConsoleColor.Red);
                return;
            }

            repositorio.InserirEquipamento(equipamento);
            Console.ReadKey();
        }
        public void Visualizar()
        {
            if (repositorio.ListaEstaVazia())
            {
                Notificador.AvisoColorido("O inventário não possui nenhum equipamento!", ConsoleColor.Red);
                return;
            }

            Cabecalho();

            repositorio.MostrarEquipamentos();
            Console.ReadKey();
        }
        public void Editar()
        {
            if (repositorio.ListaEstaVazia())
            {
                Notificador.AvisoColorido("O inventário não possui nenhum equipamento!", ConsoleColor.Red);
                return;
            }
            Cabecalho();

            string nomeEquipamento = ReceberInformacao("Informe o nome do equipamento a ser editado: ");

            if (!repositorio.EquipamentoExiste(nomeEquipamento))
            {
                Notificador.AvisoColorido("Não existem um equipamento com esse nome!", ConsoleColor.Red);
                return;
            }

            Equipamento equipamento = ObterEquipamento();
            repositorio.EditarEquipamento(nomeEquipamento, equipamento);
        }
        public void Remover()
        {
            if (repositorio.ListaEstaVazia())
            {
                Notificador.AvisoColorido("O inventário não possui nenhum equipamento!", ConsoleColor.Red);
                return;
            }
            Cabecalho();

            string nomeEquipamento = ReceberInformacao("Informe o nome do equipamento a ser editado: ");

            if (!repositorio.EquipamentoExiste(nomeEquipamento))
            {
                Notificador.AvisoColorido("Não existem um equipamento com esse nome!", ConsoleColor.Red);
            }
            repositorio.RemoverEquipamento(nomeEquipamento);
        }
    }
}
