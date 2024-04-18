namespace GestaoEquipamentos.ConsoleApp
{
    internal class RepositorioEquipamento
    {
        private Equipamento[] ListaEquipamentos;

        public RepositorioEquipamento()
        {
            ListaEquipamentos = new Equipamento[20];
        }
        public bool ListaEstaVazia()
        {
            int contador = 0;
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] is not null) contador++;
            }
            return contador == 0;
        }
        public void InserirEquipamento(Equipamento equipamento)
        {
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] is null)
                {
                    ListaEquipamentos[i] = equipamento;
                    break;
                }
            }
            Notificador.AvisoColorido("Equipamento cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void MostrarEquipamentos()
        {
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] is not null)
                {
                    ListaEquipamentos[i].MostrarEquipamento();
                }
            }
        }

        public void EditarEquipamento(string nomeEquipamento, Equipamento novoEquipamento)
        {
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] is not null && ListaEquipamentos[i].RetornaNome() == nomeEquipamento)
                {
                    ListaEquipamentos[i] = novoEquipamento;
                    Notificador.AvisoColorido("Equipamento editado com sucesso!", ConsoleColor.Green);
                }
            }
        }

        public void RemoverEquipamento(string nomeEquipamento)
        {
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] is not null && ListaEquipamentos[i].RetornaNome() == nomeEquipamento)
                {
                    ListaEquipamentos[i] = null;
                    Notificador.AvisoColorido("Equipamento removido com sucesso!", ConsoleColor.Green);
                }
            }
        }
        public bool EquipamentoExiste(string nomeEquipamento)
        {
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] is not null && ListaEquipamentos[i].RetornaNome() == nomeEquipamento)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
