using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] int _healingObj;
    [SerializeField] int _dmgPoints;
    [SerializeField] float speed;
    [SerializeField] Vector3 size;
    [SerializeField] Vector3 movement;
    [SerializeField] Quaternion rotation;


    public int HealUp () => _health += _healingObj;      // Método de curación
    public int RecieveDmg () => _health -= _dmgPoints;   // Método de daño
    public void MoveForward (){                          // Método de movimiento
        movement = transform.position;
        movement.x += 0.1f;
        transform.position = movement;
    }

    public void Initialize() {
        _health = 80;
        speed = 0.3f;
        size = new Vector3(2, 2, 2);
        rotation = new Quaternion(0, 1, 0, 5);

        _healingObj = 20;
        _dmgPoints = 35;
    }


    // As soon as the game starts
    void Awake() {

        // Se definen las variables
        Initialize();


        // Se aumenta el scale a 2
        transform.localScale += size;
        Debug.Log("I'm now twice as big");
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I'm at " + _health + " health");
        HealUp(); // Recibo HPs
        Debug.Log("I've healed up and my health is now " + _health);

        RecieveDmg(); // Recibo daño
        Debug.LogWarning("I've been hit, my current health is " + _health);


        MoveForward(); // Declaro la direccioón

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += movement * speed; // Me muevo en una dirección con una velocidad determinada
        Debug.Log("I'm moving on the X axis" + movement + " at " + speed + " speed" );
    }
}
