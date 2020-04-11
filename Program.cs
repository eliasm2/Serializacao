using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;                                    // Para TextWriter
using System.Xml;
using System.Xml.Serialization;                     // Serialização em XML

namespace Serialização
{
    public class Aluno                                     // Definição da Classe
    {
        public string Nome { get; set; }
        public string Mail { get; set; }
        public string TelCel { get; set; }
        public DataDDMM Aniversário { get; set; }
    }

    public class DataDDMM
    {
        public string Dia { get; set; }
        public string Mês { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TextWriter MeuWriter = new StreamWriter(@"D:\Lixo\ArquivoAlunos.xml");      // TextWriter - Para escrever no XML
            List<Aluno> ListaAluno = new List<Aluno>();                                 // Lista de Alunos
            Aluno xAluno;                                                               // Definição de Tipo Aluno
         
            xAluno = new Aluno();                                                       // Objeto Aluno

            xAluno.Nome = "Gustavo Campos do Nascimento";
            xAluno.Mail = "gcampos@gmail.com";
            xAluno.TelCel = "9905.5089";
            xAluno.Aniversário = new DataDDMM();                                        // Objeto Aniversário
            xAluno.Aniversário.Dia="28";
            xAluno.Aniversário.Mês = "Março";

            ListaAluno.Add(xAluno);

            xAluno = new Aluno();

            xAluno.Nome = "Luiz Cláudio Pena";
            xAluno.Mail = "lucapena@terra.com.br";
            xAluno.TelCel = "8890.6070";
            xAluno.Aniversário = new DataDDMM();
            xAluno.Aniversário.Dia = "16";
            xAluno.Aniversário.Mês = "Setembro";

            ListaAluno.Add(xAluno);

            xAluno = new Aluno();

            xAluno.Nome = "Regina Maria Dias";
            xAluno.Mail = "reginamdias@yahoo.com";
            xAluno.TelCel = "9933.7876";
            xAluno.Aniversário = new DataDDMM();
            xAluno.Aniversário.Dia = "25";
            xAluno.Aniversário.Mês = "Outubro";

            ListaAluno.Add(xAluno);

            // Serialização
            XmlSerializer Serialização = new XmlSerializer(ListaAluno.GetType());       // Passa toda a lista...

            //Serializa usando o TextWriter
            Serialização.Serialize(MeuWriter, ListaAluno);                              // Toda a lista...

            Console.WriteLine("Arquivo XML gerado com sucesso!");

            MeuWriter.Close();                  // Fecha o Arquivo

            Console.ReadKey();

            Console.Clear();

            // Deserialização - Leitura do XML para a ListaAluno
            ListaAluno.Clear();

            FileStream Arquivo=new FileStream(@"D:\Lixo\ArquivoAlunos.xml",FileMode.Open);      // Abre Arquivo para Leitura
            ListaAluno = (List<Aluno>)Serialização.Deserialize(Arquivo);                        // Deserializaa

            foreach (Aluno x in ListaAluno)
            {
                Console.WriteLine("\n{0} - {1} de {2}", x.Nome, x.Aniversário.Dia, x.Aniversário.Mês);
                Console.WriteLine("Mail de Contato: {0}", x.Mail);
                Console.WriteLine("Telefone: {0}", x.TelCel);
            }

            Console.ReadKey();

            Arquivo.Close();            // Fecha o Arquivo
        }
    }
}
