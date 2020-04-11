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

    }

    class Program
    {
        static void Main(string[] args)
        {
            TextWriter MeuWriter = new StreamWriter(@"D:\Lixo\ArquivoAlunos.xml");      // TextWriter - Para escrever no XML
            Aluno[] VetorAlunos = new Aluno[3];
            
            Aluno xAluno;
             
            xAluno=new Aluno();
            
            xAluno.Nome = "Gustavo Campos do Nascimento";
            xAluno.Mail = "gcampos@gmail.com";
            xAluno.TelCel = "9905.5089";
            
            VetorAlunos[0]=xAluno;

            xAluno=new Aluno();

            xAluno.Nome = "Luiz Cláudio Pena";
            xAluno.Mail = "lucapena@terra.com.br";
            xAluno.TelCel = "8890.6070";
            
            VetorAlunos[1]=xAluno;

            xAluno=new Aluno();

            xAluno.Nome = "Regina Maria Dias";
            xAluno.Mail = "reginamdias@yahoo.com";
            xAluno.TelCel = "9933.1234";

            VetorAlunos[2]=xAluno;
            
            // Serialização
            XmlSerializer Serialização = new XmlSerializer(VetorAlunos.GetType());       // Passa toda a lista...

            //Serializa usando o TextWriter
            Serialização.Serialize(MeuWriter, VetorAlunos );                              // Toda a lista...

            Console.WriteLine("Arquivo XML gerado com sucesso!");

            MeuWriter.Close();                  // Fecha o Arquivo

            Console.ReadKey();

            Console.Clear();

            // Deserialização - Leitura do XML para a ListaAluno
            

            FileStream Arquivo=new FileStream(@"D:\Lixo\ArquivoAlunos.xml",FileMode.Open);      // Abre Arquivo para Leitura
            VetorAlunos  = (Aluno[])Serialização.Deserialize(Arquivo);                        // Deserializaa

            foreach (Aluno x in VetorAlunos)
            {
                Console.WriteLine("\n{0}", x.Nome);
                Console.WriteLine("Mail de Contato: {0}", x.Mail);
                Console.WriteLine("Telefone: {0}", x.TelCel);
            }

            Console.ReadKey();

            Arquivo.Close();            // Fecha o Arquivo*/
        }
    }
}
