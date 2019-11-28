using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Text input;
    public Text input2;
    public Text input3;
    public Text input4;
    public Text input5;
    public Text input6;
    public Text input7;

    private int count = 0;
    private Connection _connection;
    public int numRooms = 10;
    private List<List<string>> _rooms;

    //GameObject t = new GameObject("textboxes");

    private Queue<string> _texts = new Queue<string>();
    
    void Awake()
    {
        _rooms = new List<List<string>>();
        for (var i = 0; i < numRooms; i++)
        {
            _rooms.Add(new List<string>());
        }
        
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

        _connection.Open();


        _connection.On("create-text", (string sender, string text) =>
        {
            Debug.Log("creating text");
            _texts.Enqueue(text);
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
                    _connection.SendTo("text", playerInRoom, text);
                });
            }
        });
        _connection.Open();
    }

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

    private int GetLeastPopulatedRoomIndex()
    {
        var leastPopulation = Int32.MaxValue;
        var leastIndex = -1;
        for (var i = 0; i < _rooms.Count; i++)
        {
            var room = _rooms[i];
            if (room.Count < leastPopulation)
            {
                leastPopulation = room.Count;
                leastIndex = i;
            } 
        }
        return leastIndex;
    }
    
    private void ClientConnected(string id)
    {
        var roomIndex = GetLeastPopulatedRoomIndex();
        var room = _rooms[roomIndex];
        room.Add(id);
        Debug.Log($"Added player {id} to room {roomIndex}");
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
                    // Let everyone else in the room know you left
                    if (playersLeftInRoom > 0)
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

    void Update()
    {
        if (count > 6)
        {
            count = 0;
        }
        while (_texts.Count > 0)
        {
            var text = _texts.Dequeue();
            Debug.Log(text);
            //text = "sdf";
            if (count == 0)
            {
                input.text = text;
                count += 1;
            }
            else if(count == 1)
            {
                input2.text = text;
                count += 1;
            }
            else if (count == 2)
            {
                input3.text = text;
                count += 1;
            }
            else if (count == 3)
            {
                input4.text = text;
                count += 1;
            }
            else if (count == 4)
            {
                input5.text = text;
                count += 1;
            }
            else if (count == 5)
            {
                input5.text = text;
                count += 1;
            }
            else if (count == 6)
            {
                input7.text = text;
                count += 1;
            }

        }
    }
    
}