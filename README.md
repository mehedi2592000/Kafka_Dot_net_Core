# Kafka in .NET Core

Kafka is an open-source, distributed event platform designed for building real-time data processing. It acts as a message broker. There are several message brokers available, such as RabbitMQ, Redis, and Kafka, but Kafka stands out as more reliable and efficient for several reasons: 1. High throughput 2. Real-time data streaming 3. Highly scalable, fault-tolerant, and capable of handling big data.

## Kafka Architecture

1. **Producer**: In the application, the producer sends messages to Kafka.
2. **Broker**: A server in Kafka that stores data, serves client requests, and handles data replication and topic partitioning.
3. **Topic**: Each broker has multiple topics. The producer sends data to specific topics, and consumers retrieve data from these topics. Different producers can send data to different topics, and data is organized accordingly.
4. **Partition**: Each topic has partitions, allowing Kafka to balance the load and retrieve data efficiently when consumers request it.
5. **Replication Factor**: Each partition in a topic is replicated across multiple brokers to ensure data availability and fault tolerance.
6. **Consumer**: Consumers retrieve data from Kafka. A **Consumer Group** consists of multiple consumers that work together to process data from Kafka topics. Each consumer in the group reads from one or more partitions, but each partition is consumed by only one consumer within a group.

## Kafka Installation

### Zookeeper
Zookeeper is a tool used for load balancing in Kafka.

1. **Download Kafka**: The latest Kafka version includes Zookeeper, so a separate installation is unnecessary. [Download here](https://kafka.apache.org/downloads).
2. **Configure Kafka and Zookeeper**: Copy the Kafka folder to your desired location (e.g., C drive) and set up the environment variables. Go to `config -> server.properties` and `config -> zookeeper.properties` to configure the local directories (e.g., `log.dirs=C:/kafka/kafka_2.13-3.8.1/tmp/kafka-logs`).
3. **Start Zookeeper**: `C:\kafka\kafka_2.13-3.8.1> .\bin\windows\zookeeper-server-start.bat .\config\zookeeper.properties`
4. **Start Kafka**: `C:\kafka\kafka_2.13-3.8.1>.\bin\windows\kafka-server-start.bat .\config\server.properties`

Kafka configuration is now complete.

If you want to create a topic, partition, producer, and consumer in the CLI, use the following commands:

1. **Create Topic & Partition**: `C:\kafka\kafka_2.13-3.8.1>.\bin\windows\kafka-topics.bat --create --topic test-topic-cf --bootstrap-server localhost:9092 --partitions 3 --replication-factor 1`
2. **Check Producer**: `C:\kafka\kafka_2.13-3.8.1>.\bin\windows\kafka-console-producer.bat --topic test-topic-cf --bootstrap-server localhost:9092`
3. **Check Consumer**: `C:\kafka\kafka_2.13-3.8.1>.\bin\windows\kafka-console-consumer.bat --topic test-topic-cf --bootstrap-server localhost:9092 --from-beginning`

## Resource Links

1. **Installation Help**: [YouTube - Let's Code with Kundan Kumar](https://www.youtube.com/watch?v=gE0sWA2kTfk&ab_channel=Let%27sCodewithKundanKumar)
2. **Architecture Help**: [YouTube](https://www.youtube.com/watch?v=ZJJHm_bd9Zo&t=2922s) | [Medium Article](https://medium.com/swlh/apache-kafka-what-is-and-how-it-works-e176ab31fcd5)
