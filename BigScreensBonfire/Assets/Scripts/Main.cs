using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Main : MonoBehaviour
{
    private Connection _connection;
    private readonly Dictionary<string, ClientData> _clients = new Dictionary<string, ClientData>();
    void Awake()
    {
        _connection = new Connection("https://bigscreens.herokuapp.com/socket.io/", "Balls", "game");
        //_connection = new Connection("http://10.18.15.82:8000/socket.io/", "Balls", "game");
        _connection.OnConnect(() =>
        {
            Debug.Log("CONNECTED");
        });
        _connection.OnDisconnect(() =>
        {
            Debug.Log("DISCONNECTED");
        });
        _connection.OnOtherConnect((id, type) =>
        {
            Debug.Log($"OTHER CONNECTED: {id} {type}");
        });
        _connection.OnOtherDisconnect((id, type) =>
        {
            Debug.Log($"OTHER DISCONNECTED: {id} {type}");
        });
        _connection.OnError((err) =>
        {
            Debug.LogError(err);
        });
        _connection.On("create-fire-texts", (string sourceId, string message) =>
        {
            Debug.Log($"SENDING FIRE TEXT FOR {sourceId}");
            if (GetDataForClient(sourceId, out var data))
            {
                data.Message = message;
            }
            //var ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //ball.transform.localScale = new Vector3(50, 50, 50);
            //ball.AddComponent<Rigidbody>().AddForce(Random.insideUnitCircle * 10000);
            //ball.AddComponent<SphereCollider>();
        });
        _connection.Open();
    }
    private void OnDestroy()
    {
        _connection.Close();
    }

    private void AddClient(string id)
    {
        if (GetDataForClient(id, out var data)) data.Destroy();
        _clients[id] = new ClientData();
    }

    private void ClearClient(string id)
    {
        if (GetDataForClient(id, out var data)) data.Destroy();
        _clients.Remove(id);
    }

    private void ClearAllClients()
    {
        foreach (var entry in _clients)
        {
            entry.Value.Destroy();
        }
        _clients.Clear();
    }

    private bool GetDataForClient(string clientId, out ClientData data)
    {
        if (clientId == null || !_clients.ContainsKey(clientId)) //?
        {
            data = null;
            return false;
        }

        data = _clients[clientId];
        return true;
    }
}