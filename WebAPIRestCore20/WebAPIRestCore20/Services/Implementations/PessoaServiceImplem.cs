using System.Collections.Generic;
using System.Threading;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Services.Implementations
{
    public class PessoaServiceImplem : IPessoaService
    {
        private volatile int count;

        public Pessoa Create(Pessoa pessoa)
        {
            return pessoa;
        }

        public void Delete(int Id)
        {
        }

        public List<Pessoa> FindAll()
        {
            List<Pessoa> Pessoas = new List<Pessoa>();
            for (int i = 0; i < 8; i++)
            {
                Pessoa pessoa = MockPessoa(i);
                Pessoas.Add(pessoa);
            }

            return Pessoas;
        }

        public Pessoa FindByID(int Id)
        {
            return new Pessoa {Id = Id,
                               Nome = "Ricardo",
                               SobreNome = "Cunha",
                               Endereco = "Rua Tiradentre, 1837 - Bloco 11 / Apto 71. - Sta Terezinha - São Bernardo do Campo - SP - Cep 09781-220",
                               Genero = "Masculino"
            };
        }

        public Pessoa Update(Pessoa pessoa)
        {
            return pessoa;
        }

        private Pessoa MockPessoa(int i)
        {
            return new Pessoa
            {
                Id = IncrementAndGet(),
                Nome = $"Nome Pessoa {i}",
                SobreNome = $"Sobrenome Pessoa {i}",
                Endereco = $"Endereço Pessoa {i}",
                Genero = $"Genero Pessoa {i}"
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
