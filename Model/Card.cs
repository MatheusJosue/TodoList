namespace Model
{
    public class Card
    {
        public Card(string titulo, string descricao, string ownerName, string ownerId, DateTime data, EnumStatusCard status)
        {
            Titulo = titulo;
            Descricao = descricao;
            OwnerName = ownerName;
            OwnerId = ownerId;
            Data = data;
            Status = status;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string OwnerName {  get; set; }
        public string OwnerId { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusCard Status { get; set; }

    }

    public enum EnumStatusCard
    {
        Todo = 0,
        Doing = 1,
        Test = 2,
        Done = 3
    }
}
