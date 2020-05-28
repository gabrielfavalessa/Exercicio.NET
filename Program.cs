/*
    Este programa foi construído com base na aula sobre .NET da Digital Innovation One, ministrada pelo professor Gabriel Faraday
*/

using System;

namespace Revisão
{
    class Program
    {
        static void Main(string[] args)
        {
            int indiceAluno = 0;
            Aluno[] alunos = new Aluno[5];

            Students pilha_alunos = new Students();
            string nome_aluno;
            decimal nota_aluno;

            string opcaoUsuario = ObterOpção();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    /*

                        // Solução usando a struct

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
                    */

                        // Solução usando a class
                        
                        Console.WriteLine("Informe o nome do aluno:");
                        nome_aluno = Console.ReadLine();

                        Console.WriteLine("Digite a nota do aluno:");
                        if (!decimal.TryParse(Console.ReadLine(), out nota_aluno))
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }
                        
                        pilha_alunos.incluir_Aluno(nome_aluno, nota_aluno);

                        break;

                    case "2":
                    /*

                        // Solução utilizando o struct

                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.nome))
                            {
                                Console.WriteLine($"ALUNO: {a.nome} - NOTA: {a.nota}");
                            }
                        }
                    */

                        // Solução usando a classe

                        Student a = pilha_alunos.atual;

                        while (a != null)
                        {
                            Console.WriteLine($"ALUNO: {a.nome} - NOTA: {a.nota}");
                            a = a.anterior;
                        }
                        break;

                    case "3":
                    /*

                        // Solução utilizando o struct

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
                    */

                        // Solução utilizando a classe

                        var mediaGeral = pilha_alunos.media();
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

                        Console.WriteLine($"MÉDIA GERAL - {mediaGeral} - CONCEITO: {conceitoGeral}");

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
