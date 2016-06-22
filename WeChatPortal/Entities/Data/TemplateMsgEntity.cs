namespace WeChatPortal.Entities.Data
{
    public class TemplateMsgEntity<T>
    {
        public string touser { get; set; }

        public string template_id { get; set; }

        public string url { get; set; }

        public T data { get; set; }
    }

    public class TemplateDataEntity
    {
        public TemplateDataEntity(string value,string color)
        {
            this.value = value;
            this.color = color;

        }
        public string  value { get; set; }

        public string color { get; set; }
    }
}