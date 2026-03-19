import requests
import json
from concrete_strategies import ConsoleStrategy, KafkaStrategy, RedisStrategy, FileStrategy

class DataManager:
    def __init__(self, strategy):
        self.strategy = strategy

    def process_data(self, data_list):
        for item in data_list:
            self.strategy.save(item)

def fetch_fire_data(limit=10):
    url = f"https://data.cityofnewyork.us/resource/8m42-w767.json?$limit={limit}"
    print(f"Отримання даних...")
    response = requests.get(url)
    return response.json() if response.status_code == 200 else []

if __name__ == "__main__":
    with open('config.json', 'r') as f:
        config = json.load(f)
    
    mapping = {
        "console": ConsoleStrategy(),
        "kafka": KafkaStrategy(),
        "redis": RedisStrategy(),
        "file": FileStrategy()
    }
    
    selected_target = config.get("output_target", "console")
    strategy = mapping.get(selected_target, ConsoleStrategy())
    
    data = fetch_fire_data()
    manager = DataManager(strategy)
    manager.process_data(data)