players = [
    {"name": "Player1", "score": 250},
    {"name": "Player2", "score": 150},
    {"name": "Player3", "score": 300},
    {"name": "Player4", "score": 100},
    {"name": "Player5", "score": 275},
    {"name": "Player6", "score": 200},
    {"name": "Player7", "score": 50},
    {"name": "Player8", "score": 125},
    {"name": "Player9", "score": 175},
    {"name": "Player10", "score": 225},
    {"name": "Player11", "score": 350},
    {"name": "Player12", "score": 400},
]

# Sort players by score in descending order
sorted_players = sorted(players, key=lambda x: x["score"], reverse=True)

# Print top 10 players
print("Top 10 players:")
for player in sorted_players[:10]:
    print(f"Name: {player['name']}, Score: {player['score']}")
