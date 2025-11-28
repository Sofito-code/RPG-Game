using Portador.Implementaciones;
using UnityEngine;

public class ControladorPNJ : MonoBehaviour
{
    private PortadorNoJugable _npc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PortadorNoJugable NPC { get => _npc; set => _npc = value; }
    void Start()
    {
        _npc = new PortadorNoJugable("NPC1", 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colision con " + other.name);
    }
}
