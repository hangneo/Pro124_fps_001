using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class dmg : MonoBehaviour
{
    public static dmg instance;
    public List<show_dmg> showDmg;

    private void Start()
    {
        instance = this;

        //foreach (Transform dmg in transform)
        //{
        //    showDmg.Add(dmg.GetComponent<show_dmg>());
        //}
    }

    public void Show(int dmg, Vector3 pos)
    {
        var getOne = showDmg.FirstOrDefault(x => !x.gameObject.activeSelf);
        if (getOne != null)
        {
            getOne.setDMG(dmg);
            getOne.transform.position = pos;
            getOne.gameObject.SetActive(true);
            StartCoroutine(delay(getOne.gameObject));
        }
    }

    public void random_dmg_text(int dmg__, Transform trans)
    {
        var pos_x = Random.Range(-0.5f, 0.5f);
        var pos_y = Random.Range(0.5f, 1f);
        var random_pos = trans.position + new Vector3(pos_x, pos_y, 0);
        Show(dmg__, random_pos);
    }

    IEnumerator delay(GameObject go)
    {
        yield return new WaitForSeconds(0.5f);
        go.SetActive(false);
    }
}
