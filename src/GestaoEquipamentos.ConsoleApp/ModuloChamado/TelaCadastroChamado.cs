using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    internal class TelaCadastroChamado
    {
        private RepositorioChamado repositorio = new();
        private void Cabecalho()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Chamados\n");
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
        private Chamado ObterChamado(bool ehEdicao)
        {
            //A variável bool serve pare diferenciar se estamos criando um chamado ou editando,
            //já que na edição nao podemos mudar a data.

            Equipamento equipamento;
            string tituloChamado = ReceberInformacao("Informe o titulo do chamado: ");
            string descricao = ReceberInformacao("Informe uma descrição para o chamado: ");
            do
            {
                equipamento = new RepositorioEquipamento().RetornaEquipamento(ReceberInformacao("Informe o nome do equipamento do chamado: "));
                if (equipamento != null)
                    break;
                Notificador.AvisoColorido("Equipamento inexistente! Tente novamente", ConsoleColor.Red);
            } while (true);

            if (ehEdicao)
            {
                return new Chamado(tituloChamado, descricao, equipamento);
            }

            DateTime dataAbertura = DateTime.Parse(ReceberInformacao("Informe a data de abertura (dd/mm/aaaa): "));
            return new Chamado(tituloChamado, descricao, equipamento, dataAbertura);
        }
        public int MenuSecundario()
        {
            char opcao;
            do
            {
                Cabecalho();
                Console.WriteLine(" 1 - Abrir Chamado");
                Console.WriteLine(" 2 - Visualizar chamados");
                Console.WriteLine(" 3 - Editar chamados");
                Console.WriteLine(" 4 - Excluir chamados");
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

            Chamado chamado = ObterChamado(false);
            if (repositorio.ChamadoExiste(chamado.RetornaTitulo()))
            {
                Notificador.AvisoColorido("Já existe um chamado com esse nome!", ConsoleColor.Red);
                return;
            }

            repositorio.InserirChamado(chamado);
        }
        public void Visualizar()
        {
            if (repositorio.ListaEstaVazia())
            {
                Notificador.AvisoColorido("Não há nenhum chamado registrado!", ConsoleColor.Red);
                return;
            }

            Cabecalho();

            repositorio.MostrarChamados();
            Console.ReadKey();
        }
        public void Editar()
        {
            if (repositorio.ListaEstaVazia())
            {
                Notificador.AvisoColorido("Não há nenhum chamado registrado!", ConsoleColor.Red);
                return;
            }
            Cabecalho();

            string tituloChamado = ReceberInformacao("Informe o nome do chamado a ser editado: ");

            if (!repositorio.ChamadoExiste(tituloChamado))
            {
                Notificador.AvisoColorido("Não existem um chamado com esse titulo!", ConsoleColor.Red);
                return;
            }

            Chamado chamado = ObterChamado(true);
            repositorio.EditarChamado(tituloChamado, chamado);
        }
        public void Remover()
        {
            if (repositorio.ListaEstaVazia())
            {
                Notificador.AvisoColorido("Não há nenhum chamado registrado!", ConsoleColor.Red);
                return;
            }
            Cabecalho();

            string tituloChamado = ReceberInformacao("Informe o nome do chamado a ser editado: ");

            if (!repositorio.ChamadoExiste(tituloChamado))
            {
                Notificador.AvisoColorido("Não existem um chamado com esse titulo!", ConsoleColor.Red);
            }
            repositorio.RemoverChamado(tituloChamado);
        }
        public void AcessarMenuChamados()
        {
            while (true)
            {
                int menuSecundario = MenuSecundario();

                if (menuSecundario == 0)
                    break;


                if (menuSecundario != 1 && menuSecundario != 2 && menuSecundario != 3 && menuSecundario != 4)
                {
                    Notificador.AvisoColorido("Opção Inválida! Tente novamente!", ConsoleColor.Red);
                    continue;
                }

                if (menuSecundario == 1)
                    Inserir();

                else if (menuSecundario == 2)
                    Visualizar();

                else if (menuSecundario == 3)
                    Editar();

                else
                    Remover();
            }
        }
    }
}
