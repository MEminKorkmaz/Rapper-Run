using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] sets;

    public int setAmount;
    public int setIntervals;

    private Vector3 setPos;

    private GameObject tempGO;

    void Start(){
        Shuffle();
        Placement();
    }

    // Dizinin elemanlarının yerlerini rastgele şekilde değiştiriyoruz
    //(Hep aynı sırada olmamaları için)
    void Shuffle() {
        for (int i = 0; i < sets.Length; i++) {
            int rnd = Random.Range(0, sets.Length);
            tempGO = sets[rnd];
            sets[rnd] = sets[i];
            sets[i] = tempGO;
        }
    }

    // setIntervals ile hangi aralıklarla collectibles koyacağımızı belirliyoruz
    // setAmount ile kaç adet set koyacağımıza karar veriyoruz

    void Placement(){
        for(int i = 0; i < setAmount; i++){
            Instantiate(sets[i] , setPos , Quaternion.identity);
            setPos.z += setIntervals;
        }
    }
}
