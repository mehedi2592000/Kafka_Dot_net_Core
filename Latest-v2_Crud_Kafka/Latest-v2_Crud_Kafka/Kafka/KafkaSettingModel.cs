namespace Latest_v2_Crud_Kafka.Kafka
{
    public class KafkaSettingModel
    {
        public string BootstrapServers { get; set; }
        public Dictionary<string, string> Topics { get; set; }
        public string GroupId { get; set; }
    }
}
