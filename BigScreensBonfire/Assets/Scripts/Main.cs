using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private Connection _connection;

    void Awake()
    {
        _connection = new Connection("https://bigscreens.herokuapp.com/socket.io/", "Bonfire", "game");
        //_connection = new Connection("http://10.18.15.82:8000/", "Balls", "game");

        _connection.OnConnect(() => { Debug.Log("CONNECTED"); });

        _connection.OnDisconnect(() => { Debug.Log("DISCONNECTED"); });

        _connection.OnOtherConnect((id, type) =>
            {
                Debug.Log($"OTHER CONNECTED: {id} {type}");
                ClientConnected(id);
            }
        );

        _connection.OnOtherDisconnect((id, type) =>
        {
            Debug.Log($"OTHER DISCONNECTED: {id} {type}");
            ClientDisconnected(id);
        });

        _connection.OnError((err) => { Debug.LogError(err); });
        _connection.On("create-fire-texts", (id) =>
        {
            Debug.Log($"CREATING BALL FOR {id}");
            var ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ball.transform.localScale = new Vector3(50, 50, 50);
            ball.AddComponent<Rigidbody>
                ().AddForce(Random.insideUnitCircle * 10000);
            ball.AddComponent<SphereCollider>();
        });

        _connection.Open();


        _connection.On("create-text", (string sender, string text) =>
        {
            Debug.Log("creating text");
            var roomIndex = GetRoomForClient(sender);
            if (roomIndex == -1)
            {
                Debug.LogError($"Could not find room for sender: {sender}");
            }
            else
            {
                Debug.Log($"Sending text to room {roomIndex}: {text}");
                _rooms[roomIndex].ForEach(playerInRoom =>
                {
                    if (playerInRoom != sender)
                    {
                        _connection.SendTo("text", playerInRoom, text);
                    }
                });
            }
        });
        _connection.Open();
    }

    const int NUM_PARTNERS = 4;
    private readonly List<List<string>> _rooms = new List<List<string>>();

    // Returns the index of the room the client is in or -1 if not found 
    private int GetRoomForClient(string id)
    {
        for (var i = 0; i < _rooms.Count; i++)
        {
            for (var j = 0; j < _rooms[i].Count; j++)
            {
                if (_rooms[i][j] == id) return i;
            }
        }

        return -1;
    }

    private void ClientConnected(string id)
    {
        // join the first room 
        for (var i = 0; i < _rooms.Count; i++)
        {
            var room = _rooms[i];
            if (room.Count < NUM_PARTNERS)
            {
                room.Add(id);
                Debug.Log($"Added player {id} to room {i}");
                return;
            }
        }

        // if one wasn't found create a new room with the new player in it
        _rooms.Add(new List<string> {id});
        Debug.Log($"Added player {id} to room {_rooms.Count - 1}");
    }

    private void ClientDisconnected(string id)
    {
        var roomIndex = GetRoomForClient(id);
        if (roomIndex != -1)
        {
            var room = _rooms[roomIndex];
            for (var i = 0; i < room.Count; i++)
            {
                if (room[i] == id)
                {
                    room.RemoveAt(i);
                    var playersLeftInRoom = room.Count;
                    // If there are noo players left in the room delete the room
                    if (playersLeftInRoom == 0)
                    {
                        _rooms.RemoveAt(roomIndex);
                    }
                    // Otherwise let everyone else in the room know you left
                    else
                    {
                        _rooms[roomIndex].ForEach(playerInRoom => { _connection.SendTo("leave room", playerInRoom); });
                    }
                    return;
                }
            }
        }
        else
        {
            Debug.LogError($"Client {id} disconnected but could not find them in a room");
        }
    }
}