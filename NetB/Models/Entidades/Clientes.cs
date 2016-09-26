namespace NetB.Models.Entidades
{
    public class Clientes
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf_cnpj { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string relefone2 { get; set; }
        public string tesponsavel { get; set; }
        public string endereco { get; set; }
        public bool status { get; set; }
    }
}