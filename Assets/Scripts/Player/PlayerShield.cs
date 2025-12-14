using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] GameObject Shield;
    [SerializeField] Transform PlayerSpaceShip;
    public int ShieldLife = 1;

    public static bool shield;

    Vector3 SpawnPosition;

     void Start()
      {
        if (shield == true)
        {
            GameManager.instance.WinShield();
            SpawnPosition = PlayerSpaceShip.position;
            Instantiate(Shield, PlayerSpaceShip.position, Shield.transform.rotation, PlayerSpaceShip);
        }
     }

}

