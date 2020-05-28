namespace Revisão
{
    public struct Aluno
    {
        public string nome { get; set; }

        public decimal nota { get; set; }
    }

    public class Students
    {
        public Student atual;

        public void incluir_Aluno(string nome, decimal nota)
        {
            atual = new Student(nome, nota, atual);
        }

        public decimal media()
        {
            int qtde_alunos = 0;
            decimal soma_total = 0;
            Student aux_aluno = atual;

            while (aux_aluno != null)
            {
                qtde_alunos++;
                soma_total += aux_aluno.nota;
                aux_aluno = aux_aluno.anterior;
            }

            return soma_total/qtde_alunos;

        }
        
    }

    public class Student
    {
            public string nome;

            public decimal nota;

            public Student anterior;

            public Student(string nome_passado, decimal nota_passada, Student anterior_passado)
            {
                this.nome = nome_passado;
                this.nota = nota_passada;
                this.anterior = anterior_passado;
            }

            public (string, decimal, Student) retorna_Dados()
            {
                return (nome, nota, anterior);
            }
    }
}