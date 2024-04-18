using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaCadastroEquipamento telaEquipamento = new();
            while (true)
            {
                int menuPrincipal = telaEquipamento.MenuPrincipal();

                if (menuPrincipal == 0)
                    break;

                if (menuPrincipal != 1)
                {
                    Notificador.AvisoColorido("Opção Inválida! Tente novamente!", ConsoleColor.Red);
                    continue;
                }
                while (true)
                {
                    int menuSecundario = telaEquipamento.MenuSecundario();

                    if (menuSecundario == 0)
                        break;


                    if (menuSecundario != 1 && menuSecundario != 2 && menuSecundario != 3 && menuSecundario != 4)
                    {
                        Notificador.AvisoColorido("Opção Inválida! Tente novamente!", ConsoleColor.Red);
                        continue;
                    }

                    if (menuSecundario == 1)
                        telaEquipamento.Inserir();

                    else if (menuSecundario == 2)
                        telaEquipamento.Visualizar();

                    else if (menuSecundario == 3)
                        telaEquipamento.Editar();

                    else
                        telaEquipamento.Remover();
                }
            }
        }
    }
}
