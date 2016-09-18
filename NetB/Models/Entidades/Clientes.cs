namespace NetB.Models.Entidades
{
    public class Clientes
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string cpf_cnpj { get; set; }
        public string email { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public string Responsavel { get; set; }
        public string Endereco { get; set; }
        public bool Status { get; set; }
    }
}