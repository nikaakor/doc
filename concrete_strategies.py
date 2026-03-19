import json
from strategy import OutputStrategy

class ConsoleStrategy(OutputStrategy):
    def save(self, data):
        print(f"STDOUT: Incident ID {data.get('starfire_incident_id')}")

class KafkaStrategy(OutputStrategy):
    def save(self, data):
        print(f"KAFKA: Sending event {data.get('starfire_incident_id')} to topic 'fire_incidents'")

class RedisStrategy(OutputStrategy):
    def save(self, data):
        print(f"REDIS: Caching incident {data.get('starfire_incident_id')}")

class FileStrategy(OutputStrategy):
    def save(self, data):
        with open("output_results.txt", "a", encoding="utf-8") as f:
            f.write(json.dumps(data) + "\n")
        print(f"FILE: Записано в output_results.txt")