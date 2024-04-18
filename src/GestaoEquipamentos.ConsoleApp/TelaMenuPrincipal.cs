using GestaoEquipamentos.ConsoleApp.ModuloChamado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class TelaMenuPrincipal
    {
        TelaCadastroEquipamento telaEquipamento = new();
        TelaCadastroChamado telaChamado = new();
        private int MostrarMenu()
        {
            char opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestão de Chamados\n");
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
        private void ChamarSubmenus()
        {
            while (true)
            {
                int menuPrincipal = MostrarMenu();

                if (menuPrincipal == 0)
                    break;

                if (menuPrincipal != 1 && menuPrincipal != 2)
                {
                    Notificador.AvisoColorido("Opção Inválida! Tente novamente!", ConsoleColor.Red);
                    continue;
                }

                if (menuPrincipal == 1)
                {
                    telaEquipamento.AcessarMenuEquipamentos();
                }
                if (menuPrincipal == 2)
                {
                    telaChamado.AcessarMenuChamados();
                }

            }
        }
        public void IniciarPrograma()
        {
            ChamarSubmenus();
        }
    }
}
