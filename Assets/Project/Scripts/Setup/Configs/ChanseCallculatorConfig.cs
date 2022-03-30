using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Config/ChanseSpawn", menuName = "Config/ChanseSpawn")]
public class ChanseCallculatorConfig : ScriptableObject
{
    public float appleChanseSpawn;
    public int maxKnifesAmountSpawn;
    public int minKnifesAmountSpawn;
    public int appleAmounSpaw;
    public int maxCircleSize;
    private HashSet<int> dontRepeat;

    public IEnumerable<int> GetNumbersPositionSpawn(int count)
    {
        //не самое возможно лучший подход, но лениво берем нужные значения, если значения повторяются, крутим дальше
        //проверок не делаю потому как ориентировочно больше 4-6 предметов думаю запрашивать за раз не придется
        //иначе играть станет сложно
        dontRepeat = new HashSet<int>();
        while (count-- > 0)
        {
            int value = Random.Range(0, maxCircleSize);
            if (dontRepeat.Contains(value))
            {
                ++count;
                continue;
            }
            else
            {
                dontRepeat.Add(value);
                yield return value;
            }
        }
        
        dontRepeat.Clear();
    }

    public IEnumerable<string> GetObjectToSpawn(int count)
    {
        //не было указано что яблоко должно быть одно, но легко поправить
        while (count-- > 0)
            yield return Random.value > .25 ? "knife" : "apple";
    }
}
