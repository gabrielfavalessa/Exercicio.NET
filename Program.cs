using System;

namespace Revisão
{
    class Program
    {
        static void Main(string[] args)
        {
            int indiceAluno = 0;
            Aluno[] alunos = new Aluno[5];

            string opcaoUsuario = ObterOpção();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.nome = Console.ReadLine();

                        Console.WriteLine("Digite a nota do aluno:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }
                        
                        alunos[indiceAluno] = aluno;

                        indiceAluno++;

                        break;

                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.nome))
                            {
                                Console.WriteLine($"ALUNO: {a.nome} - NOTA: {a.nota}");
                            }
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        int nrAlunos = 0;

                        for(int i=0; i< alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].nome))
                            {
                                notaTotal = notaTotal + alunos[i].nota;
                                nrAlunos++;
                            }
                        }
                        
                        var mediaGeral = notaTotal/nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL - {notaTotal/nrAlunos} - CONCEITO: {conceitoGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                Console.WriteLine("");

                opcaoUsuario = ObterOpção();

            }
        }

        private static string ObterOpção()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
