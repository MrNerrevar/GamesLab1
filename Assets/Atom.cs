using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public string electronsPerShell;
    public string atom;
    public GameObject protonPrefab;
    public GameObject electronPrefab;

    // Use this for initialization
    void Start ()
    {
        protonPrefab = new GameObject();
        electronPrefab = new GameObject();
        setElectrons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setElectrons()
    {
        string[] electronSplit = electronsPerShell.Split(',');
        for (int i = 0; i < electronSplit.Length; i++)
        {
            Debug.Log(electronSplit.ToString());
        }
        
        
        int numShells = electronSplit.Length;
        Debug.Log(numShells.ToString());

        for (int i = 0; i < numShells; i++)
        {
            int electrons = int.Parse(electronSplit[i]);
            Debug.Log(electrons.ToString());
            Instantiate(electronPrefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
    }
}
