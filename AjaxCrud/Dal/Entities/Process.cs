namespace AjaxCrud.Dal.Entities
{
    public class Process
    {
        public int ProcessId { get; set; }
        public string Note { get; set; }
        public bool IsComplated { get; set; }
        public DateTime Date { get; set; }
    }
}
