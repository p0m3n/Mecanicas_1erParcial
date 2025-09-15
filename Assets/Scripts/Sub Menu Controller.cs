using UnityEngine;

public class SubMenuController : MonoBehaviour
{
    public GameObject panelMenuPrincipal;
    public GameObject panelControles;

    public void MostrarControles()
    {
        panelMenuPrincipal.SetActive(false);
        panelControles.SetActive(true);
    }

    public void VolverAlMenu()
    {
        panelControles.SetActive(false);
        panelMenuPrincipal.SetActive(true);
    }
}
