using UnityEngine.UI;
using Monobehavior;
using UnityEngine;
using Habilidades.Implementacion;

public class UIHabilidades : MonoBehaviour
{
    [SerializeField] private GameObject jugadorGO;
    [SerializeField] private GameObject[] habilidadesUI;
    private Habilidad[] habilidades;

    private ControladorPJ _controladorPJ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controladorPJ = jugadorGO.GetComponent<ControladorPJ>();
        habilidades = _controladorPJ.Habilidades();
        for (int i = 0; i< habilidadesUI.Length; i++)
        {
            VincularHabilidad(habilidades[i], habilidadesUI[i]);
            habilidades[i].Cambiado.AddListener(ActualizarTodasLasHabilidades);
            habilidades[i].Cambiado.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VincularHabilidad(Habilidad hab, GameObject habUI)
    {
        habUI.transform.GetChild(0).GetComponent<Image>().sprite = hab.Icono;
        habUI.transform.GetChild(1).GetComponent<Text>().text = hab.Nombre;
        habUI.transform.GetChild(2).GetComponent<Image>().fillAmount = 0;
        habUI.transform.GetChild(3).GetComponent<Text>().text = "";
    }

    public void ActualizarInfoCD(Habilidad hab, GameObject habUI)
    {
        if (hab.TiempoRestanteCD() <= 0)
        {
            habUI.transform.GetChild(2).GetComponent<Image>().fillAmount = 0;
            habUI.transform.GetChild(3).GetComponent<Text>().text = "";
            return;
        }
        habUI.transform.GetChild(2).GetComponent<Image>().fillAmount = (float)hab.TiempoRestanteCD() / hab.TiempoCD;
        habUI.transform.GetChild(3).GetComponent<Text>().text = hab.TiempoRestanteCD().ToString();
    }

    public void ActualizarTodasLasHabilidades()
    {
        for (int i = 0; i < habilidadesUI.Length; i++)
        {
            ActualizarInfoCD(habilidades[i], habilidadesUI[i]);
        }
    }

}
