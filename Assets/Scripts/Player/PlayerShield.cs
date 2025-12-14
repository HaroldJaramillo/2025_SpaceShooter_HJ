using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerShield : MonoBehaviour
{
    /*[SerializeField] GameObject Shield;
    [SerializeField] Transform PlayerSpaceShip;
    public int ShieldLife = 1;

    public static bool shield;

     void Start()
      {
        if (shield == true)
        {
            GameManager.instance.WinShield();
            Instantiate(Shield, PlayerSpaceShip.position, Shield.transform.rotation, PlayerSpaceShip);
        }
     }*/

    [SerializeField] GameObject Shield;
    [SerializeField] Transform PlayerSpaceShip;
    public static PlayerShield instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public void ActivateShield()
    {
        if (GameManager.instance.hasShield == true)
        {
            HUD.instance.WinShield(1);
            Instantiate(Shield, PlayerSpaceShip.position, Shield.transform.rotation, PlayerSpaceShip);
        }
    }

}

