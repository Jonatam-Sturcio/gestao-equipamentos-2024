namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    internal class RepositorioChamado
    {
        private Chamado[] ListaChamados;

        public RepositorioChamado()
        {
            ListaChamados = new Chamado[20];
        }
        public bool ListaEstaVazia()
        {
            int contador = 0;
            for (int i = 0; i < ListaChamados.Length; i++)
            {
                if (ListaChamados[i] is not null) contador++;
            }
            return contador == 0;
        }
        public void InserirChamado(Chamado chamado)
        {
            for (int i = 0; i < ListaChamados.Length; i++)
            {
                if (ListaChamados[i] is null)
                {
                    ListaChamados[i] = chamado;
                    break;
                }
            }
            Notificador.AvisoColorido("Chamado cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void MostrarChamados()
        {
            for (int i = 0; i < ListaChamados.Length; i++)
            {
                if (ListaChamados[i] is not null)
                {
                    ListaChamados[i].MostrarChamado();
                }
            }
        }

        public void EditarChamado(string tituloChamado, Chamado novoChamado)
        {
            for (int i = 0; i < ListaChamados.Length; i++)
            {
                if (ListaChamados[i] is not null && ListaChamados[i].RetornaTitulo() == tituloChamado)
                {
                    ListaChamados[i] = novoChamado;
                    Notificador.AvisoColorido("Chamado editado com sucesso!", ConsoleColor.Green);
                }
            }
        }

        public void RemoverChamado(string tituloChamado)
        {
            for (int i = 0; i < ListaChamados.Length; i++)
            {
                if (ListaChamados[i] is not null && ListaChamados[i].RetornaTitulo() == tituloChamado)
                {
                    ListaChamados[i] = null;
                    Notificador.AvisoColorido("Chamado removido com sucesso!", ConsoleColor.Green);
                }
            }
        }
        public bool ChamadoExiste(string nomeEquipamento)
        {
            for (int i = 0; i < ListaChamados.Length; i++)
            {
                if (ListaChamados[i] is not null && ListaChamados[i].RetornaTitulo() == nomeEquipamento)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
