using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Main : MonoBehaviour
{
    private Connection _connection;
    void Awake()
    {
        _connection = new Connection("https://bigscreens.herokuapp.com/socket.io/", "Balls", "game");
        //_connection = new Connection("http://10.18.15.82:8000/", "Balls", "game");
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


        _connection.On("create-text", (id) =>
        {
            Debug.Log("creating text");
           
        });
        _connection.Open();
    
}


}