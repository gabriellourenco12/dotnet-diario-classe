using System;

namespace Diario_classe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Informe o numero de alunos na turma");
            int turma = int.Parse(Console.ReadLine());
            Aluno[] alunos = new Aluno[turma];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        do
                        {
                            Console.WriteLine("Informe a nota do aluno");
                            string nota = Console.ReadLine();
                            aluno.Nota = Nota_Decimal(nota);
                        } while (aluno.Nota < 0);
                        
                       
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;

                        Conceito conceitoGeral;
                        if (mediaGeral <= 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral <= 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral <= 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral <= 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {Decimal.Round(mediaGeral,2)} - CONCEITO GERAL {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

        }


        public static decimal Nota_Decimal(string nota)
        {
            if (decimal.TryParse(nota, out decimal nota_certa))
                {
                    return (nota_certa);
                }
            else
                {
                    Console.WriteLine("Valor da nota deve ser decimal!");
                    Console.WriteLine();
                    return -1;
                }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
